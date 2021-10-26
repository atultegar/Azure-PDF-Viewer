using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using PdfViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfViewer.Services
{
    public interface IBlobService1
    {
        //public Task<BlobInfo1> GetBlobAsync(string name);

        public IList<BlobItem> ListBlobAsync();

        public void UploadFileBlob(IFormFile file);
        

        //public Task UploadContentBlobAsync(string content, string fileName);

        //public Task DeleteBlobAsync(string blobName);
    }
}
