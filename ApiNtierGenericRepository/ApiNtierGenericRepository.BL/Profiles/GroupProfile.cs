using ApiNtierGenericRepository.BL.DTOs.Groups;
using AutoMapper;
using System.Text.RegularExpressions;

namespace ApiNtierGenericRepository.BL.Profiles;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupGetDto>();
        CreateMap<GroupCreateDto, Group>();
        CreateMap<GroupUpdateDto, Group>();
    }
}
