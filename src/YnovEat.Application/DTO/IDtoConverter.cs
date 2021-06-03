namespace YnovEat.Application.DTO
{
    public interface IDtoConverter<in T>
    {
        void FromEntity(T entity);
    }
}
