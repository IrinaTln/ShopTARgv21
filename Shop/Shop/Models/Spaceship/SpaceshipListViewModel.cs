namespace Shop.Models.Spaceship
{
    public class SpaceshipListViewModel
    {
        public Guid? Id  { get; set; }
        public string Name { get; set; }
        public string ModelType { get; set; }
        public string Passengers { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime BuildOfDate { get; set; }
    }
}
