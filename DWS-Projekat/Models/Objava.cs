using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DWS_Projekat.Models
{
    public class Objava
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Autor { get; set; }
        public String Content { get; set; }
        public String Slika { get; set; }
    }
}
