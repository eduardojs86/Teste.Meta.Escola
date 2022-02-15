using Meta.Escola.ApplicationCore.Domain._Ports.Repositories;
using Meta.Escola.ApplicationCore.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Meta.Escola.Infra.PersistenceAdapter.ADOSqlCommand
{
    public class EscolaRepository : ADOSqlCommands, IEscolaRetository<object> 
    {
        public EscolaRepository(IConfiguration config) : base(config)
        {

        }

        public object PostCurso(string Nome)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_INCLUIR_CURSO]",
            new Dictionary<string, object>()
            {
                {"@Nome", Nome}
            });

                return "Curso incluído com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Curso não incluído." + ex);
                return erros;
            }
        }
        public object PutCurso(int IdCurso, string Nome)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_EDITAR_CURSO]",
            new Dictionary<string, object>()
            {
                {"@ID", IdCurso},
                {"@Nome", Nome}
            });

                return "Curso atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Curso não atualizado." + ex);
                return erros;
            }
        }
        public object GetCurso()
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_BUSCAR_CURSO]",
                new Dictionary<string, object>()
                {
                });

                if (tabelaDados.Count > 0)
                {
                    CursoModel generoModel;
                    List<CursoModel> curso = new List<CursoModel>();

                    for (int i = 0; i < tabelaDados.Count; i++)
                    {
                        IDictionary<string, object> registroPergunta = tabelaDados[i];
                        generoModel = new CursoModel();
                        foreach (PropertyInfo propriedade in generoModel.GetType().GetProperties())
                        {
                            if (registroPergunta[propriedade.Name] != null && registroPergunta[propriedade.Name] != DBNull.Value)
                            {
                                propriedade.SetValue(generoModel, registroPergunta[propriedade.Name]);
                            }
                        }
                        curso.Add(generoModel);
                    }

                    return curso;
                }
                else
                {
                    ErroModel erros = new ErroModel();
                    erros.CodigoErro = 401;
                    erros.Mensagem = "Curso não localizado.";
                    return erros;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object PostAluno(string Nome, string Cpf, int CursoId)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_INCLUIR_ALUNO]",
            new Dictionary<string, object>()
            {
                {"@Nome", Nome},
                {"@Nome", Cpf},
                {"@Nome", CursoId}
            });

                return "Aluno incluído com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Aluno não incluído." + ex);
                return erros;
            }
        }
        public object PutAluno(int Id, string Nome, string Cpf, int CursoId)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_EDITAR_ALUNO]",
            new Dictionary<string, object>()
            {
                {"@Id", Id},
                {"@Nome", Nome},
                {"@Cpf", Cpf},
                {"@CursoId", CursoId},
            });

                return "Aluno atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Aluno não atualizado." + ex);
                return erros;
            }
        }
        public object GetAluno()
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_BUSCAR_ALUNO]",
                new Dictionary<string, object>()
                {
                });

                if (tabelaDados.Count > 0)
                {
                    AlunoModel generoModel;
                    List<AlunoModel> aluno = new List<AlunoModel>();

                    for (int i = 0; i < tabelaDados.Count; i++)
                    {
                        IDictionary<string, object> registroPergunta = tabelaDados[i];
                        generoModel = new AlunoModel();
                        foreach (PropertyInfo propriedade in generoModel.GetType().GetProperties())
                        {
                            if (registroPergunta[propriedade.Name] != null && registroPergunta[propriedade.Name] != DBNull.Value)
                            {
                                propriedade.SetValue(generoModel, registroPergunta[propriedade.Name]);
                            }
                        }
                        aluno.Add(generoModel);
                    }

                    return aluno;
                }
                else
                {
                    ErroModel erros = new ErroModel();
                    erros.CodigoErro = 401;
                    erros.Mensagem = "Aluno não localizado.";
                    return erros;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object PostNota(int CursoId, int AlunoId, int Bimestre, int Nota)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_INCLUIR_NOTA]",
            new Dictionary<string, object>()
            {
                {"@CursoId", CursoId},
                {"@AlunoId", AlunoId},
                {"@Bimestre", Bimestre},
                {"@Nota", Nota}
            });

                return "Nota incluída com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Nota não incluída." + ex);
                return erros;
            }
        }
        public object PutNota(int Id, int Nota)
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_EDITAR_NOTA]",
            new Dictionary<string, object>()
            {
                {"@Id", Id},
                {"@Nota", Nota}
            });

                return "Nota atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                ErroModel erros = new ErroModel();
                erros.CodigoErro = 404;
                erros.Mensagem = string.Format("{0}", "Nota não atualizada." + ex);
                return erros;
            }
        }
        public object GetNota()
        {
            try
            {
                List<Dictionary<string, object>> tabelaDados = ExecuteProcedure("[dbo].[PROC_BUSCAR_NOTAS]",
                new Dictionary<string, object>()
                {
                });

                if (tabelaDados.Count > 0)
                {
                    NotasModel generoModel;
                    List<NotasModel> nota = new List<NotasModel>();

                    for (int i = 0; i < tabelaDados.Count; i++)
                    {
                        IDictionary<string, object> registroPergunta = tabelaDados[i];
                        generoModel = new NotasModel();
                        foreach (PropertyInfo propriedade in generoModel.GetType().GetProperties())
                        {
                            if (registroPergunta[propriedade.Name] != null && registroPergunta[propriedade.Name] != DBNull.Value)
                            {
                                propriedade.SetValue(generoModel, registroPergunta[propriedade.Name]);
                            }
                        }
                        nota.Add(generoModel);
                    }

                    return nota;
                }
                else
                {
                    ErroModel erros = new ErroModel();
                    erros.CodigoErro = 401;
                    erros.Mensagem = "Nota não localizada.";
                    return erros;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
