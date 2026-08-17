using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Text;

namespace FileMultipleDoing
{
    public class DoMyCodes
    {

        public void ReadCode()
        {
            GetCsharpCode();
            EmitCodes(code);
        }


        /// <summary>
        /// 代码
        /// </summary>
        protected string m_code;

        /// <summary>
        /// 代码
        /// </summary>
        public string code
        {
            get { return m_code; }
            set { m_code = value; }
        }

        /// <summary>
        /// 读入自定义的C#代码，写在code里面。
        /// </summary>
        protected void GetCsharpCode()
        {
            string path = Directory.GetCurrentDirectory().Replace(@"\", @"/");

            if (path[path.Length - 1] != '/')
                path += "/";

            FileStream fs = new FileStream(path + "命名规则.cs", FileMode.Open, FileAccess.Read);
            byte[] bs = new byte[fs.Length];
            fs.Read(bs, 0, bs.Length);
            fs.Flush();
            fs.Close();

            code = Encoding.Unicode.GetString(bs);
        }

        /// <summary>
        /// 编译器
        /// </summary>
        protected CSharpCompilation comp;

        /// <summary>
        /// 编译结果
        /// </summary>
        protected EmitResult emitResult;

        /// <summary>
        /// 程序集
        /// </summary>
        protected Assembly assembly;

        /// <summary>
        /// 读入的类型（非实例）
        /// </summary>
        protected Type type;

        /// <summary>
        /// 类实例
        /// </summary>
        protected object myInstantiation;

        /// <summary>
        /// 方法——通知
        /// </summary>
        protected MethodInfo methodNotice;

        /// <summary>
        /// 方法——修改文件名
        /// </summary>
        protected MethodInfo methodChangeFileName;

        /// <summary>
        /// 保证程序集不重名
        /// </summary>
        protected int addProgramNumber = 0;

        /// <summary>
        /// 清除程序集
        /// </summary>
        public void Clear()
        {
            comp = null;
            emitResult = null;
            assembly = null;
            type = null;
            myInstantiation = null;
            methodNotice = null;
            methodChangeFileName = null;
            System.GC.Collect();
        }


        /// <summary>
        /// 编译代码，实例化类，但不执行。
        /// </summary>
        /// <param name="code">代码字符串</param>
        protected void EmitCodes(string code)
        {
            try
            {
                //创建编译器
                comp = CSharpCompilation.Create("Program" + addProgramNumber++)
                    .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

                //依赖程序集
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

                //筛选依赖程序集
                List<MetadataReference> metas = new List<MetadataReference>();

                for (int i = 0; i < assemblies.Length; ++i)
                {
                    if (!assemblies[i].IsDynamic)
                    {
                        //淘汰掉释放的assembly
                        if (assemblies[i].Location != "")
                        {
                            metas.Add(MetadataReference.CreateFromFile(assemblies[i].Location));
                        }
                        else
                        {
                            //.Net 不允许卸载一个已经加载的 Assmbly，只能卸载整个 AppDomain。
                            //AppDomain.Unload()
                            assemblies[i] = null;
                        }
                    }
                }

                //添加依赖
                comp = comp.AddReferences(metas.ToArray());
                //添加语法树
                comp = comp.AddSyntaxTrees(CSharpSyntaxTree.ParseText(code));


            }
            catch (Exception e)
            {
                if (comp != null)
                {
                    Console.WriteLine("编译报错，信息如下：" + e);

                    return;

                }
            }

            // 执行编译
            using (MemoryStream stream = new MemoryStream())
            {
                //编译结果
                emitResult = comp.Emit(stream);
                if (emitResult.Success)
                {
                    stream.Position = 0;  // 读取位置重置到开头
                    assembly = Assembly.Load(stream.GetBuffer());

                    //创建类
                    type = assembly.GetType("MyStringCodeClass");
                    if (type == null)
                    {
                        Console.WriteLine("动态代码编译错误：找不到MyStringCodeClass类");
                        return;
                    }

                    myInstantiation = Activator.CreateInstance(type);
                    methodChangeFileName = type.GetMethod("DoMyStringCode");
                    methodNotice = type.GetMethod("NoticeDirPathAndFileCount");

                    if (methodChangeFileName == null || methodNotice == null)
                    {
                        Console.WriteLine("动态代码编译错误：找不到函数");
                        return;
                    }
                }
                else
                {
                    foreach (Diagnostic diagnostic in emitResult.Diagnostics)
                    {
                        Console.WriteLine("动态代码编译错误：" + diagnostic);
                    }
                }
            }
        }

        /// <summary>
        /// 执行通知方法
        /// </summary>
        /// <param name="dirPath">文件夹路径</param>
        /// <param name="isChildDir">是子文件夹</param>
        /// <param name="childDirOrderNumber">子文件夹内置序号-从0开始。非子文件夹是-1</param>
        /// <param name="fileCount">本文件夹的文件数量（不包含子文件夹）</param>
        public void InvokeNoticeMethod(string dirPath, bool isChildDir, int childDirOrderNumber, int fileCount)
        {
            methodNotice.Invoke(myInstantiation, new object[4] { dirPath, isChildDir, childDirOrderNumber, fileCount });
        }

        /// <summary>
        /// 执行修改文件名方法
        /// </summary>
        /// <param name="orderNumber">内置文件序号</param>
        /// <param name="fileName">原本的文件名</param>
        /// <param name="fileFullName">文件完整路径</param>
        /// <returns>返回值是新的文件名</returns>
        public string InvokeChangeFileNameMethod(int orderNumber, string fileName, string fieFullName)
        {
            object obj = methodChangeFileName.Invoke(myInstantiation, new object[3] { orderNumber, fileName, fieFullName });
            return (string)obj;
        }
    }
}