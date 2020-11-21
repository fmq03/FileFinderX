using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace FileFinderX
{
    public partial class Fsearch : Form
    {
        Thread thr;
        public delegate void WTcallback(string str);
        
        public Fsearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dgs=new FolderBrowserDialog();
            dgs.RootFolder = Environment.SpecialFolder.MyComputer;
            dgs.Description = "请你选择要扫描的路径";
            dgs.ShowDialog();
            TXBpath.Text = dgs.SelectedPath;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                thr = new Thread(new ParameterizedThreadStart(NMSearch));
                thr.Start(TXBpath.Text);

            }else if(radioButton2.Checked )
            {
                thr = new Thread(new ParameterizedThreadStart(PCSearch));
            }
            else if (radioButton3.Checked)
            {
                thr = new Thread(new ParameterizedThreadStart(BKSearch));
            }
        }
        public void NMSearch(object path)
        {
            WTcallback callstatus = showpath;
            string str = path as string;
            foreach (string kstr in Directory.GetFiles(str))
            {
                Invoke(callstatus, kstr);
                TextWriter ss;
                StringWriter s = new StringWriter();
                
                   
            }
            foreach (string kstr in Directory.GetDirectories(str))
            {
                Invoke(callstatus ,kstr);
                NMSearch(kstr);
            }

        }
        public static void PCSearch(object path)
        {
            string str = path as string;

        }
        public static void BKSearch(object path)
        {
            string str = path as string;
            
        }

        private void Fsearch_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }
        public  void showstatus(string info)
        {
           BLstatus.Text = info;
        }
        public  void showpath(string path)
        {
            BLpath.Text = path;
        }
    }
}
