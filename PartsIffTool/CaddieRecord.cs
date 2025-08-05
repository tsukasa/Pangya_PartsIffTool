using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    [Serializable]
    public class CaddieRecord : ICloneable
    {
        public IffItemCommon Base = new IffItemCommon();

        public UInt32 MonthlyFee = 0;
        public string Model = "";

        public UInt16 Power = 0;
        public UInt16 Control = 0;
        public UInt16 Impact = 0;
        public UInt16 Spin = 0;
        public UInt16 Curve = 0;

        public Byte[] CompleteRecordCopy;

        public static List<CaddieRecord> LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (
                    BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read),
                                                           IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<CaddieRecord> caddieList = new List<CaddieRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 caddiesInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.GetIffRegion(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    int record_length;

                    switch (inIffFile.Region)
                    {
                        case IffFile.IFF_REGION.Default:
                            record_length = 200;
                            break;
                        case IffFile.IFF_REGION.Japan:
                            record_length = 220;
                            break;
                        case IffFile.IFF_REGION.Japan_8960:
                            record_length = 228;
                            break;
                        default:
                            record_length = 200;
                            break;
                    }

                    // Once we know the region, we have to start calling the correct LoadParts()
                    // method for the given magic number.
                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        // We'll be splitting the processing to make it easier to code
                        switch (inIffFile.Region)
                        {
                            // Process "normal" TH files
                            case (IffFile.IFF_REGION.Default):
                                //caddieList = LoadParts_0(inIffFile, reader, caddiesInFile, record_length);
                                break;

                            // Process "CC CC" JP files
                            case (IffFile.IFF_REGION.Japan):
                                //caddieList = LoadParts_52428(inIffFile, reader, caddiesInFile, record_length);
                                break;

                            // Newer 536 bytes long JP files
                            case (IffFile.IFF_REGION.Japan_8960):
                                //caddieList = LoadParts_8960(inIffFile, reader, caddiesInFile, record_length);
                                break;

                        }
                        reader.Close();

                        return caddieList;
                    }
                }
            }
            return new List<CaddieRecord>();
        }

        public object Clone()
        {
            object clone;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                clone = formatter.Deserialize(stream);
            }
            return clone;
        }
    }
}
