using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace PartsIffTool
{
    [Serializable]
    public class ClubSetRecord : ICloneable
    {
        [Serializable]
        public struct sClubs
        {
            public UInt32 Wood;
            public UInt32 Iron;
            public UInt32 Wedge;
            public UInt32 Putter;
        }

        private enum eRecordLength
        {
            DEFAULT = 184,
            GLOBAL_30087 = 180,
            GLOBAL_30425 = 184,

            JAPAN = 528,
            JAPAN_8960 = 208,

            KOREA_30395 = 180,
        }

        public IffItemCommon Base = new IffItemCommon();

        public string Model = "";

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

        public sClubs ClubIds = new sClubs();

        public UInt16 EquipmentCategory = 0;

        // A complete copy of the record so we can restore it
        public Byte[] CompleteRecordCopy = new Byte[184];

        public static bool SaveClubSetFile(string fileName, List<ClubSetRecord> clubSetList, IffFile.IFF_REGION region)
        {
            switch (region)
            {
                case (IffFile.IFF_REGION.Default):
                    return SaveClubSetFile_0(fileName, clubSetList);
            }

            // Presumably no operation took place
            return false;
        }

        public static bool SaveClubSetFile_0(string fileName, List<ClubSetRecord> clubsetList)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default));

            IffFile outIffFile = new IffFile();
            outIffFile.ObjectsInFile = UInt16.Parse(clubsetList.Count.ToString());

            outIffFile.WriteIffFileHeader(writer);
            outIffFile.StubRecords(writer, (int)eRecordLength.DEFAULT, outIffFile.ObjectsInFile);

            outIffFile.JumpToFirstRecord(writer);

            foreach (ClubSetRecord p in clubsetList)
            {
                long recordPos = writer.BaseStream.Position;
                long curPos = writer.BaseStream.Position;

                p.Base.SaveCommonProperties_0(writer, ref curPos);

                writer.Write(p.ClubIds.Wood);
                curPos += 4;

                writer.Write(p.ClubIds.Iron);
                curPos += 4;

                writer.Write(p.ClubIds.Wedge);
                curPos += 4;

                writer.Write(p.ClubIds.Putter);
                curPos += 4;

                writer.Write(p.Power);
                curPos += 2;

                writer.Write(p.Control);
                curPos += 2;

                writer.Write(p.Impact);
                curPos += 2;

                writer.Write(p.Spin);
                curPos += 2;

                writer.Write(p.Curve);
                curPos += 2;

                writer.Write(p.PowerSlot);
                curPos += 2;

                writer.Write(p.ControlSlot);
                curPos += 2;

                writer.Write(p.ImpactSlot);
                curPos += 2;

                writer.Write(p.SpinSlot);
                curPos += 2;

                writer.Write(p.CurveSlot);
                curPos += 2;
            }

            writer.Close();
            return true;
        }

        public static List<ClubSetRecord> LoadClubSetFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<ClubSetRecord> clubsetList = new List<ClubSetRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 clubsetsInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.GetIffRegion(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    int record_length;

                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        switch (inIffFile.Region)
                        {
                            case (IffFile.IFF_REGION.Default):
                                clubsetList = LoadClubSet_0(inIffFile, reader, clubsetsInFile, (int)eRecordLength.DEFAULT);
                                break;

                            case (IffFile.IFF_REGION.Global_30087):
                                clubsetList = LoadClubSet_0(inIffFile, reader, clubsetsInFile, (int)eRecordLength.GLOBAL_30087);
                                break;

                            case (IffFile.IFF_REGION.Global_30425):
                                clubsetList = LoadClubSet_0(inIffFile, reader, clubsetsInFile, (int)eRecordLength.GLOBAL_30425);
                                break;

                            case (IffFile.IFF_REGION.Japan):
                                clubsetList = LoadClubSet_52428(inIffFile, reader, clubsetsInFile, (int)eRecordLength.JAPAN);
                                break;

                            case (IffFile.IFF_REGION.Japan_8960):
                            case (IffFile.IFF_REGION.Japan_30312): // S5 ClubSet.iff, same structure - new R/MN
                                clubsetList = LoadClubSet_8960(inIffFile, reader, clubsetsInFile, (int)eRecordLength.JAPAN_8960);
                                break;

                            case (IffFile.IFF_REGION.Korea_30395):
                                clubsetList = LoadClubSet_30395(inIffFile, reader, clubsetsInFile, (int)eRecordLength.KOREA_30395);
                                break;
                        }
                        reader.Close();

                        return clubsetList;
                    }
                }
            }
            return new List<ClubSetRecord>();
        }

        public static List<ClubSetRecord> LoadClubSet_0(IffFile inIffFile, BinaryReader reader, ushort clubsetsInFile, int record_length)
        {
            List<ClubSetRecord> clubsetList = new List<ClubSetRecord>();

            for (int i = 0; i < clubsetsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubSetRecord tmpRecord = new ClubSetRecord();

                /* Save an entire copy of the recordset... */
                //tmpRecord.CompleteRecordCopy = reader.ReadBytes(record_length);

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                tmpRecord.ClubIds.Wood = reader.ReadUInt32();
                tmpRecord.ClubIds.Iron = reader.ReadUInt32();
                tmpRecord.ClubIds.Wedge = reader.ReadUInt32();
                tmpRecord.ClubIds.Putter = reader.ReadUInt32();
                curPos += 16;

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

                clubsetList.Add(tmpRecord);
            }
            reader.Close();

            return clubsetList;
        }

        public static List<ClubSetRecord> LoadClubSet_52428(IffFile inIffFile, BinaryReader reader, ushort clubsetsInFile, int record_length)
        {
            List<ClubSetRecord> clubsetList = new List<ClubSetRecord>();

            for (int i = 0; i < clubsetsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubSetRecord tmpRecord = new ClubSetRecord();

                /* Save an entire copy of the recordset... */
                //tmpRecord.CompleteRecordCopy = reader.ReadBytes(record_length);

                tmpRecord.Base.LoadCommonProperties(reader, IffFile.IFF_REGION.Japan_52428, ref curPos);

                tmpRecord.ClubIds.Wood = reader.ReadUInt32();
                tmpRecord.ClubIds.Iron = reader.ReadUInt32();
                tmpRecord.ClubIds.Wedge = reader.ReadUInt32();
                tmpRecord.ClubIds.Putter = reader.ReadUInt32();
                curPos += 16;

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

                clubsetList.Add(tmpRecord);
            }
            reader.Close();

            return clubsetList;
        }

        public static List<ClubSetRecord> LoadClubSet_8960(IffFile inIffFile, BinaryReader reader, ushort clubsetsInFile, int record_length)
        {
            List<ClubSetRecord> clubsetList = new List<ClubSetRecord>();

            for (int i = 0; i < clubsetsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubSetRecord tmpRecord = new ClubSetRecord();

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                tmpRecord.ClubIds.Wood = reader.ReadUInt32();
                tmpRecord.ClubIds.Iron = reader.ReadUInt32();
                tmpRecord.ClubIds.Wedge = reader.ReadUInt32();
                tmpRecord.ClubIds.Putter = reader.ReadUInt32();
                curPos += 16;

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

                clubsetList.Add(tmpRecord);
            }
            reader.Close();

            return clubsetList;
        }

        public static List<ClubSetRecord> LoadClubSet_30395(IffFile inIffFile, BinaryReader reader, ushort clubsetsInFile, int record_length)
        {
            List<ClubSetRecord> clubsetList = new List<ClubSetRecord>();

            for (int i = 0; i < clubsetsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                ClubSetRecord tmpRecord = new ClubSetRecord();

                /* Save an entire copy of the recordset... */
                //tmpRecord.CompleteRecordCopy = reader.ReadBytes(record_length);

                tmpRecord.Base.LoadCommonProperties(reader, IffFile.IFF_REGION.Korea_30395, ref curPos);

                tmpRecord.ClubIds.Wood = reader.ReadUInt32();
                tmpRecord.ClubIds.Iron = reader.ReadUInt32();
                tmpRecord.ClubIds.Wedge = reader.ReadUInt32();
                tmpRecord.ClubIds.Putter = reader.ReadUInt32();
                curPos += 16;

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

                clubsetList.Add(tmpRecord);
            }
            reader.Close();

            return clubsetList;
        }

        public static void GenerateSqlFile(object objectList, string fileName)
        {
            List<ClubSetRecord> itemList = (List<ClubSetRecord>)objectList;
            TextWriter writer = new StreamWriter(fileName, false);

            writer.WriteLine("USE [Pangya_S4_TH]");
            writer.WriteLine("GO\r\n");

            /*            foreach (IffItemCommon item in itemList)
                        {
                            // Have to substr here because we use a fixed 40byte long string
                            int partNameEnd = item.Name.IndexOf((char)0x00);
                            string partName = "";
                            if (partNameEnd > 0)
                                partName = item.Name.Substring(0, partNameEnd);
                            else
                                partName = "";

                            int partIconEnd = item.Icon.IndexOf((char)0x00);
                            string partIcon = "";
                            if (partIconEnd > 0)
                                partIcon = item.Icon.Substring(0, partIconEnd);
                            else
                                partIcon = "";

                            // Choose whether IS_CASH will be 0 or 1...
                            int is_cash = 0;
                            if (item.MoneyType == 0x01)
                                is_cash = 1;
                            else
                                is_cash = 0;

                            writer.WriteLine("-- Item: {0}", partName);
                            writer.WriteLine("IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {0} )", item.TypeId);
                            writer.WriteLine("BEGIN");
                            writer.WriteLine("    UPDATE PANGYA_ITEM_TYPELIST");
                            writer.WriteLine("    SET NAME = N'{0}'", partName);
                            writer.WriteLine("    , ICON = N'{0}'", partIcon);
                            writer.WriteLine("    , PRICE = {0}", item.Price);
                            writer.WriteLine("    , ISCASH = {0}", is_cash);
                            writer.WriteLine("    WHERE TYPEID = {0}", item.TypeId);
                            writer.WriteLine("END");
                            writer.WriteLine("ELSE");
                            writer.WriteLine("BEGIN");
                            writer.WriteLine("    INSERT INTO PANGYA_ITEM_TYPELIST");
                            writer.WriteLine("    ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH] )");
                            writer.WriteLine("    VALUES ( {0}, N'{1}', N'{2}', {3}, {4} )", item.TypeId, partName, partIcon, item.Price, is_cash);
                            writer.WriteLine("END\r\n");
                        }
                    */
            writer.WriteLine("GO");
            writer.Close();
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
