using AutoMapper;
using CustomerApi.DTOs;
using CustomerApi.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
}
