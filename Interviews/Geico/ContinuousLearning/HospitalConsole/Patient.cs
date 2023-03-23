using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Patient : PatientInfo
    {
        public int PatRegId = 0;
        public string Fname = string.Empty;
        public string Lname = string.Empty;
        public string phoneNum = string.Empty;
        public string gender = string.Empty;
        public int age = 0;
        public string address = string.Empty;
        public int aadhar = 0;
        public string specialty = string.Empty;

        public Patient() { }

        public Patient(int PatRegId, string Fname, string Lname, string phoneNum, 
            string gender, int age, string address, int aadhar, string specialty) 
        { 
            this.PatRegId = PatRegId;
            this.Fname = Fname;
            this.Lname = Lname;
            this.phoneNum = phoneNum;
            this.gender = gender;
            this.age = age;
            this.address = address;
            this.specialty = specialty;
            this.aadhar = aadhar;
            this.specialty = specialty;
        }

        public override string ToString()
        {
            string s = $"{PatRegId},{Fname},{Lname},{phoneNum},{gender},{age},{address},{aadhar},{specialty}";
            return s;
        }

        public void getPatientDetails(string dept)
        {
            if(specialty == dept)
            {
                getPatientSummary();
            }

        }

        public void getPatientSummary()
        {
            string s = $"\nPatient Registration Id - {PatRegId}\nFirstName - {Fname}\nLast Name - {Lname}\nPhone Number - {phoneNum}\nGender - {gender}\nAge - {age}\nAddress - {address}\nSpecialty - {specialty}";
            Console.WriteLine(s);
        }
    }
}
