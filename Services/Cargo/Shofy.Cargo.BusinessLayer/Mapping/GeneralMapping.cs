using AutoMapper;
using Shofy.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using Shofy.Cargo.DtoLayer.Dtos.CompanyDtos;
using Shofy.Cargo.DtoLayer.Dtos.CustomerDtos;
using Shofy.Cargo.DtoLayer.Dtos.DetailDtos;
using Shofy.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.BusinessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Detail, UpdateDetailDto>().ReverseMap();
            CreateMap<Detail, CreateDetailDto>().ReverseMap();
        }
    }
}
