using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PartsIffTool
{
    public class DescRecord
    {
        public static int RECORD_LENGTH = 516;

        /* Length of some elements */
        public static int ReferencedObjectLen = 4;
        public static int DescriptionLen = 511;     // actually 512, but for safety we go 511

        public UInt32 ReferencedObject = 0;
        public string Description = "";

        public static bool SaveDescFile(string fileName, List<DescRecord> descriptionList)
        {
            /* Initialize the writer, file encoding is important! */
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default));

            /* Initialize the IFF file header */
            IffFile outIffFile = new IffFile();
            outIffFile.ObjectsInFile = UInt16.Parse(descriptionList.Count.ToString());
            outIffFile.WriteIffFileHeader(writer);

            /* Fill the file with empty records so we can jump around in it... */
            outIffFile.StubRecords(writer, DescRecord.RECORD_LENGTH, descriptionList.Count);
            outIffFile.JumpToFirstRecord(writer);

            /* Write each record into the file now... */
            foreach (DescRecord p in descriptionList)
            {
                long recordPos = writer.BaseStream.Position;
                long curPos = writer.BaseStream.Position;

                writer.Write(p.ReferencedObject);
                curPos += 4;

                /* Need 0x00 at the end of the string... */
                if (p.Description.Length >= DescriptionLen)
                    p.Description.Substring(0, DescriptionLen - 1);
                writer.Write(p.Description.ToCharArray());
                //writer.Seek(p.Description.Length, SeekOrigin.Current);
                writer.Seek(512 - p.Description.Length, SeekOrigin.Current);
            }
            writer.Close();

            return true;
        }

        public static List<DescRecord> LoadDescFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                List<DescRecord> descriptionList = new List<DescRecord>();
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    IffFile inIffFile = new IffFile();
                    UInt16 partsInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        for (int i = 0; i < partsInFile; i++)
                        {
                            long recordPos = reader.BaseStream.Position;
                            long curPos = reader.BaseStream.Position;
                            DescRecord tmpRecord = new DescRecord();

                            tmpRecord.ReferencedObject = reader.ReadUInt32();
                            curPos += 4;

                            byte[] byteDescription = reader.ReadBytes(512);
                            tmpRecord.Description = IffFile.FileEncoding(IffFile.IFF_REGION.Default).GetString(byteDescription);
                            curPos += 512;

                            descriptionList.Add(tmpRecord);
                        }
                        reader.Close();
                    }
                    else
                        return new List<DescRecord>();
                }
                return descriptionList;
            }
            return new List<DescRecord>();
        }
    }
}
