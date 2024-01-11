// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.MVC.Models
{
    using AutoMapper;

    /// <summary>
    /// MapperFactory.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// CreateMapper.
        /// </summary>
        /// <returns>.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Car, MVC.Models.Car>().
                    ForMember(dest => dest.Id, map => map.MapFrom(src => src.CarId)).
                    ForMember(dest => dest.Manufacturer, map => map.MapFrom(src => src.Manufacturer)).
                    ForMember(dest => dest.Model, map => map.MapFrom(src => src.Model)).
                    ForMember(dest => dest.Class, map => map.MapFrom(src => src.Class)).
                    ForMember(dest => dest.Production, map => map.MapFrom(src => src.Production)).
                    ForMember(dest => dest.IsOperational, map => map.MapFrom(src => src.IsOperational)).
                    ForMember(dest => dest.OwnerId, map => map.MapFrom(src => src.OwnerId));
            });
            return config.CreateMapper();
        }
    }
}
