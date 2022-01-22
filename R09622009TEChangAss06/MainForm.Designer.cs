
namespace R09622009TEChangAss06
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Input Universe");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Output Universe");
            this.prgSelection = new System.Windows.Forms.PropertyGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddFS = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btn_binary_op = new System.Windows.Forms.Button();
            this.btn_unary_op = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inferenceSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mamdaniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sugenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightedAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightedSumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsukamotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightedAverageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weightedSumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab_FS_1 = new System.Windows.Forms.Label();
            this.lab_FS_2 = new System.Windows.Forms.Label();
            this.cb_unaryOperator = new System.Windows.Forms.ComboBox();
            this.cb_binaryOperator = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.trvFuzzyModel = new System.Windows.Forms.TreeView();
            this.btnCreateAUniverse = new System.Windows.Forms.Button();
            this.lb_fuzzy_system = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gb_BOFS = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_clear_lb = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gb_UOFS = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_PFS = new System.Windows.Forms.GroupBox();
            this.cb_FS_monotonic = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_FS = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAddOutputEquation = new System.Windows.Forms.Button();
            this.lsbEuqations = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_FC = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInference = new System.Windows.Forms.Button();
            this.dgvCondition = new System.Windows.Forms.DataGridView();
            this.gb_FR = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chtFuzzyModel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartController2 = new Steema.TeeChart.ChartController();
            this.LineChart = new Steema.TeeChart.TChart();
            this.COA_ = new Steema.TeeChart.Styles.Line();
            this.BOA_ = new Steema.TeeChart.Styles.Line();
            this.MOM_ = new Steema.TeeChart.Styles.Line();
            this.SOM_ = new Steema.TeeChart.Styles.Line();
            this.LOM_ = new Steema.TeeChart.Styles.Line();
            this.gb_ST = new System.Windows.Forms.GroupBox();
            this.rb_ST_Average = new System.Windows.Forms.RadioButton();
            this.rb_ST_Sum = new System.Windows.Forms.RadioButton();
            this.gb_Mamdani = new System.Windows.Forms.GroupBox();
            this.rb_M_Scale = new System.Windows.Forms.RadioButton();
            this.rb_M_Cut = new System.Windows.Forms.RadioButton();
            this.btn_final_inferencing = new System.Windows.Forms.Button();
            this.chartController1 = new Steema.TeeChart.ChartController();
            this.SurfaceChart = new Steema.TeeChart.TChart();
            this.COA = new Steema.TeeChart.Styles.Surface();
            this.BOA = new Steema.TeeChart.Styles.Surface();
            this.MOM = new Steema.TeeChart.Styles.Surface();
            this.SOM = new Steema.TeeChart.Styles.Surface();
            this.LOM = new Steema.TeeChart.Styles.Surface();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gb_BOFS.SuspendLayout();
            this.gb_UOFS.SuspendLayout();
            this.gb_PFS.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gb_FC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).BeginInit();
            this.gb_FR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtFuzzyModel)).BeginInit();
            this.gb_ST.SuspendLayout();
            this.gb_Mamdani.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgSelection
            // 
            this.prgSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgSelection.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prgSelection.Location = new System.Drawing.Point(5, 47);
            this.prgSelection.Margin = new System.Windows.Forms.Padding(5);
            this.prgSelection.Name = "prgSelection";
            this.prgSelection.Size = new System.Drawing.Size(278, 225);
            this.prgSelection.TabIndex = 2;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // btnAddFS
            // 
            this.btnAddFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFS.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddFS.Location = new System.Drawing.Point(336, 29);
            this.btnAddFS.Name = "btnAddFS";
            this.btnAddFS.Size = new System.Drawing.Size(185, 52);
            this.btnAddFS.TabIndex = 4;
            this.btnAddFS.Text = "Add The Fuzzy Set";
            this.toolTip1.SetToolTip(this.btnAddFS, "The fuzzy set should only be added on an universe. Please (create and) select an " +
        "universe.");
            this.btnAddFS.UseVisualStyleBackColor = true;
            this.btnAddFS.Click += new System.EventHandler(this.btnAddFS_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.Location = new System.Drawing.Point(213, 8);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(33, 32);
            this.btnReset.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnReset, "Reset the plot.");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn_binary_op
            // 
            this.btn_binary_op.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_binary_op.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_binary_op.Location = new System.Drawing.Point(336, 114);
            this.btn_binary_op.Name = "btn_binary_op";
            this.btn_binary_op.Size = new System.Drawing.Size(183, 52);
            this.btn_binary_op.TabIndex = 68;
            this.btn_binary_op.Text = "Create A Binary \r\nOperatored Fuzzy Set";
            this.btn_binary_op.UseVisualStyleBackColor = true;
            this.btn_binary_op.Click += new System.EventHandler(this.btn_binary_op_Click);
            // 
            // btn_unary_op
            // 
            this.btn_unary_op.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_unary_op.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_unary_op.Location = new System.Drawing.Point(336, 27);
            this.btn_unary_op.Name = "btn_unary_op";
            this.btn_unary_op.Size = new System.Drawing.Size(183, 52);
            this.btn_unary_op.TabIndex = 72;
            this.btn_unary_op.Text = "Create An Unary \r\nOperated Fuzzy Set\r\n";
            this.btn_unary_op.UseVisualStyleBackColor = true;
            this.btn_unary_op.Click += new System.EventHandler(this.btn_unary_op_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(-61, -9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.inferenceSystemToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 27);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveToolStripMenuItem.Text = "Save ...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem.Text = "Open ...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // inferenceSystemToolStripMenuItem
            // 
            this.inferenceSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mamdaniToolStripMenuItem,
            this.sugenoToolStripMenuItem,
            this.tsukamotoToolStripMenuItem});
            this.inferenceSystemToolStripMenuItem.Name = "inferenceSystemToolStripMenuItem";
            this.inferenceSystemToolStripMenuItem.Size = new System.Drawing.Size(142, 23);
            this.inferenceSystemToolStripMenuItem.Text = "Inference System";
            // 
            // mamdaniToolStripMenuItem
            // 
            this.mamdaniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.mamdaniToolStripMenuItem.Name = "mamdaniToolStripMenuItem";
            this.mamdaniToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.mamdaniToolStripMenuItem.Text = "Mamdani";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // sugenoToolStripMenuItem
            // 
            this.sugenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weightedAverageToolStripMenuItem,
            this.weightedSumToolStripMenuItem});
            this.sugenoToolStripMenuItem.Name = "sugenoToolStripMenuItem";
            this.sugenoToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.sugenoToolStripMenuItem.Text = "Sugeno";
            // 
            // weightedAverageToolStripMenuItem
            // 
            this.weightedAverageToolStripMenuItem.Name = "weightedAverageToolStripMenuItem";
            this.weightedAverageToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.weightedAverageToolStripMenuItem.Text = "Weighted Average";
            this.weightedAverageToolStripMenuItem.Click += new System.EventHandler(this.weightedAverageToolStripMenuItem_Click);
            // 
            // weightedSumToolStripMenuItem
            // 
            this.weightedSumToolStripMenuItem.Name = "weightedSumToolStripMenuItem";
            this.weightedSumToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.weightedSumToolStripMenuItem.Text = "Weighted Sum";
            this.weightedSumToolStripMenuItem.Click += new System.EventHandler(this.weightedSumToolStripMenuItem_Click);
            // 
            // tsukamotoToolStripMenuItem
            // 
            this.tsukamotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weightedAverageToolStripMenuItem1,
            this.weightedSumToolStripMenuItem1});
            this.tsukamotoToolStripMenuItem.Name = "tsukamotoToolStripMenuItem";
            this.tsukamotoToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.tsukamotoToolStripMenuItem.Text = "Tsukamoto";
            // 
            // weightedAverageToolStripMenuItem1
            // 
            this.weightedAverageToolStripMenuItem1.Name = "weightedAverageToolStripMenuItem1";
            this.weightedAverageToolStripMenuItem1.Size = new System.Drawing.Size(223, 26);
            this.weightedAverageToolStripMenuItem1.Text = "Weighted Average";
            this.weightedAverageToolStripMenuItem1.Click += new System.EventHandler(this.weightedAverageToolStripMenuItem1_Click);
            // 
            // weightedSumToolStripMenuItem1
            // 
            this.weightedSumToolStripMenuItem1.Name = "weightedSumToolStripMenuItem1";
            this.weightedSumToolStripMenuItem1.Size = new System.Drawing.Size(223, 26);
            this.weightedSumToolStripMenuItem1.Text = "Weighted Sum";
            this.weightedSumToolStripMenuItem1.Click += new System.EventHandler(this.weightedSumToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.imageToolStripMenuItem.Text = "Quick Start";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(65, 23);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lab_FS_1
            // 
            this.lab_FS_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_FS_1.BackColor = System.Drawing.Color.Transparent;
            this.lab_FS_1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_FS_1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lab_FS_1.Location = new System.Drawing.Point(40, 30);
            this.lab_FS_1.Name = "lab_FS_1";
            this.lab_FS_1.Size = new System.Drawing.Size(293, 27);
            this.lab_FS_1.TabIndex = 69;
            this.lab_FS_1.Text = "Select The First Fuzzy Set And Click";
            this.lab_FS_1.Click += new System.EventHandler(this.lab_FS_1_Click);
            // 
            // lab_FS_2
            // 
            this.lab_FS_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_FS_2.BackColor = System.Drawing.Color.Transparent;
            this.lab_FS_2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_FS_2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lab_FS_2.Location = new System.Drawing.Point(40, 58);
            this.lab_FS_2.Name = "lab_FS_2";
            this.lab_FS_2.Size = new System.Drawing.Size(293, 27);
            this.lab_FS_2.TabIndex = 70;
            this.lab_FS_2.Text = "Select The Second Fuzzy Set And Click";
            this.lab_FS_2.Click += new System.EventHandler(this.lab_FS_2_Click);
            // 
            // cb_unaryOperator
            // 
            this.cb_unaryOperator.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_unaryOperator.FormattingEnabled = true;
            this.cb_unaryOperator.Items.AddRange(new object[] {
            "Negation (Not)",
            "Sugeno\'s Complement",
            "Yager\'s Complement",
            "Concentration (Very)",
            "Concentration (Extremly)",
            "Dilation (More or Less)",
            "Value-Cut",
            "Value-Scale",
            "Intensification",
            "Diminisher"});
            this.cb_unaryOperator.Location = new System.Drawing.Point(12, 49);
            this.cb_unaryOperator.Name = "cb_unaryOperator";
            this.cb_unaryOperator.Size = new System.Drawing.Size(318, 27);
            this.cb_unaryOperator.TabIndex = 71;
            // 
            // cb_binaryOperator
            // 
            this.cb_binaryOperator.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_binaryOperator.FormattingEnabled = true;
            this.cb_binaryOperator.Items.AddRange(new object[] {
            "Intersection (min)",
            "Algebraic product",
            "Bounded product",
            "Drastic product",
            "Sugeno\'s T-norm",
            "Yager\'s T-norm",
            "Union (max)",
            "Algebraic sum",
            "Bounded sum",
            "Drastic sum",
            "Sugeno\'s S-norm",
            "Yager\'s S-norm"});
            this.cb_binaryOperator.Location = new System.Drawing.Point(10, 136);
            this.cb_binaryOperator.Name = "cb_binaryOperator";
            this.cb_binaryOperator.Size = new System.Drawing.Size(318, 27);
            this.cb_binaryOperator.TabIndex = 80;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1482, 725);
            this.splitContainer1.SplitterDistance = 547;
            this.splitContainer1.TabIndex = 81;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(547, 725);
            this.splitContainer2.SplitterDistance = 274;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.trvFuzzyModel);
            this.splitContainer4.Panel1.Controls.Add(this.btnCreateAUniverse);
            this.splitContainer4.Panel1.Controls.Add(this.btnReset);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.lb_fuzzy_system);
            this.splitContainer4.Panel2.Controls.Add(this.prgSelection);
            this.splitContainer4.Size = new System.Drawing.Size(547, 274);
            this.splitContainer4.SplitterDistance = 255;
            this.splitContainer4.TabIndex = 19;
            // 
            // trvFuzzyModel
            // 
            this.trvFuzzyModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvFuzzyModel.HideSelection = false;
            this.trvFuzzyModel.Location = new System.Drawing.Point(12, 47);
            this.trvFuzzyModel.Name = "trvFuzzyModel";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Input Universe";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Output Universe";
            this.trvFuzzyModel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.trvFuzzyModel.Size = new System.Drawing.Size(234, 225);
            this.trvFuzzyModel.TabIndex = 1;
            this.trvFuzzyModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFuzzyModel_AfterSelect);
            // 
            // btnCreateAUniverse
            // 
            this.btnCreateAUniverse.Location = new System.Drawing.Point(12, 8);
            this.btnCreateAUniverse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateAUniverse.Name = "btnCreateAUniverse";
            this.btnCreateAUniverse.Size = new System.Drawing.Size(195, 32);
            this.btnCreateAUniverse.TabIndex = 0;
            this.btnCreateAUniverse.Text = "Create An Universe";
            this.btnCreateAUniverse.UseVisualStyleBackColor = true;
            this.btnCreateAUniverse.Click += new System.EventHandler(this.btnCreateAUniverse_Click);
            // 
            // lb_fuzzy_system
            // 
            this.lb_fuzzy_system.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_fuzzy_system.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_fuzzy_system.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_fuzzy_system.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_fuzzy_system.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_fuzzy_system.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_fuzzy_system.Location = new System.Drawing.Point(5, 6);
            this.lb_fuzzy_system.Name = "lb_fuzzy_system";
            this.lb_fuzzy_system.Size = new System.Drawing.Size(279, 33);
            this.lb_fuzzy_system.TabIndex = 3;
            this.lb_fuzzy_system.Text = "label6";
            this.lb_fuzzy_system.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 447);
            this.tabControl1.TabIndex = 82;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.gb_BOFS);
            this.tabPage1.Controls.Add(this.gb_UOFS);
            this.tabPage1.Controls.Add(this.gb_PFS);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(539, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fuzzy Sets";
            // 
            // gb_BOFS
            // 
            this.gb_BOFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_BOFS.Controls.Add(this.label5);
            this.gb_BOFS.Controls.Add(this.label3);
            this.gb_BOFS.Controls.Add(this.cb_binaryOperator);
            this.gb_BOFS.Controls.Add(this.btn_binary_op);
            this.gb_BOFS.Controls.Add(this.btn_clear_lb);
            this.gb_BOFS.Controls.Add(this.lab_FS_1);
            this.gb_BOFS.Controls.Add(this.label10);
            this.gb_BOFS.Controls.Add(this.label9);
            this.gb_BOFS.Controls.Add(this.lab_FS_2);
            this.gb_BOFS.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_BOFS.Location = new System.Drawing.Point(8, 224);
            this.gb_BOFS.Name = "gb_BOFS";
            this.gb_BOFS.Size = new System.Drawing.Size(525, 185);
            this.gb_BOFS.TabIndex = 86;
            this.gb_BOFS.TabStop = false;
            this.gb_BOFS.Text = "Binary Operated Fuzzy Set";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(8, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type of the binary operator";
            // 
            // btn_clear_lb
            // 
            this.btn_clear_lb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear_lb.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_clear_lb.Location = new System.Drawing.Point(336, 29);
            this.btn_clear_lb.Name = "btn_clear_lb";
            this.btn_clear_lb.Size = new System.Drawing.Size(183, 47);
            this.btn_clear_lb.TabIndex = 81;
            this.btn_clear_lb.Text = "clear";
            this.btn_clear_lb.UseVisualStyleBackColor = true;
            this.btn_clear_lb.Click += new System.EventHandler(this.btn_clear_lb_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(5, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 19);
            this.label10.TabIndex = 83;
            this.label10.Text = "(2)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(5, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 19);
            this.label9.TabIndex = 82;
            this.label9.Text = "(1)";
            // 
            // gb_UOFS
            // 
            this.gb_UOFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_UOFS.Controls.Add(this.label2);
            this.gb_UOFS.Controls.Add(this.cb_unaryOperator);
            this.gb_UOFS.Controls.Add(this.btn_unary_op);
            this.gb_UOFS.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_UOFS.Location = new System.Drawing.Point(8, 115);
            this.gb_UOFS.Name = "gb_UOFS";
            this.gb_UOFS.Size = new System.Drawing.Size(525, 90);
            this.gb_UOFS.TabIndex = 85;
            this.gb_UOFS.TabStop = false;
            this.gb_UOFS.Text = "Unary Operated Fuzzy Set";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type of the unary operator\r\n";
            // 
            // gb_PFS
            // 
            this.gb_PFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_PFS.BackColor = System.Drawing.SystemColors.Control;
            this.gb_PFS.Controls.Add(this.cb_FS_monotonic);
            this.gb_PFS.Controls.Add(this.label1);
            this.gb_PFS.Controls.Add(this.btnAddFS);
            this.gb_PFS.Controls.Add(this.cb_FS);
            this.gb_PFS.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_PFS.Location = new System.Drawing.Point(6, 6);
            this.gb_PFS.Name = "gb_PFS";
            this.gb_PFS.Size = new System.Drawing.Size(527, 90);
            this.gb_PFS.TabIndex = 84;
            this.gb_PFS.TabStop = false;
            this.gb_PFS.Text = "Primary Fuzzy Set";
            // 
            // cb_FS_monotonic
            // 
            this.cb_FS_monotonic.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_FS_monotonic.FormattingEnabled = true;
            this.cb_FS_monotonic.Items.AddRange(new object[] {
            "Sigmoidal Function",
            "S-shaped Function",
            "Z-shaped Function",
            "StepUp Function",
            "StepDown Function"});
            this.cb_FS_monotonic.Location = new System.Drawing.Point(14, 49);
            this.cb_FS_monotonic.Name = "cb_FS_monotonic";
            this.cb_FS_monotonic.Size = new System.Drawing.Size(316, 27);
            this.cb_FS_monotonic.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type of the fuzzy membership function";
            // 
            // cb_FS
            // 
            this.cb_FS.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_FS.FormattingEnabled = true;
            this.cb_FS.Items.AddRange(new object[] {
            "Gaussian Function",
            "Triangular Function",
            "Bell Function",
            "Sigmoidal Function",
            "Left-Right Function",
            "S-shaped Function",
            "Z-shaped Function",
            "Trapzoidal Function",
            "Pi-shaped Function",
            "StepUp Function",
            "StepDown Function",
            "Fuzzy Singleton"});
            this.cb_FS.Location = new System.Drawing.Point(14, 49);
            this.cb_FS.Name = "cb_FS";
            this.cb_FS.Size = new System.Drawing.Size(316, 27);
            this.cb_FS.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnAddOutputEquation);
            this.tabPage3.Controls.Add(this.lsbEuqations);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(539, 416);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sugeno Output Equations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnAddOutputEquation
            // 
            this.btnAddOutputEquation.Location = new System.Drawing.Point(386, 17);
            this.btnAddOutputEquation.Name = "btnAddOutputEquation";
            this.btnAddOutputEquation.Size = new System.Drawing.Size(136, 50);
            this.btnAddOutputEquation.TabIndex = 1;
            this.btnAddOutputEquation.Text = "Add an Equation";
            this.btnAddOutputEquation.UseVisualStyleBackColor = true;
            this.btnAddOutputEquation.Click += new System.EventHandler(this.btnAddOutputEquation_Click);
            // 
            // lsbEuqations
            // 
            this.lsbEuqations.FormattingEnabled = true;
            this.lsbEuqations.ItemHeight = 19;
            this.lsbEuqations.Items.AddRange(new object[] {
            "(0) Y =  0.1 * X + 6.4 ",
            "(1) Y = -0.5 * X + 4",
            "(2) Y =  X - 2",
            "(3) Z = -X + Y + 1",
            "(4) Z = -Y + 3",
            "(5) Z = -X + 3",
            "(6) Z = X + Y + 2"});
            this.lsbEuqations.Location = new System.Drawing.Point(19, 17);
            this.lsbEuqations.Name = "lsbEuqations";
            this.lsbEuqations.Size = new System.Drawing.Size(350, 346);
            this.lsbEuqations.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.gb_FC);
            this.tabPage2.Controls.Add(this.gb_FR);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(539, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "If-Then Rules";
            // 
            // gb_FC
            // 
            this.gb_FC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_FC.Controls.Add(this.label7);
            this.gb_FC.Controls.Add(this.btnInference);
            this.gb_FC.Controls.Add(this.dgvCondition);
            this.gb_FC.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_FC.Location = new System.Drawing.Point(8, 251);
            this.gb_FC.Name = "gb_FC";
            this.gb_FC.Size = new System.Drawing.Size(525, 158);
            this.gb_FC.TabIndex = 6;
            this.gb_FC.TabStop = false;
            this.gb_FC.Text = "Conditions";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(6, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(301, 48);
            this.label7.TabIndex = 5;
            this.label7.Text = "The facts (obeservations). For Sugeno and Tsukamoto system, please use singleton." +
    "";
            // 
            // btnInference
            // 
            this.btnInference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInference.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInference.Location = new System.Drawing.Point(367, 19);
            this.btnInference.Name = "btnInference";
            this.btnInference.Size = new System.Drawing.Size(152, 41);
            this.btnInference.TabIndex = 4;
            this.btnInference.Text = "Individual Inference";
            this.btnInference.UseVisualStyleBackColor = true;
            this.btnInference.Click += new System.EventHandler(this.btnInference_Click);
            // 
            // dgvCondition
            // 
            this.dgvCondition.AllowUserToAddRows = false;
            this.dgvCondition.AllowUserToDeleteRows = false;
            this.dgvCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCondition.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCondition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondition.Location = new System.Drawing.Point(6, 80);
            this.dgvCondition.Name = "dgvCondition";
            this.dgvCondition.RowHeadersWidth = 51;
            this.dgvCondition.RowTemplate.Height = 27;
            this.dgvCondition.Size = new System.Drawing.Size(513, 71);
            this.dgvCondition.TabIndex = 1;
            this.dgvCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondition_CellClick);
            // 
            // gb_FR
            // 
            this.gb_FR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_FR.Controls.Add(this.label6);
            this.gb_FR.Controls.Add(this.dgvRules);
            this.gb_FR.Controls.Add(this.btnAddRule);
            this.gb_FR.Controls.Add(this.btnDeleteRule);
            this.gb_FR.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb_FR.Location = new System.Drawing.Point(8, 6);
            this.gb_FR.Name = "gb_FR";
            this.gb_FR.Size = new System.Drawing.Size(525, 239);
            this.gb_FR.TabIndex = 5;
            this.gb_FR.TabStop = false;
            this.gb_FR.Text = "Fuzzy Rules (antecedents and consequences)";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "If (some antecedents) then (consequence).";
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.AllowUserToDeleteRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Location = new System.Drawing.Point(6, 68);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowHeadersWidth = 51;
            this.dgvRules.RowTemplate.Height = 27;
            this.dgvRules.Size = new System.Drawing.Size(513, 165);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRule.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddRule.Location = new System.Drawing.Point(303, 25);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(103, 37);
            this.btnAddRule.TabIndex = 2;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRule.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteRule.Location = new System.Drawing.Point(412, 25);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(107, 37);
            this.btnDeleteRule.TabIndex = 3;
            this.btnDeleteRule.Text = "Delete Rule";
            this.btnDeleteRule.UseVisualStyleBackColor = true;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chtFuzzyModel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chartController2);
            this.splitContainer3.Panel2.Controls.Add(this.gb_ST);
            this.splitContainer3.Panel2.Controls.Add(this.gb_Mamdani);
            this.splitContainer3.Panel2.Controls.Add(this.LineChart);
            this.splitContainer3.Panel2.Controls.Add(this.btn_final_inferencing);
            this.splitContainer3.Panel2.Controls.Add(this.chartController1);
            this.splitContainer3.Panel2.Controls.Add(this.SurfaceChart);
            this.splitContainer3.Size = new System.Drawing.Size(931, 725);
            this.splitContainer3.SplitterDistance = 391;
            this.splitContainer3.TabIndex = 4;
            // 
            // chtFuzzyModel
            // 
            this.chtFuzzyModel.BorderlineColor = System.Drawing.Color.Transparent;
            this.chtFuzzyModel.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtFuzzyModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtFuzzyModel.Location = new System.Drawing.Point(0, 0);
            this.chtFuzzyModel.Name = "chtFuzzyModel";
            this.chtFuzzyModel.Size = new System.Drawing.Size(931, 391);
            this.chtFuzzyModel.TabIndex = 3;
            this.chtFuzzyModel.Text = "chart1";
            // 
            // chartController2
            // 
            this.chartController2.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.chartController2.Chart = this.LineChart;
            this.chartController2.LabelValues = true;
            this.chartController2.Location = new System.Drawing.Point(0, 25);
            this.chartController2.Name = "chartController2";
            this.chartController2.Size = new System.Drawing.Size(931, 25);
            this.chartController2.TabIndex = 6;
            this.chartController2.Text = "chartController2";
            // 
            // LineChart
            // 
            this.LineChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.LineChart.Aspect.Elevation = 360;
            this.LineChart.Aspect.ElevationFloat = 360D;
            this.LineChart.Aspect.Orthogonal = false;
            this.LineChart.Aspect.Rotation = 360;
            this.LineChart.Aspect.RotationFloat = 360D;
            this.LineChart.Aspect.View3D = false;
            this.LineChart.Aspect.ZoomText = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.LineChart.Axes.Bottom.Title.Caption = "Inputs";
            this.LineChart.Axes.Bottom.Title.Lines = new string[] {
        "Inputs"};
            // 
            // 
            // 
            this.LineChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            this.LineChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.LineChart.Axes.Left.Title.Caption = "Outputs";
            this.LineChart.Axes.Left.Title.Lines = new string[] {
        "Outputs"};
            // 
            // 
            // 
            this.LineChart.Header.Lines = new string[] {
        "Inputs vs Outputs"};
            // 
            // 
            // 
            this.LineChart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.LineChart.Legend.CheckBoxes = true;
            this.LineChart.Location = new System.Drawing.Point(176, 43);
            this.LineChart.Name = "LineChart";
            this.LineChart.Series.Add(this.COA_);
            this.LineChart.Series.Add(this.BOA_);
            this.LineChart.Series.Add(this.MOM_);
            this.LineChart.Series.Add(this.SOM_);
            this.LineChart.Series.Add(this.LOM_);
            this.LineChart.Size = new System.Drawing.Size(743, 264);
            this.LineChart.TabIndex = 3;
            // 
            // COA_
            // 
            // 
            // 
            // 
            this.COA_.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.COA_.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.COA_.ColorEach = false;
            // 
            // 
            // 
            this.COA_.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.COA_.LinePen.Width = 3;
            this.COA_.Title = "COA";
            // 
            // 
            // 
            this.COA_.XValues.DataMember = "X";
            this.COA_.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.COA_.YValues.DataMember = "Y";
            // 
            // BOA_
            // 
            // 
            // 
            // 
            this.BOA_.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BOA_.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BOA_.ColorEach = false;
            // 
            // 
            // 
            this.BOA_.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.BOA_.LinePen.Width = 3;
            this.BOA_.Title = "BOA";
            // 
            // 
            // 
            this.BOA_.XValues.DataMember = "X";
            this.BOA_.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.BOA_.YValues.DataMember = "Y";
            // 
            // MOM_
            // 
            // 
            // 
            // 
            this.MOM_.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MOM_.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MOM_.ColorEach = false;
            // 
            // 
            // 
            this.MOM_.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.MOM_.LinePen.Width = 3;
            this.MOM_.Title = "MOM";
            // 
            // 
            // 
            this.MOM_.XValues.DataMember = "X";
            this.MOM_.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MOM_.YValues.DataMember = "Y";
            // 
            // SOM_
            // 
            // 
            // 
            // 
            this.SOM_.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(228)))), ((int)(((byte)(1)))));
            this.SOM_.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(228)))), ((int)(((byte)(1)))));
            this.SOM_.ColorEach = false;
            // 
            // 
            // 
            this.SOM_.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(46)))), ((int)(((byte)(12)))));
            this.SOM_.LinePen.Width = 3;
            this.SOM_.Title = "SOM";
            // 
            // 
            // 
            this.SOM_.XValues.DataMember = "X";
            this.SOM_.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.SOM_.YValues.DataMember = "Y";
            // 
            // LOM_
            // 
            // 
            // 
            // 
            this.LOM_.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.LOM_.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.LOM_.ColorEach = false;
            // 
            // 
            // 
            this.LOM_.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(91)))), ((int)(((byte)(101)))));
            this.LOM_.LinePen.Width = 3;
            this.LOM_.Title = "LOM";
            // 
            // 
            // 
            this.LOM_.XValues.DataMember = "X";
            this.LOM_.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.LOM_.YValues.DataMember = "Y";
            // 
            // gb_ST
            // 
            this.gb_ST.Controls.Add(this.rb_ST_Average);
            this.gb_ST.Controls.Add(this.rb_ST_Sum);
            this.gb_ST.Location = new System.Drawing.Point(14, 107);
            this.gb_ST.Name = "gb_ST";
            this.gb_ST.Size = new System.Drawing.Size(147, 133);
            this.gb_ST.TabIndex = 5;
            this.gb_ST.TabStop = false;
            this.gb_ST.Text = "Parameters";
            // 
            // rb_ST_Average
            // 
            this.rb_ST_Average.AutoSize = true;
            this.rb_ST_Average.Location = new System.Drawing.Point(13, 26);
            this.rb_ST_Average.Name = "rb_ST_Average";
            this.rb_ST_Average.Size = new System.Drawing.Size(103, 42);
            this.rb_ST_Average.TabIndex = 0;
            this.rb_ST_Average.Text = "Weighted \r\nAverage";
            this.rb_ST_Average.UseVisualStyleBackColor = true;
            this.rb_ST_Average.Click += new System.EventHandler(this.rb_ST_Average_Click);
            // 
            // rb_ST_Sum
            // 
            this.rb_ST_Sum.AutoSize = true;
            this.rb_ST_Sum.Location = new System.Drawing.Point(13, 74);
            this.rb_ST_Sum.Name = "rb_ST_Sum";
            this.rb_ST_Sum.Size = new System.Drawing.Size(99, 42);
            this.rb_ST_Sum.TabIndex = 1;
            this.rb_ST_Sum.Text = "Weighted\r\nSum";
            this.rb_ST_Sum.UseVisualStyleBackColor = true;
            this.rb_ST_Sum.Click += new System.EventHandler(this.rb_ST_Sum_Click);
            // 
            // gb_Mamdani
            // 
            this.gb_Mamdani.Controls.Add(this.rb_M_Scale);
            this.gb_Mamdani.Controls.Add(this.rb_M_Cut);
            this.gb_Mamdani.Location = new System.Drawing.Point(14, 107);
            this.gb_Mamdani.Name = "gb_Mamdani";
            this.gb_Mamdani.Size = new System.Drawing.Size(147, 86);
            this.gb_Mamdani.TabIndex = 4;
            this.gb_Mamdani.TabStop = false;
            this.gb_Mamdani.Text = "Parameters";
            // 
            // rb_M_Scale
            // 
            this.rb_M_Scale.AutoSize = true;
            this.rb_M_Scale.Location = new System.Drawing.Point(13, 51);
            this.rb_M_Scale.Name = "rb_M_Scale";
            this.rb_M_Scale.Size = new System.Drawing.Size(66, 23);
            this.rb_M_Scale.TabIndex = 1;
            this.rb_M_Scale.Text = "Scale";
            this.rb_M_Scale.UseVisualStyleBackColor = true;
            this.rb_M_Scale.Click += new System.EventHandler(this.rb_M_Scale_Click);
            // 
            // rb_M_Cut
            // 
            this.rb_M_Cut.AutoSize = true;
            this.rb_M_Cut.Location = new System.Drawing.Point(13, 26);
            this.rb_M_Cut.Name = "rb_M_Cut";
            this.rb_M_Cut.Size = new System.Drawing.Size(54, 23);
            this.rb_M_Cut.TabIndex = 0;
            this.rb_M_Cut.Text = "Cut";
            this.rb_M_Cut.UseVisualStyleBackColor = true;
            this.rb_M_Cut.Click += new System.EventHandler(this.rb_M_Cut_Click);
            // 
            // btn_final_inferencing
            // 
            this.btn_final_inferencing.Location = new System.Drawing.Point(14, 43);
            this.btn_final_inferencing.Name = "btn_final_inferencing";
            this.btn_final_inferencing.Size = new System.Drawing.Size(147, 43);
            this.btn_final_inferencing.TabIndex = 2;
            this.btn_final_inferencing.Text = "Auto Inference";
            this.btn_final_inferencing.UseVisualStyleBackColor = true;
            this.btn_final_inferencing.Click += new System.EventHandler(this.btn_final_inferencing_Click);
            // 
            // chartController1
            // 
            this.chartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.chartController1.Chart = this.SurfaceChart;
            this.chartController1.LabelValues = true;
            this.chartController1.Location = new System.Drawing.Point(0, 0);
            this.chartController1.Name = "chartController1";
            this.chartController1.Size = new System.Drawing.Size(931, 25);
            this.chartController1.TabIndex = 1;
            this.chartController1.Text = "chartController1";
            // 
            // SurfaceChart
            // 
            this.SurfaceChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.SurfaceChart.Aspect.Chart3DPercent = 85;
            this.SurfaceChart.Aspect.Orthogonal = false;
            this.SurfaceChart.Aspect.Perspective = 76;
            this.SurfaceChart.Aspect.Zoom = 55;
            this.SurfaceChart.Aspect.ZoomFloat = 55D;
            this.SurfaceChart.Aspect.ZoomText = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Axes.Bottom.Title.Caption = "Input Universe 1";
            this.SurfaceChart.Axes.Bottom.Title.Lines = new string[] {
        "Input Universe 1"};
            // 
            // 
            // 
            this.SurfaceChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            this.SurfaceChart.Axes.Depth.Title.Caption = "Input Universe 2";
            this.SurfaceChart.Axes.Depth.Title.Lines = new string[] {
        "Input Universe 2"};
            this.SurfaceChart.Axes.Depth.Visible = true;
            // 
            // 
            // 
            this.SurfaceChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Axes.Left.Title.Caption = "Ouput Universe";
            this.SurfaceChart.Axes.Left.Title.Lines = new string[] {
        "Ouput Universe"};
            // 
            // 
            // 
            this.SurfaceChart.Header.Lines = new string[] {
        "Inputs vs Outputs"};
            // 
            // 
            // 
            this.SurfaceChart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.SurfaceChart.Legend.CheckBoxes = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SurfaceChart.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            // 
            // 
            // 
            this.SurfaceChart.Legend.Pen.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SurfaceChart.Legend.Symbol.Width = 40;
            this.SurfaceChart.Location = new System.Drawing.Point(176, 43);
            this.SurfaceChart.Name = "SurfaceChart";
            // 
            // 
            // 
            this.SurfaceChart.Panel.MarginBottom = 3D;
            this.SurfaceChart.Panel.MarginLeft = 0D;
            this.SurfaceChart.Panel.MarginRight = 0D;
            this.SurfaceChart.Series.Add(this.COA);
            this.SurfaceChart.Series.Add(this.BOA);
            this.SurfaceChart.Series.Add(this.MOM);
            this.SurfaceChart.Series.Add(this.SOM);
            this.SurfaceChart.Series.Add(this.LOM);
            this.SurfaceChart.Size = new System.Drawing.Size(743, 264);
            this.SurfaceChart.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Walls.Back.Brush.Visible = false;
            this.SurfaceChart.Walls.Back.Transparent = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Walls.Bottom.Brush.Visible = false;
            this.SurfaceChart.Walls.Bottom.Transparent = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.SurfaceChart.Walls.Left.Brush.Visible = false;
            this.SurfaceChart.Walls.Left.Transparent = true;
            // 
            // 
            // 
            this.SurfaceChart.Walls.Right.Transparent = true;
            // 
            // COA
            // 
            // 
            // 
            // 
            this.COA.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.COA.Brush.Gradient.Transparency = 40;
            this.COA.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.COA.ColorEach = false;
            this.COA.IrregularGrid = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.COA.Marks.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.COA.PaletteMin = 0D;
            this.COA.PaletteStep = 0D;
            this.COA.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.COA.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.COA.Title = "COA";
            this.COA.UseColorRange = false;
            // 
            // 
            // 
            this.COA.XValues.DataMember = "X";
            // 
            // 
            // 
            this.COA.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.COA.ZValues.DataMember = "Z";
            // 
            // BOA
            // 
            // 
            // 
            // 
            this.BOA.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.BOA.Brush.Gradient.Transparency = 40;
            this.BOA.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BOA.ColorEach = false;
            this.BOA.IrregularGrid = true;
            this.BOA.PaletteMin = 0D;
            this.BOA.PaletteStep = 0D;
            this.BOA.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.BOA.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BOA.Title = "BOA";
            this.BOA.UseColorRange = false;
            // 
            // 
            // 
            this.BOA.XValues.DataMember = "X";
            // 
            // 
            // 
            this.BOA.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.BOA.ZValues.DataMember = "Z";
            // 
            // MOM
            // 
            // 
            // 
            // 
            this.MOM.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.MOM.Brush.Gradient.Transparency = 40;
            this.MOM.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MOM.ColorEach = false;
            this.MOM.IrregularGrid = true;
            this.MOM.PaletteMin = 0D;
            this.MOM.PaletteStep = 0D;
            this.MOM.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.MOM.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MOM.Title = "MOM";
            this.MOM.UseColorRange = false;
            // 
            // 
            // 
            this.MOM.XValues.DataMember = "X";
            // 
            // 
            // 
            this.MOM.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.MOM.ZValues.DataMember = "Z";
            // 
            // SOM
            // 
            // 
            // 
            // 
            this.SOM.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.SOM.Brush.Gradient.Transparency = 40;
            this.SOM.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.SOM.ColorEach = false;
            this.SOM.IrregularGrid = true;
            this.SOM.PaletteMin = 0D;
            this.SOM.PaletteStep = 0D;
            this.SOM.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.SOM.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.SOM.Title = "SOM";
            this.SOM.UseColorRange = false;
            // 
            // 
            // 
            this.SOM.XValues.DataMember = "X";
            // 
            // 
            // 
            this.SOM.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.SOM.ZValues.DataMember = "Z";
            // 
            // LOM
            // 
            // 
            // 
            // 
            this.LOM.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.LOM.Brush.Gradient.Transparency = 40;
            this.LOM.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.LOM.ColorEach = false;
            this.LOM.IrregularGrid = true;
            this.LOM.PaletteMin = 0D;
            this.LOM.PaletteStep = 0D;
            this.LOM.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            this.LOM.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.LOM.Title = "LOM";
            this.LOM.UseColorRange = false;
            // 
            // 
            // 
            this.LOM.XValues.DataMember = "X";
            // 
            // 
            // 
            this.LOM.YValues.DataMember = "Y";
            // 
            // 
            // 
            this.LOM.ZValues.DataMember = "Z";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1482, 752);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCMA-21 Fuzzy Inference System (Ass06)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gb_BOFS.ResumeLayout(false);
            this.gb_BOFS.PerformLayout();
            this.gb_UOFS.ResumeLayout(false);
            this.gb_UOFS.PerformLayout();
            this.gb_PFS.ResumeLayout(false);
            this.gb_PFS.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gb_FC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).EndInit();
            this.gb_FR.ResumeLayout(false);
            this.gb_FR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtFuzzyModel)).EndInit();
            this.gb_ST.ResumeLayout(false);
            this.gb_ST.PerformLayout();
            this.gb_Mamdani.ResumeLayout(false);
            this.gb_Mamdani.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PropertyGrid prgSelection;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btn_binary_op;
        private System.Windows.Forms.Label lab_FS_1;
        private System.Windows.Forms.Label lab_FS_2;
        private System.Windows.Forms.ComboBox cb_unaryOperator;
        private System.Windows.Forms.Button btn_unary_op;
        private System.Windows.Forms.ComboBox cb_binaryOperator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCreateAUniverse;
        private System.Windows.Forms.TreeView trvFuzzyModel;
        private System.Windows.Forms.Button btnAddFS;
        private System.Windows.Forms.ComboBox cb_FS;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btn_clear_lb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.DataGridView dgvCondition;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnInference;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox gb_PFS;
        private System.Windows.Forms.GroupBox gb_BOFS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gb_UOFS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb_FR;
        private System.Windows.Forms.GroupBox gb_FC;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtFuzzyModel;
        private System.Windows.Forms.Label lb_fuzzy_system;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Steema.TeeChart.TChart SurfaceChart;
        private System.Windows.Forms.Button btn_final_inferencing;
        private Steema.TeeChart.ChartController chartController1;
        private Steema.TeeChart.Styles.Surface COA;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lsbEuqations;
        private System.Windows.Forms.Button btnAddOutputEquation;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inferenceSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mamdaniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sugenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsukamotoToolStripMenuItem;
        private Steema.TeeChart.Styles.Surface BOA;
        private Steema.TeeChart.Styles.Surface MOM;
        private Steema.TeeChart.Styles.Surface SOM;
        private Steema.TeeChart.Styles.Surface LOM;
        private Steema.TeeChart.TChart LineChart;
        private Steema.TeeChart.Styles.Line COA_;
        private Steema.TeeChart.Styles.Line BOA_;
        private Steema.TeeChart.Styles.Line MOM_;
        private Steema.TeeChart.Styles.Line SOM_;
        private Steema.TeeChart.Styles.Line LOM_;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightedAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightedSumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightedAverageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weightedSumToolStripMenuItem1;
        private System.Windows.Forms.GroupBox gb_Mamdani;
        private System.Windows.Forms.RadioButton rb_M_Scale;
        private System.Windows.Forms.RadioButton rb_M_Cut;
        private System.Windows.Forms.RadioButton rb_ST_Sum;
        private System.Windows.Forms.GroupBox gb_ST;
        private System.Windows.Forms.RadioButton rb_ST_Average;
        private Steema.TeeChart.ChartController chartController2;
        private System.Windows.Forms.ComboBox cb_FS_monotonic;
    }
}

