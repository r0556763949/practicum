using Practicum.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Services
{
    public class ProgramFileService
    {
        private readonly IProgramFileRepository _programFileRepository;
        public ProgramFileService(IProgramFileRepository programFileRepository)
        {
            _programFileRepository = programFileRepository;
        }
    }
}
