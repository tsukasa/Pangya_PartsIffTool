using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    [Serializable]
    public class SetItemRecord : ICloneable
    {
        private enum eRecordLength
        {
            DEFAULT = 216,
            GLOBAL_30087 = 216,
            GLOBAL_30425 = 216,
            JAPAN_52428 = 260,
        }

        public IffItemCommon Base = new IffItemCommon();

        public List<UInt32> ElementIds = new List<uint>();      // Contains the IDs of the items that make up the set
        public List<UInt16> ElementAmount = new List<ushort>(); // Contains the amount of items corresponding to every ID

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

        public UInt32 NumberOfElements
        {
            get
            {
                return Convert.ToUInt32(ElementIds.Count);
            }
        }

        public static List<SetItemRecord> LoadSetItemFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<SetItemRecord> setList = new List<SetItemRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 setsInFile = inIffFile.GetNumberOfRecords(reader);

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
                            case (IffFile.IFF_REGION.Global_30425):
                                record_length = 216;
                                setList = LoadSets_0(inIffFile, reader, setsInFile, record_length);
                                break;

                            // Process "CC CC" JP files
                            case (IffFile.IFF_REGION.Japan):
                                record_length = 260;
                                setList = LoadSets_52428(inIffFile, reader, setsInFile, record_length);
                                break;

                            // Newer 536 bytes long JP files
                            case (IffFile.IFF_REGION.Japan_8960):
                                record_length = 536;
                                //setList = LoadSets_8960(inIffFile, reader, setsInFile, record_length);
                                break;

                            case (IffFile.IFF_REGION.Japan_30312):
                                record_length = 248;
                                setList = LoadSets_30312(inIffFile, reader, setsInFile, record_length);
                                break;

                            case (IffFile.IFF_REGION.Korea_30395):
                                record_length = 220;
                                //setList = LoadSets_30395(inIffFile, reader, setsInFile, record_length);
                                break;
                        }
                        reader.Close();

                        return setList;
                    }
                }
            }
            return new List<SetItemRecord>();
        }

        private static List<SetItemRecord> LoadSets_30312(IffFile inIffFile, BinaryReader reader, ushort setsInFile, int record_length)
        {
            List<SetItemRecord> setList = new List<SetItemRecord>();

            for (int i = 0; i < setsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                SetItemRecord tmpRecord = new SetItemRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);
                IffItemCommon.GetCharacterId(ref tmpRecord.Base);

                // Okay, this is fun. We have to determine how many items are contained
                // in this set to read the correct amount of times.
                UInt32 numberOfElements = reader.ReadUInt32();
                curPos += 4;

                ReadElementIds(reader, numberOfElements, ref tmpRecord, ref curPos);

                ReadElementAmount(reader, numberOfElements, ref tmpRecord, ref curPos);

                // 12 empty bytes
                reader.BaseStream.Seek(12, SeekOrigin.Current);
                curPos += 12;

                setList.Add(tmpRecord);
            }

            return setList;
        }

        private static List<SetItemRecord> LoadSets_52428(IffFile inIffFile, BinaryReader reader, ushort setsInFile, int record_length)
        {
            List<SetItemRecord> setList = new List<SetItemRecord>();

            for (int i = 0; i < setsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                SetItemRecord tmpRecord = new SetItemRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);
                IffItemCommon.GetCharacterId(ref tmpRecord.Base);

                // Okay, this is fun. We have to determine how many items are contained
                // in this set to read the correct amount of times.
                UInt32 numberOfElements = reader.ReadUInt32();
                curPos += 4;

                ReadElementIds(reader, numberOfElements, ref tmpRecord, ref curPos);

                ReadElementAmount(reader, numberOfElements, ref tmpRecord, ref curPos);

                // --- COM ---
                #region COM
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
                #endregion
                // --- /COM ---

                // --- Warning: Slots are only available in the JP version!
                #region COM Slots
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
                #endregion
                // --- /Slots ---

                // 12 empty bytes
                reader.BaseStream.Seek(12, SeekOrigin.Current);
                curPos += 12;

                setList.Add(tmpRecord);
            }

            return setList;
        }

        private static List<SetItemRecord> LoadSets_0(IffFile inIffFile, BinaryReader reader, ushort setsInFile, int record_length)
        {
            List<SetItemRecord> setList = new List<SetItemRecord>();

            for (int i = 0; i < setsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                SetItemRecord tmpRecord = new SetItemRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                IffItemCommon.GetCharacterId(ref tmpRecord.Base);

                // Okay, this is fun. We have to determine how many items are contained
                // in this set to read the correct amount of times.
                UInt32 numberOfElements = reader.ReadUInt32();
                curPos += 4;

                ReadElementIds(reader, numberOfElements, ref tmpRecord, ref curPos);

                ReadElementAmount(reader, numberOfElements, ref tmpRecord, ref curPos);

                // ...now that wasn't too hard, was it?

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

                // Yeah, for some reason there are 2 empty bytes here
                // again. See 0x200 - (0x1fc + 0x2) for reference...
                reader.BaseStream.Seek(2, SeekOrigin.Current);
                curPos += 2;

                // Hopefully won't be necessary anymore, leaving it
                // for debugging purposes, it's quite handy...
                //reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                setList.Add(tmpRecord);
            }

            return setList;
        }

        private static void ReadElementIds(BinaryReader reader, uint numberOfElements, ref SetItemRecord record, ref long curPos)
        {
            // Since there's a maximum of 40 bytes and all TypeIDs are UINT32 values
            // we can only have up to 10 items.
            for (int x = 0; x < numberOfElements; x++)
            {
                record.ElementIds.Add(reader.ReadUInt32());
            }

            // Now, since we have to jump to the end of these 40 bytes, let's estimate
            // how many bytes we have left after our loop...
            reader.BaseStream.Seek(40 - (numberOfElements * 4), SeekOrigin.Current);
            curPos += 40;
        }

        private static void ReadElementAmount(BinaryReader reader, uint numberOfElements, ref SetItemRecord record, ref long curPos)
        {
            // And boom, the same procedure for the "item amount", only this time around
            // we have 20 bytes available, making this a UINT16 value.
            for (int x = 0; x < numberOfElements; x++)
            {
                record.ElementAmount.Add(reader.ReadUInt16());
            }
            reader.BaseStream.Seek(20 - (numberOfElements * 2), SeekOrigin.Current);
            curPos += 20;
        }

        public static bool SaveSetItemFile(string fileName, List<SetItemRecord> setList, IffFile.IFF_REGION region)
        {
            switch (region)
            {
                case (IffFile.IFF_REGION.Default):
                    return SaveSets_0(fileName, setList);
            }

            // Presumably no operation took place
            return false;
        }

        public static bool SaveSets_0(string fileName, List<SetItemRecord> setList)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default));

            IffFile outIffFile = new IffFile();
            outIffFile.ObjectsInFile = Convert.ToUInt16(setList.Count);

            outIffFile.WriteIffFileHeader(writer);
            outIffFile.StubRecords(writer, (int)eRecordLength.DEFAULT, outIffFile.ObjectsInFile);

            outIffFile.JumpToFirstRecord(writer);

            foreach (SetItemRecord s in setList)
            {
                long recordPos = writer.BaseStream.Position;
                long curPos = writer.BaseStream.Position;

                s.Base.SaveCommonProperties(writer, IffFile.IFF_REGION.Default, ref curPos);

                writer.Write(s.NumberOfElements);

                // Write all the Element IDs...
                foreach (UInt32 elementId in s.ElementIds)
                {
                    writer.Write(elementId);
                }

                // ...and again, make sure you use all 40 bytes the record offers!
                writer.BaseStream.Seek(40 - (s.NumberOfElements * 4), SeekOrigin.Current);
                curPos += 40;

                // Now the same game for the amount...
                foreach (UInt16 elementAmount in s.ElementAmount)
                {
                    writer.Write(elementAmount);
                }

                // ...and it's 20 bytes.
                writer.BaseStream.Seek(20 - (s.NumberOfElements * 2), SeekOrigin.Current);
                curPos += 20;

                writer.Write(s.Power);
                curPos += 2;

                writer.Write(s.Control);
                curPos += 2;

                writer.Write(s.Impact);
                curPos += 2;

                writer.Write(s.Spin);
                curPos += 2;

                writer.Write(s.Curve);
                curPos += 2;

                writer.BaseStream.Seek(2, SeekOrigin.Current);
                curPos += 2;
            }

            writer.Close();
            return true;
        }

        public static void GenerateSqlFile(object objectList, string fileName)
        {
            int modSeq = 1;
            string sqlTranName = "UpdateSetItemList"; // The T-SQL transaction name

            List<SetItemRecord> itemList = (List<SetItemRecord>)objectList;
            TextWriter writer = new StreamWriter(fileName, false);

            writer.WriteLine("USE [Pangya_S4_TH]");
            writer.WriteLine("GO\r\n");

            writer.WriteLine("BEGIN TRAN {0}\r\n", sqlTranName);

            foreach (SetItemRecord item in itemList)
            {
                // Cleanup the strings first to reduce the ugly clutter in the database.
                // Ideally this will not be necessary but we better do it anyway.
                string setIcon = IffCommonMethods.GetCleanedUpStringForSQL(item.Base.Icon);
                string setName = IffCommonMethods.GetCleanedUpStringForSQL(item.Base.Name);

                if (!string.IsNullOrEmpty(setIcon))
                {
                    writer.WriteLine("-- Item: {0}", setName);
                    writer.WriteLine("IF EXISTS ( SELECT TYPEID FROM TA_SETITEM_ACC WHERE TYPEID = {0} )", item.Base.TypeId);
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   UPDATE TA_SETITEM_ACC");
                    writer.WriteLine("   SET [NAME] = N'{0}'", setName);
                    writer.WriteLine("    , [OWNER_TYPE] = {0}", 1);
                    writer.WriteLine("    , [OWNER_SERIAL_NO] = {0}", item.Base.TypeIdValues.Pos);
                    writer.WriteLine("    , [SERIAL_NO] = {0}", item.Base.TypeIdValues.Serial);
                    writer.WriteLine("    , [LEVEL] = {0}", item.Base.Level);
                    writer.WriteLine("    , [IS_UNDER_LVL] = {0}", Convert.ToSByte(item.Base.IsMaximumLevel));
                    writer.WriteLine("    , [ICON] = N'{0}'", setIcon);
                    writer.WriteLine("    , [PRICE] = {0}", item.Base.Price);
                    writer.WriteLine("    , [SALE_PRICE] = {0}", item.Base.SalePrice);
                    writer.WriteLine("    , [PURCHASE_PRICE] = {0}", item.Base.UsedPrice);
                    writer.WriteLine("    , [IS_CASH] = {0}", Convert.ToSByte(item.Base.IsCash));
                    writer.WriteLine("    , [IS_SALABLE] = {0}", Convert.ToSByte(item.Base.IsSalable));
                    writer.WriteLine("    , [IN_STOCK] = {0}", Convert.ToSByte(item.Base.IsInStock));
                    writer.WriteLine("    , [NEW] = {0}", Convert.ToSByte(item.Base.IsNew));
                    writer.WriteLine("    , [HIT] = {0}", Convert.ToSByte(item.Base.IsHot));
                    writer.WriteLine("    , [TIME_FLAG] = {0}", item.Base.TimeFlag);
                    writer.WriteLine("    , [TIME] = {0}", item.Base.Time);
                    writer.WriteLine("    , [COM0] = {0}", item.Power);
                    writer.WriteLine("    , [COM1] = {0}", item.Control);
                    writer.WriteLine("    , [COM2] = {0}", item.Spin);
                    writer.WriteLine("    , [COM3] = {0}", item.Impact);
                    writer.WriteLine("    , [COM4] = {0}", item.Curve);
                    writer.WriteLine("    , [NUM_ELEMS] = {0}", item.NumberOfElements);
                    writer.WriteLine("    , [ELEM_0] = {0}", (item.NumberOfElements > 0) ? item.ElementIds[0] : 0);
                    writer.WriteLine("    , [ELEM_1] = {0}", (item.NumberOfElements > 1) ? item.ElementIds[1] : 0);
                    writer.WriteLine("    , [ELEM_2] = {0}", (item.NumberOfElements > 2) ? item.ElementIds[2] : 0);
                    writer.WriteLine("    , [ELEM_3] = {0}", (item.NumberOfElements > 3) ? item.ElementIds[3] : 0);
                    writer.WriteLine("    , [ELEM_4] = {0}", (item.NumberOfElements > 4) ? item.ElementIds[4] : 0);
                    writer.WriteLine("    , [ELEM_5] = {0}", (item.NumberOfElements > 5) ? item.ElementIds[5] : 0);
                    writer.WriteLine("    , [ELEM_6] = {0}", (item.NumberOfElements > 6) ? item.ElementIds[6] : 0);
                    writer.WriteLine("    , [ELEM_7] = {0}", (item.NumberOfElements > 7) ? item.ElementIds[7] : 0);
                    writer.WriteLine("    , [ELEM_8] = {0}", (item.NumberOfElements > 8) ? item.ElementIds[8] : 0);
                    writer.WriteLine("    , [ELEM_9] = {0}", (item.NumberOfElements > 9) ? item.ElementIds[9] : 0);
                    writer.WriteLine("    , [MOD_SEQ] = {0}", modSeq);
                    writer.WriteLine("    , [USE_YN] = N'{0}'", "Y");
                    writer.WriteLine("    , [IN_DATE] = GETDATE()");
                    writer.WriteLine("    , [ELEM_0_QTY] = {0}", (item.NumberOfElements > 0) ? item.ElementAmount[0] : 0);
                    writer.WriteLine("    , [ELEM_1_QTY] = {0}", (item.NumberOfElements > 1) ? item.ElementAmount[1] : 0);
                    writer.WriteLine("    , [ELEM_2_QTY] = {0}", (item.NumberOfElements > 2) ? item.ElementAmount[2] : 0);
                    writer.WriteLine("    , [ELEM_3_QTY] = {0}", (item.NumberOfElements > 3) ? item.ElementAmount[3] : 0);
                    writer.WriteLine("    , [ELEM_4_QTY] = {0}", (item.NumberOfElements > 4) ? item.ElementAmount[4] : 0);
                    writer.WriteLine("    , [ELEM_5_QTY] = {0}", (item.NumberOfElements > 5) ? item.ElementAmount[5] : 0);
                    writer.WriteLine("    , [ELEM_6_QTY] = {0}", (item.NumberOfElements > 6) ? item.ElementAmount[6] : 0);
                    writer.WriteLine("    , [ELEM_7_QTY] = {0}", (item.NumberOfElements > 7) ? item.ElementAmount[7] : 0);
                    writer.WriteLine("    , [ELEM_8_QTY] = {0}", (item.NumberOfElements > 8) ? item.ElementAmount[8] : 0);
                    writer.WriteLine("    , [ELEM_9_QTY] = {0}", (item.NumberOfElements > 9) ? item.ElementAmount[9] : 0);
                    writer.WriteLine("   WHERE TYPEID = {0}", item.Base.TypeId);
                    writer.WriteLine("END");
                    writer.WriteLine("ELSE");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   INSERT INTO TA_SETITEM_ACC");
                    writer.WriteLine("    ( [TYPEID], [NAME], [OWNER_TYPE], [OWNER_SERIAL_NO], [SERIAL_NO] ");
                    writer.WriteLine("    , [LEVEL] , [IS_UNDER_LVL], [ICON], [PRICE], [SALE_PRICE]");
                    writer.WriteLine("    , [PURCHASE_PRICE], [IS_CASH], [IS_SALABLE], [IN_STOCK], [NEW]");
                    writer.WriteLine("    , [HIT], [TIME_FLAG], [TIME], [COM0], [COM1]");
                    writer.WriteLine("    , [COM2], [COM3], [COM4], [NUM_ELEMS], [ELEM_0]");
                    writer.WriteLine("    , [ELEM_1], [ELEM_2], [ELEM_3], [ELEM_4], [ELEM_5]");
                    writer.WriteLine("    , [ELEM_6], [ELEM_7], [ELEM_8], [ELEM_9], [MOD_SEQ], [USE_YN]");
                    writer.WriteLine("    , [IN_DATE], [ELEM_0_QTY], [ELEM_1_QTY], [ELEM_2_QTY], [ELEM_3_QTY]");
                    writer.WriteLine("    , [ELEM_4_QTY], [ELEM_5_QTY], [ELEM_6_QTY], [ELEM_7_QTY], [ELEM_8_QTY]");
                    writer.WriteLine("    , [ELEM_9_QTY])");
                    writer.WriteLine("   VALUES ( {0}, N'{1}', N'{2}', {3}, {4}",
                                     item.Base.TypeId, setName, 0, item.Base.TypeIdValues.Pos,
                                     item.Base.TypeIdValues.Serial);
                    writer.WriteLine("          , {0}, {1}, N'{2}', {3}, {4}",
                                     item.Base.Level, Convert.ToSByte(item.Base.IsMaximumLevel),
                                     setIcon, item.Base.Price, item.Base.SalePrice);
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}",
                                     item.Base.UsedPrice, Convert.ToSByte(item.Base.IsCash), Convert.ToSByte(item.Base.IsSalable),
                                     Convert.ToSByte(item.Base.IsInStock), Convert.ToSByte(item.Base.IsNew));
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}",
                                     Convert.ToSByte(item.Base.IsHot), item.Base.TimeFlag, item.Base.Time, item.Power, item.Control);
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}",
                                     item.Impact, item.Spin, item.Curve, item.NumberOfElements,
                                     (item.NumberOfElements > 0) ? item.ElementIds[0] : 0
                                     );
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}",
                                    (item.NumberOfElements > 1) ? item.ElementIds[1] : 0,
                                    (item.NumberOfElements > 2) ? item.ElementIds[2] : 0,
                                    (item.NumberOfElements > 3) ? item.ElementIds[3] : 0,
                                    (item.NumberOfElements > 4) ? item.ElementIds[4] : 0,
                                    (item.NumberOfElements > 5) ? item.ElementIds[5] : 0
                        );
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}, N'{5}'",
                                    (item.NumberOfElements > 6) ? item.ElementIds[6] : 0,
                                    (item.NumberOfElements > 7) ? item.ElementIds[7] : 0,
                                    (item.NumberOfElements > 8) ? item.ElementIds[8] : 0,
                                    (item.NumberOfElements > 9) ? item.ElementIds[9] : 0,
                                    modSeq,
                                    "Y");
                    writer.WriteLine("          , GETDATE(), {0}, {1}, {2}, {3}",
                                     (item.NumberOfElements > 0) ? item.ElementAmount[0] : 0,
                                     (item.NumberOfElements > 1) ? item.ElementAmount[1] : 0,
                                     (item.NumberOfElements > 2) ? item.ElementAmount[2] : 0,
                                     (item.NumberOfElements > 3) ? item.ElementAmount[3] : 0);
                    writer.WriteLine("          , {0}, {1}, {2}, {3}, {4}",
                                     (item.NumberOfElements > 4) ? item.ElementAmount[4] : 0,
                                     (item.NumberOfElements > 5) ? item.ElementAmount[5] : 0,
                                     (item.NumberOfElements > 6) ? item.ElementAmount[6] : 0,
                                     (item.NumberOfElements > 7) ? item.ElementAmount[7] : 0,
                                     (item.NumberOfElements > 8) ? item.ElementAmount[8] : 0);
                    writer.WriteLine("          , {0})",
                                     (item.NumberOfElements > 9) ? item.ElementAmount[9] : 0);
                    writer.WriteLine("END");
                    writer.WriteLine("IF @@ERROR != 0");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   ROLLBACK TRAN {0}", sqlTranName);
                    writer.WriteLine("   RAISERROR('[E] [TA_SetItem_Acc] Execution failed on item {0}.', 1, -1)", item.Base.TypeId);
                    writer.WriteLine("   RETURN");
                    writer.WriteLine("END");
                    writer.WriteLine("\r\n");

                    modSeq++;
                }
            }

            writer.WriteLine("COMMIT TRAN {0}", sqlTranName);
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
