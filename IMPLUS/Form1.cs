using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMPLUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
        }
        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            Array arrayFileName = (Array)e.Data.GetData(DataFormats.FileDrop);

            string strFileName = arrayFileName.GetValue(0).ToString();

            System.IO.StreamReader sr = new System.IO.StreamReader(strFileName, System.Text.Encoding.Default);
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }




        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }


        

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            
        }



        //鼠标拖动
        Point mouseposition;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                mouseposition = new Point(-e.X, -e.Y);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                Point mouseset = Control.MousePosition;
                mouseset.Offset(mouseposition.X, mouseposition.Y);
                Location = mouseset;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        //保存
        
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string mpath=saveFileDialog1.FileName.ToString();
            richTextBox1.SaveFile(mpath, RichTextBoxStreamType.PlainText);
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            string userdesktoppath= Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.Title = "Save";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            saveFileDialog1.InitialDirectory = userdesktoppath;
            saveFileDialog1.ShowDialog();
        }


        




        //打开
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string mpath = openFileDialog1.FileName.ToString();
            richTextBox1.LoadFile(mpath, RichTextBoxStreamType.PlainText);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string userdesktoppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Title = "Open";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "文本文件(*.txt) | *.txt";
            openFileDialog1.InitialDirectory = userdesktoppath;
            openFileDialog1.ShowDialog();
        }
    }
}
