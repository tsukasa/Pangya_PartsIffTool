using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PartsIffTool
{
    /// <summary>
    /// This contains the base attributes just about every consumable
    /// item in Pangya has.
    /// </summary>
    [Serializable]
    public class IffItemCommon
    {
        /// <summary>
        /// Possible price values.
        /// Please note that not all values
        /// will have an effect on the game's store.
        /// 
        /// Nonetheless, you should always make use
        /// of the correct attributation as other
        /// parts (i.e. the server) might pick up
        /// on these.
        /// </summary>
        public enum eIsCash
        {
            Cookies = 0x0,
            Pang = 0x1,
            Free = 0x2,
            Set = 0x4,
        };

        /// <summary>
        /// Cheapo solution to get a character name
        /// by it's character serial until "real"
        /// Character.iff parsing is in place globally.
        /// </summary>
        public enum eCharacter
        {
            Nuri = 0,
            Hana = 1,
            Arthur = 2,
            Cesillia = 3,
            Max = 4,
            Kooh = 5,
            Arin = 6,
            Kaz = 7,
            Lucia = 8,
            Nell = 9,
        }

        /// <summary>
        /// Struct for some of the values you can derive
        /// from the Type ID. The values should always get
        /// calculated automatically.
        /// </summary>
        [Serializable]
        public struct sTypeIdValues
        {
            // Virtual properties we'll derive from the TypeId
            public eCharacter Character;
            public UInt16 Character_Raw;
            public UInt16 Group;
            public UInt16 Type;
            public UInt16 Pos;
            public UInt16 Serial;
        }

        private sTypeIdValues _TypeIdValues = new sTypeIdValues();

        public sTypeIdValues TypeIdValues
        {
            get
            {
                GetTypeIdValues();
                return _TypeIdValues;
            }
        }

        public IffFile.IFF_REGION Region = IffFile.IFF_REGION.Default;

        public UInt32 Final = 0;
        public UInt32 TypeId = 0;
        public string Name = "";

        public Byte Level = 0;
        public bool IsMaximumLevel = false;

        public string Icon = "";

        public UInt32 Price = 100;
        public UInt32 SalePrice = 100;
        public UInt32 UsedPrice = 50;

        public bool IsBasic = false;

        // These do not work yet,
        // use MoneyType instead...
        public bool IsCash = false;
        public bool IsCashSpecial = false;

        public bool IsSalable = false;

        public bool IsInStock = false;
        public bool IsReserve = false;

        public bool IsSpecial = false;
        public bool IsNew = false;
        public bool IsHot = false;

        public eIsCash MoneyUnit = eIsCash.Cookies;
        public Byte MoneyType = 0x01;
        public Byte ShopTag = 0x11;

        public Byte TimeFlag = 0;
        public Byte Time = 0;
        public UInt32 Point = 0;

        public IffFile._SYSTEMTIME SaleStart = new IffFile._SYSTEMTIME();
        public IffFile._SYSTEMTIME SaleEnd = new IffFile._SYSTEMTIME();

        /// <summary>
        /// Updates the Type ID values.
        /// </summary>
        public void GetTypeIdValues()
        {
            _TypeIdValues.Character = (eCharacter)((TypeId & (0x03fc0000)) / Math.Pow(2, 18));
            _TypeIdValues.Character_Raw = (UInt16)((TypeId & (0x03fc0000)) / Math.Pow(2, 18));
            _TypeIdValues.Group = (UInt16)((TypeId & (0xfc000000)) / Math.Pow(2, 26));
            _TypeIdValues.Type = (UInt16)((TypeId & 0x001f0000) / Math.Pow(2, 16));
            _TypeIdValues.Pos = (UInt16)((TypeId & 0x0003e003) / Math.Pow(2, 13));
            _TypeIdValues.Serial = (UInt16)(TypeId & 0x000000ff);
        }

        /// <summary>
        /// Property with only a getter, will return the
        /// maximum number of bytes (not characters!) a
        /// item name can have.
        /// </summary>
        public int NameMaxLength
        {
            get
            {
                switch (Region)
                {
                    case (IffFile.IFF_REGION.Default):
                    case (IffFile.IFF_REGION.Global_30087):
                        return 40;

                    case (IffFile.IFF_REGION.Japan):
                    case (IffFile.IFF_REGION.Japan_52428):
                    case (IffFile.IFF_REGION.Japan_8960):
                    case (IffFile.IFF_REGION.Japan_30312):
                    case (IffFile.IFF_REGION.Korea_30395):
                        return 64;

                    default:
                        return 40;
                }
            }
        }

        /// <summary>
        /// Invokes Google Translate to translate item names to
        /// another language. Works on IffItemCommon only.
        /// </summary>
        /// <param name="item"></param>
        public static void TranslateItemName(ref IffItemCommon item)
        {
            switch (item.Region)
            {
                case (IffFile.IFF_REGION.Japan):
                case (IffFile.IFF_REGION.Japan_52428):
                case (IffFile.IFF_REGION.Japan_8960):
                case (IffFile.IFF_REGION.Japan_30312):
                    item.Name =
                        IffCommonMethods.GetTranslatedItemName(item.Name,
                                                               item.TypeId,
                                                               "ja", "en");
                    break;

                case (IffFile.IFF_REGION.Korea_30395):
                    item.Name =
                        IffCommonMethods.GetTranslatedItemName(item.Name,
                                                               item.TypeId,
                                                               "kr", "en");
                    break;
            }
        }

        public static void GetCharacterId(ref IffItemCommon recordToDisplay)
        {
            recordToDisplay._TypeIdValues.Character = (eCharacter)((recordToDisplay.TypeId & (0x03fc0000)) / Math.Pow(2, 18));
        }

        public byte[] StructToByteArray(object oStruct)
        {
            try
            {
                // This function copies the structure data into a byte[] 

                // Set the buffer to the correct size ...
                byte[] buffer = new byte[Marshal.SizeOf(oStruct)];

                // Allocate the buffer to memory and pin it so that GC cannot use the 
                // space (Disable GC)...
                GCHandle h = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                // Copy the struct into int byte[] mem alloc...
                Marshal.StructureToPtr(oStruct, h.AddrOfPinnedObject(), false);

                // ...and allow the GC to do its job!
                h.Free();

                return buffer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Char[] StringToCharArray(string inputString, int maxLength)
        {
            string shortened = inputString;
            if (inputString.Length >= maxLength)
                shortened = inputString.Substring(0, maxLength - 1);

            return shortened.ToCharArray();
        }

        public static void GenerateSqlFile(object objectList, string fileName)
        {
            List<IffItemCommon> itemList = (List<IffItemCommon>)objectList;
            TextWriter writer = new StreamWriter(fileName, false);

            writer.WriteLine("USE [Pangya_S4_TH]");
            writer.WriteLine("GO\r\n");

            foreach (IffItemCommon item in itemList)
            {
                /* Have to substr here because we use a fixed 40byte long string */
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

                /* Choose whether IS_CASH will be 0 or 1... */
                int is_cash = 0;
                if (item.MoneyType == 0x01)
                    is_cash = 1;
                else
                    is_cash = 0;

                partName = partName.Replace("'", "''");

                writer.WriteLine("-- Item: {0}", partName);
                writer.WriteLine("IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {0} )", item.TypeId);
                writer.WriteLine("BEGIN");
                writer.WriteLine("    UPDATE PANGYA_ITEM_TYPELIST");
                writer.WriteLine("    SET NAME = N'{0}'", partName);
                writer.WriteLine("    , ICON = N'{0}'", partIcon);
                writer.WriteLine("    , PRICE = {0}", item.Price);
                writer.WriteLine("    , ISCASH = {0}", is_cash);
                writer.WriteLine("    , TYPE = {0}", item.Point);
                writer.WriteLine("    WHERE TYPEID = {0}", item.TypeId);
                writer.WriteLine("END");
                writer.WriteLine("ELSE");
                writer.WriteLine("BEGIN");
                writer.WriteLine("    INSERT INTO PANGYA_ITEM_TYPELIST");
                writer.WriteLine("    ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH], [TYPE] )");
                writer.WriteLine("    VALUES ( {0}, N'{1}', N'{2}', {3}, {4}, {5} )", item.TypeId, partName, partIcon, item.Price, is_cash, item.Point);
                writer.WriteLine("END\r\n");
            }

            writer.WriteLine("GO");
            writer.Close();
        }

        public static byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        public static BitArray PadToFullByte(BitArray bits)
        {
            BitArray newBa = new BitArray(8, false);

            if (bits.Count > 0)
            {
                for (int i = 0; i < bits.Count; i++)
                {
                    if (bits.Count > 8 && i < 8)
                        newBa.Set(i, bits[i]);
                }
            }
            return newBa;
        }

        public static string CleanupStringAfterReading(string input)
        {
            int propValueEnd = input.IndexOf((char)0x00);
            string propValueClean = "";
            if (propValueEnd > 0)
                propValueClean = input.Substring(0, propValueEnd);
            else
                propValueClean = "";

            return propValueClean;
        }

        public void SaveCommonProperties(BinaryWriter writer, IffFile.IFF_REGION region, ref long curPos)
        {
            switch (region)
            {
                case (IffFile.IFF_REGION.Default):
                    SaveCommonProperties_0(writer, ref curPos);
                    break;
                case (IffFile.IFF_REGION.Japan):
                    break;
                default:
                    throw new Exception("No region specified!");
            }
        }

        public void SaveCommonProperties_0(BinaryWriter writer, ref long curPos)
        {
            writer.Write(Final);
            curPos += 4;

            writer.Write(TypeId);
            curPos += 4;

            // Name
            IffCommonMethods.WriteStringOfLength(Name, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

            // Automatically increases curPos
            WriteLevel(writer, ref curPos);

            // Icon
            IffCommonMethods.WriteStringOfLength(Icon, 40, IffFile.FileEncoding(IffFile.IFF_REGION.Default), writer, ref curPos);

            writer.Seek(3, SeekOrigin.Current);
            curPos += 3;

            writer.Write(Price);
            curPos += 4;

            //writer.Seek(8, SeekOrigin.Current);
            //curPos += 8;

            writer.Write(SalePrice);
            curPos += 4;

            writer.Write(UsedPrice);
            curPos += 4;

            //WriteMoneyType(writer, ref curPos);
            writer.Write(MoneyType);
            curPos += 1;

            // Automatically increases curPos
            WriteShopTag(writer, ref curPos);

            // Time & TimeFlag
            writer.Write(TimeFlag);
            writer.Write(Time);
            curPos += 2;

            writer.Write(Point);
            curPos += 4;

            // Sanity checks for SystemTime belong into the editor
            WriteSysTime(writer, SaleStart, ref curPos);
            WriteSysTime(writer, SaleEnd, ref curPos);
        }

        public void GetItemNameFromRecord(BinaryReader reader, ref long curPos)
        {
            string name = string.Empty;
            int stringLen = 40;

            switch (Region)
            {
                case IffFile.IFF_REGION.Default:
                    stringLen = 40;
                    break;
                case IffFile.IFF_REGION.Japan:
                case IffFile.IFF_REGION.Japan_52428:
                case IffFile.IFF_REGION.Japan_8960:
                case IffFile.IFF_REGION.Japan_30312:
                    stringLen = 64;
                    break;
            }

            byte[] byteName = reader.ReadBytes(stringLen);
            name = IffFile.FileEncoding(Region).GetString(byteName).Trim();
            curPos += stringLen;

            Name = CleanupStringAfterReading(name);
        }

        public void GetLevelFromRecord(BinaryReader reader, ref long curPos)
        {
            byte byteLevel = reader.ReadByte();
            ReadLevel(byteLevel);
            curPos += 1;
        }

        public void GetIconFromRecord(BinaryReader reader, ref long curPos)
        {
            string icon = string.Empty;
            byte[] byteIcon = reader.ReadBytes(40);
            icon = IffFile.FileEncoding(Region).GetString(byteIcon);
            curPos += 40;

            Icon = CleanupStringAfterReading(icon.Trim());
        }

        public void GetMoneyTypeFromRecord(BinaryReader reader, ref long curPos)
        {
            bool alreadySet = false;

            byte moneyByte = reader.ReadByte();
            curPos += 1;

            BitArray moneyArray = new BitArray(BitConverter.GetBytes(moneyByte));
            moneyArray = PadToFullByte(moneyArray);


            // Currency: Cookies
            if (moneyArray.Get(0))
            {
                MoneyUnit = eIsCash.Cookies;
                alreadySet = true;
            }

            // Currency: Pang
            if (moneyArray.Get(1) && !alreadySet)
            {
                MoneyUnit = eIsCash.Pang;
                alreadySet = true;
            }

            // Currency: Free
            if (moneyArray.Get(2) && !alreadySet)
            {
                MoneyUnit = eIsCash.Free;
                alreadySet = true;
            }

            // Currency: Disabled/Part of a Set
            if (!moneyArray.Get(0) && !alreadySet)
            {
                MoneyUnit = eIsCash.Set;
                alreadySet = true;
            }

            // Determine whether item has a "Basic" discount.
            if (moneyArray.Get(6))
                IsBasic = true;

            MoneyType = moneyByte;
        }

        public void LoadCommonProperties(BinaryReader reader, IffFile.IFF_REGION region, ref long curPos)
        {
            Region = region;

            switch (Region)
            {
                case IffFile.IFF_REGION.Default:
                case IffFile.IFF_REGION.Global_30087:
                case IffFile.IFF_REGION.Global_30447:
                    LoadCommonProperties_0(reader, ref curPos);
                    break;
                case IffFile.IFF_REGION.Global_30425:
                    LoadCommonProperties_30425(reader, ref curPos);
                    break;
                case IffFile.IFF_REGION.Global_57:
                    LoadCommonProperties_57(reader, ref curPos);
                    break;
                case IffFile.IFF_REGION.Japan:
                case IffFile.IFF_REGION.Japan_52428:
                    LoadCommonProperties_52428(reader, ref curPos);
                    break;
                case IffFile.IFF_REGION.Japan_8960:
                case IffFile.IFF_REGION.Japan_30312:
                    LoadCommonProperties_8960(reader, ref curPos);
                    break;
                case IffFile.IFF_REGION.Korea_30395:
                    LoadCommonProperties_0(reader, ref curPos);
                    break;
                default:
                    throw new Exception("No region specified.");
            }
        }

        /// <summary>
        /// Loads the IffCommon properties for Pangya TH IFFs
        /// </summary>
        /// <param name="reader">BinaryReader to use for reading</param>
        /// <param name="curPos">Current position within the stream</param>
        public void LoadCommonProperties_0(BinaryReader reader, ref long curPos)
        {
            Final = reader.ReadUInt32();

            TypeId = reader.ReadUInt32();
            GetTypeIdValues();

            curPos += 8;

            // Get item name, GetItemNameFromRecord() sets this.Name automatically
            GetItemNameFromRecord(reader, ref curPos);

            // Process item level
            GetLevelFromRecord(reader, ref curPos);

            // Get item icon
            GetIconFromRecord(reader, ref curPos);

            // TODO: Seemingly empty bytes according to struct
            reader.BaseStream.Seek(3, SeekOrigin.Current);
            curPos += 3;

            Price = reader.ReadUInt32();
            curPos += 4;

            SalePrice = reader.ReadUInt32();
            curPos += 4;

            UsedPrice = reader.ReadUInt32();
            curPos += 4;

            // Process IsCash and IsSaleable
            GetMoneyTypeFromRecord(reader, ref curPos);

            // Shop Tag
            byte byteShopTag = reader.ReadByte();
            ReadShopTag(byteShopTag);
            curPos += 1;

            TimeFlag = reader.ReadByte();
            curPos += 1;

            Time = reader.ReadByte();
            curPos += 1;

            Point = reader.ReadUInt32();
            curPos += 4;

            // Get the saleStart and saleEnd values
            ReadSysTime(reader, ref SaleStart, ref curPos);
            ReadSysTime(reader, ref SaleEnd, ref curPos);
        }

        public void LoadCommonProperties_30425(BinaryReader reader, ref long curPos)
        {
            Final = reader.ReadUInt32();

            TypeId = reader.ReadUInt32();
            GetTypeIdValues();

            curPos += 8;

            // Get item name, GetItemNameFromRecord() sets this.Name automatically
            GetItemNameFromRecord(reader, ref curPos);

            // Process item level
            GetLevelFromRecord(reader, ref curPos);

            // Get item icon
            GetIconFromRecord(reader, ref curPos);

            // TODO: Seemingly empty bytes according to struct
            reader.BaseStream.Seek(3, SeekOrigin.Current);
            curPos += 3;

            Price = reader.ReadUInt32();
            curPos += 4;

            SalePrice = reader.ReadUInt32();
            curPos += 4;

            UsedPrice = reader.ReadUInt32();
            curPos += 4;

            // Process IsCash and IsSaleable
            GetMoneyTypeFromRecord(reader, ref curPos);

            // Shop Tag
            byte byteShopTag = reader.ReadByte();
            ReadShopTag(byteShopTag);
            curPos += 1;

            TimeFlag = reader.ReadByte();
            curPos += 1;

            Time = reader.ReadByte();
            curPos += 1;

            Point = reader.ReadUInt32();
            curPos += 4;

            // Unknown values
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            // Get the saleStart and saleEnd values
            ReadSysTime(reader, ref SaleStart, ref curPos);
            ReadSysTime(reader, ref SaleEnd, ref curPos);
        }

        public void LoadCommonProperties_57(BinaryReader reader, ref long curPos)
        {
            Final = reader.ReadUInt32();

            TypeId = reader.ReadUInt32();
            GetTypeIdValues();

            curPos += 8;

            // Get item name, GetItemNameFromRecord() sets this.Name automatically
            GetItemNameFromRecord(reader, ref curPos);

            // Process item level
            GetLevelFromRecord(reader, ref curPos);

            // Get item icon
            GetIconFromRecord(reader, ref curPos);

            // TODO: Seemingly empty bytes according to struct
            reader.BaseStream.Seek(3, SeekOrigin.Current);
            curPos += 3;

            Price = reader.ReadUInt32();
            curPos += 4;

            SalePrice = reader.ReadUInt32();
            curPos += 4;

            UsedPrice = reader.ReadUInt32();
            curPos += 4;

            // Process IsCash and IsSaleable
            GetMoneyTypeFromRecord(reader, ref curPos);

            // Shop Tag
            byte byteShopTag = reader.ReadByte();
            ReadShopTag(byteShopTag);
            curPos += 1;

            TimeFlag = reader.ReadByte();
            curPos += 1;

            Time = reader.ReadByte();
            curPos += 1;

            Point = reader.ReadUInt32();
            curPos += 4;

            // Unknown values
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            // Get the saleStart and saleEnd values
            ReadSysTime(reader, ref SaleStart, ref curPos);
            ReadSysTime(reader, ref SaleEnd, ref curPos);
        }

        public void LoadCommonProperties_52428(BinaryReader reader, ref long curPos)
        {
            Final = reader.ReadUInt32();
            TypeId = reader.ReadUInt32();
            GetTypeIdValues();
            curPos += 8;

            // Get item name
            GetItemNameFromRecord(reader, ref curPos);

            // Process item level
            GetLevelFromRecord(reader, ref curPos);

            // Get item icon
            GetIconFromRecord(reader, ref curPos);

            // TODO: Seemingly empty bytes according to struct
            reader.BaseStream.Seek(3, SeekOrigin.Current);
            curPos += 3;

            Price = reader.ReadUInt32();
            curPos += 4;

            SalePrice = reader.ReadUInt32();
            curPos += 4;

            UsedPrice = reader.ReadUInt32();
            curPos += 4;

            // Process IsCash and IsSaleable
            GetMoneyTypeFromRecord(reader, ref curPos);

            // Shop Tag
            byte byteShopTag = reader.ReadByte();
            ReadShopTag(byteShopTag);
            curPos += 1;

            TimeFlag = reader.ReadByte();
            curPos += 1;

            Time = reader.ReadByte();
            curPos += 1;

            // Get the saleStart and saleEnd values
            ReadSysTime(reader, ref SaleStart, ref curPos);
            ReadSysTime(reader, ref SaleEnd, ref curPos);
        }

        public void LoadCommonProperties_8960(BinaryReader reader, ref long curPos)
        {
            long origPos = curPos;

            Final = reader.ReadUInt32();
            TypeId = reader.ReadUInt32();
            GetTypeIdValues();
            curPos += 8;

            // Get item name
            GetItemNameFromRecord(reader, ref curPos);

            // Process item level
            GetLevelFromRecord(reader, ref curPos);

            // Get item icon
            GetIconFromRecord(reader, ref curPos);

            // TODO: Seemingly empty bytes according to struct
            reader.BaseStream.Seek(3, SeekOrigin.Current);
            curPos += 3;

            Price = reader.ReadUInt32();
            curPos += 4;

            SalePrice = reader.ReadUInt32();
            curPos += 4;

            UsedPrice = reader.ReadUInt32();
            curPos += 4;

            // Following their usual pattern is probably goes like this...
            // 0 0 0 0 | 0 0 0 0
            // `--,--´   `--,--´
            // IsSalea |  IsCash
            GetMoneyTypeFromRecord(reader, ref curPos);

            // Shop Tag
            byte byteShopTag = reader.ReadByte();
            ReadShopTag(byteShopTag);
            curPos += 1;

            TimeFlag = reader.ReadByte();
            curPos += 1;

            Time = reader.ReadByte();
            curPos += 1;

            // 8 unknown bytes
            reader.BaseStream.Seek(8, SeekOrigin.Current);
            curPos += 8;

            // Get the saleStart and saleEnd values
            ReadSysTime(reader, ref SaleStart, ref curPos);
            ReadSysTime(reader, ref SaleEnd, ref curPos);
        }

        public void DateTimeToSysTime(DateTime dTime, ref IffFile._SYSTEMTIME sTime)
        {
            sTime.wYear = short.Parse(dTime.Year.ToString());
            sTime.wSecond = short.Parse(dTime.Second.ToString());
            sTime.wMonth = short.Parse(dTime.Month.ToString());
            sTime.wMinute = short.Parse(dTime.Minute.ToString());
            sTime.wMilliseconds = short.Parse(dTime.Millisecond.ToString());
            sTime.wHour = short.Parse(dTime.Hour.ToString());
            sTime.wDayOfWeek = short.Parse(dTime.DayOfWeek.ToString());
            sTime.wDay = short.Parse(dTime.Day.ToString());
        }

        private void WriteSysTime(BinaryWriter writer, IffFile._SYSTEMTIME time, ref long curPos)
        {
            writer.Write(time.wYear);
            writer.Write(time.wMonth);
            writer.Write(time.wDayOfWeek);
            writer.Write(time.wDay);
            writer.Write(time.wHour);
            writer.Write(time.wMinute);
            writer.Write(time.wSecond);
            writer.Write(time.wMilliseconds);
            curPos += 16;
        }

        private void ReadSysTime(BinaryReader reader, ref IffFile._SYSTEMTIME time, ref long curPos)
        {
            time.wYear = reader.ReadInt16();
            time.wMonth = reader.ReadInt16();
            time.wDayOfWeek = reader.ReadInt16();
            time.wDay = reader.ReadInt16();
            time.wHour = reader.ReadInt16();
            time.wMinute = reader.ReadInt16();
            time.wSecond = reader.ReadInt16();
            time.wMilliseconds = reader.ReadInt16();
            curPos += 16;
        }

        private void WriteShopTag(BinaryWriter writer, ref long curPos)
        {
            BitArray shopTagArray = new BitArray(8, false);

            if (IsInStock)
                shopTagArray.Set(0, true);
            if (IsReserve)
                shopTagArray.Set(1, true);

            if (IsSpecial)
                shopTagArray.Set(3, true);
            if (IsNew)
                shopTagArray.Set(4, true);
            if (IsHot)
                shopTagArray.Set(5, true);

            Byte thisShopTag = ConvertToByte(shopTagArray);

            writer.Write(thisShopTag);
            curPos += 1;
        }

        private void ReadShopTag(byte byteShopTag)
        {
            BitArray shopTagArray = new BitArray(BitConverter.GetBytes(byteShopTag));
            shopTagArray = PadToFullByte(shopTagArray);

            IsInStock = shopTagArray.Get(0);
            IsReserve = shopTagArray.Get(1);

            IsSpecial = shopTagArray.Get(3);
            IsHot = shopTagArray.Get(5);
            IsNew = shopTagArray.Get(4);

            ShopTag = byteShopTag;
        }

        private void WriteLevel(BinaryWriter writer, ref long curPos)
        {
            BitArray levelArray = new BitArray(BitConverter.GetBytes(Level));
            levelArray = PadToFullByte(levelArray);

            if (IsMaximumLevel)
                levelArray.Set(7, true);
            else
                levelArray.Set(7, false);

            Byte thisLevel = ConvertToByte(levelArray);

            writer.Write(thisLevel);
            curPos += 1;
        }

        private void ReadLevel(byte byteLevel)
        {
            BitArray levelArray = new BitArray(BitConverter.GetBytes(byteLevel));
            levelArray = PadToFullByte(levelArray);

            if (levelArray.Get(7))
            {
                // Highest bit indicates whether this is
                // maximum or minimum level, so we need to
                // set it to 0 to get the correct level...
                IsMaximumLevel = true;
                levelArray.Set(7, false);
            }
            else
                IsMaximumLevel = false;

            Level = ConvertToByte(levelArray);
        }
    }
}
