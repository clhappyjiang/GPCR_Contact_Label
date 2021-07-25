using ShowContact.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowContact
{
    public partial class ShowPic : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ShowPic(String path)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            Graphics dc = CreateGraphics();
            Show();
            Pen MediumOrchidPen = new Pen(Color.MediumOrchid, 1);
            Pen GoldPen = new Pen(Color.Gold, 1);
            CsvStreamReader reader = new CsvStreamReader(path);
            int col = reader.ColCount;
            int row = reader.RowCount;
            //this.Size = new Size(col*3, col * 3);
            this.Text = "序列长度为：" + col.ToString();
            Console.WriteLine(col + "," + row);
            for (int k = 1; k <= col; k++)
            {
                for (int q = 1; q <= col; q++)
                {
                    if (reader[k, q].Trim() == "1")
                    {
                        dc.DrawRectangle(GoldPen, (k) * 1, (q) * 1, 1, 1);
                    }
                    else
                    {
                        dc.DrawRectangle(MediumOrchidPen, (k) * 1, (q) * 1, 1, 1);
                    }
                }
            }
              
        }

        private void ShowPic_Load(object sender, EventArgs e)
        {
        }
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Panel PnlImage;
    }
}
