using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    public class SkinRecord : ICloneable
    {
        private enum eRecordLength
        {
            DEFAULT = 208,
        }

        public IffItemCommon Base = new IffItemCommon();

        public string Texture = "";

        public UInt16 HScroll = 0;
        public UInt16 VScroll = 0;

        public UInt16 Power = 0;
        public UInt16 Control = 0;
        public UInt16 Impact = 0;
        public UInt16 Spin = 0;
        public UInt16 Curve = 0;

        public UInt16 PowerSlot = 0;
        public UInt16 ControlSlot = 0;
        public UInt16 ImpactSlot = 0;
        public UInt16 SpinSlot = 0;
        public UInt16 CurveSlot = 0;

        public static List<SkinRecord> LoadSkinFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<SkinRecord> skinList = new List<SkinRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 skinsInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.GetIffRegion(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    int record_length;

                    // Once we know the region, we have to start calling the correct LoadParts()
                    // method for the given magic number.
                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        // We'll be splitting the processing to make it easier to code
                        switch (inIffFile.Region)
                        {
                            // Process "normal" TH files
                            case (IffFile.IFF_REGION.Default):
                                record_length = 208;
                                skinList = LoadSkins_0(inIffFile, reader, skinsInFile, record_length);
                                break;

                            case (IffFile.IFF_REGION.Global_30447):
                                record_length = 196;
                                skinList = LoadSkins_30447(inIffFile, reader, skinsInFile, record_length);
                                break;

                            // Process "CC CC" JP files
                            case (IffFile.IFF_REGION.Japan):
                            case (IffFile.IFF_REGION.Japan_52428):
                                record_length = 528;
                                //partsList = LoadParts_52428(inIffFile, reader, partsInFile, record_length);
                                break;

                            // Newer 536 bytes long JP files
                            case (IffFile.IFF_REGION.Japan_8960):
                                record_length = 536;
                                //partsList = LoadParts_8960(inIffFile, reader, partsInFile, record_length);
                                break;

                            case (IffFile.IFF_REGION.Korea_30395):
                                record_length = 516;
                                //partsList = LoadParts_30395(inIffFile, reader, partsInFile, record_length);
                                break;
                        }
                        reader.Close();

                        return skinList;
                    }
                }
            }
            return new List<SkinRecord>();
        }

        private static List<SkinRecord> LoadSkins_0(IffFile inIffFile, BinaryReader reader, ushort skinsInFile, int record_length)
        {
            List<SkinRecord> skinList = new List<SkinRecord>();

            for (int i = 0; i < skinsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                SkinRecord tmpRecord = new SkinRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                IffItemCommon.GetCharacterId(ref tmpRecord.Base);

                byte[] byteTexture = reader.ReadBytes(40);
                tmpRecord.Texture = IffFile.FileEncoding(inIffFile.Region).GetString(byteTexture);
                curPos += 40;

                tmpRecord.HScroll = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.VScroll = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Power = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Control = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Impact = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Spin = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Curve = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.PowerSlot = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.ControlSlot = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.ImpactSlot = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.SpinSlot = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.CurveSlot = reader.ReadUInt16();
                curPos += 2;

                Debug.Print("{5} -- Pw: {0}, Co: {1}, Im: {2}, Sp: {3}, Cu: {4}", tmpRecord.Power, tmpRecord.Control, tmpRecord.Impact, tmpRecord.Spin, tmpRecord.Curve, tmpRecord.Base.Name);

                //reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                skinList.Add(tmpRecord);
            }

            return skinList;
        }

        private static List<SkinRecord> LoadSkins_30447(IffFile inIffFile, BinaryReader reader, ushort skinsInFile, int record_length)
        {
            List<SkinRecord> skinList = new List<SkinRecord>();

            for (int i = 0; i < skinsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                SkinRecord tmpRecord = new SkinRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                IffItemCommon.GetCharacterId(ref tmpRecord.Base);

                reader.BaseStream.Seek(52, SeekOrigin.Current);

                Debug.Print("curPos: {0}", curPos);

                //reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                skinList.Add(tmpRecord);
            }

            return skinList;
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
