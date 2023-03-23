using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousLearning
{
    class Patient : PatientInfo
    {
        int PatRegId = 0;
        string fname = string.Empty;
        string Lname = string.Empty;
        string phoneNum = string.Empty;
        string gender = string.Empty;
        int age = 0;
        string address = string.Empty;
        int aadhar = 0;
        string specialty = string.Empty;

        public Patient() { }
    }
}
