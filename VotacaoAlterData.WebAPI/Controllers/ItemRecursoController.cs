using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ItemRecursoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository _repo;
        public ItemRecursoController(IMapper mapper, IRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetItem/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
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


        // GET: api/<ItemRecursoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ItemRecursoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemRecursoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemRecursoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
