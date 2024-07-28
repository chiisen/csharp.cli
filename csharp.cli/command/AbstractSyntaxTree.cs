using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing;
using Console = Colorful.Console;

namespace csharp.cli;

public partial class Program
{
    /// <summary>
    /// 範例程式
    /// 命令列引數: Abstract Syntax Tree
    /// </summary>
    public static void AbstractSyntaxTree()
    {
        _ = App.Command("ast", command =>
        {
            // 第二層 Help 的標題
            command.Description = "AbstractSyntaxTree 說明";
            command.HelpOption("-?|-h|-help");

            command.OnExecute(() =>
            {
#region C# 抽象語法樹（Abstract Syntax Tree）的套件

                // C# 抽象語法樹（Abstract Syntax Tree）的套件
                string code = @"
            using System;

            // This is a single-line comment

            /* 
                This is a
                multi-line comment
            */

            class Program
            {
                static void Main()
                {
                    int a = 0;
                    if ( a == 0 )
                    {
                        Console.WriteLine(""Hello, World!"");
                    }
                }
            }
        ";
                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
                // 找出 class 名稱
                var rootClassName = syntaxTree.GetRoot();
                var classDeclaration = rootClassName.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (classDeclaration != null)
                {
                    string className = classDeclaration.Identifier.Text;
                    Console.WriteLine("Class Name: " + className);
                }
                else
                {
                    Console.WriteLine("Class not found!");
                }

                // 找出所有的註解
                var rootComment = syntaxTree.GetRoot();
                var comments = rootComment.DescendantTrivia()
                                    .Where(trivia => trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) || trivia.IsKind(SyntaxKind.MultiLineCommentTrivia))
                                    .Select(trivia => trivia.ToString());

                foreach (var comment in comments)
                {
                    Console.WriteLine("Comment: " + comment);
                }

#endregion C# 抽象語法樹（Abstract Syntax Tree）的套件


                Console.WriteLine($"Abstract Syntax Tree", Color.Azure);
                return 0;
            });
        });
    }
}