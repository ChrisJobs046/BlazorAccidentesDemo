using BlazorPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Data
{
    interface IAccidenteService
    {
        Task<IEnumerable<Accidente>> GetAllAccidente();
        Task<Accidente> GetAccidenteDetails(int id);
        Task<bool> InsertAccidente(Accidente accidente);
        Task<bool> UpdateAccidente(Accidente accidente);
        Task<bool> DeleteAccidente(int id);
        Task<bool> SaveAccidente(Accidente Accidente);
    }
}
