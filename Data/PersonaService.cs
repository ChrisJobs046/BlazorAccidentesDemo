using BlazorPrueba.Entities;
using BlazorPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Data
{
    public class PersonaService : IPersonaService
    {
        private readonly SQlitedbContext _context;

        public PersonaService(SQlitedbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            _context.Personas.Remove(persona);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Persona>> GetAllPersona()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetPersonaDetails(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<bool> InsertPersona(Persona persona)
        {
            _context.Personas.Add(persona);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SavePersona(Persona persona)
        {
            if (persona.PersonaId > 0)
                return await UpdatePersona(persona);
            else
                return await InsertPersona(persona);
        }

        public async Task<bool> UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
