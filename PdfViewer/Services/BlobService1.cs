using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using PdfViewer.Extensions;
using PdfViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.Threading.Tasks;

namespace PdfViewer.Services
{
    public class BlobService1 : IBlobService1
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService1(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        //public Task DeleteBlobAsync(string blobName)
        //{
        //    throw new NotImplementedException();
        //}

        public BlobInfo1 GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("ebooks");
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = blobClient.Download();

            return new BlobInfo1(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public IList<BlobItem> ListBlobAsync()
        {
            List<BlobItem> blobList = new List<BlobItem>();
            var containerClient = _blobServiceClient.GetBlobContainerClient("ebooks");
            
            foreach (var blobItem in containerClient.GetBlobs())
            {
                blobList.Add(blobItem);
            }

            return blobList;

        }

        //public Task UploadContentBlobAsync(string content, string fileName)
        //{
        //    throw new NotImplementedException();
        //}

        public void UploadFileBlob(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("ebooks");
            var blobClient = containerClient.GetBlobClient(file.Name);
            string filePath = file.FileName;
            blobClient.Upload(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });


        }
    }
}
