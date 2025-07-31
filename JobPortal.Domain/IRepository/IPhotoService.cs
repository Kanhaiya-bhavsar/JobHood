﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JobPortal.Domain.Repositories
{
    public interface IPhotoService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }

}
