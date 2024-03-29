﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IRealEstatesServices
    {
        //IEnumerable<RealEstate> GetAllRealEstates();
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> Update(RealEstateDto dto);
        Task<RealEstate> Delete(Guid id);
        Task<RealEstate> GetAsync(Guid id);
        string FilesToApi(RealEstateDto dto, RealEstate realEstate);
    }
}
