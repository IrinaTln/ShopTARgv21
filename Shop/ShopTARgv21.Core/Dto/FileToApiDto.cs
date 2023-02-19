namespace ShopTARgv21.Core.Dto
{
    public class FileToApiDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? RealEstateId { get; set; }
    }
}
