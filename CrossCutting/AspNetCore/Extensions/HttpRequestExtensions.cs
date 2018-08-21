using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Solution.Model.Models;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class HttpRequestExtensions
    {
        public static IEnumerable<FileModel> Upload(this HttpRequest request, string directory)
        {
            Directory.CreateDirectory(directory);

            foreach (var file in request.Form.Files)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(directory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                yield return new FileModel
                {
                    FileName = file.FileName,
                    FileNameSave = fileName
                };
            }
        }
    }
}
