using System.ComponentModel.DataAnnotations;

namespace proTaxi.Domain.Base
{
    public abstract class BaseEntity<TType>
    {
        [Key]
        public  abstract TType Id { get; set; }
    }
}
