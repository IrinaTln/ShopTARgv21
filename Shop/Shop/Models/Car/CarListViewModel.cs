namespace Shop.Models.Car
{
    public class CarListViewModel
    {
        public Guid? Id { get; set; }
        public string OwnerName { get; set; }
        public string NumberOfRegistration { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public List<IFormFile> Pictures { get; set; }
        public List<PictureViewModel> Image { get; set; } = new List<PictureViewModel>();
    }
}
