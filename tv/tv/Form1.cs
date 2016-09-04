using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace tv
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        int ayar1 = 0;
        public Form1()
        {
            InitializeComponent();
            
            uint CurrVol = 0;
  
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
       
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
         
           ayar1 = CalcVol / (ushort.MaxValue / 10);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        void ses()
        {
              int NewVolume = ((ushort.MaxValue / 10) * ayar1);
                
                uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
             
                waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
                

            
          
          
        }
        int kac = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible=false;
            webBrowser1.ScriptErrorsSuppressed = true;
            serialPort1.PortName = File.ReadAllText("comport.txt");
            serialPort1.Open();
            timer1.Start();
            int BrowserVer, RegVal;

       
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

          
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

        
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
            Key.Close();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            webBrowser1 .Navigate("http://www.hdcanlitvizle.org/embed/show-tv-1.php");
        }

        long t1 = 2160019894; // Kumandanın tuşları  bu t1,t2 v.s  kumandadaki sayı tuşları
        long t2 = 2160052534;
        long t3 = 2160014284;
        long t4 = 2160030094;
        long t5 = 2160062734;
        long t6 = 2160006124;
        long t7 = 2160021934;
        long t8 = 2160054574;
        long t9 = 2160010204;
        long t0 = 2160058654;

        long ses1 = 2160001534;
        long ses2 = 2160034174;//ses tuşları
        long kanal1 = 2160042334; //kanal  yukarı aşağı tuşu fakat boş bu bir işlem yapmadım buna
        long kanal2 = 2160026014;
        long ok = 2160030604;
        //Yunus emre düşmez-  iletişim: ydmez6@gmail.com - facebook.com/yvnu5
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
        
            string serialdengelen = "";
            serialdengelen = serialPort1.ReadLine();
           
            if (long.Parse(serialdengelen) == ok)
            {
               
                if (kac == 0)
                {
                    kac = 1;

                }
                else
                {
                    kac = 0;
                }
            }
            if (long.Parse(serialdengelen) == t1)
            {
                webBrowser1.Navigate(lsbkanallist.Items[1].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t2)
            {
                webBrowser1.Navigate(lsbkanallist.Items[2].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t3)
            {
                webBrowser1.Navigate(lsbkanallist.Items[3].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t4)
            {
                webBrowser1.Navigate(lsbkanallist.Items[4].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t5)
            {
                webBrowser1.Navigate(lsbkanallist.Items[5].ToString());
                tv = 1;

            }
            if (long.Parse(serialdengelen) == t6)
            {
                webBrowser1.Navigate(lsbkanallist.Items[6].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t7)
            {
                webBrowser1.Navigate(lsbkanallist.Items[7].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t8)
            {
                webBrowser1.Navigate(lsbkanallist.Items[8].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t9)
            {
                webBrowser1.Navigate(lsbkanallist.Items[9].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == t0)
            {
                webBrowser1.Navigate(lsbkanallist.Items[0].ToString());
                tv = 1;
            }
            if (long.Parse(serialdengelen) == ses1)
            {
                if (ayar1 >= 9)
                {
                    ayar1 = 9;
                }
                ayar1 += 1;
                ses();
              
            }
            if (long.Parse(serialdengelen) == ses2)
            {
                if (ayar1 <= 0)
                {
                    ayar1 = 0;
                }
                ayar1 -= 1;
                ses();
             
            }

            
            
        }
        
        private void lsbkanallist_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            tv = 0;
        }
        int tv = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (tv==1)
            {
                label1.Visible = true;
            }
            else if (tv==0)
            {
                label1.Visible = false;
            }
            if (kac==0)
            {
                groupBox1 .Visible = false;
            }
            else if (kac==1)
            {
                groupBox1 .Visible = true;
            }
        }
    }
}
