namespace YLunch.Domain.DTO.UserModels.Registration
{
    public class InitSuperAdminDto : UserCreationDto
    {
        public string EndpointPassword { get; set; }
        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
