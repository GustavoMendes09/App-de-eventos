using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        private readonly ILogger<LotesController> _logger;
        private readonly ILoteService loteService;

        public LotesController(ILoteService loteService)
        {
            this.loteService = loteService;
        }

        [HttpGet("{eventoId:int}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await loteService.GetLotesByEventoIdAsync(eventoId);

                if (lotes == null)
                    return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar lotes. Erro: {ex.Message}");
            }
        }

       
        [HttpPut("{eventoId:int}")]
        public async Task<IActionResult> SaveLotes(int eventoId, IEnumerable<LoteDto> models)
        {
            try
            {
                var lotes = await loteService.SaveLotes(eventoId, models);

                if (lotes == null)
                    return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar lotes. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{eventoId:int}/{loteId:int}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await loteService.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null)
                    return NoContent();

                return await loteService.DeleteLote(lote.EventoId, lote.Id)
                    ? Ok(new { message = "Lote Deletado" })
                    : throw new Exception("Ocorreu um problema ao deletar Lote.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar lotes. Erro: {ex.Message}");
            }
        }

    }
}
