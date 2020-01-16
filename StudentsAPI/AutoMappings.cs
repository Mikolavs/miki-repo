using AutoMapper;

namespace StudentsAPI
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<V1.Models.Student, StudentsAPI.Core.Entities.Student>();
            CreateMap<StudentsAPI.Core.Entities.Student, V1.Models.Student>();
            CreateMap<V1.Models.Filter, V2.Models.Filter>();
            CreateMap<V2.Models.Filter, V1.Models.Filter>();
        }
    }
}
