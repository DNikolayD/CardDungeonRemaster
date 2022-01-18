using Service.Common;

namespace Service.DTOs.User
{
    public class RoleDto : BaseDto<string>
    {
        public string Name { get; set; }
    }
}
