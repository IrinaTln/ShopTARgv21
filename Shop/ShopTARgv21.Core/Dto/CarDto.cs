using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string OwnerName { get; set; }
        public string NumberOfRegistration { get; set; }
        public string VINCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public int Capacity { get; set; }
        public int NumberOfCarDoors { get; set; }
        public int NumberOfPassangersWithDriver { get; set; }
        public int CarWeight { get; set; }
        public DateTime BuildOfDate { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}