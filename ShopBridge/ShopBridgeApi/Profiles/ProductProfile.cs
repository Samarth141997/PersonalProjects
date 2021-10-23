using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Profiles
{
    // Profiles are used for mapping entiities to make assignment, comparing etc operations easy
    //Automapper Package used for mapping
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Entity.Product, Models.ProductModel>().ReverseMap();
            CreateMap<Entity.Product, Models.EditProduct>().ReverseMap();
        }
    }
}
