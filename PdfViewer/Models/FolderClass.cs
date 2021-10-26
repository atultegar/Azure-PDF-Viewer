using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfViewer.Models
{
    public class FolderClass
    {
        public string Name { get; set; }

        public string ParentFolder { get; set; }

        public string FolderPath { get; set; }

        public List<FolderClass> Folders { get; set; } = new List<FolderClass>();
    }
}
