namespace YLunch.Domain.DTO.UserModels.Registration
{
    public class SuperAdminCreationDto : UserCreationDto
    {
        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
