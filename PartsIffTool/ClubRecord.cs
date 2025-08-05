using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    [Serializable]
    public class ClubRecord : ICloneable
    {
        public enum eClubType
        {
            WOOD = 0,
            IRON = 1,
            WEDGE = 2,
            PUTTER = 3,
        }

        private enum eRecordLength
        {
            DEFAULT = 196,
            JAPAN_30312 = 224,
            KOREA_30395 = 196,
        }

        public IffItemCommon Base = new IffItemCommon();

        public string Model = "";
        public eClubType Type = 0;

        public UInt16 Power = 0;
        public UInt16 Control = 0;
        public UInt16 Impact = 0;
        public UInt16 Spin = 0;
        public UInt16 Curve = 0;

        public static List<ClubRecord> LoadClubFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<ClubRecord> clubList = new List<ClubRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 clubsInFile = inIffFile.GetNumberOfRecords(reader);

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
                            case (IffFile.IFF_REGION.Global_30087):
                                record_length = 196;
                                clubList = LoadClubs_0(inIffFile, reader, clubsInFile, record_length);
                                break;
                            case (IffFile.IFF_REGION.Global_30425):
                                record_length = 200;
                                clubList = LoadClubs_0(inIffFile, reader, clubsInFile, record_length);
                                break;

                            // Process "CC CC" JP files
                            case (IffFile.IFF_REGION.Japan):
                            case (IffFile.IFF_REGION.Japan_52428):
                                record_length = 528;
                                clubList = LoadClubs_52428(inIffFile, reader, clubsInFile, record_length);
                                break;

                            // Newer 536 bytes long JP files
                            case (IffFile.IFF_REGION.Japan_8960):
                            case (IffFile.IFF_REGION.Japan_30312):
                                record_length = 224;
                                clubList = LoadClubs_8960(inIffFile, reader, clubsInFile, record_length);
                                break;

                            case (IffFile.IFF_REGION.Korea_30395):
                                record_length = 196;
                                clubList = LoadClubs_30395(inIffFile, reader, clubsInFile, record_length);
                                break;
                        }
                        reader.Close();

                        return clubList;
                    }
                }
            }
            return new List<ClubRecord>();
        }

        private static List<ClubRecord> LoadClubs_52428(IffFile inIffFile, BinaryReader reader, ushort clubsInFile, int record_length)
        {
            List<ClubRecord> clubList = new List<ClubRecord>();

            for (int i = 0; i < clubsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubRecord tmpRecord = new ClubRecord();

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                byte[] byteItemModelInShop = reader.ReadBytes(40);
                tmpRecord.Model = IffFile.FileEncoding(inIffFile.Region).GetString(byteItemModelInShop);
                curPos += 40;

                tmpRecord.Type = (eClubType)reader.ReadUInt16();
                curPos += 1;

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

                clubList.Add(tmpRecord);
            }

            return clubList;
        }

        private static List<ClubRecord> LoadClubs_8960(IffFile inIffFile, BinaryReader reader, ushort clubsInFile, int record_length)
        {
            List<ClubRecord> clubList = new List<ClubRecord>();

            for (int i = 0; i < clubsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubRecord tmpRecord = new ClubRecord();

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                byte[] byteItemModelInShop = reader.ReadBytes(40);
                tmpRecord.Model = IffFile.FileEncoding(inIffFile.Region).GetString(byteItemModelInShop);
                curPos += 40;

                tmpRecord.Type = (eClubType)reader.ReadUInt16();
                curPos += 1;

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

                clubList.Add(tmpRecord);
            }

            return clubList;
        }

        private static List<ClubRecord> LoadClubs_30395(IffFile inIffFile, BinaryReader reader, ushort clubsInFile, int record_length)
        {
            List<ClubRecord> clubList = new List<ClubRecord>();

            for (int i = 0; i < clubsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubRecord tmpRecord = new ClubRecord();

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                byte[] byteItemModelInShop = reader.ReadBytes(40);
                tmpRecord.Model = IffFile.FileEncoding(inIffFile.Region).GetString(byteItemModelInShop);
                curPos += 40;

                tmpRecord.Type = (eClubType)reader.ReadUInt16();
                curPos += 1;

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

                clubList.Add(tmpRecord);
            }

            return clubList;
        }

        private static List<ClubRecord> LoadClubs_0(IffFile inIffFile, BinaryReader reader, ushort clubsInFile, int record_length)
        {
            List<ClubRecord> clubList = new List<ClubRecord>();

            for (int i = 0; i < clubsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubRecord tmpRecord = new ClubRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                byte[] byteItemModelInShop = reader.ReadBytes(40);
                tmpRecord.Model = IffFile.FileEncoding(inIffFile.Region).GetString(byteItemModelInShop);
                curPos += 40;

                tmpRecord.Type = (eClubType)reader.ReadUInt16();
                curPos += 1;

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

                clubList.Add(tmpRecord);
            }

            return clubList;
        }

        public static bool SaveClubFile(string fileName, List<ClubRecord> clubList, IffFile.IFF_REGION region)
        {
            switch (region)
            {
                case (IffFile.IFF_REGION.Default):
                    return SaveClubs_0(fileName, clubList);
            }

            // Presumably no operation took place
            return false;
        }

        public static bool SaveClubs_0(string fileName, List<ClubRecord> clubList)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default));

            IffFile outIffFile = new IffFile();
            outIffFile.ObjectsInFile = Convert.ToUInt16(clubList.Count);

            outIffFile.WriteIffFileHeader(writer);
            outIffFile.StubRecords(writer, (UInt16)eRecordLength.DEFAULT, outIffFile.ObjectsInFile);

            outIffFile.JumpToFirstRecord(writer);

            foreach (ClubRecord c in clubList)
            {
                long recordPos = writer.BaseStream.Position;
                long curPos = writer.BaseStream.Position;

                // After refactoring SavePartFile into multiple procedures, this one only
                // takes care of TH files. We have to convert possible other region entries
                // to TH.
                c.Base.SaveCommonProperties(writer, IffFile.IFF_REGION.Default, ref curPos);

                // Save Model string
                IffCommonMethods.WriteStringOfLength(c.Model, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

                // Save Equipment Category
                writer.Write((UInt16)c.Type);
                curPos += 1;

                writer.Write(c.Power);
                curPos += 2;

                writer.Write(c.Control);
                curPos += 2;

                writer.Write(c.Impact);
                curPos += 2;

                writer.Write(c.Spin);
                curPos += 2;

                writer.Write(c.Curve);
                curPos += 2;
            }

            writer.Close();
            return true;
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

        /// <summary>
        /// Returns the name of the club.
        /// 
        /// Necessary for fancy stuff like LINQ operations...
        /// </summary>
        /// <returns>this.Base.Name</returns>
        public override string ToString()
        {
            return Base.Name;
        }
    }
}
