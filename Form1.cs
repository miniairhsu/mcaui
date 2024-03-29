﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mca
{
    public partial class Form1 : Form
    {
        InfoGlobal adInfo = new InfoGlobal();
        Network_Observable_UDP udpObservable;
        Command_Observable cmdObservable;
        int adaIndex = 0;
        int adaPkt_size = 1;
        int adaLength = 1000;
        int adbIndex = 0;
        int adbPkt_size = 1;
        int adbLength = 1000;
        bool adaPlotOn = false;
        bool adbPlotOn = false;
        Thread adaChartThread;
        //Thread adbChartThread;
        string[] adVertical = {"100", "500", "1000", "2500", "5000", "10000", "15000", "20000", "30000", "40000"};
        public Form1()
        {
            InitializeComponent();
            //GUI setup
            this.adaPlot.Legends.Clear();
            this.adaVerticalBox.DataSource = adVertical;

            udpObservable = new Network_Observable_UDP("169.254.154.115", 1111, adInfo);
            Network_Observer udpObserver = new Network_Observer();
            cmdObservable = new Command_Observable();
            cmdObservable.addUDP_Observer(udpObservable);
            udpObserver.adChanged = this.ShowInfo;
            udpObserver.adbChanged = this.ShowInfoB;
            udpObservable.addObserver(udpObserver);
            adaChartThread = new Thread(new ThreadStart(this.RunADAUpdate));
            adaChartThread.IsBackground = true;
            adaChartThread.Start();
            //adbChartThread = new Thread(new ThreadStart(this.RunADBUpdate));
            //adbChartThread.IsBackground = true;
            //adbChartThread.Start();
            udpObservable.startRx();

        }

        public void ShowInfo(InfoGlobal adData)
        {
            adaLength = (adData.adData[3] << 8 | adData.adData[2]);
            adaIndex = (adData.adData[5] << 8 | adData.adData[4]);
            adaPkt_size = (adData.adData[7] << 8 | adData.adData[6]);
            //Console.WriteLine("ada index {0:D}", adbIndex);
            //Console.WriteLine("ada size {0:D}", adbPkt_size);
            //if ((adData.adaData[0] == this.adInfo.ADA_HH) && (adData.adaData[1] == this.adInfo.ADA_HL))
            //{
            Buffer.BlockCopy(adData.adData, 8, adData.adaDataShort, (adaIndex * adaLength * sizeof(short)), (adaLength * sizeof(short)));
            //}
            if (adaIndex == adaPkt_size)
            {
                adaPlotOn = true;
            }
            else adaPlotOn = false;

            /*if ((adData.adaData[0] == this.adInfo.ADB_HH) && (adData.adaData[1] == this.adInfo.ADB_HL))
            {
                Buffer.BlockCopy(adData.adaData, 8, adData.adbDataShort, (adaIndex * adaLength * sizeof(short)), (adaLength * sizeof(short)));
            }
            if ((adaIndex == adaPkt_size) && (adData.adaData[0] == this.adInfo.ADB_HH) && (adData.adaData[1] == this.adInfo.ADB_HL))
            {
                adbPlotOn = true;
            }
            else adbPlotOn = false;*/
        }

        public void ShowInfoB(InfoGlobal adData)
        {
            adbLength = (adData.adData[3] << 8 | adData.adData[2]);
            adbIndex = (adData.adData[5] << 8 | adData.adData[4]);
            adbPkt_size = (adData.adData[7] << 8 | adData.adData[6]);
            //Console.WriteLine("adb index {0:D}", adbIndex);
            //Console.WriteLine("adb size {0:D}", adbPkt_size);
            Buffer.BlockCopy(adData.adData, 8, adData.adbDataShort, (adbIndex * adbLength * sizeof(short)), (adbLength * sizeof(short)));
            if (adbIndex == adbPkt_size)
            {
                adbPlotOn = true;
            }
            else adbPlotOn = false;
        }

        public void RunADAUpdate()
        {
            while (true)
            {
                if ((adaPlot.IsHandleCreated && (adaPlotOn == true)))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateADAChart(); });
                }
                else if((adaPlot.IsHandleCreated && (adbPlotOn == true)))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateADAChart(); });
                }
            }
        }

        /*public void RunADBUpdate()
        {
            while (true)
            {
                if ((adbPlot.IsHandleCreated && (adbPlotOn == true)))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateADBChart(); });
                }
            }
        }

        private void UpdateADBChart()
        {
            adbPlot.Series["ADBSeries"].Points.Clear();
            adbPlot.ChartAreas[0].AxisX.Maximum = adbLength * adbPkt_size;
            adbPlot.ChartAreas[0].AxisX.Minimum = 0;
            for (int i = 0; i < adbLength * adbPkt_size; i++)
            {
                adbPlot.Series["ADBSeries"].Points.AddY((double)adInfo.adbDataShort[i] / 4);
            }
        }*/

        private void UpdateADAChart()
        {
            if ( adaPlotOn == true )
            {
                adaPlot.Series["ADSeries"].Points.Clear();
                adaPlot.ChartAreas[0].AxisX.Maximum = adaLength * adaPkt_size;
                adaPlot.ChartAreas[0].AxisX.Minimum = 0;
                for (int i = 0; i < adaLength * adaPkt_size; i++)
                {
                    adaPlot.Series["ADSeries"].Points.AddY((double)adInfo.adaDataShort[i] / 4);
                }
            }else if ( adbPlotOn == true )
            {
                adaPlot.Series["ADBSeries"].Points.Clear();
                adaPlot.ChartAreas[1].AxisX.Maximum = adbLength * adbPkt_size;
                adaPlot.ChartAreas[1].AxisX.Minimum = 0;
                for (int i = 0; i < adbLength * adbPkt_size; i++)
                {
                    adaPlot.Series["ADBSeries"].Points.AddY((double)adInfo.adbDataShort[i] / 4);
                }
            }
           
        }

        private void sendButton_MouseClick(object sender, MouseEventArgs e)
        {
            cmdObservable.send_Command(Encoding.ASCII.GetBytes(commandBox.Text));
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            
            adaChartThread.Abort();
            //adbChartThread.Abort();
            udpObservable.stopRx();
        }

        private void adaVertical_changed(object sender, EventArgs e)
        {
            adaPlot.ChartAreas[0].AxisY.Maximum = Double.Parse(adaVerticalBox.SelectedValue.ToString());
            adaPlot.ChartAreas[0].AxisY.Minimum = Double.Parse(adaVerticalBox.SelectedValue.ToString()) * -1;
            adaPlot.ChartAreas[1].AxisY.Maximum = Double.Parse(adaVerticalBox.SelectedValue.ToString());
            adaPlot.ChartAreas[1].AxisY.Minimum = Double.Parse(adaVerticalBox.SelectedValue.ToString()) * -1;
        }
    }
}
