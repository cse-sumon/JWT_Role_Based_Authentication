using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTApplication.Models
{
    public partial class Image
    {
        public int ImageID { get; set; }
        public string ImageCaption { get; set; }
        public string ImageName { get; set; }
    }
}
