using ApiNtierGenericRepository.BL.DTOs.Rooms;
using ApiNtierGenericRepository.DAL.Entities;
using AutoMapper;

namespace ApiNtierGenericRepository.BL.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomGetDto>();
        CreateMap<RoomCreateDto, Room>();
        CreateMap<RoomUpdateDto, Room>();
    }
}
