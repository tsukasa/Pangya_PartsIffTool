using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    public class CardRecord : ICloneable
    {
        public enum eCardRareType
        {
            Normal = 0,
            Rare = 1,
            SuperRare = 2,
            Secret = 3,
        }

        private enum eRecordLength
        {
            DEFAULT = 328,
            JAPAN_30312 = 224,
            KOREA_30395 = 196,
        }

        public IffItemCommon Base = new IffItemCommon();

        public eCardRareType RareType;
        public byte RareTypeRaw;

        public string Image = "";
        public string SubIcon = "";
        public string SlotImg = "";
        public string BuffImg = "";

        public UInt16 Power;
        public UInt16 Control;
        public UInt16 Impact;
        public UInt16 Spin;
        public UInt16 Curve;

        public UInt16 Ability;
        public UInt16 AbilityValue;

        public UInt16 UseTime;

        public UInt16 Volume;
        public UInt16 CardIndex;

        public static bool SaveCardFile(string fileName, List<CardRecord> cardList)
        {
            return true;
        }

        public static List<CardRecord> LoadCardFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read), IffFile.FileEncoding(IffFile.IFF_REGION.Default)))
                {
                    List<CardRecord> cardList = new List<CardRecord>();

                    IffFile inIffFile = new IffFile();
                    UInt16 cardsInFile = inIffFile.GetNumberOfRecords(reader);

                    inIffFile.GetIffRegion(reader);

                    inIffFile.JumpToFirstRecord(reader);

                    // Once we know the region, we have to start calling the correct LoadParts()
                    // method for the given magic number.
                    if (inIffFile.CheckMagicNumber(reader))
                    {
                        // We'll be splitting the processing to make it easier to code
                        switch (inIffFile.Region)
                        {
                            // Process "normal" TH files
                            case (IffFile.IFF_REGION.Default):
                                cardList = LoadCards_0(inIffFile, reader, cardsInFile, (int)eRecordLength.DEFAULT);
                                break;
                        }

                        reader.Close();

                        return cardList;
                    }
                }
            }
            return new List<CardRecord>();
        }

        public static List<CardRecord> LoadCards_0(IffFile inIffFile, BinaryReader reader, ushort cardsInFile, int record_length)
        {
            List<CardRecord> cardList = new List<CardRecord>();

            for (int i = 0; i < cardsInFile; i++)
            {
                long recordPos = reader.BaseStream.Position;
                long curPos = reader.BaseStream.Position;
                CardRecord tmpRecord = new CardRecord();

                tmpRecord.Base.LoadCommonProperties(reader, inIffFile.Region, ref curPos);

                tmpRecord.RareTypeRaw = reader.ReadByte();
                curPos += 2;

                tmpRecord.Image = IffCommonMethods.ReadStringOfLength(reader, 40, inIffFile.Region, ref curPos);

                reader.BaseStream.Seek(1, SeekOrigin.Current);
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

                tmpRecord.Ability = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.AbilityValue = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.SubIcon = IffCommonMethods.ReadStringOfLength(reader, 40, inIffFile.Region, ref curPos);
                tmpRecord.SlotImg = IffCommonMethods.ReadStringOfLength(reader, 40, inIffFile.Region, ref curPos);
                tmpRecord.BuffImg = IffCommonMethods.ReadStringOfLength(reader, 40, inIffFile.Region, ref curPos);

                tmpRecord.UseTime = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.Volume = reader.ReadUInt16();
                curPos += 2;

                tmpRecord.CardIndex = reader.ReadUInt16();
                curPos += 2;

                reader.BaseStream.Seek(2, SeekOrigin.Current);

                cardList.Add(tmpRecord);
            }

            return cardList;
        }

        public void GenerateSqlFile(List<CardRecord> cardList, string fileName)
        {

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
