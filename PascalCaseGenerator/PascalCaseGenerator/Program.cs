using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PascalCaseGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("This tool helps to transform upper case into pascal case!");
            var path = @"C:\Users\yks57\Downloads\pascaltest.txt";
            Console.WriteLine("Path is to set in program.\r\nDo you want to use path include program?\r\n(YES : y, No : n)");
            var isUsePath = Console.ReadLine();
            if (!isUsePath.Equals("y"))
            {
                Console.WriteLine("Input file path!");
                path = Console.ReadLine();
            }
            var beforePascal = "";
            try
            {
                using (var sr = new StreamReader(path))
                {
                    beforePascal = sr.ReadToEnd();
                }
                var beforePascalList = beforePascal.Split(new[] { "\r\n" }, StringSplitOptions.None);
                var result = "";
                foreach (var item in beforePascalList)
                {
                    var itemList = item.Split('_');
                    foreach (var tynyItem in itemList)
                    {
                        if (tynyItem != "")
                        {
                            var first = tynyItem.First();
                            var last = tynyItem.ToLower().Substring(1, tynyItem.Length - 1);
                            result += first + last;
                        }
                    }
                    result += "\r\n";
                }
                Console.WriteLine(result);
                Clipboard.SetText(result);
                Console.WriteLine("Pascal case is set up into clipboard!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error is occured!\r\nHere is a error message.\r\n" + e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("End of program...");
                Console.ReadLine();
            }
        }
    }
}
