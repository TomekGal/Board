using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Board.Core.Models.Domains
{
    public class FileModel 
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public string FilePath { get; set; }

        public byte[] DataFiles { get; set; }

        public int PublicationId { get; set; }

        public Publication Publication { get; set; }
    }
}
