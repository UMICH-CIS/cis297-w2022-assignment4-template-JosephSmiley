using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    public class DisplayFileInConsole
    {
        /// <summary>
        /// Outputs file to console
        /// </summary>
        public static void DisplayFile()
        {
            if (File.Exists(FileCreate.fileName))
            {
                StreamReader file = new StreamReader(FileCreate.fileName);
                string line;

                while((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                file.Close();
            }
        }
    }
}
