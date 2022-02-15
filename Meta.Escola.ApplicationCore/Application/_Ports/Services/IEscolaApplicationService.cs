namespace Meta.Escola.ApplicationCore.Application._Ports.Services
{
    public interface IEscolaApplicationService
    {
        object IncluirCurso(string Nome);
        object AtualizarCurso(int IdCurso, string Nome);
        object BuscarCurso();
        object IncluirAluno(string Nome, string Cpf, int CursoId);
        object AtualizarAluno(int Id, string Nome, string Cpf, int CursoId);
        object BuscarAluno();
        object IncluirNota(int CursoId, int AlunoId, int Bimestre, int Nota);
        object AtualizarNota(int Id, int Nota);
        object BuscarNota();



    }
}
