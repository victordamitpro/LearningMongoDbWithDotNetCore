using AutoMapper;
using CommonShare.Enums;
using Electric.Application.Commands;
using Electric.Application.Responses;
using Electric.Core.Entities;

namespace Electric.Application.Mappers
{
    public class DeviceMappingProfile : Profile
    {
        public DeviceMappingProfile()
        {
            // Respone
            CreateMap<ElectricMetter, DeviceResponse>()
                .ForMember(vm => vm.Type, m => m.MapFrom(u => (int)ElectricType.Electric))
                .ReverseMap();
            CreateMap<WaterMetter, DeviceResponse>()
                 .ForMember(vm => vm.Type, m => m.MapFrom(u => (int)ElectricType.Water))
                .ReverseMap();
            CreateMap<GateWay, DeviceResponse>()
                .ForMember(vm => vm.Type, m => m.MapFrom(u => (int)ElectricType.GateWay))
                .ReverseMap();

            // Request
            CreateMap<ElectricMetter, CreateElectricMetterCommand>().ReverseMap();
            CreateMap<ElectricMetter, UpdateElectricMetterCommand>().ReverseMap();

            CreateMap<WaterMetter, CreateWaterMetterCommand>().ReverseMap();
            CreateMap<WaterMetter, UpdateWaterMetterCommand>().ReverseMap();

            CreateMap<GateWay, CreateGateWayCommand>().ReverseMap();
            CreateMap<GateWay, UpdateGateWayCommand>().ReverseMap();
            // Map nested command
            //CreateMap<GateWay, GateWayCommand>().ReverseMap();
        }
    }
}
