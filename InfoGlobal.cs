using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca
{
    public class InfoGlobal
    {
        public byte ADA_HH = 0x0A;
        public byte ADA_HL = 0x0B;
        public byte ADA_FH = 0x0B;
        public byte ADA_FL = 0x0A;
        public byte[] adaData = new byte[16384];
        public byte[] dabData = new byte[16384];
        public short[] adaDataShort = new short[32768];
        public short[] adbDataShort = new short[32768];

    }
}
