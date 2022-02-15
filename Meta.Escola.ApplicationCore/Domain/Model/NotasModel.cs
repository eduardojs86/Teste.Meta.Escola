namespace Meta.Escola.ApplicationCore.Domain.Model
{
    public class NotasModel
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        public int Bimestre { get; set; }
        public int Nota { get; set; }
    }
}
