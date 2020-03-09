using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalTask.Entities
{
    public struct User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Verified { get; set; }
    }
}
