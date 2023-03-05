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
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();

    }
}
