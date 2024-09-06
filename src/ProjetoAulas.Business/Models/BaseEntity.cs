namespace ProjetoAulas.Business.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
