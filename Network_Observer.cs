using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca
{
    class Network_Observer : Inetwork_Observer<InfoGlobal>
    {
        public delegate void UpdateData(InfoGlobal adData);
        public UpdateData adChanged;

        public Network_Observer()
        {
            adChanged = adDataChanged;
        }

        /**
       * @brief  UDP observer update
       * @param  adData
       * @retval None
       */
        public void Update(InfoGlobal adData)
        { 
            adChanged.Invoke(adData);
            //notify ui
        }

        public void adDataChanged(InfoGlobal adData)
        {
            return;
        }
    }
}
