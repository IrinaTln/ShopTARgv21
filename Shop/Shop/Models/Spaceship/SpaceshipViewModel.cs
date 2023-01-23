namespace Shop.Models.Spaceship
{
    public class SpaceshipViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string ModelType { get; set; }
        public string SpaceshipBuilder { get; set; }
        public string PlaceOfBuild { get; set; }
        public int EnginePower { get; set; }
        public int LiftUpToSpaceByTonn { get; set; }
        public int Crew { get; set; }
        public string Passengers { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime BuildOfDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();

    }
}
