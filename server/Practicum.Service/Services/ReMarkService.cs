using Practicum.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Services
{
    public class ReMarkService
    {
        private readonly IReMarkRepository _remarkRepository;
        public ReMarkService(IReMarkRepository remarkRepository)
        {
            _remarkRepository = remarkRepository;
        }
    }
}
