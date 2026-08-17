

namespace FileMultipleDoing
{
    public partial class CopyFilesForm : Form
    {
        /// <summary>
        /// 内部使用，是否排序。建议排序，不排序的话都是乱序。
        /// 值从控件读入。
        /// </summary>
        private bool isNameSort = true;

        /// <summary>
        /// 父窗口
        /// </summary>
        private StartMenuForm rootForm;

        public CopyFilesForm(StartMenuForm rootForm)
        {
            InitializeComponent();
            progressBarCompletion.Minimum = 0;
            progressBarCompletion.Maximum = 1000;
            //设置起始位置
            this.rootForm = rootForm;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = rootForm.Location;

            //不允许修改大小
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnStartCopy_Click(object sender, EventArgs e)
        {
            //显示百分比
            progressBarCompletion.Value = 0;
            labelCompletion.Text = "0／0　0%";
            labelCompletion.Refresh();
            this.Enabled = false;

            string inPath = textInputFolder.Text.Replace(@"\", @"/");
            string outPath = textOutputFolder.Text.Replace(@"\", @"/");

            if (inPath[inPath.Length - 1] != '/')
                inPath += "/";
            if (outPath[outPath.Length - 1] != '/')
                outPath += "/";

            isNameSort = isSort.Checked;

            CopyAllFiles(inPath, outPath);
        }


        public async Task CopyAllFiles(string inPath, string outPath)
        {

            if (!Directory.Exists(inPath))
            {
                MessageBox.Show("源文件夹不存在或异常，\n请检查。",
                    "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;

                return;
            }

            if (!Directory.Exists(outPath))
            {
                MessageBox.Show("输出文件夹不存在或异常，\n请检查。",
                    "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;

                return;
            }


            DirectoryInfo root = new DirectoryInfo(inPath);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles();


            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            int fileLength = files.Length;
            string[] fileNameList = new string[fileLength];

            for (int i = 0; i < fileLength; ++i)
            {
                fileNameList[i] = files[i].Name;
            }

            char cha = textSortDelimiter.Text[0];

            if (isNameSort)
                fileNameList = fileNameList.SortStr(cha);

            string listNames = fileNameList.AddUp("\n");

            byte[] bStream = System.Text.Encoding.Default.GetBytes(listNames);
            string txtPath = Directory.GetCurrentDirectory() + "/文件列表.txt";

            FileStream fsTxt = new FileStream(txtPath,
                FileMode.Create, FileAccess.ReadWrite);

            fsTxt.Write(bStream, 0, bStream.Length);
            fsTxt.Flush();
            fsTxt.Close();


            for (int j = 0; j < fileLength; ++j)
            {
                //显示百分比，进度条
                labelCompletion.Text = (j + 1) + "／" + fileLength + "　　" +
                    (((float)(j + 1) / (float)fileLength) * 100).ToString("F2") + "％";
                labelCompletion.Refresh();

                progressBarCompletion.Value =
                    (int)(((float)(j + 1) / (float)fileLength) * 1000f);

                await Copy(fileNameList[j], inPath, outPath);
            }

            this.Enabled = true;
            MessageBox.Show("复制完成。", "通知",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static readonly object writeFinishLock = new object();
        public static bool isRunning = false;
        private async Task Copy(string fileName, string inPath, string outPath)
        {
            try
            {
                lock (writeFinishLock)
                {
                    isRunning = true;
                    FileStream fs = new FileStream(inPath + fileName,
                        FileMode.Open, FileAccess.Read, FileShare.Read);

                    byte[] bs = new byte[fs.Length];
                    int ret = fs.Read(bs, 0, bs.Length);
                    fs.Flush();
                    fs.Close();

                    FileStream fsWrite = new FileStream(outPath + fileName,
                        FileMode.Create, FileAccess.ReadWrite);
                    fsWrite.Write(bs, 0, bs.Length);
                    fsWrite.Flush();
                    fsWrite.Close();
                    isRunning = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            // 这里处理位置改变的逻辑
            //MessageBox.Show($"窗体位置已改变: X={this.Left}, Y={this.Top}");
            if (this != null && rootForm != null)
            {
                rootForm.Left = this.Left;
                rootForm.Top = this.Top;
            }

        }

        private void textSortDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (textSortDelimiter.Text.Length > 1)
                textSortDelimiter.Text = textSortDelimiter.Text[0].ToString();
        }
    }
}
