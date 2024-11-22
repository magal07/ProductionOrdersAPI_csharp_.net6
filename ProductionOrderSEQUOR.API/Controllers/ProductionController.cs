﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Infra.Ioc;
using ProductionOrderSEQUOR.Application.Interfaces;

namespace PproductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> só usuários autenticados conseguirão acessar clientes e gerar mudanças
    public class ProductionController : Controller
    {

        private readonly IProductionService _productionService;
        private readonly IUsuarioService _usuarioService;

        public ProductionController(IProductionService productionService, IUsuarioService usuarioService)
        {
            _productionService = productionService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(ProductionPostDTO productionPostDTO)
        {
            // Define as datas
            productionPostDTO.Date = DateTime.Now;   // Data de início
            productionPostDTO.DateEnd = DateTime.Now; // Data de término

            // Calcula o CycleTime (diferença entre as duas datas)
            if (productionPostDTO.Date != null && productionPostDTO.DateEnd != null)
            {
                // Converte explicitamente o valor de double para decimal
                productionPostDTO.CycleTime = (decimal)(productionPostDTO.DateEnd - productionPostDTO.Date).TotalMinutes; // ou TotalSeconds, TotalHours, conforme necessário
            }
            else
            {
                return BadRequest("Datas de início e fim não foram emprestadas corretamente.");
            }

            // Chama o serviço para incluir a produção
            var productionDTOIncluido = await _productionService.Incluir(productionPostDTO);

            // Verifica se ocorreu algum erro
            if (productionDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir a produção.");
            }

            return Ok("Produção incluída com sucesso!");
        }



        [HttpPut]

        public async Task<ActionResult> Alterar(ProductionDTO productionDTO)
        {
            var productionDTOalterado = await _productionService.Alterar(productionDTO);
            if (productionDTOalterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente");
            }
            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {

            var productionDTOExcluido = await _productionService.Excluir(id);
            if (productionDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente.");
            }
            return Ok("Cliente excluido com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var productionDTO = await _productionService.SelecionarAsync(id);
            if (productionDTO == null)
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok(productionDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var productionsDTO = await _productionService.SelecionarTodosAsync();

            return Ok(productionsDTO);
        }
    }
}
