﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca
{
    interface Inetworking
    {
        void startRx();
        void Update_Command(byte[] bytes);
    }
}
