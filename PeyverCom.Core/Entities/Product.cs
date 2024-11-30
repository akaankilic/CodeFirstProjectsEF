﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeyverCom.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal StartingPrice { get; set; }
        public int CustomerId {  get; set; }
        public Customer Customer { get; set; }
        public ICollection<Auction> Auctions { get; set; }
        public DateTime CreatedAd { get; set; }
        public int Stock {  get; set; }
    }
}