using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PartsIffTool
{
    [Serializable]
    public class PartsRecord : ICloneable
    {
        /// <summary>
        /// Struct for the SubParts.
        /// 
        /// Contains two UInt32 values to reference
        /// to the SubPart TypeIDs.
        /// </summary>
        [Serializable]
        public struct SubPartsStruct
        {
            public UInt32 SubPart1;
            public UInt32 SubPart2;
        }

        /// <summary>
        /// Enum containing the record lengths of records
        /// in a Part.iff file for a specific region.
        /// 
        /// Please add values to this enum when adding new
        /// regions.
        /// </summary>
        private enum RecordLengthEnum
        {
            Default = 512,
            Global_30087 = 516,
            Global_30425 = 520,

            Japan = 528,
            Japan_52428 = 528,
            Japan_8960 = 536,
            Japan_30312 = 544,

            Korea_30395 = 516,
        }

        public IffItemCommon Base = new IffItemCommon();

        public IffFile.sTex Tex;
        public IffFile.sOrgTex OrgTex;

        public string Model = "";

        public UInt16 Power;
        public UInt16 Control;
        public UInt16 Impact;
        public UInt16 Spin;
        public UInt16 Curve;

        public UInt16 PowerSlot;
        public UInt16 ControlSlot;
        public UInt16 ImpactSlot;
        public UInt16 SpinSlot;
        public UInt16 CurveSlot;

        public UInt16 ItemMount;

        public Byte EquipmentCategory;
        public UInt32 PosMask;
        public UInt32 HideMask;

        public string EquippableWith = "";
        public SubPartsStruct SubParts;

        public UInt16 CardCharSlots;
        public UInt16 CardCaddySlots;

        public UInt16 Points;

        #region SavePartFile Methods
        /// <summary>
        /// General caller method to save a new Part.iff file.
        /// </summary>
        /// <param name="fileName">Filename to save to.</param>
        /// <param name="partsList">List of PartsRecords to save.</param>
        /// <param name="region">The desired output region.</param>
        /// <returns>Bool indicating whether the operation was successful or not.</returns>
        public static bool SavePartFile(string fileName, List<PartsRecord> partsList, IffFile.IFF_REGION region)
        {
            switch (region)
            {
                case (IffFile.IFF_REGION.Default):
                    return SaveParts_0(fileName, partsList);
            }

            // Presumably no operation took place
            return false;
        }

        private static bool SaveParts_0(string fileName, List<PartsRecord> partsList)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write), IffFile.FileEncoding(IffFile.IFF_REGION.Default));

            IffFile outIffFile = new IffFile();
            outIffFile.ObjectsInFile = UInt16.Parse(partsList.Count.ToString());

            outIffFile.WriteIffFileHeader(writer);
            outIffFile.StubRecords(writer, (int)RecordLengthEnum.Default, outIffFile.ObjectsInFile);

            outIffFile.JumpToFirstRecord(writer);

            foreach (PartsRecord p in partsList)
            {
                long curPos = writer.BaseStream.Position;

                // After refactoring SavePartFile into multiple procedures, this one only
                // takes care of TH files. We have to convert possible other region entries
                // to TH.
                p.Base.SaveCommonProperties(writer, IffFile.IFF_REGION.Default, ref curPos);

                // Save Model string
                IffCommonMethods.WriteStringOfLength(p.Model, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

                // Save Equipment Category
                writer.Write(p.EquipmentCategory);
                curPos += 1;

                writer.Seek(3, SeekOrigin.Current);
                curPos += 3;

                writer.Write(p.PosMask);
                curPos += 4;

                writer.Write(p.HideMask);
                curPos += 4;

                // Tex
                IffCommonMethods.WriteStringOfLength(p.Tex.Tex1, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);
                IffCommonMethods.WriteStringOfLength(p.Tex.Tex2, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);
                IffCommonMethods.WriteStringOfLength(p.Tex.Tex3, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

                // OrgTex
                IffCommonMethods.WriteStringOfLength(p.OrgTex.OrgTex1, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);
                IffCommonMethods.WriteStringOfLength(p.OrgTex.OrgTex2, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);
                IffCommonMethods.WriteStringOfLength(p.OrgTex.OrgTex3, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

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

                IffCommonMethods.WriteStringOfLength(p.EquippableWith, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

                writer.Write(p.SubParts.SubPart1);
                curPos += 4;

                writer.Write(p.SubParts.SubPart2);
                curPos += 4;

                writer.Write(p.CardCharSlots);
                curPos += 2;

                writer.Write(p.CardCaddySlots);
                curPos += 2;

                writer.Write(p.Points);
                curPos += 2;

                writer.Seek(2, SeekOrigin.Current);
            }

            writer.Close();
            return true;
        }
        #endregion

        #region LoadPartFile Methods
        /// <summary>
        /// General caller method to load from a Part.iff file.
        /// </summary>
        /// <param name="fileName">Filename to load from.</param>
        /// <returns>A list of PartsRecords read from the file.</returns>
        public static List<PartsRecord> LoadPartFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<PartsRecord> partsList = new List<PartsRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 partsInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.GetIffRegion(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    // Once we know the region, we have to start calling the correct LoadParts()
                    // method for the given magic number.
                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        // We'll be splitting the processing to make it easier to code
                        switch (inIffFile.Region)
                        {
                            // Season 4.5 GB/TH, all Updates < 585.00
                            case (IffFile.IFF_REGION.Default):
                                partsList = LoadParts_0(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Default);
                                break;

                            // Season 4.5 Japan, "CC CC" JP files
                            case (IffFile.IFF_REGION.Japan):
                            case (IffFile.IFF_REGION.Japan_52428):
                                partsList = LoadParts_52428(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Japan);
                                break;

                            // Newer 536 bytes long JP files
                            case (IffFile.IFF_REGION.Japan_8960):
                                partsList = LoadParts_8960(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Japan_8960);
                                break;

                            // Season 5 Japan, 604 Update
                            case (IffFile.IFF_REGION.Japan_30312):
                            case (IffFile.IFF_REGION.Global_30087):
                            case (IffFile.IFF_REGION.Global_30425):
                                partsList = LoadParts_30312(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Japan_30312);
                                break;

                            case (IffFile.IFF_REGION.Global_57):
                                partsList = LoadParts_CommonOnly(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Global_30425);
                                break;

                            // Season 4.5 Korea, 614 Update
                            case (IffFile.IFF_REGION.Korea_30395):
                                partsList = LoadParts_30395(inIffFile, reader, partsInFile, (int)RecordLengthEnum.Korea_30395);
                                break;
                        }
                        reader.Close();

                        return partsList;
                    }
                }
            }
            return new List<PartsRecord>();
        }

        private static List<PartsRecord> LoadParts_CommonOnly(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                reader.BaseStream.Seek(recordPos + record_length, SeekOrigin.Begin);

                partsList.Add(tmpRecord);
            }

            return partsList;
        }

        private static List<PartsRecord> LoadParts_0(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                GetModel(inIffFile, reader, ref tmpRecord, ref curPos);

                tmpRecord.EquipmentCategory = reader.ReadByte();
                curPos += 1;

                // According to the struct there are 3 empty bytes here...
                reader.BaseStream.Seek(3, SeekOrigin.Current);
                curPos += 3;

                tmpRecord.PosMask = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.HideMask = reader.ReadUInt32();
                curPos += 4;

                GetTextures(inIffFile, reader, ref tmpRecord, ref curPos);

                GetOrgTextures(inIffFile, reader, ref tmpRecord, ref curPos);

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

                byte[] byteEqWith = reader.ReadBytes(40);
                string tmpEqWithString = IffFile.FileEncoding(inIffFile.Region).GetString(byteEqWith);
                tmpRecord.EquippableWith = IffItemCommon.CleanupStringAfterReading(tmpEqWithString);
                curPos += 40;

                tmpRecord.SubParts.SubPart1 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.SubParts.SubPart2 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.CardCharSlots = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.CardCaddySlots = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Points = reader.ReadUInt16();
                curPos += 2;

                // Yeah, for some reason there are 2 empty bytes here
                // again. See 0x200 - (0x1fc + 0x2) for reference...
                reader.BaseStream.Seek(2, SeekOrigin.Current);
                curPos += 2;

                // Hopefully won't be necessary anymore, leaving it
                // for debugging purposes, it's quite handy...
                //reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                partsList.Add(tmpRecord);
            }

            return partsList;
        }

        private static List<PartsRecord> LoadParts_30395(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                GetModel(inIffFile, reader, ref tmpRecord, ref curPos);

                tmpRecord.EquipmentCategory = reader.ReadByte();
                curPos += 1;

                reader.BaseStream.Seek(3, SeekOrigin.Current);
                curPos += 3;

                tmpRecord.PosMask = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.HideMask = reader.ReadUInt32();
                curPos += 4;

                GetTextures(inIffFile, reader, ref tmpRecord, ref curPos);

                GetOrgTextures(inIffFile, reader, ref tmpRecord, ref curPos);

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

                byte[] byteEqWith = reader.ReadBytes(40);
                tmpRecord.EquippableWith = IffFile.FileEncoding(inIffFile.Region).GetString(byteEqWith);
                curPos += 40;

                tmpRecord.SubParts.SubPart1 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.SubParts.SubPart2 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.CardCharSlots = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.CardCaddySlots = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Points = reader.ReadUInt16();
                curPos += 2;

                // Seek 6 unknown bytes
                reader.BaseStream.Seek(6, SeekOrigin.Current);
                curPos += 6;

                // Hopefully won't be necessary anymore, leaving it
                // for debugging purposes, it's quite handy...
                //reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                partsList.Add(tmpRecord);
            }

            return partsList;
        }

        private static List<PartsRecord> LoadParts_52428(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                GetModel(inIffFile, reader, ref tmpRecord, ref curPos);

                tmpRecord.EquipmentCategory = reader.ReadByte();
                curPos += 1;

                // According to the struct there are 3 empty bytes here...
                reader.BaseStream.Seek(3, SeekOrigin.Current);
                curPos += 3;

                tmpRecord.PosMask = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.HideMask = reader.ReadUInt32();
                curPos += 4;

                GetTextures(inIffFile, reader, ref tmpRecord, ref curPos);

                GetOrgTextures(inIffFile, reader, ref tmpRecord, ref curPos);

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

                byte[] byteEqWith = reader.ReadBytes(40);
                tmpRecord.EquippableWith = IffFile.FileEncoding(inIffFile.Region).GetString(byteEqWith);
                curPos += 40;

                tmpRecord.SubParts.SubPart1 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.SubParts.SubPart2 = reader.ReadUInt32();
                curPos += 4;

                tmpRecord.CardCharSlots = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.CardCaddySlots = reader.ReadUInt16();
                curPos += 2;

                // Hopefully won't be necessary anymore, leaving it
                // for debugging purposes, it's quite handy...
                reader.BaseStream.Seek(record_length - (curPos - recordPos), SeekOrigin.Current);

                partsList.Add(tmpRecord);
            }

            return partsList;
        }

        private static List<PartsRecord> LoadParts_8960(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);
                // 172

                GetModel(inIffFile, reader, ref tmpRecord, ref curPos);
                // 212

                tmpRecord.EquipmentCategory = reader.ReadByte();
                curPos += 1;
                // 213

                // According to the struct there are 4 empty bytes here...
                reader.BaseStream.Seek(3, SeekOrigin.Current);
                curPos += 3;
                // 216

                tmpRecord.PosMask = reader.ReadUInt32();
                curPos += 4;
                // 220

                tmpRecord.HideMask = reader.ReadUInt32();
                curPos += 4;
                // 224

                GetTextures(inIffFile, reader, ref tmpRecord, ref curPos);
                // 344

                GetOrgTextures(inIffFile, reader, ref tmpRecord, ref curPos);
                // 464

                tmpRecord.Power = reader.ReadUInt16();
                curPos += 2;
                // 466

                tmpRecord.Control = reader.ReadUInt16();
                curPos += 2;
                // 468

                tmpRecord.Impact = reader.ReadUInt16();
                curPos += 2;
                // 470

                tmpRecord.Spin = reader.ReadUInt16();
                curPos += 2;
                // 472

                tmpRecord.Curve = reader.ReadUInt16();
                curPos += 2;
                // 474

                tmpRecord.PowerSlot = reader.ReadUInt16();
                curPos += 2;
                // 476

                tmpRecord.ControlSlot = reader.ReadUInt16();
                curPos += 2;
                // 478

                tmpRecord.ImpactSlot = reader.ReadUInt16();
                curPos += 2;
                // 480

                tmpRecord.SpinSlot = reader.ReadUInt16();
                curPos += 2;
                // 482

                tmpRecord.CurveSlot = reader.ReadUInt16();
                curPos += 2;
                // 484

                byte[] byteEqWith = reader.ReadBytes(40);
                tmpRecord.EquippableWith = IffFile.FileEncoding(inIffFile.Region).GetString(byteEqWith);
                curPos += 40;
                // 524

                tmpRecord.SubParts.SubPart1 = reader.ReadUInt32();
                curPos += 4;
                // 528

                tmpRecord.SubParts.SubPart2 = reader.ReadUInt32();
                curPos += 4;
                // 532

                tmpRecord.CardCharSlots = reader.ReadUInt16();
                curPos += 2;
                // 536

                tmpRecord.CardCaddySlots = reader.ReadUInt16();
                curPos += 2;
                // 538

                partsList.Add(tmpRecord);
            }

            return partsList;
        }

        private static List<PartsRecord> LoadParts_30312(IffFile inIffFile, BinaryReader reader, ushort partsInFile, int record_length)
        {
            List<PartsRecord> partsList = new List<PartsRecord>();

            for (int i = 0; i < partsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                PartsRecord tmpRecord = new PartsRecord();

                // Load basic properties
                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);
                // 172

                GetModel(inIffFile, reader, ref tmpRecord, ref curPos);
                // 212

                tmpRecord.EquipmentCategory = reader.ReadByte();
                curPos += 1;
                // 213

                // According to the struct there are 4 empty bytes here...
                reader.BaseStream.Seek(3, SeekOrigin.Current);
                curPos += 3;
                // 216

                tmpRecord.PosMask = reader.ReadUInt32();
                curPos += 4;
                // 220

                tmpRecord.HideMask = reader.ReadUInt32();
                curPos += 4;
                // 224

                GetTextures(inIffFile, reader, ref tmpRecord, ref curPos);
                // 344

                GetOrgTextures(inIffFile, reader, ref tmpRecord, ref curPos);
                // 464

                tmpRecord.Power = reader.ReadUInt16();
                curPos += 2;
                // 466

                tmpRecord.Control = reader.ReadUInt16();
                curPos += 2;
                // 468

                tmpRecord.Impact = reader.ReadUInt16();
                curPos += 2;
                // 470

                tmpRecord.Spin = reader.ReadUInt16();
                curPos += 2;
                // 472

                tmpRecord.Curve = reader.ReadUInt16();
                curPos += 2;
                // 474

                tmpRecord.PowerSlot = reader.ReadUInt16();
                curPos += 2;
                // 476

                tmpRecord.ControlSlot = reader.ReadUInt16();
                curPos += 2;
                // 478

                tmpRecord.ImpactSlot = reader.ReadUInt16();
                curPos += 2;
                // 480

                tmpRecord.SpinSlot = reader.ReadUInt16();
                curPos += 2;
                // 482

                tmpRecord.CurveSlot = reader.ReadUInt16();
                curPos += 2;
                // 484

                byte[] byteEqWith = reader.ReadBytes(40);
                tmpRecord.EquippableWith = IffFile.FileEncoding(inIffFile.Region).GetString(byteEqWith);
                curPos += 40;
                // 524

                tmpRecord.SubParts.SubPart1 = reader.ReadUInt32();
                curPos += 4;
                // 528

                tmpRecord.SubParts.SubPart2 = reader.ReadUInt32();
                curPos += 4;
                // 532

                tmpRecord.CardCharSlots = reader.ReadUInt16();
                curPos += 2;
                // 536

                tmpRecord.CardCaddySlots = reader.ReadUInt16();
                curPos += 2;
                // 538

                // Hopefully won't be necessary anymore, leaving it
                // for debugging purposes, it's quite handy...
                reader.BaseStream.Seek(8, SeekOrigin.Current);

                partsList.Add(tmpRecord);
            }

            return partsList;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Read the "model" value and clean up the string.
        /// </summary>
        /// <param name="inIffFile">IFF file containing the base properties (like region).</param>
        /// <param name="reader">BinaryReader to use while reading.</param>
        /// <param name="recordToModify">Reference to the PartsRecord to use.</param>
        /// <param name="curPos">Reference to the curPos indicator to increase.</param>
        private static void GetModel(IffFile inIffFile, BinaryReader reader, ref PartsRecord recordToModify, ref long curPos)
        {
            string tmpModel = "";
            byte[] byteItemModelInShop = reader.ReadBytes(40);
            tmpModel = IffFile.FileEncoding(inIffFile.Region).GetString(byteItemModelInShop);
            recordToModify.Model = IffItemCommon.CleanupStringAfterReading(tmpModel);
            curPos += 40;
        }

        /// <summary>
        /// Read the Tex1, Tex2 and Tex3 values and cleans up the strings.
        /// </summary>
        /// <param name="inIffFile">IFF file containing the base properties (like region).</param>
        /// <param name="reader">BinaryReader to use while reading.</param>
        /// <param name="recordToModify">Reference to the PartsRecord to use.</param>
        /// <param name="curPos">Reference to the curPos indicator to increase.</param>
        private static void GetTextures(IffFile inIffFile, BinaryReader reader, ref PartsRecord recordToModify, ref long curPos)
        {
            string tmpTexName = "";

            byte[] byteTex1 = reader.ReadBytes(40);
            tmpTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteTex1);
            recordToModify.Tex.Tex1 = IffItemCommon.CleanupStringAfterReading(tmpTexName);
            curPos += 40;

            byte[] byteTex2 = reader.ReadBytes(40);
            tmpTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteTex2);
            recordToModify.Tex.Tex2 = IffItemCommon.CleanupStringAfterReading(tmpTexName);
            curPos += 40;

            byte[] byteTex3 = reader.ReadBytes(40);
            tmpTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteTex3);
            recordToModify.Tex.Tex3 = IffItemCommon.CleanupStringAfterReading(tmpTexName);
            curPos += 40;
        }

        /// <summary>
        /// Read the OrgTex1, OrgTex2 and OrgTex3 values and cleans up the strings.
        /// </summary>
        /// <param name="inIffFile">IFF file containing the base properties (like region).</param>
        /// <param name="reader">BinaryReader to use while reading.</param>
        /// <param name="recordToModify">Reference to the PartsRecord to use.</param>
        /// <param name="curPos">Reference to the curPos indicator to increase.</param>
        private static void GetOrgTextures(IffFile inIffFile, BinaryReader reader, ref PartsRecord recordToModify, ref long curPos)
        {
            string tmpOrgTexName = "";

            byte[] byteOrgTex1 = reader.ReadBytes(40);
            tmpOrgTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteOrgTex1);
            recordToModify.OrgTex.OrgTex1 = IffItemCommon.CleanupStringAfterReading(tmpOrgTexName);
            curPos += 40;

            byte[] byteOrgTex2 = reader.ReadBytes(40);
            tmpOrgTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteOrgTex2);
            recordToModify.OrgTex.OrgTex2 = IffItemCommon.CleanupStringAfterReading(tmpOrgTexName);
            curPos += 40;

            byte[] byteOrgTex3 = reader.ReadBytes(40);
            tmpOrgTexName = IffFile.FileEncoding(inIffFile.Region).GetString(byteOrgTex3);
            recordToModify.OrgTex.OrgTex3 = IffItemCommon.CleanupStringAfterReading(tmpOrgTexName);
            curPos += 40;
        }

        /// <summary>
        /// Generates SQL queries to fill/update the database and saves them to one or multiple files.
        /// </summary>
        /// <param name="objectList">List of PartsRecords to process.</param>
        /// <param name="fileName">Filename of the output file.</param>
        public static void GenerateSqlFile(object objectList, string fileName)
        {
            const int partsPerSqlFile = 750;              // Number of parts per file
            const string sqlTranName = "UpdatePartList";  // The T-SQL transaction name

            int c = 0;                                    // Part counter for the foreach() loop
            int seq = 0;                                  // SEQ counter for the generation
            int fileNum = 1;                              // Start suffix for the query filename

            List<PartsRecord> itemList = (List<PartsRecord>)objectList;
            FileInfo fileInfo = new FileInfo(fileName);

            TextWriter writer = new StreamWriter(fileInfo.DirectoryName + Path.DirectorySeparatorChar +
                fileInfo.Name.Replace(fileInfo.Extension, "") + "_" + String.Format("{0:00}", fileNum) + fileInfo.Extension, false);

            fileNum++;

            writer.WriteLine("USE [Pangya_S4_TH]");
            writer.WriteLine("GO\r\n");

            writer.WriteLine("BEGIN TRAN {0}\r\n", sqlTranName);

            foreach (PartsRecord item in itemList)
            {
                // Cleanup the strings first to reduce the ugly clutter in the database.
                // Ideally this will not be necessary but we better do it anyway.
                string partIcon = IffCommonMethods.GetCleanedUpStringForSQL(item.Base.Icon);
                string partModel = IffCommonMethods.GetCleanedUpStringForSQL(item.Model);
                string partName = IffCommonMethods.GetCleanedUpStringForSQL(item.Base.Name);
                string partTex1 = IffCommonMethods.GetCleanedUpStringForSQL(item.Tex.Tex1);
                string partTex2 = IffCommonMethods.GetCleanedUpStringForSQL(item.Tex.Tex2);
                string partTex3 = IffCommonMethods.GetCleanedUpStringForSQL(item.Tex.Tex3);
                string partOTex1 = IffCommonMethods.GetCleanedUpStringForSQL(item.OrgTex.OrgTex1);
                string partOTex2 = IffCommonMethods.GetCleanedUpStringForSQL(item.OrgTex.OrgTex2);
                string partOTex3 = IffCommonMethods.GetCleanedUpStringForSQL(item.OrgTex.OrgTex3);
                string partEqWith = IffCommonMethods.GetCleanedUpStringForSQL(item.EquippableWith);
                int isCash = Convert.ToSByte(item.Base.IsCash);

                if (!string.IsNullOrEmpty(partIcon))
                {
                    if (c >= partsPerSqlFile)
                    {
                        writer.Close();
                        writer = new StreamWriter(fileInfo.DirectoryName + Path.DirectorySeparatorChar +
                            fileInfo.Name.Replace(fileInfo.Extension, "") + "_" + String.Format("{0:00}", fileNum) + fileInfo.Extension, false);

                        writer.WriteLine("USE [Pangya_S4_TH]");
                        writer.WriteLine("GO\r\n");

                        writer.WriteLine("BEGIN TRAN {0}\r\n", sqlTranName);

                        c = 0;
                        fileNum++;
                    }

                    // Pangya_Item_Typelist
                    writer.WriteLine("-- Item: {0}", partName);
                    writer.WriteLine("IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {0} )", item.Base.TypeId);
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   UPDATE PANGYA_ITEM_TYPELIST");
                    writer.WriteLine("   SET [NAME] = N'{0}'", partName);
                    writer.WriteLine("    , [ICON] = N'{0}'", partIcon);
                    writer.WriteLine("    , [PRICE] = {0}", item.Base.Price);
                    writer.WriteLine("    , [ISCASH] = {0}", isCash);
                    writer.WriteLine("    , [TYPE] = {0}", item.Base.TypeIdValues.Type);
                    writer.WriteLine("    , [COM0] = {0}", item.Power);
                    writer.WriteLine("    , [COM1] = {0}", item.Control);
                    writer.WriteLine("    , [COM2] = {0}", item.Spin);
                    writer.WriteLine("    , [COM3] = {0}", item.Impact);
                    writer.WriteLine("    , [COM4] = {0}", item.Curve);
                    writer.WriteLine("    , [CHAR_SERIALNO] = {0}", item.Base.TypeIdValues.Character_Raw);
                    writer.WriteLine("    , [DESC] = N'{0}'", partName);
                    writer.WriteLine("    , [TNAME] = N'{0}'", partName);
                    writer.WriteLine("    , [IS_SALABLE] = {0}", Convert.ToSByte(item.Base.IsSalable));
                    writer.WriteLine("   WHERE TYPEID = {0}", item.Base.TypeId);
                    writer.WriteLine("END");
                    writer.WriteLine("ELSE");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   INSERT INTO PANGYA_ITEM_TYPELIST");
                    writer.WriteLine("    ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH], [TYPE], [COM0], [COM1], [COM2], [COM3], [COM4], [CHAR_SERIALNO], [DESC], [TNAME], [IS_SALABLE] )");
                    writer.WriteLine("   VALUES ( {0}, N'{1}', N'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, N'{12}', N'{13}', {14} )",
                                        item.Base.TypeId, partName, partIcon, item.Base.Price, isCash, item.Base.TypeIdValues.Type,
                                        item.Power, item.Control, item.Spin, item.Impact, item.Curve, item.Base.TypeIdValues.Character_Raw,
                                        partName, partName, Convert.ToSByte(item.Base.IsSalable));
                    writer.WriteLine("END");
                    writer.WriteLine("IF @@ERROR != 0");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   ROLLBACK TRAN {0}", sqlTranName);
                    writer.WriteLine("   RAISERROR('[E] [Pangya_Item_Typelist] Execution failed on item {0}.', 1, -1)", item.Base.TypeId);
                    writer.WriteLine("   RETURN");
                    writer.WriteLine("END");
                    writer.WriteLine("\r\n");

                    // TA_Parts_Acc
                    writer.WriteLine("IF EXISTS ( SELECT TYPEID FROM TA_PARTS_ACC WHERE TYPEID = {0} )", item.Base.TypeId);
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   UPDATE TA_PARTS_ACC");
                    writer.WriteLine("   SET CHAR_SERIAL = {0}", item.Base.TypeIdValues.Character_Raw);
                    writer.WriteLine("    , [POS] = {0}", item.Base.TypeIdValues.Pos);
                    writer.WriteLine("    , [GROUP] = {0}", 0);
                    writer.WriteLine("    , [TYPE] = {0}", 0);
                    writer.WriteLine("    , [SERIAL] = {0}", item.Base.TypeIdValues.Serial);
                    writer.WriteLine("    , [SEQ] = {0}", seq);
                    writer.WriteLine("    , [NAME] = N'{0}'", partName);
                    writer.WriteLine("    , [LEVEL] = {0}", item.Base.Level);
                    writer.WriteLine("    , [IS_UNDERLVL] = {0}", Convert.ToSByte(item.Base.IsMaximumLevel));
                    writer.WriteLine("    , [ICON] = N'{0}'", partIcon);
                    writer.WriteLine("    , [PRICE] = {0}", item.Base.Price);
                    writer.WriteLine("    , [SALE_PRICE] = {0}", item.Base.SalePrice);
                    writer.WriteLine("    , [PURCHASE_PRICE] = {0}", item.Base.UsedPrice);
                    writer.WriteLine("    , [IS_CASH] = {0}", isCash);
                    writer.WriteLine("    , [IS_SALABLE] = {0}", Convert.ToSByte(item.Base.IsSalable));
                    writer.WriteLine("    , [IN_STOCK] = {0}", Convert.ToSByte(item.Base.IsInStock));
                    writer.WriteLine("    , [NEW] = {0}", Convert.ToSByte(item.Base.IsNew));
                    writer.WriteLine("    , [HIT] = {0}", Convert.ToSByte(item.Base.IsHot));
                    writer.WriteLine("    , [TIME_FLAG] = {0}", item.Base.TimeFlag);
                    writer.WriteLine("    , [TIME] = {0}", item.Base.Time);
                    writer.WriteLine("    , [POWER] = {0}", item.Power);
                    writer.WriteLine("    , [CONTROL] = {0}", item.Control);
                    writer.WriteLine("    , [ACCURACY] = {0}", item.Impact);
                    writer.WriteLine("    , [SPIN] = {0}", item.Spin);
                    writer.WriteLine("    , [CURVE] = {0}", item.Curve);
                    writer.WriteLine("    , [DATA] = N'{0}'", partModel);
                    writer.WriteLine("    , [POWER_SLOT] = {0}", item.PowerSlot);
                    writer.WriteLine("    , [CONTROL_SLOT] = {0}", item.ControlSlot);
                    writer.WriteLine("    , [ACCUACY_SLOT] = {0}", item.ImpactSlot);
                    writer.WriteLine("    , [SPIN_SLOT] = {0}", item.SpinSlot);
                    writer.WriteLine("    , [CURVE_SLOT] = {0}", item.CurveSlot);
                    writer.WriteLine("    , [PART_CATEGORY] = {0}", item.EquipmentCategory);
                    writer.WriteLine("    , [POS_MASK] = {0}", item.PosMask);
                    writer.WriteLine("    , [HIDE_MASK] = {0}", "NULL"); // TODO: Bugfix the overflow
                    writer.WriteLine("    , [TEX_0] = N'{0}'", partTex1);
                    writer.WriteLine("    , [ORGIN_TEX_0] = N'{0}'", partOTex1);
                    writer.WriteLine("    , [TEX_1] = N'{0}'", partTex2);
                    writer.WriteLine("    , [ORGIN_TEX_1] = N'{0}'", partOTex2);
                    writer.WriteLine("    , [TEX_2] = N'{0}'", partTex3);
                    writer.WriteLine("    , [ORGIN_TEX_2] = N'{0}'", partOTex3);
                    writer.WriteLine("    , [EQUIPPABLE_WITH] = N'{0}'", partEqWith);
                    writer.WriteLine("    , [SUB_PART_0] = {0}", item.SubParts.SubPart1);
                    writer.WriteLine("    , [SUB_PART_1] = {0}", item.SubParts.SubPart2);
                    writer.WriteLine("    , [CHARACTER_SLOT] = {0}", item.CardCharSlots);
                    writer.WriteLine("    , [CADDIE_SLOT] = {0}", item.CardCaddySlots);
                    writer.WriteLine("    , [DISC] = N'{0}'", partName);

                    if (item.Base.SaleStart.wYear != 0)
                        writer.WriteLine("    , [SALE_START] = N'{0}-{1}-{2} {3}:{4}:{5}'", item.Base.SaleStart.wYear, item.Base.SaleStart.wMonth, item.Base.SaleStart.wDay, item.Base.SaleStart.wHour, item.Base.SaleStart.wMinute, item.Base.SaleStart.wSecond);
                    if (item.Base.SaleEnd.wYear != 0)
                        writer.WriteLine("    , [SALE_END] = N'{0}-{1}-{2} {3}:{4}:{5}'", item.Base.SaleEnd.wYear, item.Base.SaleEnd.wMonth, item.Base.SaleEnd.wDay, item.Base.SaleEnd.wHour, item.Base.SaleEnd.wMinute, item.Base.SaleEnd.wSecond);

                    writer.WriteLine("    , [IN_DATE] = GETDATE()");
                    writer.WriteLine("    , [USE_YN] = N'Y'");
                    writer.WriteLine("   WHERE TYPEID = {0}", item.Base.TypeId);
                    writer.WriteLine("END");
                    writer.WriteLine("ELSE");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   INSERT INTO TA_PARTS_ACC");
                    writer.WriteLine("   ( ");
                    writer.WriteLine("    [TYPEID], [CHAR_SERIAL], [POS], [GROUP], [TYPE], [SERIAL], [SEQ],");
                    writer.WriteLine("    [NAME], [LEVEL], [IS_UNDERLVL], [ICON], [PRICE], [SALE_PRICE],");
                    writer.WriteLine("    [PURCHASE_PRICE], [IS_CASH], [IS_SALABLE], [IN_STOCK], [NEW],");
                    writer.WriteLine("    [HIT], [TIME_FLAG], [TIME], [POWER], [CONTROL], [ACCURACY], [SPIN], [CURVE],");
                    writer.WriteLine("    [DATA], [POWER_SLOT], [CONTROL_SLOT], [ACCUACY_SLOT], [SPIN_SLOT], [CURVE_SLOT],");
                    writer.WriteLine("    [PART_CATEGORY], [POS_MASK], [HIDE_MASK], [TEX_0], [ORGIN_TEX_0],");
                    writer.WriteLine("    [TEX_1], [ORGIN_TEX_1], [TEX_2], [ORGIN_TEX_2], [EQUIPPABLE_WITH], ");
                    writer.WriteLine("    [SUB_PART_0], [SUB_PART_1], [CHARACTER_SLOT], [CADDIE_SLOT], [DISC],");
                    writer.WriteLine("    [SALE_START], [SALE_END], [IN_DATE], [USE_YN]");
                    writer.WriteLine("   ) VALUES (");
                    writer.WriteLine("      {0}", item.Base.TypeId);
                    writer.WriteLine("    , {0}", item.Base.TypeIdValues.Character_Raw);
                    writer.WriteLine("    , {0}", item.Base.TypeIdValues.Pos);
                    writer.WriteLine("    , {0}", 0);
                    writer.WriteLine("    , {0}", 0);
                    writer.WriteLine("    , {0}", item.Base.TypeIdValues.Serial);
                    writer.WriteLine("    , {0}", seq);
                    writer.WriteLine("    , N'{0}'", partName);
                    writer.WriteLine("    , {0}", item.Base.Level);
                    writer.WriteLine("    , {0}", Convert.ToSByte(item.Base.IsMaximumLevel));
                    writer.WriteLine("    , N'{0}'", partIcon);
                    writer.WriteLine("    , {0}", item.Base.Price);
                    writer.WriteLine("    , {0}", item.Base.SalePrice);
                    writer.WriteLine("    , {0}", item.Base.UsedPrice);
                    writer.WriteLine("    , {0}", isCash);
                    writer.WriteLine("    , {0}", Convert.ToSByte(item.Base.IsSalable));
                    writer.WriteLine("    , {0}", Convert.ToSByte(item.Base.IsInStock));
                    writer.WriteLine("    , {0}", Convert.ToSByte(item.Base.IsNew));
                    writer.WriteLine("    , {0}", Convert.ToSByte(item.Base.IsHot));
                    writer.WriteLine("    , {0}", item.Base.TimeFlag);
                    writer.WriteLine("    , {0}", item.Base.Time);
                    writer.WriteLine("    , {0}", item.Power);
                    writer.WriteLine("    , {0}", item.Control);
                    writer.WriteLine("    , {0}", item.Impact);
                    writer.WriteLine("    , {0}", item.Spin);
                    writer.WriteLine("    , {0}", item.Curve);
                    writer.WriteLine("    , N'{0}'", partModel);
                    writer.WriteLine("    , {0}", item.PowerSlot);
                    writer.WriteLine("    , {0}", item.ControlSlot);
                    writer.WriteLine("    , {0}", item.ImpactSlot);
                    writer.WriteLine("    , {0}", item.SpinSlot);
                    writer.WriteLine("    , {0}", item.CurveSlot);
                    writer.WriteLine("    , {0}", item.EquipmentCategory);
                    writer.WriteLine("    , {0}", item.PosMask);
                    writer.WriteLine("    , {0}", "NULL"); //TODO: Smallint overflow problem...
                    writer.WriteLine("    , N'{0}'", partTex1);
                    writer.WriteLine("    , N'{0}'", partOTex1);
                    writer.WriteLine("    , N'{0}'", partTex2);
                    writer.WriteLine("    , N'{0}'", partOTex2);
                    writer.WriteLine("    , N'{0}'", partTex3);
                    writer.WriteLine("    , N'{0}'", partOTex3);
                    writer.WriteLine("    , N'{0}'", partEqWith);
                    writer.WriteLine("    , {0}", item.SubParts.SubPart1);
                    writer.WriteLine("    , {0}", item.SubParts.SubPart2);
                    writer.WriteLine("    , {0}", item.CardCharSlots);
                    writer.WriteLine("    , {0}", item.CardCaddySlots);
                    writer.WriteLine("    , N'{0}'", partName);

                    if (item.Base.SaleStart.wYear != 0)
                        writer.WriteLine("    , N'{0}-{1}-{2} {3}:{4}:{5}'", item.Base.SaleStart.wYear, item.Base.SaleStart.wMonth, item.Base.SaleStart.wDay, item.Base.SaleStart.wHour, item.Base.SaleStart.wMinute, item.Base.SaleStart.wSecond);
                    else
                        writer.WriteLine("    , NULL");

                    if (item.Base.SaleEnd.wYear != 0)
                        writer.WriteLine("    , N'{0}-{1}-{2} {3}:{4}:{5}'", item.Base.SaleEnd.wYear, item.Base.SaleEnd.wMonth, item.Base.SaleEnd.wDay, item.Base.SaleEnd.wHour, item.Base.SaleEnd.wMinute, item.Base.SaleEnd.wSecond);
                    else
                        writer.WriteLine("    , NULL");

                    writer.WriteLine("    , GETDATE()");
                    writer.WriteLine("    , N'Y'");
                    writer.WriteLine("   )");
                    writer.WriteLine("END");
                    writer.WriteLine("IF @@ERROR != 0");
                    writer.WriteLine("BEGIN");
                    writer.WriteLine("   ROLLBACK TRAN {0}", sqlTranName);
                    writer.WriteLine("   RAISERROR('[E] [TA_Parts_Acc] Execution failed on item {0}.', 1, -1)", item.Base.TypeId);
                    writer.WriteLine("   RETURN");
                    writer.WriteLine("END");
                    writer.WriteLine("\r\n");

                    c++;
                    seq++;

                    if (c >= partsPerSqlFile)
                    {
                        writer.WriteLine("COMMIT TRAN {0}", sqlTranName);
                    }
                }
            }

            writer.WriteLine("COMMIT TRAN {0}", sqlTranName);
            writer.WriteLine("GO");
            writer.Close();
        }
        #endregion

        /// <summary>
        /// Clones the current PartRecord.
        /// </summary>
        /// <returns>A clone of the original record.</returns>
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
