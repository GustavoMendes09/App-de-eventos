using AutoMapper;
using ProEventos.Domain.Dtos;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Business;
using ProEventos.Domain.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Business
{
    public class LoteService : ILoteService
    {
        private readonly ILoteRepository loteRepository;
        private readonly IMapper mapper;
        public LoteService(ILoteRepository loteRepository, IMapper mapper)
        {
            this.loteRepository = loteRepository;
            this.mapper = mapper;
        }

        public async Task AddLotes(int eventoId, LoteDto model)
        {
            try
            {
                var lote = mapper.Map<LoteEntity>(model);
                lote.EventoId = eventoId;

                loteRepository.Add(lote);

                await loteRepository.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<LoteDto>> SaveLotes(int eventoId, IEnumerable<LoteDto> models)
        {
            try
            {
                var lotes = await loteRepository.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null)
                    return null;

                foreach (var model in models)
                {
                    if (model.Id == 0)
                    {
                        await AddLotes(eventoId, model);
                    }
                    else 
                    {
                        var lote = lotes.FirstOrDefault(l => l.Id == model.Id);
                        model.EventoId = eventoId;
                        loteRepository.Update(lote);

                        await loteRepository.SaveChangesAsync();
                    }
                }

                var eventoRetorno = await loteRepository.GetLotesByEventoIdAsync(eventoId);


                    return mapper.Map<IEnumerable<LoteDto>>(eventoRetorno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await loteRepository.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null)
                    throw new Exception("Evento para delete não foi encontrado");

                loteRepository.Delete(lote);

                return await loteRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<LoteDto>> GetLotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lotes = await loteRepository.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null)
                    return null;

                var result = mapper.Map<List<LoteDto>>(lotes);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await loteRepository.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null)
                    return null;

                var result = mapper.Map<LoteDto>(lote);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       
    }
}
