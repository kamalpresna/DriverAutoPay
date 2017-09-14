using AutoMapper;
using PayTNCDriver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Utils.Mappings
{
    public class UserHPPProfileMappingProfile : Profile
    {

        public static void init(IMapperConfigurationExpression mapper)
        {

            mapper.CreateMap<UserHPPProfileBindingModel, UserHPPProfile>()
                .ForMember(destination => destination.Id, option => option.MapFrom(userHPPProfile => userHPPProfile.Id))
                .ForMember(destination => destination.UserId, option => option.MapFrom(userHPPProfile => userHPPProfile.UserId))
                .ForMember(destination => destination.HPPProfileId, option => option.MapFrom(userHPPProfile => userHPPProfile.HPPProfileId))
                .ForMember(destination => destination.FriendlyName, option => option.MapFrom(userHPPProfile => userHPPProfile.FriendlyName))
                .ForMember(destination => destination.PrimaryProfile, option => option.MapFrom(userHPPProfile => userHPPProfile.PrimaryProfile))
                .ReverseMap();
        }
    }
}
