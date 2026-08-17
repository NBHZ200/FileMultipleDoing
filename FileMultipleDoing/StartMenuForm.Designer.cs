namespace FileMultipleDoing
{
    partial class StartMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenuForm));
            btnCopyFiles = new Button();
            btnMultipleDoFileNames = new Button();
            btnOpenRootDirectory = new Button();
            ProjectName = new Label();
            SuspendLayout();
            // 
            // btnCopyFiles
            // 
            btnCopyFiles.Location = new Point(37, 90);
            btnCopyFiles.Name = "btnCopyFiles";
            btnCopyFiles.Size = new Size(237, 29);
            btnCopyFiles.TabIndex = 0;
            btnCopyFiles.Text = "按顺序批量复制文件";
            btnCopyFiles.UseVisualStyleBackColor = true;
            btnCopyFiles.Click += BtnCopyFiles_Click;
            // 
            // btnMultipleDoFileNames
            // 
            btnMultipleDoFileNames.Location = new Point(37, 125);
            btnMultipleDoFileNames.Name = "btnMultipleDoFileNames";
            btnMultipleDoFileNames.Size = new Size(237, 29);
            btnMultipleDoFileNames.TabIndex = 1;
            btnMultipleDoFileNames.Text = "批量操作文件名";
            btnMultipleDoFileNames.UseVisualStyleBackColor = true;
            btnMultipleDoFileNames.Click += BtnMultipleDoFileNames_Click;
            // 
            // btnOpenRootDirectory
            // 
            btnOpenRootDirectory.Location = new Point(37, 160);
            btnOpenRootDirectory.Name = "btnOpenRootDirectory";
            btnOpenRootDirectory.Size = new Size(237, 29);
            btnOpenRootDirectory.TabIndex = 2;
            btnOpenRootDirectory.Text = "打开软件根目录";
            btnOpenRootDirectory.UseVisualStyleBackColor = true;
            btnOpenRootDirectory.Click += BtnOpenRootDirectory_Click;
            // 
            // ProjectName
            // 
            ProjectName.AutoSize = true;
            ProjectName.Location = new Point(340, 33);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(114, 20);
            ProjectName.TabIndex = 3;
            ProjectName.Text = "文件批量操作器";
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ProjectName);
            Controls.Add(btnCopyFiles);
            Controls.Add(btnMultipleDoFileNames);
            Controls.Add(btnOpenRootDirectory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartMenuForm";
            Text = "文件批量操作器--起始菜单";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCopyFiles;
        private Button btnMultipleDoFileNames;
        private Button btnOpenRootDirectory;
        private Label ProjectName;
    }
}
