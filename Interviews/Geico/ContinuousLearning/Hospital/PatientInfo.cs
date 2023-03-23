using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousLearning
{
    public interface PatientInfo
    {
        public void getPatientSummary()
        {

        }

        public void getPatientDetails(string dept)
        {
            if (dept == "General Medicine") getPatientSummary();
            if (dept == "Orthopedics") getPatientSummary();
            if (dept == "Dental") getPatientSummary();
        }
    }

}
