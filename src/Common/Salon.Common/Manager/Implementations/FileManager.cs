﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Salon.Common.Managers.Abstract;

namespace Salon.Common.Managers.Implementations
{
    internal class FileManager : IFileManager
    {
        public async Task MoveFileAsync(IFormFile file, string directoryPath, string uniqueFileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imagePath = Path.Combine(directoryPath, uniqueFileName);
            using var stream = new FileStream(imagePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        public void RemoveFile(string path)
        {
            File.Delete(path);

            var directoryPath = Path.GetDirectoryName(path);

            var items = Directory.EnumerateDirectories(directoryPath).ToList();
            items.AddRange(Directory.EnumerateFiles(directoryPath));
            if (!items.Any())
            {
                Directory.Delete(directoryPath);
            }
        }
    }
}
