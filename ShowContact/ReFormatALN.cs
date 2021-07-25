using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowContact
{
    public partial class ALN格式化 : Form
    {
        public ALN格式化()
        {
            InitializeComponent();
        }
        List<string> pdblist = new List<string>();
        /// <summary>
        /// 设置grid分格
        /// </summary>
        /// <param name="grd"></param>
        public static void SetGridStyle(DataGridView grd)
        {
            grd.AllowUserToAddRows = false;
            grd.AllowUserToResizeRows = false;
            grd.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 235, 247);
            grd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grd.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            grd.EnableHeadersVisualStyles = false;
            grd.GridColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
            //grd.ReadOnly = true;
            grd.RowsDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 255);
            grd.AutoGenerateColumns = false;

        }

        private void ReFormatALN_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            SetGridStyle(this.dgv);
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.probar.Visible = false;
            this.labelgif.Visible = false;
          
            this.Text = "ALN格式对齐";
            this.label1.Text = "请将需要格式对齐的ALN文件拖动到下方框中↓";
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.labelpath.Text = path.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pdblist.Clear();
            this.dgv.Rows.Clear();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] rs = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < rs.Length; i++)
                {

                    if ( rs[i].Contains(".aln"))
                    {
                        pdblist.Add(rs[i]);
                        DataGridViewRow dgvr = new DataGridViewRow();
                        foreach (DataGridViewColumn c in this.dgv.Columns)
                        {
                            dgvr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                        }
                        var FilePath = rs[i].ToString();
                        dgvr.Cells[0].Value = FilePath;
                        this.dgv.Rows.Add(dgvr);
                    }
                  
                }
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            //只允许文件拖放
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
