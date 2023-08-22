using AutoMapper;
using BE_Mascotas.Models.DTO;

namespace BE_Mascotas.Models.Profiles
{
    public class MascotaProfile: Profile
    {

        public MascotaProfile() {
            CreateMap<Mascota, MascotDTO>();
            CreateMap<MascotDTO, Mascota>();

        }

    }
}
