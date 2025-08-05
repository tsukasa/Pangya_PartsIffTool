using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PartsIffTool
{
    public class ProgramConfiguration
    {
        private const string CONFIGURATION_FILE = "PartIffTool.Configuration.xml";

        public string SystemDsn = "Pangya_S4_TH";
        public string DsnUsername = "sa";
        public string DsnPassword = "Password";

        public List<string> RecentNicks = new List<string>();

        public string ItemEncyclopediaApiUrl = "http://pyp.tsukasa.eu/encyclopedia/api/";
        public string ItemEncyclopediaApiUsername = "";
        public string ItemEncyclopediaApiPassword = "";

        public string PangyaUSunpackedPath = "";
        public string PangyaTHunpackedPath = "";
        public string PangyaJPunpackedPath = "";
        public string PangyaKRunpackedPath = "";
        public string PangyaNewPakPath = "";

        public ProgramConfiguration()
        {
            SystemDsn = "Pangya_S4_TH";
            DsnUsername = "sa";
            DsnPassword = "Password";

            RecentNicks = new List<string>();
        }

        public static void SerializeConfiguration(ProgramConfiguration databaseConfiguration)
        {
            XmlSerializer objSerializer = new XmlSerializer(typeof(ProgramConfiguration));
            using (TextWriter objTxtWriter = new StreamWriter(CONFIGURATION_FILE))
            {
                objSerializer.Serialize(objTxtWriter, databaseConfiguration);
                objTxtWriter.Close();
                objTxtWriter.Dispose();
            }
        }

        public static ProgramConfiguration DeserializeConfiguration()
        {
            if (!File.Exists(CONFIGURATION_FILE))
            {
                return new ProgramConfiguration();
            }
            else
            {
                ProgramConfiguration databaseConfiguration;
                XmlSerializer objSerializer = new XmlSerializer(typeof(ProgramConfiguration));
                using (TextReader objTxtReader = new StreamReader(CONFIGURATION_FILE))
                {
                    databaseConfiguration = objSerializer.Deserialize(objTxtReader) as ProgramConfiguration;
                    objTxtReader.Close();
                    objTxtReader.Dispose();
                }
                return databaseConfiguration;
            }
        }
    }
}
