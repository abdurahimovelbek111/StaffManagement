using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement_.Net_5.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;
        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff(){ id=1,FirtName="Malik",LastName="Abduxoshimov",Email="malikabdu@gmail.com",Department="Admin"},
                new Staff(){ id=2,FirtName="Tohir",LastName="Karimov",Email="tohir@gmail.com",Department="Production"},
                new Staff(){ id=3,FirtName="Abdulla",LastName="Nematov",Email="abdulla@gmail.com",Department="R&D"}
            };
        }
        public Staff Get(int id)
        {
           return  _staffs.FirstOrDefault(staff => staff.id == id);           
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }
    }
}
