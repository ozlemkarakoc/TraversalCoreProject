using AutoMapper;
using DTOLayer.DTOs.AnnouncomentDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncomentAddDto, Announcoment>();
            CreateMap<Announcoment, AnnouncomentAddDto>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();

            CreateMap<AnnouncementListDto, Announcoment>();
            CreateMap<Announcoment, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcoment>();
            CreateMap<Announcoment, AnnouncementUpdateDto>();
        }
    }
}
