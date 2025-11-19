using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;
using Models.Klasser;

namespace Business
{
    public class PoddService
    {
        private readonly IRssHämtare _rssHämtare;
        private readonly IPoddRepository _poddRepository;
        public PoddService(IRssHämtare rssHämtare, IPoddRepository poddRepository)
        {
            _rssHämtare = rssHämtare;
            _poddRepository = poddRepository;
        }
    }
}
