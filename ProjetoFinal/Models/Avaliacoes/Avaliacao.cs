using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoFinal.Models.Avalicacao.Enums;
using ProjetoFinal.Models.Materias;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models.Avaliacoes
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        public Tipo Tipo { get; set; }
        public DateTime Data { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Nota { get; set; }

        public Avaliacao()
        {

        }

        public Avaliacao(int avaliacaoId, Tipo tipo, DateTime data, int materiaId, Materia materia, decimal nota)
        {
            AvaliacaoId = avaliacaoId;
            Tipo = tipo;
            Data = data;
            MateriaId = materiaId;
            Materia = materia;
            Nota = nota;
        }
    }
}
