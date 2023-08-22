using AutoMapper;
using BE_Mascotas.Models;
using BE_Mascotas.Models.DTO;
using BE_Mascotas.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Mascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AplicationDbContext _context;
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaController(AplicationDbContext context, IMapper mapper, IMascotaRepository mascotaRepository)
        {
            _context = context;
            _mapper = mapper;
            _mascotaRepository = mascotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listMascotas = await _mascotaRepository.GetMascotas();
                var listMascotasDto = _mapper.Map<IEnumerable<MascotDTO>>(listMascotas);
                return Ok(listMascotasDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascota(id);
                if (mascota  == null)
                {
                    return NotFound();
                }

                var mascotaDto = _mapper.Map<MascotDTO>(mascota);
                return Ok(mascotaDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound(id);
                }
                else
                {
                    await _mascotaRepository.DeleteMascota(mascota);
                    return NoContent();

                }



            }
            catch(Exception ex) { 
                return BadRequest(ex.Message);
                
            }

        }

        [HttpPost]

        public async Task<IActionResult> create(MascotDTO mascotaDto)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDto);

                   mascota.FechaCreacion = DateTime.Now;
                   mascota = await _mascotaRepository.AddMascota(mascota);
                   mascotaDto = _mapper.Map<MascotDTO>(mascota);

                return CreatedAtAction("Get", new { id = mascota.Id }, mascotaDto);



            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MascotDTO mascotaDto)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDto);

                if (id != mascota.Id)
                {
                    return BadRequest("El Id en la URL no coincide con el Id de la mascota");
                }

                var mascotaExistente = await _mascotaRepository.GetMascota(id);
                if (mascotaExistente == null)
                {
                    return NotFound("No se encontró una mascota con ese Id");
                }

                await _mascotaRepository.UpdateMascota(mascotaExistente, mascota);

                return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }




    }
}
