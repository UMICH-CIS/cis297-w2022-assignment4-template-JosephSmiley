using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    public class MinBalanceDue
    {
        /// <summary>
        /// Finds and outputs the patients who have a balance owed greater than or equal to param balance
        /// </summary>
        /// <param name="balance"></param>
        public static void FindMinBalance(decimal balance)
        {
            string lastLine = "empty";
            string line0;
            string line1;
            string line2;
            string line3;
            decimal dec;
            using (StreamReader reader = new StreamReader(FileCreate.fileName))
            {
                while (!reader.EndOfStream)
                {
                    lastLine = reader.ReadLine();
                    if (reader.Peek() == -1)
                    {
                        reader.DiscardBufferedData();
                        reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    reader.ReadLine();
                    line0 = reader.ReadLine();
                    line1 = reader.ReadLine();
                    line2 = reader.ReadLine();
                    line3 = reader.ReadLine();
                    if (line2.Contains("Balance"))
                    {
                        string[] bits = line2.Split(' ');
                        dec = decimal.Parse(bits[2]);
                        if (dec >= balance)
                        {
                            Console.Write(line0 + "\n" + line1 + "\n" + line2 + "\n\n");
                        }
                    }
                }
                Console.Write("Searched all patients with a balance due over ${0}", balance);
            }
        }
    }
}
