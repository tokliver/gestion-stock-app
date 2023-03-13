using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.DTOs;
using TickLive.Core.Entities;

namespace TickLive.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ForMember(x => x.StockId, x => x.MapFrom(y => y.Id));

        }
    }
}