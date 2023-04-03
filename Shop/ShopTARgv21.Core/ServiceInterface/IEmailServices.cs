using ShopTARgv21.Core.Dto;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IEmailServices : IApplicationServices
    {
        void SendEmail(EmailDto dto);
    }
}
