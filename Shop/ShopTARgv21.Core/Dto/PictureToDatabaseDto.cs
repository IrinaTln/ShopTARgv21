using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto
{
    public class PictureToDatabaseDto
    {
        public Guid Id { get; set; }
        public string PictureTitle { get; set; }
        public byte[] PictureData { get; set; }
        public Guid? CarId { get; set; }
    }
}
