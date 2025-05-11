    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoRishi.LMS.Repository.DataModel
{
    public class BorrowedBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int MemberId { get; set; }

        public DateTime BorrowedDate { get; set; } = DateTime.Now;

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
