﻿using Board.Core.Models;
using Board.Core.Models.Domains;
using System;
using System.Collections.Generic;

namespace Board.Core.ViewModels
{
    public class PublicationsViewModel

    {
        public PublicationsViewModel()
        {
            PublicationId = new Publication().Id;
        }
        public IEnumerable<Publication> Publications { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public FilterPublications FilterPublications { get; set; }

        public List<FileModel> FileModels { get; set; }

        public List<Tuple<int,string>> ImagesFromFiles { get; set; }

        public int PublicationId { get; set; }
    }
}
