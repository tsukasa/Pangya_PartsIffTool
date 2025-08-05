using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PartsIffTool
{
    public class FurnitureRecord : ICloneable
    {
        public IffItemCommon Base = new IffItemCommon();
        public string Model = "";

        public uint Num = 0;

        public uint IsOwn = 0;
        public uint IsMove = 0;
        public uint IsFunction = 0;

        public uint Etc = 0;

        public float PosX = 0;
        public float PosY = 0;
        public float PosZ = 0;
        public float PosR = 0;

        public IffFile.sTex Tex;
        public IffFile.sOrgTex OrgTex;

        public UInt16 Power = 0;
        public UInt16 Control = 0;
        public UInt16 Impact = 0;
        public UInt16 Spin = 0;
        public UInt16 Curve = 0;

        public UInt16 UseTime = 0;

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
