namespace ProjetoFinal.Models.Notificacoes
{
    public class Mesagem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Mesagem()
        {

        }
        public Mesagem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
