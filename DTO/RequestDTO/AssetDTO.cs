﻿using PPI_Challenge_API.Entities;

namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class AssetDTO
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int AssetTypeID { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
