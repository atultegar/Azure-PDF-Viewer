using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfViewer.Models;
using PdfViewer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PdfViewer.Controllers
{
    public class Files1Controller : Controller
    {
        IWebHostEnvironment _hostingEnvironment = null;

        private readonly IBlobService1 _blobService;

        public Files1Controller(IBlobService1 blobService)
        {
            _blobService = blobService;
        }

        // Get Title from File Name containing path
        private string GetTitle(string fileName)
        {
            string[] strFileParts = fileName.Split('/');
            string output = "";

            if (strFileParts.Length > 0)
            {
                output = strFileParts[strFileParts.Length - 1];
            }
            return output;
        }

        private string GetParentFolder(string fileName)
        {
            string[] strFileParts = fileName.Split('/');
            string output = "";

            if (strFileParts.Length > 1)
            {
                output = strFileParts[strFileParts.Length - 2];
            }
            
            return output;
        }

        private string GetFolder2(string fileName)
        {
            string[] strFileParts = fileName.Split('/');
            string output = "";

            if (strFileParts.Length > 2)
            {
                output = strFileParts[strFileParts.Length - 3];
            }

            return output;
        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            FileClass fileObj = new FileClass();
            FolderClass folderObj = new FolderClass();
            fileObj.Name = fileName;
                        
            int nId = 1;

            IList<BlobItem> blobs = _blobService.ListBlobAsync();

            foreach (BlobItem item in blobs)
            {
                fileObj.Files.Add(new FileClass()
                {
                    FileId = nId++,
                    Name = item.Name,
                    Title = GetTitle(item.Name),
                    ParentFolder = GetParentFolder(item.Name),
                    FolderPath = GetFolderPath(item.Name)
                    
                });

                folderObj.Folders.Add(new FolderClass()
                {
                    Name = GetParentFolder(item.Name),
                    FolderPath = GetFolderPath(GetFolderPath(item.Name)),
                    ParentFolder = GetParentFolder(GetParentFolder(item.Name))
                });

            }

            return View(fileObj);
        }

        private string GetFolderPath(string fileName)
        {
            string[] strFileParts = fileName.Split('/');
            string output = "";

            if (strFileParts.Length > 1)
            {
                output = String.Join("/",strFileParts.SkipLast(1).ToArray());
            }

            return output;

        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            
            _blobService.UploadFileBlob(file);

            return Index();
        }

        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }

    }
}
