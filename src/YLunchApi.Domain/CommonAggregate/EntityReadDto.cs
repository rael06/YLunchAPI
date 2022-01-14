using YLunchApi.Domain.Core.Utils;

namespace YLunchApi.Domain.CommonAggregate;

public class EntityReadDto
{
    public string Link { get; }
    public string Id { get; }

    protected EntityReadDto(string id, string resourcesName)
    {
        Id = id;
        Link = $"{EnvironmentUtils.BaseUrl}/{resourcesName}/{id}";
    }
}
