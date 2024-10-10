using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Persistance.Helper
{
    public class UploadImages
    {
        public static string SaveFile(IFormFile photoUrl, string file)
        {
            string MainPath1 = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + file;

            // photo Or File name
            string FileName = Guid.NewGuid() + Path.GetFileName(photoUrl.FileName);

            // full Path
            string FullPath1 = Path.Combine(MainPath1, FileName);

            // Save file as Stream
            using (var Stream = new FileStream(FullPath1, FileMode.Create))
            {
                photoUrl.CopyTo(Stream);
            }
            return FileName;
        }
    }
}
