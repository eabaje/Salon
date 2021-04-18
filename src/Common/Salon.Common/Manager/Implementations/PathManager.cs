﻿using System.IO;
using Microsoft.AspNetCore.Hosting;
using Salon.Common.Managers.Abstract;

namespace Salon.Common.Managers.Implementations
{
    internal class PathManager : IPathManager
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public PathManager(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public string GetCharmImagePath(string categoryUnique)
        {
            var path = Path.Combine("Images", "Charms", categoryUnique);
            return path;
        }

        public string GetProductImagesPath(string categoryUnique, string productUnique)
        {
            var path = Path.Combine("Images", "Products", categoryUnique, productUnique);
            return path;
        }

        public string GetProductPath(string categoryUnique, string productUnique)
        {
            var path = Path.Combine("wwwroot", "Images", "Products", categoryUnique, productUnique);
            return path;
        }

        public string GetPhysicalPath(string path)
        {
            return Path.Combine(hostingEnvironment.ContentRootPath, path);
        }

        public string GetEmailTemplatePath(string templateName)
        {
            var path = Path.Combine("wwwroot", "EmailTemplates", templateName);
            return path;
        }

        public string GetSlideImagesPath()
        {
            return Path.Combine("Images", "Slides");
        }
    }
}
