using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lunchinator.Data.Entities;
namespace Lunchinator.Domain.BusinessApi
{
    public class YelpBusinessToLunchinatorBusinessMapper
    {
        public Business Map(YelpSharp.Data.Business yelpBusiness)
        {
            var mapper = Mapper.CreateMap<YelpSharp.Data.Business, Business>()
                               .ForMember(m => m.ImageUrl, o => o.MapFrom(s => s.image_url));
            
            var business = Mapper.Map<YelpSharp.Data.Business, Business>(yelpBusiness);

            //couldn't get automapper to play nicely here, so i'm mapping the address manually.
            business.Address1 = yelpBusiness.location.display_address[0];
            if (yelpBusiness.location.display_address.Length > 1)
                business.Address2 = yelpBusiness.location.display_address[1];


            return business;
        }
    }
}
