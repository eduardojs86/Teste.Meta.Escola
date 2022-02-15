using Meta.Escola.ApplicationCore.Application._Ports.Services;
using Meta.Escola.ApplicationCore.Domain._Ports.Repositories;

namespace Meta.Escola.ApplicationCore.Application.Services
{
    public class EscolaApplicationServices : IEscolaApplicationService
    {
        private readonly IEscolaRetository<object> _escolaRepository;

        public EscolaApplicationServices(IEscolaRetository<object> escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }


        public object IncluirCurso(string Nome)
        {
            return _escolaRepository.PostCurso(Nome);
        }

        public object AtualizarCurso(int IdCurso, string Nome)
        {
            return _escolaRepository.PutCurso(IdCurso, Nome);
        }

        public object BuscarCurso()
        {
            return _escolaRepository.GetCurso();
        }

        public object IncluirAluno(string Nome, string Cpf, int CursoId)
        {
            return _escolaRepository.PostAluno(Nome, Cpf, CursoId);
        }

        public object AtualizarAluno(int Id, string Nome, string Cpf, int CursoId)
        {
            return _escolaRepository.PutAluno(Id, Nome, Cpf, CursoId);
        }

        public object BuscarAluno()
        {
            return _escolaRepository.GetAluno();
        }
        public object IncluirNota(int CursoId, int AlunoId, int Bimestre, int Nota)
        {
            return _escolaRepository.PostNota(CursoId, AlunoId, Bimestre, Nota);
        }

        public object AtualizarNota(int Id, int Nota)
        {
            return _escolaRepository.PutNota(Id, Nota);
        }

        public object BuscarNota()
        {
            return _escolaRepository.GetNota();
        }
        
    }
}
