using AutoMapper;
using Moms.RevenueManagement.Core.Domain.Item.Models;

namespace Moms.RevenueManagement.Core.Domain.Item.Dto
{
    public class ConfigurationProfile: Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<ItemConfiguration, ItemConfigurationDto>();
            CreateMap<ItemMaster, ItemMasterDto>();
            CreateMap<ItemTypeSubType, ItemTypeSubTypeDto>();
        }
    }
}
