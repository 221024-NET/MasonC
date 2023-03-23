using System;
using System.Collections.Generic;

namespace Hospital
{
    public class Program
    {
        public static List<Patient> ReadInPatients(string textFile)
        {
            List < Patient > patients = new List < Patient >();
            Patient newPatient = new Patient();
            using (StreamReader file = new StreamReader(textFile))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] strs = ln.Split(",");
                    Patient s = new Patient(Int32.Parse(strs[0]), strs[1], strs[2], strs[3], strs[4],
                        Int32.Parse(strs[5]), strs[6], Int32.Parse(strs[7]), strs[8]);
                    patients.Add(s);
                }
                file.Close();
            }
            return patients;
        }

        public static void writePatient(string textFile, Patient p)
        {
            string s = p.ToString();
            File.AppendAllText(textFile, s + Environment.NewLine);
        }

        public static void makePatient(string textFile, int nextPat)
        {
            Patient p = new Patient();
            p.PatRegId = nextPat;
            string Fname = string.Empty;
            string Lname = string.Empty;
            string phoneNum = string.Empty;
            string gender = string.Empty;
            int age = 0;
            string address = string.Empty;
            int aadhar = 0;
            string specialty = string.Empty;

            Console.WriteLine("Please enter First Name:");
            Fname = Console.ReadLine();
            while(Fname.Length <= 0 || Fname.Length > 50)
            {
                Console.WriteLine("First Name cannot be empty or greater than 50 characters.");
                Console.WriteLine("Please enter First Name:");
                Fname = Console.ReadLine();
            }
            Console.WriteLine("Please enter Last Name:");
            Lname = Console.ReadLine();
            while (Lname.Length <= 0)
            {
                Console.WriteLine("Last Name cannot be empty.");
                Console.WriteLine("Please enter Last Name:");
                Lname = Console.ReadLine();
            }

            Console.WriteLine("Please enter Phone Number:");
            phoneNum = Console.ReadLine();
            while (phoneNum.Length <= 0 || phoneNum.Length > 10)
            {
                Console.WriteLine("Phone Number cannot be empty or greater than 10 characters.");
                Console.WriteLine("Please enter Phone number:");
                phoneNum = Console.ReadLine();
            }

            Console.WriteLine("Please enter Gender:");
            gender = Console.ReadLine();
            while (gender.Length <= 0)
            {
                Console.WriteLine("Gender cannot be empty.");
                Console.WriteLine("Please enter Gender:");
                gender = Console.ReadLine();
            }

            Console.WriteLine("Please enter Age:");
            age = Int32.Parse(Console.ReadLine());
            while (age <= 0)
            {
                Console.WriteLine("Age cannot be empty or less than 0.");
                Console.WriteLine("Please enter Age:");
                age = Int32.Parse(Console.ReadLine());
            }

            Console.WriteLine("Please enter Address:");
            address = Console.ReadLine();
            while (address.Length <= 0)
            {
                Console.WriteLine("Address cannot be empty.");
                Console.WriteLine("Please enter Address:");
                address = Console.ReadLine();
            }
            Console.WriteLine("Please enter Aadhar:");
            aadhar = Int32.Parse(Console.ReadLine());
            while (aadhar <= 0)
            {
                Console.WriteLine("Aadhar cannot be empty or less than 0.");
                Console.WriteLine("Please enter Aadhar:");
                aadhar = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Please enter number of specialty:");
            Console.WriteLine("1. General Medicine");
            Console.WriteLine("2. Orthopedics");
            Console.WriteLine("3. Dental");
            string s = Console.ReadLine();
            int choice = Int32.Parse(s);
            while (choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine("Please enter number of specialty:");
                Console.WriteLine("1. General Medicine");
                Console.WriteLine("2. Orthopedics");
                Console.WriteLine("3. Dental");
                s = Console.ReadLine();
                choice = Int32.Parse(s);
            }
            if(choice == 1)
            {
                p.specialty = "General Medicine";
            } else if(choice == 2)
            {
                p.specialty = "Orthopedics";
            }
            else if(choice == 3)
            {
                p.specialty = "Dental";
            }

            p.Fname = Fname;
            p.Lname = Lname;
            p.age = age;
            p.phoneNum = phoneNum;
            p.gender = gender;
            p.address = address;
            p.aadhar = aadhar;
            writePatient(textFile, p);
        }

        public static void patient(string textFile, int nextPat)
        {
            int choice = 0;
            bool b = false;
            string s = string.Empty;
            Console.WriteLine("You have chosen Patient!");
            Console.WriteLine("Please make a choice using the number:");
            Console.WriteLine("1. Create New Patient");
            Console.WriteLine("2. Exit");
            s = Console.ReadLine();
            b = Int32.TryParse(s, out choice);
            while (!b || choice > 2 || choice < 1)
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Please try again");
                Console.WriteLine("Please make a choice using the number:");
                Console.WriteLine("1. Create New Patient");
                Console.WriteLine("2. Exit");
                s = Console.ReadLine();

                b = Int32.TryParse(s, out choice);
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Create New Patient was chosen.");
                    makePatient(textFile, nextPat);
                    break;
                case 2:
                    Environment.Exit(1);
                    break;
            }
        }

        public static void admin(List<Patient> p)
        {
            int choice = 0;
            bool b = false;
            string s = string.Empty;
            Console.WriteLine("You have chosen Admin!");
            Console.WriteLine("Please make a choice using the number:");
            Console.WriteLine("1. Get All Patient Summaries");
            Console.WriteLine("2. Get Patient Summaries by department");
            Console.WriteLine("3. Exit");
            s = Console.ReadLine();
            b = Int32.TryParse(s, out choice);
            while (!b || choice > 3 || choice < 1)
            {
                Console.WriteLine("Incorrect input");
                Console.WriteLine("Please try again");
                Console.WriteLine("Please make a choice using the number:");
                Console.WriteLine("1. Get All Patient Summaries");
                Console.WriteLine("2. Get Patient Summaries by department");
                Console.WriteLine("3. Exit");
                s = Console.ReadLine();

                b = Int32.TryParse(s, out choice);
            }
            switch (choice)
            {
                case 1: 
                    Console.WriteLine("Get All Patietient Summaries");
                    foreach(Patient pat in p)
                    {
                        pat.getPatientSummary();
                    }
                    break;
                case 2:
                    Console.WriteLine("Please make a choice using the number:");
                    Console.WriteLine("1. General Medicine");
                    Console.WriteLine("2. Orthopedics");
                    Console.WriteLine("3. Dental");
                    s = Console.ReadLine();
                    b = Int32.TryParse(s, out choice);
                    while(!b || choice > 3 || choice < 1)
                    {
                        Console.WriteLine("Invalid Input. Please try again.");
                        Console.WriteLine("Please make a choice using the number:");
                        Console.WriteLine("1. General Medicine");
                        Console.WriteLine("2. Orthopedics");
                        Console.WriteLine("3. Dental");
                        s = Console.ReadLine();
                        b = Int32.TryParse(s, out choice);
                    }
                    if (choice == 1)
                    {
                        foreach (Patient pat in p)
                        {
                            pat.getPatientDetails("General Medicine");
                        }
                    }
                    if (choice == 2)
                    {
                        foreach (Patient pat in p)
                        {
                            pat.getPatientDetails("Orthopedics");
                        }
                    }
                    if (choice == 3)
                    {
                        foreach (Patient pat in p)
                        {
                            pat.getPatientDetails("Dental");
                        }
                    }

                    break;
                case 3:
                    Environment.Exit(1);
                    break;
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            string textFile = "C:\\Users\\mpcat\\RevatureTraining\\MasonC\\Interviews\\Geico\\ContinuousLearning\\HospitalConsole\\patients.txt";
            //Console.WriteLine("Hello World");

            while (true)
            {
                List<Patient> p = ReadInPatients(textFile);
                int nextPat = p.Count + 1;

                //Console readlines to make sure that everything is read in correctly.
                //foreach (Patient pat in p)
                //{
                //    Console.WriteLine(pat.Fname);
                //}

                int choice = 0;
                bool b = false;
                string s = string.Empty;
                Console.WriteLine("Please make a choice using the number:");
                Console.WriteLine("1. Patient");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                s = Console.ReadLine();

                b = Int32.TryParse(s, out choice);

                while (!b || choice > 3 || choice < 1)
                {
                    Console.WriteLine("Incorrect input");
                    Console.WriteLine("Please try again");
                    Console.WriteLine("Please make a choice using the number:");
                    Console.WriteLine("1. Patient");
                    Console.WriteLine("2. Admin");
                    Console.WriteLine("3. Exit");
                    s = Console.ReadLine();

                    b = Int32.TryParse(s, out choice);
                }

                switch (choice)
                {
                    case 1:
                        patient(textFile, nextPat);
                        break;
                    case 2:
                        admin(p);
                        break;
                    case 3:
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}