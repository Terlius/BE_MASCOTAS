using Microsoft.EntityFrameworkCore;

namespace BE_Mascotas.Models.Repository
{
    public class MascotaRepository: IMascotaRepository
    {

        private readonly AplicationDbContext _context;

        public MascotaRepository(AplicationDbContext context)
        {
            _context = context;

        }

       
        public async Task<Mascota> GetMascota(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        public async Task<List<Mascota>> GetMascotas()
        {
            return await _context.Mascotas.ToListAsync();
        }

        public async Task DeleteMascota(Mascota mascota)
        {
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
        }

        public async Task<Mascota> AddMascota(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task UpdateMascota(Mascota mascotaExistente, Mascota mascota)
        {
            // Excluir Id y FechaCreacion de la actualización
            _context.Entry(mascotaExistente).Property(x => x.Id).IsModified = false;
            _context.Entry(mascotaExistente).Property(x => x.FechaCreacion).IsModified = false;

            // Actualizar todas las demás propiedades
            _context.Entry(mascotaExistente).CurrentValues.SetValues(mascota);

            await _context.SaveChangesAsync();
        }
    }
}
