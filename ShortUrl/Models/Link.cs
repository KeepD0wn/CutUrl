using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Models
{
    public class Link
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите ссылку")]
        [RegularExpression("^[(http(s)?):\\/\\/(www\\.)?a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)$", ErrorMessage = "Вы ввели некорректную ссылку")]
        public string LongURL { get; set; }        
        public string ShortUrl { get; set; }
        public string CreatedData { get; set; }
        public int Count { get; set; }
    }
}
