using BE_Mascotas.Models.DTO;

namespace BE_Mascotas.Models.Repository
{
    public interface IMascotaRepository
    {

        Task<List<Mascota>> GetMascotas();
        Task<Mascota> GetMascota(int id);
        Task DeleteMascota(Mascota mascota);

        Task<Mascota> AddMascota(Mascota mascota);

        Task UpdateMascota(Mascota mascotaEx, Mascota mascotaNueva);


    }
}
