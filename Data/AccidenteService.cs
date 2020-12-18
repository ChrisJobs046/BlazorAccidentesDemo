using BlazorPrueba.Entities;
using BlazorPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Data
{
    public class AccidenteService : IAccidenteService
    {
        private readonly SQlitedbContext _context;

        public AccidenteService(SQlitedbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAccidente(int id)
        {
            var accidente = await _context.Accidentes.FindAsync(id);

            _context.Accidentes.Remove(accidente);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Accidente>> GetAllAccidente()
        {
            return await _context.Accidentes.ToListAsync();
        }

        public async Task<Accidente> GetAccidenteDetails(int id)
        {
            return await _context.Accidentes.FindAsync(id);
        }

        public async Task<bool> InsertAccidente(Accidente accidente)
        {
            _context.Accidentes.Add(accidente);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveAccidente(Accidente accidente)
        {
            if (accidente.AccidenteId > 0)
                return await UpdateAccidente(accidente);
            else
                return await InsertAccidente(accidente);
        }

        public async Task<bool> UpdateAccidente(Accidente accidente)
        {
            _context.Entry(accidente).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

