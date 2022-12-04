using AutoMapper;

namespace eBookStore.API.Basket.Application.Basket
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Basket, BasketDto>().ReverseMap();

            CreateMap<Model.Item, ItemDto>().ReverseMap();
        }
    }
}
