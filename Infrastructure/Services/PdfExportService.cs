using System.Text;

namespace Infrastructure.Services
{
    public class PdfExportService
    {
        public byte[] GeneratePdf(string content)
        {
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
