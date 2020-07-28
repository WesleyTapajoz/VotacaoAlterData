using System;
using System.Collections.Generic;
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
    public class ItemRecursoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemRecursoController(IMapper mapper, IRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<ItemRecursoController>
        [HttpGet("{recursoId}")]
        public async Task<IActionResult> Get(int recursoId)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var recurso = await _repo.GetById<Recurso>(recursoId);

                if (recurso.RecursosUsers.Any(s => s.Id == int.Parse(userId)))
                {
                    var result = _mapper.Map<ItemRecursoDto[]>(recurso.ItensRecurso);
                    return Ok(result);
                }

                var results = _mapper.Map<ItemRecursoVotoDto[]>(recurso.ItensRecurso);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        // GET: api/<ItemRecursoController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var recursos = await _repo.GetAllAsync<ItemRecurso>();
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var results = _mapper.Map<ItemRecurso[]>(recursos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


    }
}
