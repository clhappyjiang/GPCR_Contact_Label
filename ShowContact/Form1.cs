using ShowContact.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;

namespace ShowContact
{
    public partial class Form1 : CCSkinMain
    {
        Dictionary<string, string> acid = new Dictionary<string, string>();
        public Form1()
        {
            acid.Add("ALA","A"); 
            acid.Add("CYS","C");
            acid.Add("ASP","D");
            acid.Add("GLU","E");
            acid.Add("PHE","F");
            acid.Add("GLY","G");
            acid.Add("HIS","H");
            acid.Add("LYS","K");
            acid.Add("ILE","I");
            acid.Add("LEU","L");
            acid.Add("MET","M");
            acid.Add("ASN","N");
            acid.Add("PRO","P");
            acid.Add("GLN","Q");
            acid.Add("ARG","R");
            acid.Add("SER","S");
            acid.Add("THR","T");
            acid.Add("VAL","V");
            acid.Add("TYR","Y");
            acid.Add("TRP","W");
            acid.Add("ACE","X");
            acid.Add("YCM","C");
            InitializeComponent();
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.probar.Visible = false;
            for (int i = 0; i < this.dgv1.Rows.Count; i++)
            {
                this.dgv1.Rows[i].Cells["check"].Value = false;
            }


        }
        /// <summary>
        /// 设置grid分格
        /// </summary>
        /// <param name="grd"></param>
        public static void SetGridStyle(SkinDataGridView grd)
        {
            grd.AllowUserToAddRows = false;
            grd.AllowUserToResizeRows = false;
            grd.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(231, 235, 247);
            grd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grd.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            grd.EnableHeadersVisualStyles = false;
            grd.GridColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
            //grd.ReadOnly = true;
            //grd.RowsDefaultCellStyle.BackColor = Color.FromArgb(239, 243, 255);
            grd.AutoGenerateColumns = false;
            grd.TitleBackColorBegin = Color.FromArgb(168, 222, 223);
            grd.TitleBackColorEnd = Color.FromArgb(168, 222, 223);
            grd.SkinGridColor = Color.FromArgb(51, 204, 255);
            //grd.TitleBackColorEnd = Color.FromArgb(249, 226, 174);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.op_path.Text = "请到功能菜单中设置PDB文件所在路径";
            this.pdb_path.Text = "请到功能菜单中设置接触文件输出路径";
            this.op_path.ForeColor = Color.Red;
            this.pdb_path.ForeColor = Color.Red;
            SetGridStyle(this.dgv1);
            ScanFiles(@"C:\Users\jts\Desktop\新建文件夹");
            this.op_path.Text = @"C:\Users\jts\Desktop\CSV";
            this.pdb_path.Text = @"C:\Users\jts\Desktop\新建文件夹";
        }

        private void 选择PDB文件路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.pdb_path.Text = path.SelectedPath;
            this.dgv1.Rows.Clear();
            ScanFiles(path.SelectedPath);
        }

