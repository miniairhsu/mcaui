using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mca
{
    class Network_Observable_UDP : Inetworking
    {
        private List<Network_Observer> observerList;
        Thread rxThread;
        public string ipAddr { get; set; }
        public int nPort { get; set; }
        public InfoGlobal adInfo { get; set; }
        public Network_Observable_UDP(string ipAddr, int nPort, InfoGlobal adInfo)
        {
            this.ipAddr = ipAddr;
            this.nPort = nPort;
            this.adInfo = adInfo;
            observerList = new List<Network_Observer>();
        }

        /**
         * @brief  add observer to observers list
         * @param  netObserver 
         * @retval None
         */
        public void addObserver(Network_Observer netObserver)
        {
            Console.WriteLine($"add observer");
            observerList.Add(netObserver);
        }

        /**
        * @brief  remove observer to observers list
        * @param  netObserver 
        * @retval None
        */
        public void removeObserver(Network_Observer netObserver)
        {
            observerList.Remove(netObserver);
        }

        /**
        * @brief  start receiver thread
        * @param  none
        * @retval None
        */
        public void startRx()
        {
            Console.WriteLine($"startRx thread");
            rxThread = new Thread(this.receive);
            rxThread.IsBackground = true;
            rxThread.Start();

        }

        /**
       * @brief  stop receiver thread
       * @param  none
       * @retval None
       */
        public void stopRx()
        {
            rxThread.Abort();
        }

        /**
       * @brief  UDP packet receiver and data broadcast
       * @param  none
       * @retval None
       */
        public void receive()
        {
            // accept 1001 port from client
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this.nPort); 
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            Console.WriteLine($"In RX");
            while (true)
            {
                int recv = newsock.ReceiveFrom(this.adInfo.adaData, ref Remote); // receive packets
                if ( ((this.adInfo.adaData[0] == this.adInfo.ADA_HH) && (this.adInfo.adaData[1] == this.adInfo.ADA_HL)) || ((this.adInfo.adaData[0] == this.adInfo.ADB_HH) && (this.adInfo.adaData[1] == this.adInfo.ADB_HL)) )
                {
                    foreach (var observer in observerList)
                    {
                        observer.Update(this.adInfo);
                    }
                }
            }
        }

        public void Update_Command(byte[] bytes)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(this.ipAddr), this.nPort); //local device port
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.SendTo(bytes, ipep);
            server.Close();
        }
    }
}
