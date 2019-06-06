using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColorControl.Models
{
    public class Input
    {
        [Required]
        public string NameLamp { get; set; }

        [Required]
        public string Color { get; set; }
        public Input() { }

        public Input(string NameLamp, string Color)
        {
            this.NameLamp = NameLamp;
            this.Color = Color;

        }

    }
}
