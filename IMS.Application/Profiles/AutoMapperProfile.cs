using AutoMapper;
using IMS.Domain.Entites;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS.Application.Features.Product.ProductManagementModel;

namespace IMS.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Product
            CreateMap<Product, GetProductByIdResponse>().ReverseMap();
            CreateMap<Product, AddProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();




            #region Account 
            // Register
            //  CreateMap<AccountGeneralResponse, AccountRegisterRequest>().ReverseMap();
            #endregion
        }
    }
}
