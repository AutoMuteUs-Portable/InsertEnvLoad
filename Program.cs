using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertEnvLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("main.go");
            List<string> newLines = new List<string>();

            for (var i = 0; i < allLines.Length; i++)
            {
                newLines.Add(allLines[i]);
                if (allLines[i].Contains("func main()"))
                {
                    newLines.Add("  _loadErr := load()");
                    newLines.Add("  if (_loadErr != nil) {");
                    newLines.Add("      log.Fatal(_loadErr)");
                    newLines.Add("  }");
                }
            }

            File.WriteAllLines("main.go", newLines);
        }
    }
}
