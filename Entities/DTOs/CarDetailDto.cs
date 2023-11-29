﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
