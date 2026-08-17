using System.Diagnostics;

namespace FileMultipleDoing
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //不允许修改大小
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //开启文件日志
            FileLog.Start();

            FileLog.WriteLog("软件启动");
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopyFiles_Click(object sender, EventArgs e)
        {
            CopyFilesForm copyFiles = new CopyFilesForm(this);
            copyFiles.ShowDialog();
        }

        /// <summary>
        /// 批量改文件名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMultipleDoFileNames_Click(object sender, EventArgs e)
        {
            MultipleDoFileNamesForm multipleDoFile = new MultipleDoFileNamesForm(
                this);
            multipleDoFile.ShowDialog();
        }

        /// <summary>
        /// 打开本软件根目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenRootDirectory_Click(object sender, EventArgs e)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start("explorer.exe", appDirectory);
        }
    }
}
