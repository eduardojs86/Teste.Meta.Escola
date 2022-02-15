using Meta.Escola.ApplicationCore.Application._Ports.Services;
using Meta.Escola.ApplicationCore.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Meta.Escola.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaApplicationService _escolaApplicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EscolaController(IEscolaApplicationService escolaApplicationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _escolaApplicationService = escolaApplicationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("IncluirCurso")]
        public IActionResult IncluirCurso(string Nome)
        {
            try
            {
                object retorno = _escolaApplicationService.IncluirCurso(Nome);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Curso incluído com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível incluir o Curso."));
            }
        }

        [HttpPut("AtualizarCurso")]
        public IActionResult AtualizarCurso(int Codigo, string Nome)
        {
            try
            {
                object retorno = _escolaApplicationService.AtualizarCurso(Codigo, Nome);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Curso atualizado com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível atualizar os dados do Curso."));
            }
        }

        [HttpGet("BuscarCurso")]
        public IActionResult BuscarCurso()
        {
            try
            {
                object retorno = _escolaApplicationService.BuscarCurso();

                if (retorno is CursoModel)
                {
                    if ((retorno as CursoModel).Id > 0)
                    {
                        return Ok(retorno); //200
                    }
                    else
                    {
                        return Unauthorized(retorno); //401
                    }
                }
                else
                {
                    return Unauthorized(retorno); //401
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível localizar nenhum Curso."));
            }
        }

        [HttpPost("IncluirAluno")]
        public IActionResult IncluirAluno(string Nome, string Cpf, int CursoId)
        {
            try
            {
                object retorno = _escolaApplicationService.IncluirAluno(Nome, Cpf, CursoId);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Aluno incluído com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível incluir Aluno."));
            }
        }

        [HttpPut("AtualizarAluno")]
        public IActionResult AtualizarAluno(int Id, string Nome, string Cpf, int CursoId)
        {
            try
            {
                object retorno = _escolaApplicationService.AtualizarAluno(Id, Nome, Cpf, CursoId);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Aluno atualizado com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível atualizar os dados do Aluno."));
            }
        }

        [HttpGet("BuscarAluno")]
        public IActionResult BuscarAluno()
        {
            try
            {
                object retorno = _escolaApplicationService.BuscarAluno();

                if (retorno is AlunoModel)
                {
                    if ((retorno as AlunoModel).Id > 0)
                    {
                        return Ok(retorno); //200
                    }
                    else
                    {
                        return Unauthorized(retorno); //401
                    }
                }
                else
                {
                    return Unauthorized(retorno); //401
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível localizar nenhum Aluno."));
            }
        }

        [HttpPost("IncluirNota")]
        public IActionResult IncluirNota(int CursoId, int AlunoId, int Bimestre, int Nota)
        {
            try
            {
                object retorno = _escolaApplicationService.IncluirNota(CursoId, AlunoId, Bimestre, Nota);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Nota incluída com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível incluir a Nota."));
            }
        }

        [HttpPut("AtualizarNota")]
        public IActionResult AtualizarNota(int Id, int Nota)
        {
            try
            {
                object retorno = _escolaApplicationService.AtualizarNota(Id, Nota);

                if (retorno is ErroModel)
                {
                    return Unauthorized(retorno);
                }
                else
                {
                    ErroModel retornos = new ErroModel();
                    retornos.CodigoErro = 200;
                    retornos.Mensagem = "Nota atualizada com sucesso.";
                    return Ok(retornos);
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível atualizar a nota."));
            }
        }

        [HttpGet("BuscarNota")]
        public IActionResult BuscarNota()
        {
            try
            {
                object retorno = _escolaApplicationService.BuscarNota();

                if (retorno is NotasModel)
                {
                    if ((retorno as NotasModel).Id > 0)
                    {
                        return Ok(retorno); //200
                    }
                    else
                    {
                        return Unauthorized(retorno); //401
                    }
                }
                else
                {
                    return Unauthorized(retorno); //401
                }
            }
            catch (Exception)
            {
                return BadRequest(string.Format("{0}", "Não foi possível localizar nenhuma Nota."));
            }
        }
    }
}
