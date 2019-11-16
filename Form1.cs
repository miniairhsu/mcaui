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
        bool adaPlotOn = false;
        bool adbPlotOn = false;
        Thread adaChartThread;
        string[] adVertical = {"100", "500", "1000", "2500", "5000", "10000", "15000", "20000", "30000", "40000"};
        public Form1()
        {
            InitializeComponent();
            //GUI setup
            this.adaPlot.Legends.Clear();
            this.adbPlot.Legends.Clear();
            this.adaVerticalBox.DataSource = adVertical;

            udpObservable = new Network_Observable_UDP("169.254.154.115", 1111, adInfo);
            Network_Observer udpObserver = new Network_Observer();
            cmdObservable = new Command_Observable();
            cmdObservable.addUDP_Observer(udpObservable);
            udpObserver.adChanged += this.ShowInfo;
            udpObservable.addObserver(udpObserver);
            adaChartThread = new Thread(new ThreadStart(this.RunADAUpdate));
            adaChartThread.IsBackground = true;
            adaChartThread.Start();
            udpObservable.startRx();

        }

        public void ShowInfo(InfoGlobal adData)
        {
            adaLength = (adData.adaData[3] << 8 | adData.adaData[2]);
            adaIndex = (adData.adaData[5] << 8 | adData.adaData[4]);
            adaPkt_size = (adData.adaData[7] << 8 | adData.adaData[6]);
            if ((adData.adaData[0] == adInfo.ADA_HH) && (adData.adaData[1] == adInfo.ADA_HL))
            {
                Buffer.BlockCopy(adData.adaData, 8, adData.adaDataShort, (adaIndex * adaLength * sizeof(short)), (adaLength * sizeof(short)));
            }
            if ((adData.adaData[0] == adInfo.ADB_HH) && (adData.adaData[1] == adInfo.ADB_HL))
            {
                Buffer.BlockCopy(adData.adaData, 8, adData.adbDataShort, (adaIndex * adaLength * sizeof(short)), (adaLength * sizeof(short)));
            }

            if ((adaIndex == adaPkt_size) && (adData.adaData[0] == adInfo.ADA_HH) && (adData.adaData[1] == adInfo.ADA_HL))
            {
                adaPlotOn = true;
            }
            else adaPlotOn = false;

            if ((adaIndex == adaPkt_size) && (adData.adaData[0] == adInfo.ADB_HH) && (adData.adaData[1] == adInfo.ADB_HL))
            {
                adbPlotOn = true;
            }
            else adbPlotOn = false;


        }

        public void RunADAUpdate()
        {
            while (true)
            {
                if ((adaPlot.IsHandleCreated && adaPlotOn == true) || (adbPlot.IsHandleCreated && adbPlotOn == true))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateADAChart(); });
                }
            }
        }

        private void UpdateADAChart()
        {
            if (adaPlotOn == true)
            {
                adaPlot.Series["ADSeries"].Points.Clear();
                adaPlot.ChartAreas[0].AxisX.Maximum = adaLength * adaPkt_size;
                adaPlot.ChartAreas[0].AxisX.Minimum = 0;
                for (int i = 0; i < adaLength * adaPkt_size; i++)
                {
                    adaPlot.Series["ADSeries"].Points.AddY((double)adInfo.adaDataShort[i] / 4);
                }
            }

            if (adbPlotOn == true)
            {
                adbPlot.Series["ADSeries"].Points.Clear();
                adbPlot.ChartAreas[0].AxisX.Maximum = adaLength * adaPkt_size;
                adbPlot.ChartAreas[0].AxisX.Minimum = 0;
                for (int i = 0; i < adaLength * adaPkt_size; i++)
                {
                    adbPlot.Series["ADSeries"].Points.AddY((double)adInfo.adbDataShort[i] / 4);
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
            udpObservable.stopRx();
        }

        private void adaVertical_changed(object sender, EventArgs e)
        {
            adaPlot.ChartAreas[0].AxisY.Maximum = Double.Parse(adaVerticalBox.SelectedValue.ToString());
            adaPlot.ChartAreas[0].AxisY.Minimum = Double.Parse(adaVerticalBox.SelectedValue.ToString()) * -1;
            adbPlot.ChartAreas[0].AxisY.Maximum = Double.Parse(adaVerticalBox.SelectedValue.ToString());
            adbPlot.ChartAreas[0].AxisY.Minimum = Double.Parse(adaVerticalBox.SelectedValue.ToString()) * -1;
        }
    }
}
