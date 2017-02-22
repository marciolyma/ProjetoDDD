using AutoMapper;

namespace ProjetoDDD.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x => 
            {
                x.AddProfile<DominioToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDominioMappingProfile>();
            });
        }
    }
}