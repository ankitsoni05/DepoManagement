using AutoMapper;
using DAM = DBAccess.DataAccessModels;
using DMM = DriversManagement.Models;

namespace DriversManagement.AutoMapperProfiles
{
    public class ApplicationModelMapper : Profile
    {
        public ApplicationModelMapper()
        {
            CreateMap<DAM.Division, DMM.Division>().ReverseMap();
            CreateMap<DAM.Depo, DMM.Depo>().ReverseMap();
            CreateMap<DAM.Driver, DMM.Driver>().ReverseMap();
            CreateMap<DAM.DriverPay, DMM.DriverPay>().ReverseMap();
        }
    }
}
