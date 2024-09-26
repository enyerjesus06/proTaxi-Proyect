using proTaxi.Domain.Entities;

namespace proTaxi.Api.Models.Role
{
    public abstract record BaseRoleDto
    {
        public required string Nombre { get; set; }

        
    }
}
