using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Data.Models
{
    public class ReMark
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateOnly CreateAt { get; set; }
        public Client Creator { get; set; }

    }
}
