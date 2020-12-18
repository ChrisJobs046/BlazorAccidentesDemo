using BlazorPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Data
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetAllPersona();
        Task<Persona> GetPersonaDetails(int id);
        Task<bool> InsertPersona(Persona persona);
        Task<bool> UpdatePersona(Persona persona);
        Task<bool> DeletePersona(int id);
        Task<bool> SavePersona(Persona persona);
    }
}
