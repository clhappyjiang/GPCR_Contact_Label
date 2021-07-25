using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowContact
{
    public partial class PDB2FA : Form
    {
        Dictionary<string, string> acid = new Dictionary<string, string>();
        int type = -1;//type = 1 是2fa   type = 2 是2aln

        public PDB2FA(int num)
        {
            InitializeComponent();
            acid.Add("ALA", "A");
            acid.Add("CYS", "C");
            acid.Add("ASP", "D");
            acid.Add("GLU", "E");
            acid.Add("PHE", "F");
            acid.Add("GLY", "G");
            acid.Add("HIS", "H");
            acid.Add("LYS", "K");
            acid.Add("ILE", "I");
            acid.Add("LEU", "L");
            acid.Add("MET", "M");
            acid.Add("ASN", "N");
            acid.Add("PRO", "P");
            acid.Add("GLN", "Q");
            acid.Add("ARG", "R");
            acid.Add("SER", "S");
            acid.Add("THR", "T");
            acid.Add("VAL", "V");
            acid.Add("TYR", "Y");
            acid.Add("TRP", "W");
            acid.Add("ACE", "X");
            acid.Add("YCM", "C");
            type = num;
        }
        List<string> pdblist = new List<string>();
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] rs = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i<rs.Length;i++)
                {

                    if (type == 1 && rs[i].Contains(".pdb"))
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
                    if (type == 2 && rs[i].Contains(".a3m"))
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

        private void PDB2FA_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            SetGridStyle(this.dgv);
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.probar.Visible = false;
            this.labelgif.Visible = false;
            if (type == 1)
            {
                this.Text = "PDB转FA";
                this.label1.Text = "请将需要转换格式的PDB文件拖动到下方框中↓";
            }
            if (type == 2)
            {
                this.Text = "a3m转aln";
                this.label1.Text = "请将需要转换格式的a3m文件拖动到下方框中↓";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pdblist.Clear();
            this.dgv.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.labelpath.Text = path.SelectedPath;
        }
        public void PdbtoFa(string path, string pdbid)
        {
            if (type == 1) // type ==1 是2fa
            {
                List<string> fullContent = new List<string>();//fullContent存全部行内容
                fullContent = FormPublic.GetFlieContentByLine(path, false);
                List<string> pdbcontents = new List<string>();
                string chain = "";
                bool fisrtchain = true;
                List<string> serreslist = new List<string>();//serreslist存SEQRES
                List<string> seqlist = new List<string>();//seqlist存全部序列的3个字母列表,用于计算一级序列

                foreach (var stu in fullContent)//
                {
                    if ("SEQRES" == stu.Substring(0, 6))
                    {
                        serreslist.Add(stu);
                    }
                }
                int SEQ_LENGTH = 0;
                string line2 = serreslist[0].ToString();
                string[] mm23 = Regex.Split(line2, "\\s+", RegexOptions.IgnoreCase);
                chain = mm23[2];
                SEQ_LENGTH = int.Parse(mm23[3]);
                for (int b = 0; b < serreslist.Count; b++)
                {
                    string line = serreslist[b].ToString();
                    string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                    //string[] mm2 = Regex.Split(line, SEQ_LENGTH.ToString(), RegexOptions.IgnoreCase);
                    string[] mm2 = Regex.Split(line, SEQ_LENGTH.ToString(), RegexOptions.IgnoreCase);
                    if (mm[2] == chain)
                    {
                        seqlist.Add(mm2[1]);
                    }
                }
                string tempseq = "";
                //☆☆☆这里开始计算一级序列
                for (int a = 0; a < seqlist.Count; a++)
                {
                    string line = seqlist[a].ToString().Trim();
                    tempseq = tempseq + " " + line;
                    Console.WriteLine(line);
                }
                string[] temp = Regex.Split(tempseq, "\\s+", RegexOptions.IgnoreCase);
                string seq = "";//seq变量存一级序列 。例如：GPGSGPNSDLDVNTDIYSKVLVTAIYLALFVVGTV...
                for (int a = 0; a < temp.Length; a++)
                {
                    if (temp[a].Length == 3)
                    {
                        try
                        {
                            seq = seq + acid[temp[a]];

                        }
                        catch (Exception E)
                        {
                            Console.WriteLine("NOFOUND");
                            Console.WriteLine(temp[a]);
                            seq = seq + "B";
                        }
                    }
                }
                Console.WriteLine(seq);
                Console.WriteLine(seq.Length);
                string text = ">" + pdbid + "\n" + seq.ToUpper().ToString();
                System.IO.File.WriteAllText(this.labelpath.Text + "\\" + pdbid, text);
            }

            if (type == 2) // type ==2 是a3m
            {
                List<string> fullContent = new List<string>();//fullContent存全部行内容
                fullContent = FormPublic.GetFlieContentByLine(path, false);
                List<string> alncontents = new List<string>();
                
                foreach (var stu in fullContent)//
                {
                    if (stu.Length > 1 && !stu.Contains('>'))
                    {
                        alncontents.Add(stu);
                    }
                }
                Name = pdbid.Split('.')[0];
                WriteListToTextFile(alncontents,this.labelpath.Text + "\\" + Name + ".aln");

                //string text = ">" + pdbid + "\n" + seq.ToUpper().ToString();
                //System.IO.File.WriteAllText(this.labelpath.Text + "\\" + pdbid, text);
            }
        }

        //将List转换为TXT文件 

        public void WriteListToTextFile(List<string> list, string txtFile)
        {
            //创建一个文件流，用以写入或者创建一个StreamWriter 
            FileStream fs = new FileStream(txtFile, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Flush();
            // 使用StreamWriter来往文件中写入内容 
            sw.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < list.Count; i++) sw.WriteLine(list[i]);
            //关闭此文件 
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                //*****以下是异步执行的代码*****
                int select_count1 = 0;
                select_count1 = pdblist.Count;
                if (select_count1 == 0)
                {
                    MessageBox.Show("您当前未选中需要转化的序列，请在列表中重新勾选！", "提示");
                    return;
                }
                if (this.labelpath.Text.Length == 0)
                {
                    MessageBox.Show("当前未设置fa文件输出路径，请到点击“设置输出路径”按钮设置！", "提示");
                    return;
                }

                if (MessageBox.Show("是否确认转换列表中的" + select_count1 + "条序列?", "格式转换确认按钮", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //跨线程更新UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        this.label3.Visible = true;
                        this.label4.Visible = true;
                        this.label4.Text = "共计算"+ select_count1.ToString()+"条，正在计算中";
                        this.probar.Maximum = select_count1;
                        this.probar.Value = 0;
                        this.probar.Visible = true;
                        this.labelgif.Visible = true;
                    });
                    this.BeginInvoke(mi);


                    for (int j = 0; j < pdblist.Count;j++)
                    {
                        Console.WriteLine(pdblist[j]);
                        string[] rs = pdblist[j].ToString().Split('\\');
                        string pdbid = rs[rs.Length-1];
                        pdbid = pdbid.Replace("pdb","fa");
                        PdbtoFa(pdblist[j], pdbid);
                        Console.WriteLine(pdbid);
                        //跨线程更新UI
                        MethodInvoker mi3 = new MethodInvoker(() =>
                        {
                            this.probar.Value = j;
                        });
                        this.BeginInvoke(mi3);
                    }
                }

                //跨线程更新UI
                MethodInvoker mi4 = new MethodInvoker(() =>
                {
                    this.label4.Text = "计算完毕！";
                    this.labelgif.Visible = false;
                });
                this.BeginInvoke(mi4);
                //*****以上是异步执行的代码*****
            });
            task.Start();
        }
    }
}
