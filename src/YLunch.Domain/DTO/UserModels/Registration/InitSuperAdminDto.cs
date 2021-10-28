namespace YLunch.Domain.DTO.UserModels.Registration
{
    public class InitSuperAdminDto
    {
        public string EndpointPassword { get; set; }
        public SuperAdminCreationDto User { get; set; }
    }
}
