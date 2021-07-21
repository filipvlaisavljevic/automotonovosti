using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWS_Projekat.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public String Autor { get; set; }
        public String tekst { get; set; }
        public int Objavaid { get; set; }
    }
}
