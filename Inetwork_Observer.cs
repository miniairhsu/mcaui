using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca
{
    interface Inetwork_Observer<T>
    {
        void Update(T updateData);
        void UpdateB(T updateData);
    }
}
