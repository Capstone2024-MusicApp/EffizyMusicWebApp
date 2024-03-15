using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class InstrumentService
    {
        private readonly EffizyMusicContext _context;

        public InstrumentService(EffizyMusicContext context)
        {
            _context = context;
        }
        public async Task<List<Instrument>> GetInstruments()
        {
            return await _context.Instruments.ToListAsync();
        }
    }
}
