using ApiControle.Model;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Validator;
using System;

namespace ApiControle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        private IBaseService<Publicacao> _service;

        public PublicacaoController(IBaseService<Publicacao> service)
        {
            _service = service;
        }

        //End Point de salvar
        [HttpPost]
        public IActionResult Create([FromBody] CreatePublicacao publicacao)
        {
            if (publicacao == null)
                return NotFound();

            return Execute(() => _service.Add<CreatePublicacao, PublicacaoModel, PublicacaoValidator>(publicacao));
        }

        //End Point de atualizar (caso necessário)
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePublicacao publicacao)
        {
            if (publicacao == null)
                return NotFound();

            return Execute(() => _service.Update<UpdatePublicacao, PublicacaoModel, PublicacaoValidator>(publicacao));
        }

        //End Point de excluir(caso necessário)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _service.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        //End Point de busca(caso necessário)
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _service.Get<PublicacaoModel>());
        }

        //End Point de busca por ID(caso necessário)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _service.GetById<PublicacaoModel>(id));
        }

        //Função para Executar busca nos service
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}