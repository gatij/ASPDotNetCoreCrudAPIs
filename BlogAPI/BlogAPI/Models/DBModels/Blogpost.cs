using System;
using System.Collections.Generic;

namespace BlogAPI.Models.DBModels
{
    public partial class Blogpost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}
