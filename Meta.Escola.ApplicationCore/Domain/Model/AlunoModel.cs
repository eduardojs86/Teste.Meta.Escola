using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Escola.ApplicationCore.Domain.Model
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Cpf { get; set; }
        public int CursoId { get; set; }
    }
}
