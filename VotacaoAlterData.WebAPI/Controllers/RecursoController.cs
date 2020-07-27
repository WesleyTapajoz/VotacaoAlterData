using System;
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
        public RecursoController(IMapper mapper, IRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
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
        public async Task<IActionResult> Post([FromBody]RecursoDto model)
        {
            try
            {
                var recurso = _mapper.Map<Recurso>(model);
              
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
    }
}
