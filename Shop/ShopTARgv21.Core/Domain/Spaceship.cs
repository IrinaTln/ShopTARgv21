using System.ComponentModel.DataAnnotations;

namespace ShopTARgv21.Core.Domain
{
    public class Spaceship
    {
        [Key]
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
        public IEnumerable<FileToDatabase> FileToDatabases { get; set; } = new List<FileToDatabase>();
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
