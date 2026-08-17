using System.Diagnostics;
using System.Text;


namespace FileMultipleDoing
{
    public partial class MultipleDoFileNamesForm : Form
    {
        /// <summary>
        /// 父窗口
        /// </summary>
        private StartMenuForm rootForm;

        /// <summary>
        /// 读入后的简繁对照表
        /// </summary>
        private String2[] str2ChangeList = null;

        /// <summary>
        /// 程序根目录
        /// </summary>
        private string thisPath = "";

        /// <summary>
        /// 自己的代码操作类
        /// </summary>
        public DoMyCodes doMyCodes;

        public MultipleDoFileNamesForm(StartMenuForm rootForm)
        {
            InitializeComponent();
            //模式为序号不变
            comboBoxNumberChangeMode.SelectedIndex = 0;
            //设置窗口起始位置
            this.rootForm = rootForm;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = rootForm.Location;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //创建测试文件夹
            string pathTest = Directory.GetCurrentDirectory() + "\\测试文件夹";
            if (!Directory.Exists(pathTest))
            {
                Directory.CreateDirectory(pathTest);
            }
            textBoxSourceFolder.Text = pathTest;

            //获取根目录路径
            thisPath = Directory.GetCurrentDirectory().Replace(@"\", @"/");

            //读入简繁对照表
            GetChangeTxt();

            //实例化代码执行类
            doMyCodes = new DoMyCodes();
        }

        /// <summary>
        /// 读入简繁对照表
        /// </summary>
        public void GetChangeTxt()
        {
            string path = Directory.GetCurrentDirectory().Replace(@"\", @"/");

            if (path[path.Length - 1] != '/')
                path += "/";

            FileStream fs = new FileStream(path + "简繁对照表.txt",
                FileMode.Open, FileAccess.Read);
            byte[] bs = new byte[fs.Length];
            fs.Read(bs, 0, bs.Length);
            fs.Flush();
            fs.Close();

            string str = Encoding.Unicode.GetString(bs).Replace("\r", "").Replace("，", ",");


            string[] strs = str.Split('\n');
            int strsLen = strs.Length;
            str2ChangeList = new String2[strsLen];
            string[] str2block = new string[2];
            str2block[0] = "";
            str2block[1] = "";
            for (int i = 0; i < strsLen; ++i)
            {
                str2block = strs[i].Split(',');
                str2ChangeList[i] = new String2();
                str2ChangeList[i].str1 = str2block[1];
                str2ChangeList[i].str2 = str2block[0];
            }

        }

        /// <summary>
        /// 简繁互转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSampleOrTraditional_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AllSimpleOrTraditionalChange(textBoxSourceFolder.Text, true);
            this.Enabled = true;
            MessageBox.Show("处理完成。", "通知", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 全部转换
        /// </summary>
        /// <param name="path"></param>
        public void AllSimpleOrTraditionalChange(string path, bool isRootPath)
        {
            path = path.Replace(@"\", @"/");
            bool isSimple = checkBoxToSImple.Checked;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] paths = path.Split('/');
            string pathSimple = "", pathTraditional = "";
            for (int i = 0; i < paths.Length - 1; ++i)
            {
                pathSimple += paths[i] + "/";
                pathTraditional += paths[i] + "/";
            }

            if (isRootPath && !checkBoxIncludeRoot.Checked)
            {
                pathSimple += paths[paths.Length - 1];
                pathTraditional += paths[paths.Length - 1];
            }
            else
            {
                pathSimple += paths[paths.Length - 1].ToSimpleChinese(str2ChangeList);
                pathTraditional += paths[paths.Length - 1].ToTraditionalChinese(str2ChangeList);
            }

            if (isSimple)
            {
                if (path != pathSimple && path != thisPath)
                {
                    try
                    {
                        Directory.Move(path, pathSimple);
                        path = pathSimple;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            else
            {
                if (path != pathTraditional && path != thisPath)
                {
                    try
                    {
                        Directory.Move(path, pathTraditional);
                        path = pathTraditional;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }

            if (path[path.Length - 1] != '/')
                path += "/";

            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles();

            int fileLength = files.Length;
            string[] fileNameList = new string[fileLength];
            string[] fileNewNameList = new string[fileLength];
            bool isChild = checkBoxIncludeChildDir.Checked;

            for (int i = 0; i < fileLength; ++i)
            {
                fileNameList[i] = files[i].Name;
                if (isSimple)
                    fileNewNameList[i] = fileNameList[i].ToSimpleChinese(str2ChangeList);
                else if (!isSimple)
                    fileNewNameList[i] = fileNameList[i].ToTraditionalChinese(str2ChangeList);
            }

            for (int j = 0; j < fileLength; ++j)
            {
                ChangeFileName(fileNameList[j], fileNewNameList[j], path);
            }

            if (isChild)
            {

                string[] dirNames = new string[dics.Length];
                for (int j = 0; j < dics.Length; ++j)
                {
                    dirNames[j] = dics[j].FullName;
                }

                dirNames = dirNames.SortByFileName();


                for (int j = 0; j < dics.Length; ++j)
                {
                    if (!checkBoxIncludeRoot.Checked)
                    {
                        if (dirNames[j].Replace(@"\", @"/") != thisPath)
                            AllSimpleOrTraditionalChange(dirNames[j], false);
                    }
                    else
                    {
                        if (isSimple)
                        {
                            if (dirNames[j].Replace(@"\", @"/") != pathSimple)
                                AllSimpleOrTraditionalChange(dirNames[j], false);
                        }
                        else
                        {
                            if (dirNames[j].Replace(@"\", @"/") != pathTraditional)
                                AllSimpleOrTraditionalChange(dirNames[j], false);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 修改文件名
        /// </summary>
        /// <returns>真：修改成功；假：修改失败</returns>
        public bool ChangeFileName(string oldName, string newName, string path)
        {
            string oldPath = path + oldName;
            string newPath = path + newName;

            if (File.Exists(newPath))
                return false;
            try
            {
                if (File.Exists(oldPath))
                {
                    FileInfo fi = new FileInfo(oldPath);
                    fi.MoveTo(newPath);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 增删序号（每文件夹重新计数）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangeNumber_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AllNumberChange(textBoxSourceFolder.Text);

            this.Enabled = true;
            MessageBox.Show("处理完成", "通知",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 递归调用计数
        /// </summary>
        private int goNum = 1;
        /// <summary>
        /// 增删序号（多文件夹顺延）
        /// </summary>
        private void buttonChangeNumberMutiple_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            goNum = int.Parse(textBoxStartNumber.Text);
            AllNumberChange_SY(textBoxSourceFolder.Text, goNum);

            this.Enabled = true;
            MessageBox.Show("处理完成", "通知",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// 全部转换（序号）
        /// </summary>
        /// <param name="path"></param>
        public void AllNumberChange(string path)
        {
            path = path.Replace(@"\", @"/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            char sep = '.';
            if (textBoxDelimiter.Text != "")
                sep = textBoxDelimiter.Text[0];

            int countNum = 1;
            try
            {
                countNum = int.Parse(textBoxStartNumber.Text);
            }
            catch (Exception e)
            {
                if (e != null)
                    countNum = 1;
            }

            if (path[path.Length - 1] != '/')
                path += "/";

            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles().SortByFileName();

            int fileLength = files.Length;
            string[] fileNameList = new string[fileLength];
            string[] fileNewNameList = new string[fileLength];
            bool isChild = checkBoxIncludeChildDir.Checked;

            for (int b = 0; b < fileLength; ++b)
            {
                fileNameList[b] = files[b].Name;
            }


            for (int i = 0; i < fileLength; ++i)
            {
                if (comboBoxNumberChangeMode.SelectedIndex == 0)
                    fileNewNameList[i] = fileNameList[i];
                else if (comboBoxNumberChangeMode.SelectedIndex == 1)
                {
                    fileNewNameList[i] = fileNameList[i].AddNumber(countNum++, sep);
                }
                else if (comboBoxNumberChangeMode.SelectedIndex == 2)
                {
                    fileNewNameList[i] = fileNameList[i].DeleteNumber(sep, files[i].FullName);
                }
            }

            for (int j = 0; j < fileLength; ++j)
            {
                ChangeFileName(fileNameList[j], fileNewNameList[j], path);
            }

            if (isChild)
            {
                for (int j = 0; j < dics.Length; ++j)
                {
                    if (dics[j].FullName.Replace(@"\", @"/") != thisPath)
                        AllNumberChange(dics[j].FullName);
                }
            }
        }


        /// <summary>
        /// 全部转换（序号）-多文件夹顺延
        /// </summary>
        /// <param name="path"></param>
        public void AllNumberChange_SY(string path, int gogoNum)
        {
            path = path.Replace(@"\", @"/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            char sep = '.';
            if (textBoxDelimiter.Text != "")
                sep = textBoxDelimiter.Text[0];

            int countNum = 1;
            try
            {
                countNum = gogoNum;
            }
            catch (Exception e)
            {
                if (e != null)
                    countNum = 1;
            }

            if (path[path.Length - 1] != '/')
                path += "/";

            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles().SortByFileName();

            int fileLength = files.Length;
            string[] fileNameList = new string[fileLength];
            string[] fileNewNameList = new string[fileLength];
            bool isChild = checkBoxIncludeChildDir.Checked;

            for (int b = 0; b < fileLength; ++b)
            {
                fileNameList[b] = files[b].Name;
            }


            for (int i = 0; i < fileLength; ++i)
            {
                if (comboBoxNumberChangeMode.SelectedIndex == 0)
                    fileNewNameList[i] = fileNameList[i];
                else if (comboBoxNumberChangeMode.SelectedIndex == 1)
                {
                    fileNewNameList[i] = fileNameList[i].AddNumber(countNum++, sep);
                }
                else if (comboBoxNumberChangeMode.SelectedIndex == 2)
                {
                    fileNewNameList[i] = fileNameList[i].DeleteNumber(sep, files[i].FullName);
                }
            }

            for (int j = 0; j < fileLength; ++j)
            {
                ChangeFileName(fileNameList[j], fileNewNameList[j], path);
            }

            goNum += fileLength;

            if (isChild)
            {
                string[] dirNames = new string[dics.Length];
                for (int j = 0; j < dics.Length; ++j)
                {
                    dirNames[j] = dics[j].FullName;
                }

                dirNames = dirNames.SortByFileName();

                //改写子文件夹
                for (int j = 0; j < dics.Length; ++j)
                {
                    if (dirNames[j].Replace(@"\", @"/") != thisPath)
                        AllNumberChange_SY(dirNames[j], goNum);
                }
            }

        }

        /// <summary>
        /// 执行自定义代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangeFileName_MyCode_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //读入自定义C#代码
            doMyCodes.ReadCode();

            AllFileNameChange_MyCode(textBoxSourceFolder.Text, false, -1);

            //清除代码
            doMyCodes.Clear();
            this.Enabled = true;
            MessageBox.Show("处理完成", "通知",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// 全部转换（自定义代码）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="isChildDir">是子文件夹</param>
        /// <param name="childDirOrderNumber">子文件夹内置序号-从0开始。非子文件夹是-1</param>
        public void AllFileNameChange_MyCode(string path, bool isChildDir, int childDirOrderNumber)
        {
            try
            {
                path = path.Replace(@"\", @"/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (path[path.Length - 1] != '/')
                    path += "/";

                DirectoryInfo root = new DirectoryInfo(path);
                DirectoryInfo[] dics = root.GetDirectories();
                FileInfo[] files = root.GetFiles().SortByFileName();

                int fileLength = files.Length;
                string[] fileNameList = new string[fileLength];
                string[] fileNewNameList = new string[fileLength];
                bool isChild = checkBoxIncludeChildDir.Checked;

                doMyCodes.InvokeNoticeMethod(path, isChildDir, childDirOrderNumber, fileLength);


                for (int i = 0; i < fileLength; ++i)
                {
                    fileNameList[i] = files[i].Name;
                }

                //排序
                //fileNameList = fileNameList.SortByFileName();


                //改名
                for (int i = 0; i < fileLength; ++i)
                {
                    fileNewNameList[i] = doMyCodes.InvokeChangeFileNameMethod(i, fileNameList[i], files[i].FullName);
                }

                for (int j = 0; j < fileLength; ++j)
                {
                    ChangeFileName(fileNameList[j], fileNewNameList[j], path);
                }



                if (isChild)
                {
                    string[] dirNames = new string[dics.Length];
                    for (int j = 0; j < dics.Length; ++j)
                    {
                        dirNames[j] = dics[j].FullName;
                    }

                    dirNames = dirNames.SortByFileName();


                    for (int j = 0; j < dics.Length; ++j)
                    {
                        if (dirNames[j].Replace(@"\", @"/") != thisPath)
                            AllFileNameChange_MyCode(dirNames[j], true, j);
                    }
                }
            }
            catch (Exception e)
            {
                //doing.SetActive(false);
                throw (new Exception("执行失败！详细如下：\n" + e.ToString()));
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

        private void textBoxStartNumber_TextChanged(object sender, EventArgs e)
        {
            string str = textBoxStartNumber.Text;
            string ret = "";
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] >= '0' && str[i] <= '9')
                    ret += str[i];
                else if (i == 0 && str[i] == '-')
                    ret += str[i];
            }
            textBoxStartNumber.Text = ret;
        }

        private void textBoxDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDelimiter.Text.Length > 1)
                textBoxDelimiter.Text = textBoxDelimiter.Text[0].ToString();
        }

        /// <summary>
        /// 打开本软件根目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenRoot_Click(object sender, EventArgs e)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start("explorer.exe", appDirectory);
        }

        /// <summary>
        /// 打开源文件夹路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenSourceDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", textBoxSourceFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("源文件夹路径有问题，请检查", "通知", MessageBoxButtons.OK);
            }
        }
    }
}
