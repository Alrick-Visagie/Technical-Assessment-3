using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class CarDetailModel : Entity<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}
