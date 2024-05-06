using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDll.Bl
{
    public class RT : Dwellers
    {
        private string PhoneNumber;
        public RT() 
        {

        }

        public RT(string name, string password, int age, string cnic, string role, string gender) :  base(name, password, age, cnic, role, gender)
        {

        }
        public RT(string name, string password, int age, string cnic, string role, string gender, Hostel hostel, string phonenumber) : base(name, password, age, cnic, role, gender, hostel)
        {
            this.PhoneNumber = phonenumber;
        }
        public string GetPhoneNumber() { return this.PhoneNumber; }
        public void SetPhoneNumber(string phoneNumber) { this.PhoneNumber = phoneNumber; }

    }
}
