using Mapster;

namespace Core.Mapper;

public interface IMappingProfile
{
    public void Register(TypeAdapterConfig config);
}