using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PartsIffTool
{
    public class IffFile
    {
        /// <summary>
        /// Port of Windows' SYSTEMTIME struct
        /// to be used for SaleStart and SaleEnd
        /// reading/writing.
        /// </summary>
        [Serializable]
        public struct _SYSTEMTIME // 0x10
        {
            public short wYear; // +0x0(0x2)
            public short wMonth; // +0x2(0x2)
            public short wDayOfWeek; // +0x4(0x2)
            public short wDay; // +0x6(0x2)
            public short wHour; // +0x8(0x2)
            public short wMinute; // +0xa(0x2)
            public short wSecond; // +0xc(0x2)
            public short wMilliseconds; // +0xe(0x2)
        };

        /// <summary>
        /// The "Region" becomes important when choosing
        /// a matching parser for a file. Depending on the
        /// region the length of the IffCommon header will
        /// change and some attributes may not be needed.
        /// </summary>
        public enum IFF_REGION
        {
            Default = 0,            // Season 4.9 TH/GB

            Global_30447 = 30447,   // Season 4.5 GB 560 (Skin.iff)
            Global_30087 = 30087,   // Season 5 GB 602
            Global_30425 = 30425,   // Season 5 GB
            Global_57    = 57,      // Season 6 GB Tomahawk

            Japan = 548,            // Season 4 Original
            Japan_52428 = 52428,    // Season 4.5 Update 1
            Japan_8960 = 8960,      // Season 4.5 Update 2
            Japan_30312 = 30312,    // Season 5

            Korea_30395 = 30395,    // Korea Open Tournament
        }

        /// <summary>
        /// The Magic Number indicates the "version"
        /// and "season" of a file.
        /// 
        /// We need to check a file for the existance
        /// of the numbers in the array below to make
        /// sure we can actually parse it correctly.
        /// </summary>
        public UInt16[] lMagicNumber =
        {
            11,                     // Season 4
            12,                     // Season 5
            13,                     // Season 5 JP/Season 6 GB Tomahawk
        };

        /// <summary>
        /// Struct for the common "Tex" properties.
        /// </summary>
        [Serializable]
        public struct sTex
        {
            public string Tex1;
            public string Tex2;
            public string Tex3;
        }

        /// <summary>
        /// Struct for the common "OrgTex" properties.
        /// </summary>
        [Serializable]
        public struct sOrgTex
        {
            public string OrgTex1;
            public string OrgTex2;
            public string OrgTex3;
        }

        #region Header properties
        public UInt16 ObjectsInFile = 0;
        public UInt16 MagicNumber = 0;
        public IFF_REGION Region = IFF_REGION.Default;
        #endregion

        #region Methods
        /// <summary>
        /// Methods serves two purposes:
        /// - Read the Magic Number into the MagicNumber variable.
        /// - Check whether the magic number matches one from the whitelist.
        /// 
        /// The magic number is used to identify IFF versions
        /// and regions. Currently there isn't much use to this
        /// but we should still do it, no?
        /// </summary>
        /// <param name="reader">BinaryReader to get the bytes from.</param>
        /// <returns>True/False depending on whether a valid "Magic Number" was found.</returns>
        public bool CheckMagicNumber(BinaryReader reader)
        {
            // Save the old position, just in case
            long streamPosition = reader.BaseStream.Position;

            reader.BaseStream.Seek(4, SeekOrigin.Begin);
            MagicNumber = reader.ReadUInt16();

            // Restore old position, just in case
            reader.BaseStream.Seek(streamPosition, SeekOrigin.Begin);

            return lMagicNumber.Contains(MagicNumber);
        }

        /// <summary>
        /// Sets the correct encoding for a file depending on the region.
        /// </summary>
        /// <param name="region">The region your encoding should be for.</param>
        /// <returns>Encoding</returns>
        public static Encoding FileEncoding(IFF_REGION region)
        {
            switch (region)
            {
                case IFF_REGION.Default:
                    return Encoding.GetEncoding(874); // Hard to tell which one is right... KR or TH. So let's go with TH.
                case IFF_REGION.Global_30087:
                case IFF_REGION.Global_30447:
                case IFF_REGION.Global_30425:
                case IFF_REGION.Global_57:
                    return Encoding.GetEncoding(949); // Yes, it's KR.
                case IFF_REGION.Japan:
                case IFF_REGION.Japan_52428:
                case IFF_REGION.Japan_8960:
                case IFF_REGION.Japan_30312:
                    return Encoding.GetEncoding(932); // JP encoding
                case IFF_REGION.Korea_30395:
                    return Encoding.GetEncoding(949); // KR encoding
                default:
                    return Encoding.GetEncoding(949); // Game is from Korea, so KR as default
            }
        }

        /// <summary>
        /// Gets the IFF region for a file.
        /// 
        /// Please keep in mind that region informations tend to
        /// vary and Ntreev adds new values on a regular basis.
        /// </summary>
        /// <param name="reader">BinaryReader to get the bytes from.</param>
        public void GetIffRegion(BinaryReader reader)
        {
            long oldPos = reader.BaseStream.Position;

            reader.BaseStream.Seek(2, SeekOrigin.Begin);

            UInt16 regionNum = reader.ReadUInt16();

            switch (regionNum)
            {
                // -- TH and GB --
                case 0:
                    Region = IFF_REGION.Default;
                    break;

                case 30447:
                    Region = IFF_REGION.Global_30447;
                    break;
                case 30087:
                    Region = IFF_REGION.Global_30087;
                    break;
                case 30425:
                    Region = IFF_REGION.Global_30425;
                    break;
                case 53: // Season 6 Tomahawk
                case 57: // Season 6 Tomahawk
                    Region = IFF_REGION.Global_57;
                    break;

                // -- JP --
                case 52428: // New CC CC format
                case 548:
                    Region = IFF_REGION.Japan;
                    break;
                case 8960: // Longer pre-amble
                    Region = IFF_REGION.Japan_8960;
                    break;
                case 30312: // S5 Japan initial
                    Region = IFF_REGION.Japan_30312;
                    break;

                // -- KR --
                case 30395: // Based on PAK 614
                    Region = IFF_REGION.Korea_30395;
                    break;

                // -- Everything else :p --
                default:
                    Region = IFF_REGION.Default;
                    break;
            }
        }

        /// <summary>
        /// Reads the number of records from the IFF header.
        /// </summary>
        /// <param name="reader">BinaryReader to get the bytes from.</param>
        /// <returns>Number of records in file according to the header.</returns>
        public UInt16 GetNumberOfRecords(BinaryReader reader)
        {
            // Save the old position, just in case
            long streamPosition = reader.BaseStream.Position;

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            UInt16 numberOfRecords = reader.ReadUInt16();

            // Restore old position, just in case
            reader.BaseStream.Seek(streamPosition, SeekOrigin.Begin);
            return numberOfRecords;
        }

        /// <summary>
        /// Calculates the length of a single record by
        /// dividing (filesize - 8) / number of items in file.
        /// </summary>
        /// <param name="reader">BinaryReader to use for this.</param>
        /// <returns>Length of a single record.</returns>
        public long GetRecordLength(BinaryReader reader)
        {
            UInt16 numberOfRecords = GetNumberOfRecords(reader);

            long fileLength = reader.BaseStream.Length;
            long fileLengthWithoutHeaders = fileLength - 8;
            return fileLengthWithoutHeaders / numberOfRecords;
        }

        /// <summary>
        /// Jumps to the first record in a BinaryReader
        /// </summary>
        /// <param name="reader">BinaryReader to jump around in.</param>
        public void JumpToFirstRecord(BinaryReader reader)
        {
            reader.BaseStream.Seek(8, SeekOrigin.Begin);
        }

        /// <summary>
        /// Jumps to the first record in a BinaryWriter.
        /// 
        /// Note: The file has to be stubbed for this to work!
        /// </summary>
        /// <param name="writer">BinaryWriter to jump around in.</param>
        public void JumpToFirstRecord(BinaryWriter writer)
        {
            writer.BaseStream.Seek(8, SeekOrigin.Begin);
        }

        /// <summary>
        /// Writes the standard IFF file header to the BinaryWriter.
        /// </summary>
        /// <param name="writer">BinaryWriter to write the bytes to.</param>
        public void WriteIffFileHeader(BinaryWriter writer)
        {
            writer.Seek(0, SeekOrigin.Begin);
            writer.Write(ObjectsInFile);

            // For multi-region support
            WriteIffRegion(writer);

            // TODO: A better way to find out which magic number to write...
            switch (Region)
            {
                // Season 4.9: Magic Number 11
                case (IFF_REGION.Default):
                case (IFF_REGION.Japan):
                case (IFF_REGION.Japan_52428):
                case (IFF_REGION.Japan_8960):
                    writer.Write(lMagicNumber[0]);
                    break;
                // Season 5: Magic Number 12
                case (IFF_REGION.Korea_30395):
                case (IFF_REGION.Japan_30312):
                case (IFF_REGION.Global_30087):
                    writer.Write(lMagicNumber[1]);
                    break;
                // Unknown: Probably Season 4 - Magic: 11
                default:
                    writer.Write(lMagicNumber[0]);
                    break;
            }
            writer.Seek(2, SeekOrigin.Current);
        }

        /// <summary>
        /// Writes the IFF region to an output BinaryWriter.
        /// </summary>
        /// <param name="writer">BinaryWriter to write the bytes to.</param>
        public void WriteIffRegion(BinaryWriter writer)
        {
            writer.Write((UInt16)Region);
        }

        /// <summary>
        /// Creates empty dummy records to "gloss over".
        /// </summary>
        /// <param name="writer">BinaryWriter to write the bytes to.</param>
        /// <param name="recordsetLength">Length of a single record.</param>
        /// <param name="itemCount">Number of records to stub.</param>
        public void StubRecords(BinaryWriter writer, int recordsetLength, int itemCount)
        {
            // Fill the file with 0x00 data...
            byte[] emptyRecord = new byte[recordsetLength];
            for (int i = 0; i < recordsetLength; i++)
            {
                emptyRecord[i] = 0x00;
            }

            for (int i = 0; i < itemCount; i++)
            {
                writer.BaseStream.Write(emptyRecord, 0, recordsetLength);
            }

            // Reset to the first record...
            writer.Seek(8, SeekOrigin.Begin);
        }
        #endregion
    }
}
