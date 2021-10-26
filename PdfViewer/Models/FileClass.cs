using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfViewer.Models
{
    public class FileClass
    {
        public int FileId { get; set; } = 0;

        public string Name { get; set; } = "";

        public string Title { get; set; } = "";

        public string Path { get; set; } = "";

        public string ParentFolder { get; set; }

        public string FolderPath { get; set; }

        public List<FileClass> Files { get; set; } = new List<FileClass>();

    }
}
