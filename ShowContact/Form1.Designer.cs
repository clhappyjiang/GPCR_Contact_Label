namespace ShowContact
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pdb_path = new System.Windows.Forms.Label();
            this.op_path = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.count = new System.Windows.Forms.Label();
            this.probar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.dgv1 = new CCWin.SkinControl.SkinDataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.path1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showcontact = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelgif = new System.Windows.Forms.Label();
            this.skinMenuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
            this.残基接触菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择PDB文件所在路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置接触矩阵输出路径ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.序列格式转换ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pDB转FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a3M转ALNToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aln格式对齐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.使用教程ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.联系我们ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.skinMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(65, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前PDB文件所在路径:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前接触文件输出路径:";
            // 
            // pdb_path
            // 
            this.pdb_path.AutoSize = true;
            this.pdb_path.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pdb_path.ForeColor = System.Drawing.Color.DarkCyan;
            this.pdb_path.Location = new System.Drawing.Point(280, 19);
            this.pdb_path.Name = "pdb_path";
            this.pdb_path.Size = new System.Drawing.Size(209, 19);
            this.pdb_path.TabIndex = 4;
            this.pdb_path.Text = "当前PDB文件所在路径:";
            // 
            // op_path
            // 
            this.op_path.AutoSize = true;
            this.op_path.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.op_path.ForeColor = System.Drawing.Color.DarkCyan;
            this.op_path.Location = new System.Drawing.Point(280, 48);
            this.op_path.Name = "op_path";
            this.op_path.Size = new System.Drawing.Size(209, 19);
            this.op_path.TabIndex = 5;
            this.op_path.Text = "当前PDB文件所在路径:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.pdb_path);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.op_path);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(9, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(841, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径设置";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(671, 614);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(179, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "PDB数据库网站连接（点击跳转）";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(21, 151);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.count.ForeColor = System.Drawing.Color.Blue;
            this.count.Location = new System.Drawing.Point(75, 151);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(0, 14);
            this.count.TabIndex = 10;
            // 
            // probar
            // 
            this.probar.Location = new System.Drawing.Point(127, 613);
            this.probar.Name = "probar";
            this.probar.Size = new System.Drawing.Size(129, 18);
            this.probar.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(56, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "计算进度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(262, 615);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "共计算";
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(173)))), ((int)(((byte)(14)))));
            this.skinButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(173)))), ((int)(((byte)(14)))));
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.Location = new System.Drawing.Point(760, 137);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Radius = 10;
            this.skinButton1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton1.Size = new System.Drawing.Size(83, 31);
            this.skinButton1.TabIndex = 16;
            this.skinButton1.Text = "计算接触";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ColumnFont = null;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.name1,
            this.path1,
            this.showcontact});
            this.dgv1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv1.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv1.Location = new System.Drawing.Point(9, 174);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(841, 423);
            this.dgv1.TabIndex = 17;
            this.dgv1.TitleBack = null;
            this.dgv1.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgv1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // check
            // 
            this.check.DataPropertyName = "check";
            this.check.FillWeight = 20F;
            this.check.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.check.HeaderText = "是否计算";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // name1
            // 
            this.name1.DataPropertyName = "name1";
            this.name1.FillWeight = 40F;
            this.name1.HeaderText = "PDBID";
            this.name1.Name = "name1";
            // 
            // path1
            // 
            this.path1.DataPropertyName = "path1";
            this.path1.HeaderText = "PDB文件路径";
            this.path1.Name = "path1";
            // 
            // showcontact
            // 
            this.showcontact.DataPropertyName = "showcontact";
            this.showcontact.FillWeight = 25F;
            this.showcontact.HeaderText = "查看接触图";
            this.showcontact.Name = "showcontact";
            this.showcontact.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.showcontact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.showcontact.Text = "查看接触图";
            this.showcontact.ToolTipText = "查看接触图";
            this.showcontact.UseColumnTextForButtonValue = true;
            // 
            // labelgif
            // 
            this.labelgif.BackColor = System.Drawing.Color.Transparent;
            this.labelgif.Image = global::ShowContact.Properties.Resources.load__1__gaitubao_50x50;
            this.labelgif.Location = new System.Drawing.Point(12, 600);
            this.labelgif.Name = "labelgif";
            this.labelgif.Size = new System.Drawing.Size(42, 37);
            this.labelgif.TabIndex = 14;
            this.labelgif.Visible = false;
            // 
            // skinMenuStrip1
            // 
            this.skinMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.skinMenuStrip1.Back = System.Drawing.Color.White;
            this.skinMenuStrip1.BackRadius = 4;
            this.skinMenuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.skinMenuStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinMenuStrip1.BaseForeAnamorphosis = false;
            this.skinMenuStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinMenuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseItemAnamorphosis = true;
            this.skinMenuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemBorderShow = true;
            this.skinMenuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemDown")));
            this.skinMenuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemMouse")));
            this.skinMenuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemRadius = 4;
            this.skinMenuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinMenuStrip1.Fore = System.Drawing.Color.Black;
            this.skinMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.ItemAnamorphosis = true;
            this.skinMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemBorderShow = true;
            this.skinMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemRadius = 4;
            this.skinMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.残基接触菜单ToolStripMenuItem,
            this.序列格式转换ToolStripMenuItem1,
            this.帮助ToolStripMenuItem1});
            this.skinMenuStrip1.Location = new System.Drawing.Point(4, 28);
            this.skinMenuStrip1.Name = "skinMenuStrip1";
            this.skinMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Size = new System.Drawing.Size(850, 25);
            this.skinMenuStrip1.SkinAllColor = true;
            this.skinMenuStrip1.TabIndex = 15;
            this.skinMenuStrip1.Text = "skinMenuStrip1";
            this.skinMenuStrip1.TitleAnamorphosis = true;
            this.skinMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinMenuStrip1.TitleRadius = 4;
            this.skinMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 残基接触菜单ToolStripMenuItem
            // 
            this.残基接触菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择PDB文件所在路径ToolStripMenuItem,
            this.设置接触矩阵输出路径ToolStripMenuItem1});
            this.残基接触菜单ToolStripMenuItem.Image = global::ShowContact.Properties.Resources.itme3;
            this.残基接触菜单ToolStripMenuItem.Name = "残基接触菜单ToolStripMenuItem";
            this.残基接触菜单ToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.残基接触菜单ToolStripMenuItem.Text = "残基接触菜单";
            // 
            // 选择PDB文件所在路径ToolStripMenuItem
            // 
            this.选择PDB文件所在路径ToolStripMenuItem.Image = global::ShowContact.Properties.Resources.item;
            this.选择PDB文件所在路径ToolStripMenuItem.Name = "选择PDB文件所在路径ToolStripMenuItem";
            this.选择PDB文件所在路径ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.选择PDB文件所在路径ToolStripMenuItem.Text = "①选择PDB文件所在路径";
            this.选择PDB文件所在路径ToolStripMenuItem.Click += new System.EventHandler(this.选择PDB文件所在路径ToolStripMenuItem_Click);
            // 
            // 设置接触矩阵输出路径ToolStripMenuItem1
            // 
            this.设置接触矩阵输出路径ToolStripMenuItem1.Image = global::ShowContact.Properties.Resources.item;
            this.设置接触矩阵输出路径ToolStripMenuItem1.Name = "设置接触矩阵输出路径ToolStripMenuItem1";
            this.设置接触矩阵输出路径ToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.设置接触矩阵输出路径ToolStripMenuItem1.Text = "②设置接触矩阵输出路径";
            this.设置接触矩阵输出路径ToolStripMenuItem1.Click += new System.EventHandler(this.设置接触矩阵输出路径ToolStripMenuItem1_Click);
            // 
            // 序列格式转换ToolStripMenuItem1
            // 
            this.序列格式转换ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDB转FAToolStripMenuItem,
            this.a3M转ALNToolStripMenuItem1,
            this.aln格式对齐ToolStripMenuItem});
            this.序列格式转换ToolStripMenuItem1.Image = global::ShowContact.Properties.Resources.图片1;
            this.序列格式转换ToolStripMenuItem1.Name = "序列格式转换ToolStripMenuItem1";
            this.序列格式转换ToolStripMenuItem1.Size = new System.Drawing.Size(108, 21);
            this.序列格式转换ToolStripMenuItem1.Text = "序列格式转换";
            // 
            // pDB转FAToolStripMenuItem
            // 
            this.pDB转FAToolStripMenuItem.Name = "pDB转FAToolStripMenuItem";
            this.pDB转FAToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pDB转FAToolStripMenuItem.Text = "①PDB转FA";
            this.pDB转FAToolStripMenuItem.Click += new System.EventHandler(this.pDB转FAToolStripMenuItem_Click);
            // 
            // a3M转ALNToolStripMenuItem1
            // 
            this.a3M转ALNToolStripMenuItem1.Name = "a3M转ALNToolStripMenuItem1";
            this.a3M转ALNToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.a3M转ALNToolStripMenuItem1.Text = "②A3M转ALN";
            this.a3M转ALNToolStripMenuItem1.Click += new System.EventHandler(this.a3M转ALNToolStripMenuItem1_Click);
            // 
            // aln格式对齐ToolStripMenuItem
            // 
            this.aln格式对齐ToolStripMenuItem.Name = "aln格式对齐ToolStripMenuItem";
            this.aln格式对齐ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aln格式对齐ToolStripMenuItem.Text = "③ALN格式对齐";
            this.aln格式对齐ToolStripMenuItem.Click += new System.EventHandler(this.aln格式对齐ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用教程ToolStripMenuItem1,
            this.联系我们ToolStripMenuItem1});
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // 使用教程ToolStripMenuItem1
            // 
            this.使用教程ToolStripMenuItem1.Name = "使用教程ToolStripMenuItem1";
            this.使用教程ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.使用教程ToolStripMenuItem1.Text = "使用教程";
            // 
            // 联系我们ToolStripMenuItem1
            // 
            this.联系我们ToolStripMenuItem1.Name = "联系我们ToolStripMenuItem1";
            this.联系我们ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.联系我们ToolStripMenuItem1.Text = "联系我们";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(858, 643);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.labelgif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.probar);
            this.Controls.Add(this.count);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.skinMenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPCR接触矩阵计算软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.skinMenuStrip1.ResumeLayout(false);
            this.skinMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pdb_path;
        private System.Windows.Forms.Label op_path;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.ProgressBar probar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelgif;
        private CCWin.SkinControl.SkinMenuStrip skinMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 残基接触菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 序列格式转换ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 选择PDB文件所在路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置接触矩阵输出路径ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pDB转FAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem a3M转ALNToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 使用教程ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinDataGridView dgv1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn path1;
        private System.Windows.Forms.DataGridViewButtonColumn showcontact;
        private System.Windows.Forms.ToolStripMenuItem aln格式对齐ToolStripMenuItem;
    }
}