        private void 设置接触矩阵输出路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.op_path.Text = path.SelectedPath;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupBox1.BackColor);
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.Blue, 10, 1);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2);
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www1.rcsb.org/");
            }
            catch (Exception EEe)
            {
                MessageBox.Show("您的电脑浏览器似乎有些问题，那就手动打开网址吧：https://www1.rcsb.org/","提示");
            }
        }

        /// <summary>
        /// 扫描指定路径下文件
        /// </summary>
        public void ScanFiles(string SrcDirectory)
        {
            try
            {
                var Path = SrcDirectory;//文件夹路径
                System.IO.DirectoryInfo dir = new DirectoryInfo(Path);

                FileInfo[] fiList = dir.GetFiles();
                DataTable dt = new DataTable();
                foreach (var item in fiList)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    foreach (DataGridViewColumn c in this.dgv1.Columns)
                    {
                        dgvr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                    }
                    var FilePath = item.FullName; //路径
                    var FileName = item.Name;     //文件名加后缀
                    dgvr.Cells[1].Value = FileName;
                    dgvr.Cells[2].Value = FilePath;
                    this.dgv1.Rows.Add(dgvr);
                }
                this.count.Text = "序列数量：" + fiList.Length.ToString() + "条";
            }
            catch (Exception e)
            {
                MessageBox.Show("当前设置路径有误！请重新设置！","提示");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                for (int i = 0; i < this.dgv1.Rows.Count; i++)
                {
                    this.dgv1.Rows[i].Cells["check"].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < this.dgv1.Rows.Count; i++)
                {
                    this.dgv1.Rows[i].Cells["check"].Value = 0;
                }
            }
        }
        /// <summary> 
        /// 计算两个点之间的距离
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="z0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <returns></returns>
        public static double Calculate(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            //Console.WriteLine("x1:"+x1 + ",y1: " + y1 + ",z1: "+z1);
            //Console.WriteLine("x2:"+x2+ ",y2 " + y2 + ",z2: " + z2);
           
            double xdiff = x1 - x2;
            double ydiff = y1 - y2;
            double zdiff = z1 - z2;
            //Console.WriteLine("xdiff:" + xdiff);
            //Console.WriteLine("ydiff:" + ydiff);
            //Console.WriteLine("zdiff:" + zdiff);
            //Console.WriteLine(Math.Sqrt(xdiff * xdiff + ydiff * ydiff + zdiff * zdiff));

            return Math.Sqrt(Math.Pow(xdiff, 2)   + Math.Pow(ydiff, 2) + Math.Pow(zdiff, 2));
        }

        /// <summary>
        /// 保存CSV文件
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="fileName">文件全路径</param>
        /// <param name="msg">要写入的信息</param>
        private void SaveCSV(string path, string fileName, string msg)
        {
            string Folder = path; // 文件夹路径
            if (!System.IO.Directory.Exists(Folder)) // 判断文件夹是否存在
                System.IO.Directory.CreateDirectory(Folder); // 创建文件夹
            using (TextWriter fw = new StreamWriter(path+fileName, true)) // 以有序字符写入
            {
                fw.WriteLine(msg); // 写入数据
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.Columns[e.ColumnIndex].Name == "showcontact")
                {
                    string filepath = this.op_path.Text + '\\' + dgv1.Rows[e.RowIndex].Cells["name1"].Value.ToString().Split('.')[0] + ".csv";
                    if (System.IO.File.Exists(filepath))
                    {
                        ShowPic frm = new ShowPic(filepath);
                        frm.Show();
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception E)
            {

            }
            
        }

        public int[] GetSubStrCountInStr(String str, String substr, int StartPos)
        {
            int foundPos = -1;
            int count = 0;
            List<int> foundItems = new List<int>();
            do
            {
                foundPos = str.IndexOf(substr, StartPos);
                if (foundPos > -1)
                {
                    StartPos = foundPos + 1;
                    count++;
                    foundItems.Add(foundPos);
                }
            } while (foundPos > -1 && StartPos < str.Length);

            return ((int[])foundItems.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //
        public string FormatAcidAndXYZ(string line)
        {
            //情况1
            // 0        1   2   3  4  5        6      7        8
            //ATOM      2  CA  ASN A  52     -36.547 -40.605    48.269  1.00 92.56           C  
            //情况2
            // 0        1   2   3    4            5        6      7        8
            //ATOM   1827  CA  LEU A1242      -5.340 102.645 333.104  1.00112.55           C
            //情况3
            // 0        1   2      3  4            5        6      7        8
            //ATOM   1287  CE2ATRP A 161     -36.521   0.432  29.392  0.50 61.31           C  
            string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
            #region
            string acid ="";
            string x = "";
            string y = "";
            string z = "";
            string ALA = "ALA";
            string CYS = "CYS";
            string ASP = "ASP";
            string GLU = "GLU";
            string PHE = "PHE";
            string GLY = "GLY";
            string HIS = "HIS";
            string LYS = "LYS";
            string ILE = "ILE";
            string LEU = "LEU";
            string MET = "MET";
            string ASN = "ASN";
            string PRO = "PRO";
            string GLN = "GLN";
            string ARG = "ARG";
            string SER = "SER";
            string THR = "THR";
            string VAL = "VAL";
            string TYR = "TYR";
            string TRP = "TRP";
            int xyzcount = 1;
            if (line.Contains("ALA"))
            {
                acid = "ALA";
            }
            if (line.Contains(CYS))
            {
                acid = CYS;
            }
            if (line.Contains(ASP))
            {
                acid = ASP;
            }
            if (line.Contains(GLU))
            {
                acid = GLU;
            }
            if (line.Contains(PHE))
            {
                acid = PHE;
            }
            if (line.Contains(GLY))
            {
                acid = GLY;
            }
            if (line.Contains(HIS))
            {
                acid = HIS;
            }
            if (line.Contains(LYS))
            {
                acid = LYS;
            }
            if (line.Contains(ILE))
            {
                acid = ILE;
            }
            if (line.Contains(LEU))
            {
                acid = LEU;
            }
            if (line.Contains(MET))
            {
                acid = MET;
            }
            if (line.Contains(ASN))
            {
                acid = ASN;
            }
            if (line.Contains(PRO))
            {
                acid = PRO;
            }
            if (line.Contains(GLN))
            {
                acid = GLN;
            }
            if (line.Contains(ARG))
            {
                acid = ARG;
            }
            if (line.Contains(SER))
            {
                acid = SER;
            }
            if (line.Contains(THR))
            {
                acid = THR;
            }
            if (line.Contains(VAL))
            {
                acid = VAL;
            }
            if (line.Contains(TYR))
            {
                acid = TYR;
            }
            if (line.Contains(TRP))
            {
                acid = TRP;
            }
            #endregion
            //-34.522  -3.498-101.586  1.00 79.28           O  
            //-34.522-3.498-101.586  1.00 79.28           O  
            //-34.522-3.498 101.586  1.00 79.28           O  
            List<string> xyz = new List<string>();
            int dotcount = 0;
            for (int q = 0;q<mm.Length;q++)
            {
                if (mm[q].Contains('.'))
                {
                    dotcount = dotcount + 1;
                }
            }
            if (dotcount == 5)//这一行是标准的 x y z
            {
                for (int q = 0; q < mm.Length; q++)
                {
                    if (mm[q].Contains('.'))
                    {
                        xyz.Add(mm[q]);
                    }
                }
                string acid3_1 = mm[3];
                return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
            }
            else//这一行是不标准的 x y z
            {
                List<string> tempxyz = new List<string>();
                for (int q = 0; q < mm.Length; q++)
                {
                    if (mm[q].Contains('.'))
                    {
                        tempxyz.Add(mm[q]);
                    }
                }
                int count1 =  CalauteCharShowCount_For('.',tempxyz[0].ToString());
                int count2 =  CalauteCharShowCount_For('.',tempxyz[1].ToString());
                int count3 =  CalauteCharShowCount_For('.',tempxyz[2].ToString());
                if (count1 == 1 && count2 == 1 && count3 == 1)
                {
                    xyz.Add(tempxyz[0].ToString());
                    xyz.Add(tempxyz[1].ToString());
                    xyz.Add(tempxyz[2].ToString());
                    Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                    string acid3_1 = mm[3];
                    return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                }
                else if (count1 == 1 && count2 == 2 )
                {
                    xyz.Add(tempxyz[0].ToString());
                    string temp = tempxyz[1];
                    if(temp.Substring(0,1) == "-")
                    {
                        //-34.522  -3.498-101.586  1.00 79.28           O  
                        xyz.Add("-" + tempxyz[1].ToString().Split('-')[1]);
                        xyz.Add("-" + tempxyz[1].ToString().Split('-')[2]);
                        Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                        string acid3_1 = mm[3];
                        return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                    }
                    else
                    {
                        //-34.522  3.498-101.586  1.00 79.28           O  
                        xyz.Add(tempxyz[1].ToString().Split('-')[0]);
                        xyz.Add("-" + tempxyz[1].ToString().Split('-')[1]);
                        Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                        string acid3_1 = mm[3];
                        return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                    }
                   
                }
                else if (count1 == 2 && count2 == 1)
                {
                    string temp = tempxyz[0];
                    if (temp.Substring(0, 1) == "-")
                    {
                        //-34.522-3.498 101.586  1.00 79.28           O  
                        xyz.Add("-" + tempxyz[0].ToString().Split('-')[1]);
                        xyz.Add("-" + tempxyz[0].ToString().Split('-')[2]);
                        xyz.Add(tempxyz[1].ToString());
                        Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                        string acid3_1 = mm[3];
                        return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                    }
                    else
                    {
                        //34.522-3.498 101.586  1.00 79.28           O  
                        xyz.Add("-" + tempxyz[0].ToString().Split('-')[0]);
                        xyz.Add("-" + tempxyz[0].ToString().Split('-')[1]);
                        xyz.Add(tempxyz[1].ToString());
                        Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                        string acid3_1 = mm[3];
                        return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                    }
                  
                }
                else if (count1 == 3 )
                {
                    //-34.522-3.498-101.586  1.00 79.28           O  
                    xyz.Add(tempxyz[0].ToString().Split('-')[0]);
                    xyz.Add("-" + tempxyz[0].ToString().Split('-')[1]);
                    Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                    xyz.Add("-" + tempxyz[0].ToString().Split('-')[2]);
                    string acid3_1 = mm[3];
                    return acid + "," + xyz[0] + "," + xyz[1] + "," + xyz[2];
                }
                else
                {
                    Console.WriteLine("line:"+ line);
                    Console.WriteLine(xyz[0] + ",     " + xyz[1] + ",     " + xyz[2]);
                    string acid3_1 = mm[3];
                    return acid + "," + 0.ToString() + "," + 0.ToString() + "," + 0.ToString();
                }
                
            }
        }
        /// <summary>
        /// 使用For循环统计文本字符串中某一字符出现的次数
        /// </summary>
        /// <param name="c">指定字符</param>
        /// <param name="text">文本字符串</param>
        /// <returns></returns>
        public int CalauteCharShowCount_For(char c, string text)
        {
            int count = 0; //定义一个计数器 
            //循环统计
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == c)
                    count++;
            }
            return count;
        }

        private void 功能菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 序列格式转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pDB2FAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDB2FA form = new PDB2FA(1);
            form.ShowDialog();
        }

        private void a3M转ALNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDB2FA form = new PDB2FA(2);
            form.ShowDialog();
        }

        private void 选择PDB文件所在路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.pdb_path.Text = path.SelectedPath;
            this.dgv1.Rows.Clear();
            ScanFiles(path.SelectedPath);
        }

        private void 设置接触矩阵输出路径ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.op_path.Text = path.SelectedPath;
        }

        private void pDB转FAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDB2FA form = new PDB2FA(1);
            form.ShowDialog();
        }

        private void a3M转ALNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PDB2FA form = new PDB2FA(2);
            form.ShowDialog();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string outerror = "";
            Task task = new Task(() =>
            {
                //*****以下是异步执行的代码*****
                int select_count1 = 0;
                List<int> selectList = new List<int>();

                for (int iRow = 0; iRow < this.dgv1.RowCount; ++iRow)
                {
                    if (Convert.ToBoolean(dgv1.Rows[iRow].Cells["check"].Value))
                    {
                        selectList.Add(iRow);
                        Console.Write(iRow.ToString() + ",");
                    }
                }
                select_count1 = selectList.Count;
                if (select_count1 == 0)
                {
                    MessageBox.Show("您当前未选中需要计算的序列，请在列表中重新勾选！", "提示");
                    return;
                }
                if (this.op_path.Text == "请到功能菜单中设置PDB文件所在路径")
                {
                    MessageBox.Show("当前未设置PDB文件所在路径，请到功能菜单中设置PDB文件所在路径！", "提示");
                    return;
                }
                if (this.pdb_path.Text == "请到功能菜单中设置接触文件输出路径")
                {
                    MessageBox.Show("当前未设置接触矩阵输出路径，请到功能菜单中设置接触文件输出路径！", "提示");
                    return;
                }

                if (MessageBox.Show("是否确认计算选中的" + select_count1 + "条序列?", "计算接触确认按钮", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    #region
                    //跨线程更新UI
                    MethodInvoker mi = new MethodInvoker(() =>
                    {
                        this.label3.Visible = true;
                        this.label4.Visible = true;
                        this.probar.Value = 0;
                        this.probar.Visible = true;
                        this.labelgif.Visible = true;
                    });
                    this.BeginInvoke(mi);

                    int select_count = 0;

                    Console.WriteLine();
                    select_count = selectList.Count;
                    //跨线程更新UI
                    MethodInvoker mi2 = new MethodInvoker(() =>
                    {
                        this.label4.Text = "共计算" + select_count + "条序列,正在计算中";
                        this.probar.Maximum = select_count;
                    });
                    this.BeginInvoke(mi2);
                    string error = "下列PDB数据因为格式问题计算失败，请联系我们或自己另行计算。\n";
                    #region 接触计算过程
                    for (int i = 0; i < selectList.Count; i++)
                    {
                        if (this.dgv1.Rows[selectList[i]].Cells["check"].Value != null)//计算接触
                        {
                            string name = "";
                            //try
                            //{
                            name = this.dgv1.Rows[selectList[i]].Cells["name1"].Value.ToString();
                            string path = this.dgv1.Rows[selectList[i]].Cells["path1"].Value.ToString();
                            string contents = FormPublic.ReadLog(path);
                            List<string> fullContent = new List<string>();
                            fullContent = FormPublic.GetFlieContentByLine(path, false);
                            List<string> pdbcontents = new List<string>();
                            string chain = "";//chain是第一次出现SEQRES的链
                            bool fisrtchain = true;
                            List<string> serreslist = new List<string>();//serreslist存SEQRES
                            bool ismodel = false;//是否拥有多个构想
                            foreach (var stu in fullContent)//这里开始计算标签的第一步 1.过滤掉无用行
                            {
                                if ("MODEL" == stu.Substring(0, 5))
                                {
                                    ismodel = true;
                                    string line = stu.ToString();
                                }
                                if ("SEQRES" == stu.Substring(0, 6))
                                {
                                    serreslist.Add(stu);
                                }
                            }
                            string lineseqres = serreslist[0].ToString();
                            string[] mm233 = Regex.Split(lineseqres, "\\s+", RegexOptions.IgnoreCase);
                            chain = mm233[2];
                            //★★★★★★★★★★★★★★★★★★★★★★★★★★★★拥有多构想模式的接触计算★★★★★★★★★★★★★★★★★★★★★★★★★★★★
                            #region
                            if (ismodel)//ismodel 为true 说明拥有多种构象
                            {
                                //这里只截取第一个构象的内容
                                int model_index = -1;
                                int endmodel_index = -1;
                                int count = 0;
                                List<string> firstmodellist = new List<string>();
                                //☆☆☆这里开始计算标签的第一步 1.过滤掉无用行
                                foreach (var stu in fullContent)
                                {
                                    if (model_index < 0)
                                    {
                                        if ("MODEL" == stu.Substring(0, 5))//ENDMDL
                                        {
                                            model_index = count + 1;
                                        }
                                    }
                                    if (endmodel_index < 0)
                                    {
                                        if ("ENDMDL" == stu.Substring(0, 6))//ENDMDL
                                        {
                                            endmodel_index = count;
                                        }
                                    }
                                    count++;
                                }
                                firstmodellist = fullContent.GetRange(0, endmodel_index - model_index);


                                #region 这里是多种构想模式

                                int SEQ_LENGTH = 0;

                                List<string> allpdb = new List<string>();//allpdb 只保存用于计算的CA原子行数；fullContent是整个PDB文件
                                List<string> seqlist = new List<string>();//seqlist存全部序列的3个字母列表,用于计算一级序列
                                //☆☆☆这里开始计算标签的第一步 1.读取序列信息、序列长度和PDB坐标存到allpdb中
                                for (int b = 0; b < firstmodellist.Count; b++)
                                {
                                    if (b + 2 < firstmodellist.Count)
                                    {
                                        string line = firstmodellist[b].ToString();
                                        string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                        string atomname = mm[0];

                                        string next_line = firstmodellist[b + 1].ToString();
                                        string[] nextmm = Regex.Split(next_line, "\\s+", RegexOptions.IgnoreCase);
                                        string nextatomname = nextmm[0];

                                        string next_next_line = firstmodellist[b + 2].ToString();
                                        string[] nextnextmm = Regex.Split(next_next_line, "\\s+", RegexOptions.IgnoreCase);
                                        string nextnextatomname = nextnextmm[0];
                                        if (mm[0] == "SEQRES" && mm[1] == "1" && mm[2] == chain)
                                        {
                                            SEQ_LENGTH = int.Parse(mm[3].ToString());
                                        }
                                        if (mm[0] == "SEQRES" && mm[2] == chain)
                                        {
                                            string line2 = firstmodellist[b].ToString();
                                            string[] mm2 = Regex.Split(line, SEQ_LENGTH.ToString(), RegexOptions.IgnoreCase);
                                            seqlist.Add(mm2[1]);
                                        }

                                        if ((atomname == "ATOM" && nextatomname == "ATOM") || (atomname == "ATOM" && nextatomname == "ANISOU"))
                                        {
                                            allpdb.Add(line);
                                        }
                                        if ((atomname == "ATOM" && nextatomname == "TER") || (atomname == "ATOM" && nextatomname == "ANISOU" && nextnextatomname == "TER"))
                                        {
                                            allpdb.Add(line);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        string line = firstmodellist[b].ToString();
                                        string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                        string atomname = mm[0];
                                        if (atomname == "ATOM")
                                        {
                                            allpdb.Add(line);
                                        }
                                    }
                                }
                                Console.WriteLine("SEQ_LENGTH:" + SEQ_LENGTH.ToString());
                                Console.WriteLine("allpdb:" + allpdb.Count);
                                //☆☆☆这里开始计算标签的第二步 1.将序列信息转换成一级序列 存到变量seq中
                                string tempseq = "";
                                //☆☆☆这里开始计算一级序列
                                for (int a = 0; a < seqlist.Count; a++)
                                {
                                    string line = seqlist[a].ToString().Trim();
                                    tempseq = tempseq + " " + line;
                                    Console.WriteLine(line);
                                }
                                Console.WriteLine("tempseq:");
                                Console.WriteLine(tempseq);
                                string[] temp = Regex.Split(tempseq, "\\s+", RegexOptions.IgnoreCase);
                                string seq = "";//seq变量存一级序列 。例如：GPGSGPNSDLDVNTDIYSKVLVTAIYLALFVVGTV...
                                for (int a = 0; a < temp.Length; a++)
                                {
                                    if (temp[a].Length != 0)
                                    {
                                        seq = seq + acid[temp[a]];
                                    }
                                }
                                Console.WriteLine(seq);
                                Console.WriteLine(seq.Length);
                                //☆☆☆这里开始计算标签的第三步 把所有包含CA原子的氨基酸全部取出来，放到calist中。
                                List<string> calist = new List<string>();
                                for (int a = 0; a < allpdb.Count; a++)
                                {
                                    string line = allpdb[a].ToString();
                                    string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                    string atomname = mm[2];
                                    if (atomname == "CA")
                                    {
                                        calist.Add(line);
                                        Console.WriteLine(line);
                                    }
                                }
                                Console.WriteLine("calist:" + calist.Count);
                                int[,] m = new int[SEQ_LENGTH, SEQ_LENGTH];//m是接触矩阵
                                string[,] n = new string[SEQ_LENGTH, SEQ_LENGTH];//n是坐标矩阵
                                                                                 // //☆☆☆这里开始计算标签的第四步 遍历calist确定每一个氨基酸的位置
                                for (int c = 0; c < calist.Count; c++)
                                {
                                    if (c <= 10)//比后8个    目标氨基酸---后8个
                                    {
                                        #region
                                        string x = "", y = "", z = "";
                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c + 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c + 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c + 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c + 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c + 5].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c + 6].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c + 7].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];

                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        string seq_temp = acid[acid3_1] + acid[acid3_2] + acid[acid3_3] + acid[acid3_4] + acid[acid3_5] + acid[acid3_6] + acid[acid3_7] + acid[acid3_8];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0], pos[0]] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }

                                        #endregion
                                    }
                                    if (10 < c && c <= calist.Count - 10)//比对前后各5个     前5个---目标氨基酸---后5个
                                    {
                                        #region
                                        string x = "", y = "", z = "";

                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c - 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c - 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c - 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c - 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c + 1].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c + 2].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c + 3].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];

                                        string line9 = calist[c + 4].ToString();
                                        string result9 = FormatAcidAndXYZ(line9);
                                        string[] acidxyz9 = result9.Split(',');
                                        string acid3_9 = acidxyz9[0];

                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        acid3_9 = acid3_9.Substring(acid3_9.Length - 3);
                                        string seq_temp = acid[acid3_5] + acid[acid3_4] + acid[acid3_3] + acid[acid3_2] + acid[acid3_1] + acid[acid3_6] + acid[acid3_7] + acid[acid3_8] + acid[acid3_9];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0] + 4, pos[0] + 4] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }

                                        #endregion
                                    }
                                    if (c > calist.Count - 10)//比对前8个     前8个---目标氨基酸
                                    {
                                        #region
                                        string x = "", y = "", z = "";

                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c - 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c - 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c - 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c - 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c - 5].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c - 6].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c - 7].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];
                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        string seq_temp = acid[acid3_8] + acid[acid3_7] + acid[acid3_6] + acid[acid3_5] + acid[acid3_4] + acid[acid3_3] + acid[acid3_2] + acid[acid3_1];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0] + 7, pos[0] + 7] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }
                                        #endregion
                                    }
                                }
                                Console.WriteLine(n.ToString());
                                Console.WriteLine(n.ToString());
                                // ☆☆☆这里开始计算标签的第五步 遍历对角线的坐标矩阵。来计算接触矩阵m
                                List<string> duijiaoxian = new List<string>();
                                for (int k = 0; k < SEQ_LENGTH; k++)
                                {
                                    duijiaoxian.Add(n[k, k]);
                                }
                                for (int k = 0; k < duijiaoxian.Count; k++)
                                {
                                    for (int h = 0; h < duijiaoxian.Count; h++)
                                    {
                                        Console.WriteLine("k={0},h={1}, item={2}", k, h, duijiaoxian[k]);
                                        if (duijiaoxian[k] != null && duijiaoxian[h] != null && duijiaoxian[k].Contains(',') && duijiaoxian[h].Contains(','))
                                        {
                                            if (k == h)
                                            {
                                                m[k, h] = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("k={0},h={1}, item={2}", k, h, duijiaoxian[k]);

                                                string x1 = duijiaoxian[k].ToString().Split(',')[0].Trim();
                                                string y1 = duijiaoxian[k].ToString().Split(',')[1].Trim();
                                                string z1 = duijiaoxian[k].ToString().Split(',')[2].Trim();

                                                string x2 = duijiaoxian[h].ToString().Split(',')[0].Trim();
                                                string y2 = duijiaoxian[h].ToString().Split(',')[1].Trim();
                                                string z2 = duijiaoxian[h].ToString().Split(',')[2].Trim();
                                                double dis = Form1.Calculate(double.Parse(x1), double.Parse(y1), double.Parse(z1), double.Parse(x2), double.Parse(y2), double.Parse(z2));
                                                if (dis < 8)
                                                {
                                                    m[k, h] = 1;
                                                }
                                                else
                                                {
                                                    m[k, h] = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            m[k, h] = 0;
                                        }
                                    }
                                }
                                Matrix contacts_matirx = new Matrix(m);
                                Console.WriteLine(contacts_matirx.Cols);
                                Console.WriteLine(contacts_matirx.Rows);
                                // ☆☆☆这里开始计算标签的第六步 写入csv文件
                                SaveCSV(this.op_path.Text + '\\', name.ToUpper().ToString().Split('.')[0] + ".csv", contacts_matirx.ToString());
                                #endregion

                            }
                            #endregion
                            //★★★★★★★★★★★★★★★★★★★★★★★★★★★★拥有单个构想模式的接触计算★★★★★★★★★★★★★★★★★★★★★★★★★★★★
                            if (!ismodel)//这里是只有一种构想模式
                            {
                                #region 这里是只有一种构想模式

                                int SEQ_LENGTH = 0;

                                List<string> allpdb = new List<string>();//allpdb 只保存用于计算的CA原子行数；fullContent是整个PDB文件
                                List<string> seqlist = new List<string>();//seqlist存全部序列的3个字母列表,用于计算一级序列
                                //☆☆☆这里开始计算标签的第一步 1.读取序列信息、序列长度和PDB坐标存到allpdb中
                                for (int b = 0; b < fullContent.Count; b++)
                                {
                                    if (b + 1 < fullContent.Count)
                                    {
                                        string line = fullContent[b].ToString();
                                        string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                        string atomname = mm[0];
                                        string next_line = fullContent[b + 1].ToString();
                                        string[] nextmm = Regex.Split(next_line, "\\s+", RegexOptions.IgnoreCase);
                                        string nextatomname = nextmm[0];

                                        string next_next_line = fullContent[b + 2].ToString();
                                        string[] nextnextmm = Regex.Split(next_next_line, "\\s+", RegexOptions.IgnoreCase);
                                        string nextnextatomname = nextnextmm[0];
                                        if (mm[0] == "SEQRES" && mm[1] == "1" && mm[2] == chain)
                                        {
                                            SEQ_LENGTH = int.Parse(mm[3].ToString());
                                        }
                                        if (mm[0] == "SEQRES" && mm[2] == chain)
                                        {
                                            string line2 = fullContent[b].ToString();
                                            string[] mm2 = Regex.Split(line, SEQ_LENGTH.ToString(), RegexOptions.IgnoreCase);
                                            seqlist.Add(mm2[1]);
                                        }

                                        if ((atomname == "ATOM" && nextatomname == "ATOM") || (atomname == "ATOM" && nextatomname == "ANISOU"))
                                        {
                                            allpdb.Add(line);
                                        }
                                        if ((atomname == "ATOM" && nextatomname == "TER") || (atomname == "ATOM" && nextatomname == "ANISOU" && nextnextatomname == "TER"))
                                        {
                                            allpdb.Add(line);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        string line = fullContent[b].ToString();
                                        string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                        string atomname = mm[0];
                                        if (atomname == "ATOM")
                                        {
                                            allpdb.Add(line);
                                        }
                                    }
                                }
                                Console.WriteLine("SEQ_LENGTH:" + SEQ_LENGTH.ToString());
                                Console.WriteLine("allpdb:" + allpdb.Count);
                                //☆☆☆这里开始计算标签的第二步 1.将序列信息转换成一级序列 存到变量seq中
                                string tempseq = "";
                                //☆☆☆这里开始计算一级序列
                                for (int a = 0; a < seqlist.Count; a++)
                                {
                                    string line = seqlist[a].ToString().Trim();
                                    tempseq = tempseq + " " + line;
                                    Console.WriteLine(line);
                                }
                                Console.WriteLine("tempseq:");
                                Console.WriteLine(tempseq);
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
                                            seq = seq + "B";
                                        }
                                    }
                                }
                                Console.WriteLine(seq);
                                Console.WriteLine(seq.Length);
                                //☆☆☆这里开始计算标签的第三步 把所有包含CA原子的氨基酸全部取出来，放到calist中。
                                List<string> calist = new List<string>();
                                for (int a = 0; a < allpdb.Count; a++)
                                {
                                    string line = allpdb[a].ToString();
                                    string[] mm = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                                    string atomname = mm[2];
                                    if (atomname == "CA")
                                    {
                                        calist.Add(line);
                                        Console.WriteLine(line);
                                    }
                                }
                                Console.WriteLine("calist:" + calist.Count);
                                int[,] m = new int[SEQ_LENGTH, SEQ_LENGTH];//m是接触矩阵
                                string[,] n = new string[SEQ_LENGTH, SEQ_LENGTH];//n是坐标矩阵
                                // //☆☆☆这里开始计算标签的第四步 遍历calist确定每一个氨基酸的位置
                                for (int c = 0; c < calist.Count; c++)
                                {
                                    if (c <= 10)//比后8个    目标氨基酸---后8个
                                    {
                                        #region
                                        string x = "", y = "", z = "";
                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c + 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c + 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c + 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c + 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c + 5].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c + 6].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c + 7].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];

                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        string seq_temp = acid[acid3_1] + acid[acid3_2] + acid[acid3_3] + acid[acid3_4] + acid[acid3_5] + acid[acid3_6] + acid[acid3_7] + acid[acid3_8];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0], pos[0]] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }

                                        #endregion
                                    }
                                    if (10 < c && c <= calist.Count - 10)//比对前后各5个     前5个---目标氨基酸---后5个
                                    {
                                        #region
                                        string x = "", y = "", z = "";

                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c - 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c - 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c - 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c - 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c + 1].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c + 2].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c + 3].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];

                                        string line9 = calist[c + 4].ToString();
                                        string result9 = FormatAcidAndXYZ(line9);
                                        string[] acidxyz9 = result9.Split(',');
                                        string acid3_9 = acidxyz9[0];

                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        acid3_9 = acid3_9.Substring(acid3_9.Length - 3);
                                        string seq_temp = acid[acid3_5] + acid[acid3_4] + acid[acid3_3] + acid[acid3_2] + acid[acid3_1] + acid[acid3_6] + acid[acid3_7] + acid[acid3_8] + acid[acid3_9];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0] + 4, pos[0] + 4] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }

                                        #endregion
                                    }
                                    if (c > calist.Count - 10)//比对前8个     前8个---目标氨基酸
                                    {
                                        #region
                                        string x = "", y = "", z = "";

                                        string line1 = calist[c].ToString();
                                        string result = FormatAcidAndXYZ(line1);
                                        string[] acidxyz1 = result.Split(',');
                                        string acid3_1 = acidxyz1[0];
                                        x = acidxyz1[1];
                                        y = acidxyz1[2];
                                        z = acidxyz1[3];

                                        string line2 = calist[c - 1].ToString();
                                        string result2 = FormatAcidAndXYZ(line2);
                                        string[] acidxyz2 = result2.Split(',');
                                        string acid3_2 = acidxyz2[0];

                                        string line3 = calist[c - 2].ToString();
                                        string result3 = FormatAcidAndXYZ(line3);
                                        string[] acidxyz3 = result3.Split(',');
                                        string acid3_3 = acidxyz3[0];

                                        string line4 = calist[c - 3].ToString();
                                        string result4 = FormatAcidAndXYZ(line4);
                                        string[] acidxyz4 = result4.Split(',');
                                        string acid3_4 = acidxyz4[0];

                                        string line5 = calist[c - 4].ToString();
                                        string result5 = FormatAcidAndXYZ(line5);
                                        string[] acidxyz5 = result5.Split(',');
                                        string acid3_5 = acidxyz5[0];

                                        string line6 = calist[c - 5].ToString();
                                        string result6 = FormatAcidAndXYZ(line6);
                                        string[] acidxyz6 = result6.Split(',');
                                        string acid3_6 = acidxyz6[0];

                                        string line7 = calist[c - 6].ToString();
                                        string result7 = FormatAcidAndXYZ(line7);
                                        string[] acidxyz7 = result7.Split(',');
                                        string acid3_7 = acidxyz7[0];

                                        string line8 = calist[c - 7].ToString();
                                        string result8 = FormatAcidAndXYZ(line8);
                                        string[] acidxyz8 = result8.Split(',');
                                        string acid3_8 = acidxyz8[0];
                                        acid3_1 = acid3_1.Substring(acid3_1.Length - 3);
                                        acid3_2 = acid3_2.Substring(acid3_2.Length - 3);
                                        acid3_3 = acid3_3.Substring(acid3_3.Length - 3);
                                        acid3_4 = acid3_4.Substring(acid3_4.Length - 3);
                                        acid3_5 = acid3_5.Substring(acid3_5.Length - 3);
                                        acid3_6 = acid3_6.Substring(acid3_6.Length - 3);
                                        acid3_7 = acid3_7.Substring(acid3_7.Length - 3);
                                        acid3_8 = acid3_8.Substring(acid3_8.Length - 3);
                                        string seq_temp = acid[acid3_8] + acid[acid3_7] + acid[acid3_6] + acid[acid3_5] + acid[acid3_4] + acid[acid3_3] + acid[acid3_2] + acid[acid3_1];
                                        //匹配第一次出现的位置，写入坐标矩阵。
                                        int[] pos = GetSubStrCountInStr(seq, seq_temp, 0);
                                        if (pos.Length != 0)
                                        {
                                            n[pos[0] + 7, pos[0] + 7] = x + "," + y + "," + z;
                                        }
                                        else
                                        {
                                            n[c, c] = "E";
                                        }
                                        #endregion
                                    }
                                }
                                Console.WriteLine(n.ToString());
                                // ☆☆☆这里开始计算标签的第五步 遍历对角线的坐标矩阵。来计算接触矩阵m
                                List<string> duijiaoxian = new List<string>();
                                for (int k = 0; k < SEQ_LENGTH; k++)
                                {
                                    duijiaoxian.Add(n[k, k]);
                                }
                                for (int k = 0; k < duijiaoxian.Count; k++)
                                {
                                    for (int h = 0; h < duijiaoxian.Count; h++)
                                    {
                                        if (duijiaoxian[k] != null && duijiaoxian[h] != null && duijiaoxian[k].Contains(',') && duijiaoxian[h].Contains(','))
                                        {
                                            if (k == h)
                                            {
                                                m[k, h] = 0;
                                            }
                                            else
                                            {
                                                string x1 = duijiaoxian[k].ToString().Split(',')[0].Trim();
                                                string y1 = duijiaoxian[k].ToString().Split(',')[1].Trim();
                                                string z1 = duijiaoxian[k].ToString().Split(',')[2].Trim();

                                                string x2 = duijiaoxian[h].ToString().Split(',')[0].Trim();
                                                string y2 = duijiaoxian[h].ToString().Split(',')[1].Trim();
                                                string z2 = duijiaoxian[h].ToString().Split(',')[2].Trim();
                                                double dis = Form1.Calculate(double.Parse(x1), double.Parse(y1), double.Parse(z1), double.Parse(x2), double.Parse(y2), double.Parse(z2));
                                                if (dis < 8)
                                                {
                                                    m[k, h] = 1;
                                                }
                                                else
                                                {
                                                    m[k, h] = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            m[k, h] = 0;
                                        }
                                    }
                                }
                                Matrix contacts_matirx = new Matrix(m);
                                Console.WriteLine(contacts_matirx.Cols);
                                Console.WriteLine(contacts_matirx.Rows);
                                // ☆☆☆这里开始计算标签的第六步 写入csv文件
                                SaveCSV(this.op_path.Text + '\\', name.ToUpper().ToString().Split('.')[0] + ".csv", contacts_matirx.ToString());
                                #endregion
                            }
                            //跨线程更新UI
                            MethodInvoker mi3 = new MethodInvoker(() =>
                            {
                                this.probar.Value = i;
                            });
                            this.BeginInvoke(mi3);
                            //}
                            //catch (Exception ee)
                            //{
                            //    error = error + name + ",";
                            //    outerror = error;
                            //    Console.WriteLine(error);
                            //    Console.WriteLine(ee.Message);
                            //    Console.WriteLine(ee.StackTrace);
                            //}
                        }
                    }
                    #endregion
                    #endregion
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
            Console.WriteLine("outerror");
            Console.WriteLine(outerror);
        }

        private void aln格式对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ALN格式化 form = new ALN格式化();
            form.ShowDialog();
        }
    }
}

