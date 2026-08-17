namespace FileMultipleDoing
{
    partial class CopyFilesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyFilesForm));
            textInputFolder = new TextBox();
            labelInputFolder = new Label();
            textOutputFolder = new TextBox();
            btnStartCopy = new Button();
            isSort = new CheckBox();
            textSortDelimiter = new TextBox();
            labelOutputFolder = new Label();
            labelTitle = new Label();
            progressBarCompletion = new ProgressBar();
            labelCompletion = new Label();
            labelSortBase = new Label();
            SuspendLayout();
            // 
            // textInputFolder
            // 
            textInputFolder.Location = new Point(46, 158);
            textInputFolder.Name = "textInputFolder";
            textInputFolder.Size = new Size(714, 27);
            textInputFolder.TabIndex = 1;
            textInputFolder.Text = "D:\\源文件夹";
            textInputFolder.TextAlign = HorizontalAlignment.Center;
            // 
            // labelInputFolder
            // 
            labelInputFolder.AutoSize = true;
            labelInputFolder.Location = new Point(340, 135);
            labelInputFolder.Name = "labelInputFolder";
            labelInputFolder.Size = new Size(99, 20);
            labelInputFolder.TabIndex = 2;
            labelInputFolder.Text = "源文件夹路径";
            // 
            // textOutputFolder
            // 
            textOutputFolder.Location = new Point(46, 233);
            textOutputFolder.Name = "textOutputFolder";
            textOutputFolder.Size = new Size(714, 27);
            textOutputFolder.TabIndex = 3;
            textOutputFolder.Text = "D:\\输出文件夹";
            textOutputFolder.TextAlign = HorizontalAlignment.Center;
            // 
            // btnStartCopy
            // 
            btnStartCopy.Location = new Point(331, 288);
            btnStartCopy.Name = "btnStartCopy";
            btnStartCopy.Size = new Size(123, 29);
            btnStartCopy.TabIndex = 4;
            btnStartCopy.Text = "开始复制文件";
            btnStartCopy.UseVisualStyleBackColor = true;
            btnStartCopy.Click += btnStartCopy_Click;
            // 
            // isSort
            // 
            isSort.AutoSize = true;
            isSort.Checked = true;
            isSort.CheckState = CheckState.Checked;
            isSort.Location = new Point(46, 52);
            isSort.Name = "isSort";
            isSort.RightToLeft = RightToLeft.No;
            isSort.Size = new Size(61, 24);
            isSort.TabIndex = 5;
            isSort.Text = "排序";
            isSort.UseVisualStyleBackColor = true;
            // 
            // textSortDelimiter
            // 
            textSortDelimiter.Location = new Point(46, 85);
            textSortDelimiter.Name = "textSortDelimiter";
            textSortDelimiter.Size = new Size(125, 27);
            textSortDelimiter.TabIndex = 6;
            textSortDelimiter.Text = ".";
            textSortDelimiter.TextAlign = HorizontalAlignment.Center;
            textSortDelimiter.TextChanged += textSortDelimiter_TextChanged;
            // 
            // labelOutputFolder
            // 
            labelOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelOutputFolder.AutoSize = true;
            labelOutputFolder.Location = new Point(340, 210);
            labelOutputFolder.Name = "labelOutputFolder";
            labelOutputFolder.Size = new Size(114, 20);
            labelOutputFolder.TabIndex = 7;
            labelOutputFolder.Text = "输出文件夹路径";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(321, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(144, 20);
            labelTitle.TabIndex = 8;
            labelTitle.Text = "文件按顺序批量复制";
            // 
            // progressBarCompletion
            // 
            progressBarCompletion.Location = new Point(46, 355);
            progressBarCompletion.Name = "progressBarCompletion";
            progressBarCompletion.Size = new Size(714, 29);
            progressBarCompletion.TabIndex = 9;
            // 
            // labelCompletion
            // 
            labelCompletion.AutoSize = true;
            labelCompletion.Location = new Point(370, 402);
            labelCompletion.Name = "labelCompletion";
            labelCompletion.Size = new Size(81, 20);
            labelCompletion.TabIndex = 10;
            labelCompletion.Text = "0／0　0％";
            // 
            // labelSortBase
            // 
            labelSortBase.AutoSize = true;
            labelSortBase.Location = new Point(177, 88);
            labelSortBase.Name = "labelSortBase";
            labelSortBase.Size = new Size(84, 20);
            labelSortBase.TabIndex = 11;
            labelSortBase.Text = "序号分隔符";
            // 
            // CopyFilesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelSortBase);
            Controls.Add(labelCompletion);
            Controls.Add(progressBarCompletion);
            Controls.Add(labelTitle);
            Controls.Add(labelOutputFolder);
            Controls.Add(textSortDelimiter);
            Controls.Add(isSort);
            Controls.Add(btnStartCopy);
            Controls.Add(textOutputFolder);
            Controls.Add(labelInputFolder);
            Controls.Add(textInputFolder);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CopyFilesForm";
            Text = "文件批量操作器--按顺序批量复制";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textInputFolder;
        private Label labelInputFolder;
        private TextBox textOutputFolder;
        private Button btnStartCopy;
        private CheckBox isSort;
        private TextBox textSortDelimiter;
        private Label labelOutputFolder;
        private Label labelTitle;
        private ProgressBar progressBarCompletion;
        private Label labelCompletion;
        private Label labelSortBase;
    }
}