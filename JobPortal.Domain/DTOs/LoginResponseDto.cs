using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.DTOs
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public string Name { get; set; }

        public List<string> Role { get; set; }
    }
}
