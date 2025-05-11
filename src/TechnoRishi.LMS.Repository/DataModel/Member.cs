using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoRishi.LMS.Repository.DataModel
{
    public class Member
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime MembershipStartDate { get; set; }
    }
}
