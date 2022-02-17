using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    public class FindID
    {
        /// <summary>
        /// Finds patient whos ID is specified by the param num
        /// </summary>
        /// <param name="num"></param>
        public static void IDFinder(string num)
        {
            string lastLine = "empty";
            string line2;
            using (StreamReader reader = new StreamReader(FileCreate.fileName))
            {
                while (!reader.EndOfStream)
                {
                    lastLine = reader.ReadLine();
                    if(reader.Peek() == -1)
                    {
                        reader.DiscardBufferedData();
                        reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        break;
                    }
                }
                foreach (string line in File.ReadLines(FileCreate.fileName))
                {
                    line2 = reader.ReadLine();
                    if (line.Contains(num))
                    {
                        Console.WriteLine(line2);
                        line2 = reader.ReadLine();
                        Console.WriteLine(line2);
                        line2 = reader.ReadLine();
                        Console.WriteLine(line2);
                        break;
                    }
                    if (line2 == lastLine)
                    {
                        Console.Write("No results found for patient ID {0}", num);
                        break;
                    }
                }
                reader.Close();
            }
        }
    }
}
