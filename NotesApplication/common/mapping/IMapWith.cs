using AutoMapper;

namespace NotesApplication.common.mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
