using Practicum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Data
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProgramFile> ProgramFiles { get; set; }
        public List<ReMark> ReMarks { get; set; }
        public DataContext()
        {
            Clients = new List<Client>
        }
    }
}
