namespace YnovEat.Domain.DTO
{
    public interface IDtoConverter<in T>
    {
        void FromEntity(T entity);
    }
}
