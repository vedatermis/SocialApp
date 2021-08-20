﻿using AutoMapper;
using ServerApp.Dto;
using ServerApp.Models;
using System.Linq;

namespace ServerApp.Helpers
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                            .ForMember(dest => dest.Images, opt =>
                                opt.MapFrom(src => src.Images.FirstOrDefault(i => i.IsProfile)))
                            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailsDTO>();
            CreateMap<Image, ImagesForDetails>();
        }
    }
}
