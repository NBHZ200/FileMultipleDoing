using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;



public static class Example
{
    
    // 编译一段保存在字符串里的C#代码并执行
    public static void RunCode(this string code)
    {
        // 创建编译器
        CSharpCompilation comp = CSharpCompilation.Create("Program")
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic)
            .Select(a => MetadataReference.CreateFromFile(a.Location)))
            .AddSyntaxTrees(CSharpSyntaxTree.ParseText(code));

        // 执行编译
        using (MemoryStream stream = new MemoryStream())
        {
            //编译结果
            EmitResult emitResult = comp.Emit(stream);
            if (emitResult.Success)
            {
                stream.Position = 0;  // 读取位置重置到开头
                Assembly assembly = Assembly.Load(stream.GetBuffer());
                Type type = assembly.GetType("MyStringCode");
                if (type == null)
                {
                    Console.WriteLine("动态代码编译错误：找不到MyClass类");
                    return;
                }
                object myInstantiation = Activator.CreateInstance(type);
                MethodInfo met = type.GetMethod("Method");
                met.Invoke(myInstantiation, new string[1] { "aa" });

                MethodInfo method = type.GetMethod("Main", BindingFlags.Static | BindingFlags.Public);
                if (method == null)
                {
                    Console.WriteLine("动态代码编译错误：找不到静态Main函数");
                    return;
                }
                method.Invoke(null, null);
                Console.WriteLine("动态代码编译并执行成功！");
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
}

