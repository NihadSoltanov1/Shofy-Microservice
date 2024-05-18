﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.DtoLayer.Dtos.CargoOperationDtos
{
    public class UpdateCargoOperationDto
    {
        public int Id { get; set; }
        public int Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}