namespace Shop.Models.Car
{
    public class PictureViewModel
    {
        public Guid PictureId { get; set; }
        public string PictureTitle { get; set; }
        public byte[] PictureData { get; set; }
        public string Picture { get; set; }
        public Guid CarId { get; set; }
    }
}
