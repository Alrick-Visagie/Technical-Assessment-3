using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public class CarsMappingProfile : Profile
    {
        public CarsMappingProfile()
        {
            CreateMap<CarDetail, CarDetailModel>().ReverseMap();
        }
    }
}
