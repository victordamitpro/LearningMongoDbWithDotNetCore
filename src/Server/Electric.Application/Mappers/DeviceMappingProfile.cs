using AutoMapper;
using Electric.Application.Commands;
using Electric.Application.Responses;
using Electric.Core.Entities;
using GateWay = Electric.Core.Entities.GateWay;

namespace Electric.Application.Mappers
{
    public class DeviceMappingProfile : Profile
    {
        public DeviceMappingProfile()
        {
            // Respone
            CreateMap<Device, DeviceResponse>().ReverseMap();
            CreateMap<GateWay, GateWayResponse>().ReverseMap();
            // Request
            CreateMap<Device, CreateDeviceCommand>().ReverseMap();
            CreateMap<Device, UpdateDeviceCommand>().ReverseMap();
            // Map nested command
            CreateMap<GateWay, GateWayCommand>().ReverseMap();
        }
    }
}
