namespace YnovEatApi.Core
{
    public interface IDtoConverter<in T>
    {
        void FromEntity(T entity);
    }
}
