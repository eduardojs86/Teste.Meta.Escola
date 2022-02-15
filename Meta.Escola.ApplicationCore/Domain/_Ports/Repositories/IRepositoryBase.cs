namespace Meta.Escola.ApplicationCore.Domain._Ports.Repositories
{
    public interface IRepositoryBase<T>
    {
        T PostCurso(string nome);
        T PutCurso(int IdCurso , string Nome);
        T GetCurso();
        T PostAluno(string Nome, string Cpf, int CursoId);
        T PutAluno(int Id, string Nome, string Cpf, int CursoId);
        T GetAluno();
        T PostNota(int CursoId, int AlunoId, int Bimestre, int Nota);
        T PutNota(int Id, int Nota);
        T GetNota();

    }
}
