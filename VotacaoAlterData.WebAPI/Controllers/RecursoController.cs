using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotacaoAlterData.Domain.Entity;
using VotacaoAlterData.Repository;
using VotacaoAlterData.WebAPI.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VotacaoAlterData.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecursoController(IMapper mapper, IRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<RecursoController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var recursos = await _repo.GetAllAsync<Recurso>();
                var results = _mapper.Map<RecursoDto[]>(recursos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        // GET api/<RecursoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var recurso = await _repo.GetById<Recurso>(id);

                var results = _mapper.Map<RecursoDto>(recurso);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // POST api/<RecursoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecursoDto model)
        {
            try
            {
                var recurso = _mapper.Map<Recurso>(model);
                recurso.Ativo = true;
                _repo.Add(recurso);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/recurso/{model.RecursoId}", _mapper.Map<RecursoDto>(recurso));

                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("AdicionarVoto")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarVoto([FromBody] VotarDto model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                var recurso = _repo.GetById<Recurso>(model.RecursoId).Result;

                var recursosUsers = recurso.RecursosUsers.Where(s => s.Id == int.Parse(userId));

                if (recursosUsers.Any())
                {
                    return BadRequest();
                }

                var user = new RecursoUser()
                {
                    RecursoId = model.RecursoId,
                    Id = int.Parse(userId)
                };

                var voto = new Voto()
                {
                    Comentario = model.Comentario,
                    ItemRecursoId = model.ItemRecursoId
                };

                _repo.Add(user);
                _repo.Add(voto);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();

                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }
    }
}
