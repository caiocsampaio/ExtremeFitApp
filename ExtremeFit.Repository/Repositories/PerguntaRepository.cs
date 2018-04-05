using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeFit.Domain.Entities;
using ExtremeFit.Repository.DataContext;
using ExtremeFit.Repository.DTOs;
using ExtremeFit.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtremeFit.Repository.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly ApiContext _context;

        public PerguntaRepository(ApiContext context)
        {
            _context = context;
        }

        public int Atualizar(PerguntaDto perguntaDto, int id)
        {
            try{
                var pergunta = _context.Perguntas.FirstOrDefault(x => x.Id == id);

                pergunta.Pergunta = perguntaDto.Pergunta;
                _context.Perguntas.Update(pergunta);
                
                //Encontrar alternativas referentes à pergunta
                var alternativas = _context.Alternativas
                                            .Where(x => x.PerguntaId == pergunta.Id)
                                            .ToList();
                
                //excluir alternativas já cadastradas
                foreach (var alternativa in alternativas)
                {
                    _context.Remove(alternativa);
                }

                //inserir novas alternativas
                var novasAlternativas = perguntaDto.Alternativas;
                foreach (var novaAlternativa in novasAlternativas)
                {
                    AlternativaDomain alternativa = new AlternativaDomain();
                    alternativa.Resposta = novaAlternativa;
                    alternativa.Pergunta = pergunta;
                    _context.Alternativas.Add(alternativa);
                }

                return _context.SaveChanges();

            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public PerguntaDomain BuscarPorId(int id)
        {
            try{
                PerguntaDomain pergunta = _context.Perguntas
                    .Include("Alternativas")
                    .FirstOrDefault(x => x.Id == id);
                
                return pergunta;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int Deletar(int id)
        {
            try{
                PerguntaDomain pergunta = _context.Perguntas.FirstOrDefault(x => x.Id == id);
                ICollection<AlternativaDomain> alternativas = _context.Alternativas
                                                                        .Where(x => x.PerguntaId == id)
                                                                        .ToList();
                _context.Perguntas.Remove(pergunta);

                foreach (var alternativa in alternativas)
                {
                    _context.Alternativas.Remove(alternativa);
                }

                return _context.SaveChanges();
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public int Inserir(PerguntaDto perguntaDto)
        {
            try{
                PerguntaDomain pergunta = new PerguntaDomain();
                pergunta.Pergunta = perguntaDto.Pergunta;
                _context.Perguntas.Add(pergunta);

                foreach (var item in perguntaDto.Alternativas)
                {
                    AlternativaDomain alternativa = new AlternativaDomain();
                    alternativa.Resposta = item;
                    alternativa.Pergunta = pergunta;
                    _context.Alternativas.Add(alternativa);
                }

                return _context.SaveChanges();
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }

        public List<PerguntaDomain> Listar()
        {
            try{
                var lista = _context.Perguntas
                    .Include("Alternativas")
                    .ToList();
                
                return lista;
            }
            catch(Exception e){
                throw new Exception(e.Message);
            }
        }
    }
}