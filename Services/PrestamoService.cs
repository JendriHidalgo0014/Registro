using System.Linq.Expressions;
using JendriHidalgo_Ap1_P1.DAL;
using JendriHidalgo_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JendriHidalgo_Ap1_P1.Services
{
    public class PrestamoService
    {

        private readonly Context _context;

        public PrestamoService(Context context)
        {
            _context = context;

        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Prestamo.AnyAsync(D => D.DeudorId == id);
        }

        public async Task<bool> Insertar(Prestamo prestamo)
        {
            _context.Prestamo.Add(prestamo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prestamo prestamo)
        {
            _context.Prestamo.Update(prestamo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prestamo prestamo)
        {
            if (!await Existe(prestamo.DeudorId))
                return await Insertar(prestamo);
            return await Modificar(prestamo);

        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _context.Prestamo
                .Where(a => a.DeudorId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Prestamo?> Buscar(int id)
        {
            return await _context.Prestamo.AsNoTracking()
                .FirstOrDefaultAsync(a => a.DeudorId == id);
        }

        public async Task<List<Prestamo>> Listar(Expression<Func<Prestamo, bool>> criterio)
        {
            return await _context.Prestamo.AsNoTracking()
               .Where(criterio)
               .ToListAsync();
        }

        public async Task<Prestamo?> EncontrarNombre(string Deudor)
        {
            return await _context.Prestamo.AsNoTracking()
                .FirstOrDefaultAsync(D => D.Deudor == Deudor);

        }


        public async Task<bool> ValidarDeudor(string Deudor)
        {
            return await _context.Prestamo.AnyAsync(n => n.Deudor == Deudor);
        }



    }
}

