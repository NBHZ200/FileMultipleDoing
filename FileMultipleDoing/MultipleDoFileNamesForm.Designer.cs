namespace FileMultipleDoing
{
    partial class MultipleDoFileNamesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleDoFileNamesForm));
            comboBoxNumberChangeMode = new ComboBox();
            checkBoxToSImple = new CheckBox();
            checkBoxIncludeRoot = new CheckBox();
            checkBoxIncludeChildDir = new CheckBox();
            textBoxStartNumber = new TextBox();
            textBoxDelimiter = new TextBox();
            textBoxSourceFolder = new TextBox();
            buttonSampleOrTraditional = new Button();
            buttonChangeNumber = new Button();
            buttonChangeNumberMutiple = new Button();
            buttonChangeFileName_MyCode = new Button();
            labelStartNumber = new Label();
            labelDelimiter = new Label();
            labelNumberChangeMode = new Label();
            labelSourceFolder = new Label();
            labelTitle = new Label();
            buttonOpenRoot = new Button();
            buttonOpenSourceDir = new Button();
            SuspendLayout();
            // 
            // comboBoxNumberChangeMode
            // 
            comboBoxNumberChangeMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNumberChangeMode.FormattingEnabled = true;
            comboBoxNumberChangeMode.Items.AddRange(new object[] { "序号不变", "批量添加序号", "批量删除序号" });
            comboBoxNumberChangeMode.Location = new Point(494, 140);
            comboBoxNumberChangeMode.Name = "comboBoxNumberChangeMode";
            comboBoxNumberChangeMode.Size = new Size(281, 28);
            comboBoxNumberChangeMode.TabIndex = 0;
            // 
            // checkBoxToSImple
            // 
            checkBoxToSImple.AutoSize = true;
            checkBoxToSImple.Checked = true;
            checkBoxToSImple.CheckState = CheckState.Checked;
            checkBoxToSImple.Location = new Point(28, 53);
            checkBoxToSImple.Name = "checkBoxToSImple";
            checkBoxToSImple.Size = new Size(106, 24);
            checkBoxToSImple.TabIndex = 1;
            checkBoxToSImple.Text = "转为简体字";
            checkBoxToSImple.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeRoot
            // 
            checkBoxIncludeRoot.AutoSize = true;
            checkBoxIncludeRoot.Location = new Point(28, 83);
            checkBoxIncludeRoot.Name = "checkBoxIncludeRoot";
            checkBoxIncludeRoot.Size = new Size(376, 24);
            checkBoxIncludeRoot.TabIndex = 2;
            checkBoxIncludeRoot.Text = "繁简转换包含源文件夹名字（转换后注意重写路径）";
            checkBoxIncludeRoot.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeChildDir
            // 
            checkBoxIncludeChildDir.AutoSize = true;
            checkBoxIncludeChildDir.Location = new Point(28, 113);
            checkBoxIncludeChildDir.Name = "checkBoxIncludeChildDir";
            checkBoxIncludeChildDir.Size = new Size(121, 24);
            checkBoxIncludeChildDir.TabIndex = 3;
            checkBoxIncludeChildDir.Text = "包含子文件夹";
            checkBoxIncludeChildDir.UseVisualStyleBackColor = true;
            // 
            // textBoxStartNumber
            // 
            textBoxStartNumber.Location = new Point(494, 75);
            textBoxStartNumber.Name = "textBoxStartNumber";
            textBoxStartNumber.Size = new Size(125, 27);
            textBoxStartNumber.TabIndex = 4;
            textBoxStartNumber.Text = "1";
            textBoxStartNumber.TextAlign = HorizontalAlignment.Center;
            textBoxStartNumber.TextChanged += textBoxStartNumber_TextChanged;
            // 
            // textBoxDelimiter
            // 
            textBoxDelimiter.Location = new Point(650, 75);
            textBoxDelimiter.Name = "textBoxDelimiter";
            textBoxDelimiter.Size = new Size(125, 27);
            textBoxDelimiter.TabIndex = 5;
            textBoxDelimiter.Text = ".";
            textBoxDelimiter.TextAlign = HorizontalAlignment.Center;
            textBoxDelimiter.TextChanged += textBoxDelimiter_TextChanged;
            // 
            // textBoxSourceFolder
            // 
            textBoxSourceFolder.Location = new Point(28, 232);
            textBoxSourceFolder.Name = "textBoxSourceFolder";
            textBoxSourceFolder.Size = new Size(747, 27);
            textBoxSourceFolder.TabIndex = 6;
            textBoxSourceFolder.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonSampleOrTraditional
            // 
            buttonSampleOrTraditional.Location = new Point(28, 288);
            buttonSampleOrTraditional.Name = "buttonSampleOrTraditional";
            buttonSampleOrTraditional.Size = new Size(170, 120);
            buttonSampleOrTraditional.TabIndex = 7;
            buttonSampleOrTraditional.Text = "转简体字\n或繁体字";
            buttonSampleOrTraditional.UseVisualStyleBackColor = true;
            buttonSampleOrTraditional.Click += buttonSampleOrTraditional_Click;
            // 
            // buttonChangeNumber
            // 
            buttonChangeNumber.Location = new Point(215, 288);
            buttonChangeNumber.Name = "buttonChangeNumber";
            buttonChangeNumber.Size = new Size(170, 120);
            buttonChangeNumber.TabIndex = 8;
            buttonChangeNumber.Text = "增删序号\n（每文件夹重新计数）";
            buttonChangeNumber.UseVisualStyleBackColor = true;
            buttonChangeNumber.Click += buttonChangeNumber_Click;
            // 
            // buttonChangeNumberMutiple
            // 
            buttonChangeNumberMutiple.Location = new Point(408, 288);
            buttonChangeNumberMutiple.Name = "buttonChangeNumberMutiple";
            buttonChangeNumberMutiple.Size = new Size(170, 120);
            buttonChangeNumberMutiple.TabIndex = 9;
            buttonChangeNumberMutiple.Text = "增删序号\n（多文件夹顺延）";
            buttonChangeNumberMutiple.UseVisualStyleBackColor = true;
            buttonChangeNumberMutiple.Click += buttonChangeNumberMutiple_Click;
            // 
            // buttonChangeFileName_MyCode
            // 
            buttonChangeFileName_MyCode.Location = new Point(595, 288);
            buttonChangeFileName_MyCode.Name = "buttonChangeFileName_MyCode";
            buttonChangeFileName_MyCode.Size = new Size(170, 120);
            buttonChangeFileName_MyCode.TabIndex = 10;
            buttonChangeFileName_MyCode.Text = "执行自定义代码\n改变文件名\n\n命名规则.cs";
            buttonChangeFileName_MyCode.UseVisualStyleBackColor = true;
            buttonChangeFileName_MyCode.Click += buttonChangeFileName_MyCode_Click;
            // 
            // labelStartNumber
            // 
            labelStartNumber.AutoSize = true;
            labelStartNumber.Location = new Point(494, 53);
            labelStartNumber.Name = "labelStartNumber";
            labelStartNumber.Size = new Size(69, 20);
            labelStartNumber.TabIndex = 11;
            labelStartNumber.Text = "起始序号";
            // 
            // labelDelimiter
            // 
            labelDelimiter.AutoSize = true;
            labelDelimiter.Location = new Point(650, 52);
            labelDelimiter.Name = "labelDelimiter";
            labelDelimiter.Size = new Size(84, 20);
            labelDelimiter.TabIndex = 12;
            labelDelimiter.Text = "序号分隔符";
            // 
            // labelNumberChangeMode
            // 
            labelNumberChangeMode.AutoSize = true;
            labelNumberChangeMode.Location = new Point(494, 117);
            labelNumberChangeMode.Name = "labelNumberChangeMode";
            labelNumberChangeMode.Size = new Size(99, 20);
            labelNumberChangeMode.TabIndex = 13;
            labelNumberChangeMode.Text = "序号变更方式";
            // 
            // labelSourceFolder
            // 
            labelSourceFolder.AutoSize = true;
            labelSourceFolder.Location = new Point(334, 206);
            labelSourceFolder.Name = "labelSourceFolder";
            labelSourceFolder.Size = new Size(99, 20);
            labelSourceFolder.TabIndex = 14;
            labelSourceFolder.Text = "源文件夹路径";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(355, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(99, 20);
            labelTitle.TabIndex = 15;
            labelTitle.Text = "文件批量改名";
            // 
            // buttonOpenRoot
            // 
            buttonOpenRoot.Location = new Point(28, 162);
            buttonOpenRoot.Name = "buttonOpenRoot";
            buttonOpenRoot.Size = new Size(177, 29);
            buttonOpenRoot.TabIndex = 16;
            buttonOpenRoot.Text = "打开本软件根目录";
            buttonOpenRoot.UseVisualStyleBackColor = true;
            buttonOpenRoot.Click += buttonOpenRoot_Click;
            // 
            // buttonOpenSourceDir
            // 
            buttonOpenSourceDir.Location = new Point(28, 197);
            buttonOpenSourceDir.Name = "buttonOpenSourceDir";
            buttonOpenSourceDir.Size = new Size(177, 29);
            buttonOpenSourceDir.TabIndex = 17;
            buttonOpenSourceDir.Text = "打开源文件夹路径";
            buttonOpenSourceDir.UseVisualStyleBackColor = true;
            buttonOpenSourceDir.Click += buttonOpenSourceDir_Click;
            // 
            // MultipleDoFileNamesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonOpenSourceDir);
            Controls.Add(buttonOpenRoot);
            Controls.Add(labelTitle);
            Controls.Add(labelSourceFolder);
            Controls.Add(labelNumberChangeMode);
            Controls.Add(labelDelimiter);
            Controls.Add(labelStartNumber);
            Controls.Add(buttonChangeFileName_MyCode);
            Controls.Add(buttonChangeNumberMutiple);
            Controls.Add(buttonChangeNumber);
            Controls.Add(buttonSampleOrTraditional);
            Controls.Add(textBoxSourceFolder);
            Controls.Add(textBoxDelimiter);
            Controls.Add(textBoxStartNumber);
            Controls.Add(checkBoxIncludeChildDir);
            Controls.Add(checkBoxIncludeRoot);
            Controls.Add(checkBoxToSImple);
            Controls.Add(comboBoxNumberChangeMode);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MultipleDoFileNamesForm";
            Text = "文件批量操作器--批量改名";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxNumberChangeMode;
        private CheckBox checkBoxToSImple;
        private CheckBox checkBoxIncludeRoot;
        private CheckBox checkBoxIncludeChildDir;
        private TextBox textBoxStartNumber;
        private TextBox textBoxDelimiter;
        private TextBox textBoxSourceFolder;
        private Button buttonSampleOrTraditional;
        private Button buttonChangeNumber;
        private Button buttonChangeNumberMutiple;
        private Button buttonChangeFileName_MyCode;
        private Label labelStartNumber;
        private Label labelDelimiter;
        private Label labelNumberChangeMode;
        private Label labelSourceFolder;
        private Label labelTitle;
        private Button buttonOpenRoot;
        private Button buttonOpenSourceDir;
    }
}