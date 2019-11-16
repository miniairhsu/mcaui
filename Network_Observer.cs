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
        public delegate void UpdateDataB(InfoGlobal adData);
        public UpdateDataB adbChanged;

        public Network_Observer()
        {
            adChanged = adDataChanged;
            adbChanged = adbDataChanged;
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

        public void UpdateB(InfoGlobal adData)
        {
            adbChanged.Invoke(adData);
        }

        public void adDataChanged(InfoGlobal adData)
        {
            return;
        }
        
        public void adbDataChanged(InfoGlobal adData)
        {
            return;
        }
    }
}
