using proTaxi.Domain.Entities;

namespace proTaxi.Api.Models.Role
{
    public record RoleUpdateDto : BaseRoleDto
    {
        public int Id { get; set; }
        
    }
}
