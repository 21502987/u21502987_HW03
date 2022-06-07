using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace u21502987_HWA3.Models
{
    public class FileModel
    {
        [Display(Name = "File Name")]
        public String FileName { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "Browse Local Files")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}