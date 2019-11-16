using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca
{
    class Command_Observable
    {
        private List<Network_Observable_UDP> observerList;
        public Command_Observable()
        {
            observerList = new List<Network_Observable_UDP>();
        }
        /**
        * @brief  add observer to observers list
        * @param  Network_Observable_UDP 
        * @retval None
        */
        public void addUDP_Observer(Network_Observable_UDP udpObserver)
        {
            Console.WriteLine($"add observer");
            observerList.Add(udpObserver);
        }

        /**
       * @brief  remove observer to observers list
       * @param  udpObserver 
       * @retval None
       */
        public void removeUDP_Observer(Network_Observable_UDP udpObserver)
        {
            observerList.Remove(udpObserver);
        }

        /**
       * @brief  send command through network observer
       * @param  bytes data
       * @retval None
       */
        public void send_Command(byte[] bytes)
        {
            foreach (var observer in observerList)
            {
                observer.Update_Command(bytes);
            }
        }
    }
}
