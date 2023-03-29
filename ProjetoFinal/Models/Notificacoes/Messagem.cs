namespace ProjetoFinal.Models.Notificacoes
{
    public class Messagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Messagem()
        {

        }
        public Messagem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
