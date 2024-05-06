using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelDll.Bl
{
    public class Student: Dwellers
    {

        private Room Room;
        private string StudentStatus;
        List<Complain> Complains = new List<Complain>();

        public Student(string name, string password, int age, string cnic, string role, string gender) : base(name,password,age,cnic,role,gender)
        {
            this.StudentStatus = "Unalloted";
        }
        public Student(string name, string password, int age, string cnic, string role, string gender,Hostel hostel, Room room,string status) : base(name, password, age, cnic, role, gender,hostel)
        {
            this.Room = room;
            this.StudentStatus= status;

        }
        public Student(string name, string password, int age, string cnic, string role, string gender, Hostel hostel, Room room, string status, List<Complain> complains)
           : base(name, password, age, cnic, role, gender, hostel)
        {
            this.Room = room;
            this.StudentStatus = status;
            this.Complains = complains;
        }

        public string GetStudentStatus() { return this.StudentStatus; }
        public void SetStudentStatus(string studentStatus) {  this.StudentStatus = studentStatus; }
        public Room GetRoom() {  return this.Room; }
        public void SetRoom(Room room) { this.Room = room; }
        public List<Complain> GetComplins()
        { return this.Complains; }
        public void SetComplains(List<Complain> complains)
        {
            this.Complains = complains;
        }
        public void AddComplains(Complain complain)
        {
            Complains.Add(complain);
        }





    }
}
