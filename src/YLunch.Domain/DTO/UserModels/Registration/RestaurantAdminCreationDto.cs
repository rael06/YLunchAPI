namespace YLunch.Domain.DTO.UserModels.Registration
{
    public class RestaurantAdminCreationDto : UserCreationDto
    {
        public string RestaurantId { get; set; }
        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
