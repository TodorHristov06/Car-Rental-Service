using AutoMapper;
using CarPal.Models;
using CarPal.ViewModels;

namespace CarPal.Маpping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
            CreateMap<Rental, RentalViewModel>().ReverseMap();
        }
    }
}
