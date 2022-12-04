using AutoMapper;

namespace eBookStore.API.Book.Application.Book
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Book, BookDto>();
        }
    }
}
