using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m02s09_exercicio.DTO;
using m02s09_exercicio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace m02s09_exercicio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SemanaController : ControllerBase
    {

        private readonly SemanaContext semanaContext;


        //Construtor com parametro (Injetado)   
        public SemanaController(SemanaContext semanaContext)
        {
            this.semanaContext = semanaContext;
        }

        [HttpPost]
        public ActionResult<SemanaCreateDTO> Post([FromBody] SemanaCreateDTO semanaDTO)
        {
            SemanaModel semanaModel = new SemanaModel();
            semanaModel.DataSemana = semanaDTO.DataSemana;
            //semanaModel.MesId = semanaDTO.MesId;
            semanaModel.AplicadoConteudo = semanaDTO.AplicadoConteudo;

            //Verificar se existe o MES no banco de dados
            //var mesModel = semanaContext.Semana.Find(semanaDTO.Id);

            if (semanaDTO.Id > 0)
                return BadRequest("Não é possível inserir uma semana com Id preenchido!");

            //Add na lista do DBSet Semana
            semanaContext.Semana.Add(semanaModel);

            //Salvar no banco de dados
            semanaContext.SaveChanges();

            semanaDTO.Id = semanaModel.Id;
            return Ok(semanaDTO);

        }

        [HttpPut]
        public ActionResult<SemanaUpdateDTO> Put(SemanaUpdateDTO semanaUpdateDTO)
        {

            //Verificar se existe a SEMANA no banco de dados
            var semanaModel = semanaContext.Semana.Find(semanaUpdateDTO.Id);

            if (semanaModel != null)
            {
                semanaModel.Id = semanaUpdateDTO.Id;
                semanaModel.DataSemana = semanaUpdateDTO.DataSemana;
                semanaModel.Conteudo = semanaUpdateDTO.Conteudo;
                semanaModel.AplicadoConteudo = semanaUpdateDTO.ConteudoAplicado;

                //Add na lista do DBSet Semana
                semanaContext.Semana.Attach(semanaModel);

                //Salvar no banco de dados
                semanaContext.SaveChanges();

                semanaModel.Id = semanaModel.Id;
                return Ok(semanaUpdateDTO);
            }
            else
            {
                return BadRequest("Erro ao salvar a semana no banco de dados");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            //Verificar se existe registro no banco de dados
            var semanaModel = semanaContext.Semana.Find(id);

            if (semanaModel != null)
            {
                //Deletar o regitro no banco de dados
                //meuBancoDadosContext.Remove(mesModel);
                semanaContext.Semana.Remove(semanaModel);
                semanaContext.SaveChanges();

                return Ok();
            }
            else
            {
                //se for null retorno um request de erro
                return BadRequest("Erro ao atualizar o registro");
            }
        }


        //Devolve todos os registros
        [HttpGet]
        public ActionResult<List<SemanaGetDTO>> Get()
        {
            List<SemanaGetDTO> lista = new List<SemanaGetDTO>();

            //SELECT Mes.*, Semana.*
            //FROM Mes
            //INNER JOIN Semana ON Semana.MesId = Mes.Id
            IQueryable<SemanaModel> semanasInnerJoin = semanaContext.Semana;

            foreach (var semana in semanasInnerJoin)
            {
                SemanaGetDTO semanaGetDTOUm = new SemanaGetDTO();
                semanaGetDTOUm.Id = semana.Id;
                semanaGetDTOUm.DataSemana = semana.DataSemana;
                semanaGetDTOUm.Conteudo = semana.Conteudo;
                semanaGetDTOUm.AplicadoConteudo = semana.AplicadoConteudo;
                lista.Add(semanaGetDTOUm);
            }

            return Ok(lista);
        }

        //Devolve todos os registro
        [HttpGet("{id}")]
        public ActionResult<SemanaGetDTO> Get([FromRoute] int id)
        {            
            SemanaModel? semanasInnerJoin = semanaContext.Semana.Where(w => w.Id == id).FirstOrDefault();
            if (semanasInnerJoin == null)
            {
                return BadRequest("Registro não encontrado");
            }

            SemanaGetDTO semanaGetDto = new SemanaGetDTO();
            //Classe.Propriedade.Atributos = Valor.Id
            semanaGetDto.Id = semanasInnerJoin.Id;
            semanaGetDto.DataSemana = semanasInnerJoin.DataSemana;
            semanaGetDto.Conteudo = semanasInnerJoin.Conteudo;
            semanaGetDto.AplicadoConteudo = semanasInnerJoin.AplicadoConteudo;

            return Ok(semanaGetDto);
        }


    }
}