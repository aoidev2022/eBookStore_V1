using AutoMapper;

namespace eBookStore.API.Author.Application.Author
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Author, AuthorDto>();
        }
    }
}
