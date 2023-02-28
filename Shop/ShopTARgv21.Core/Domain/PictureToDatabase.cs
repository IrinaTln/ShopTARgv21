using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Domain
{
    public class PictureToDatabase
    {
        public Guid Id { get; set; }
        public string PictureTitle { get; set; }
        public byte[] PictureData { get; set; }
        public Guid? CarId { get; set; }
    }
}
