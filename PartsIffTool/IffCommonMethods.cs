using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Google.API.Translate;

namespace PartsIffTool
{
    public class IffCommonMethods
    {
        public static UInt32 GenerateNewTypeId(IffItemCommon itemOnEdit, int iffType, int characterId, int pos, int group, int type, int serial)
        {
            if ((group - 1) < 0)
                group = 0;

            return
            Convert.ToUInt32(((((((iffType) * Math.Pow((2), (26)) + characterId * Math.Pow((2), (18)))
                    + pos * Math.Pow((2), (13)))
                    + group * Math.Pow((2), (11)))
                    + type * Math.Pow((2), (9)))
                    + serial));
        }

        /// <summary>
        /// Sets the _SYSTEMTIME for a given reference to either a
        /// specified DateTime or to NULL.
        /// </summary>
        /// <param name="time">Reference to the _SYSTEMTIME you want to modify.</param>
        /// <param name="dateTime">DateTime containing the date/time to set for "time"</param>
        /// <param name="setDate">Set to True to set the date, set to False to NULL all values.</param>
        public static void SetSystemTimeValue(ref IffFile._SYSTEMTIME time, DateTime dateTime, bool setDate)
        {
            if (setDate)
            {
                time.wYear = (short)dateTime.Year;
                time.wMonth = (short)dateTime.Month;
                time.wDayOfWeek = (short)dateTime.DayOfWeek;
                time.wDay = (short)dateTime.Day;
                time.wHour = (short)dateTime.Hour;
                time.wMinute = (short)dateTime.Minute;
                time.wSecond = (short)dateTime.Second;
                time.wMilliseconds = (short)dateTime.Millisecond;
            }
            else
            {
                time.wYear = 0;
                time.wMonth = 0;
                time.wDayOfWeek = 0;
                time.wDay = 0;
                time.wHour = 0;
                time.wMinute = 0;
                time.wSecond = 0;
                time.wMilliseconds = 0;
            }
        }

        public static string GetTranslatedItemName(string input, uint typeid, string from, string to)
        {
            string resultName = "";

            try
            {
                TranslateClient translateClient = new TranslateClient("http://pangya.tsukasa.eu/");
                resultName = translateClient.Translate(input, from, to);

                // Capitalize each word for good measure
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                resultName = textInfo.ToTitleCase(resultName);
            }
            catch (Exception)
            {
                resultName = "Item " + typeid;
            }

            return resultName;
        }

        public static void WriteStringOfLength(string stringToShorten, int maxLen, Encoding encoding, BinaryWriter writer, ref long curPos)
        {
            int x = stringToShorten.IndexOf((char)0x00);
            string realStringToShorten = string.Empty;
            byte[] stringToWrite = new byte[maxLen];

            // Find the "end" of the text first...
            if (x != -1)
                realStringToShorten = stringToShorten.Substring(0, x);
            else
                realStringToShorten = stringToShorten;

            // Convert the pure text into an array of bytes...
            stringToWrite = encoding.GetBytes(realStringToShorten);

            // Figure out how many bytes we'll have to fill...
            int bytesToFill = (maxLen - stringToWrite.Length);

            // Shorten string after converting it to byteArray if necessary
            if (stringToWrite.Length >= maxLen)
            {
                byte[] resizedString = new byte[maxLen];
                Array.Copy(stringToWrite, 0, resizedString, 0, maxLen);
                stringToWrite = (byte[])resizedString.Clone();
            }

            // Write the string portion we have
            writer.Write(stringToWrite);

            // ...and fill up the rest of the available space with 0x00
            if (bytesToFill > 0)
            {
                string fillZero = new string((char)0x00, bytesToFill);
                byte[] fillZeroBytes = encoding.GetBytes(fillZero);
                writer.Write(fillZeroBytes);
            }

            // Ah yeah, and set curPos...
            curPos += maxLen;
        }

        public static string ReadStringOfLength(BinaryReader reader, int length, IffFile.IFF_REGION region, ref long curPos)
        {
            byte[] byteItemModelInShop = reader.ReadBytes(length);
            string tmpString = IffFile.FileEncoding(region).GetString(byteItemModelInShop);

            curPos += length;

            return IffItemCommon.CleanupStringAfterReading(tmpString);
        }

        public static string GetCleanedUpStringForSQL(string input)
        {
            int propValueEnd = input.IndexOf((char)0x00);
            string propValueClean = "";
            if (propValueEnd > 0)
                propValueClean = input.Substring(0, propValueEnd);
            else
                propValueClean = "";

            propValueClean = propValueClean.Replace("'", "''");
            propValueClean = propValueClean.Replace("`", "");

            return propValueClean;
        }
    }
}
