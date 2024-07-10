namespace MechaSync.Domain
{
    /// <summary>
    /// Propósito: Estabelecer a relação entre serviços e categorias de serviços.
    /// Necessidade: Se os serviços podem pertencer a múltiplas categorias ou você deseja organizar serviços em categorias, essa entidade é necessária para manter o relacionamento.
    /// </summary>
    public class ServiceCategoryRelation
    {
        public int ServiceId { get; set; }
        public int CategoryId { get; set; }

        public Service Service { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}