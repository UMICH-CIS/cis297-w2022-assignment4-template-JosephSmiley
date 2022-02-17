using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// This program implements functions for a doctor's office to keep track of different patient names, ID's and balance due
/// </summary>
/// <Student>Joseph Smiley</Student>
/// <Class>CIS 297</Class>
/// <Semester>Winter2022</Semester>
namespace PatientRecordApplication
{
    class FileCreate
    {
        /// <summary>
        /// Implements all the functions
        /// </summary>
        public static string fileName = "PatientData.txt";
        static void Main(string[] args)
        {
            // create patient objects
            Patient p1 = new Patient();
            Patient p2 = new Patient();
            Patient p3 = new Patient();

            // call functions to get data from user
            GetPatientData(1, p1);
            GetPatientData(2, p2);
            GetPatientData(3, p3);

            // writes data to a file
            WriteData(p1, p2, p3);

            // displays file to the console
            Console.WriteLine("\nDisplaying Contents of the file: \n");
            DisplayFileInConsole.DisplayFile();

            // finds patient with specified ID
            Console.WriteLine("\nEnter the ID of the patient you are looking for: ");
            string num = Console.ReadLine();
            Console.Write("\nPatient ID {0} info: \n", num);
            FindID.IDFinder(num);

            // finds patients with balance due greater than or equal to amount specified
            Console.WriteLine("Enter the minimum balance due to display: ");
            decimal dec = decimal.Parse(Console.ReadLine());
            Console.Write("\nPatients with more than ${0} due: \n", dec);
            MinBalanceDue.FindMinBalance(dec);

            Console.ReadLine();
        }

        /// <summary>
        /// Gets patient data from the user
        /// </summary>
        /// <param name="num"></param>
        /// <param name="p"></param>
        static void GetPatientData(int num, Patient p)
        {
            try
            {
                Console.WriteLine("Enter data for patient {0}: ", num);
                Console.WriteLine("ID: ");
                p.id = int.Parse(Console.ReadLine());
                if (p.id < 0)
                    throw new NegNumException();
                Console.WriteLine("Name: ");
                p.name = Console.ReadLine();
                Console.WriteLine("Balance Due: ");
                p.balanceOwed = decimal.Parse(Console.ReadLine());
                if (p.balanceOwed < 0)
                    throw new NegNumException();
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Incorrect format");
                GetPatientData(num, p);
            }
            catch (NegNumException)
            {
                Console.WriteLine("ERROR: Use a positive number");
                GetPatientData(num, p);
            }
        }

        /// <summary>
        /// Writes patients data to file
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        static void WriteData(Patient p1, Patient p2, Patient p3)
        {
            int i = 0;
            using (StreamWriter writer = new StreamWriter(@fileName))
            {
                writer.Write("Patient {0}:\nID: " + p1.id + "\nName: " + p1.name + "\nBalance Owed: " + p1.balanceOwed + "\n----------\n", i + 1);
                i++;
                writer.Write("Patient {0}:\nID: " + p2.id + "\nName: " + p2.name + "\nBalance Owed: " + p2.balanceOwed + "\n----------\n", i + 1);
                i++;
                writer.Write("Patient {0}:\nID: " + p3.id + "\nName: " + p3.name + "\nBalance Owed: " + p3.balanceOwed + "\n----------\nEND OF FILE", i + 1);
                
            }
        }
    }
}
