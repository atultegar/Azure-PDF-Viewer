using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfViewer.Models;

namespace PdfViewer
{
    public interface IBlobService
    {
        public Task<BlobInfo1> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobAsync();

        public Task UploadFileBlobAsync(string filepath, string fileName);

        public Task UploadContentBlobAsync(string content, string fileName);

        public Task DeleteBlobAsync(string blobName);
       
    }
}
