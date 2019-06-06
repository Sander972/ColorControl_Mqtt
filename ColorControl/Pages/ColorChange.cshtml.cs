using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ColorControl.Models;

namespace ColorControl.Pages
{
    public class ColorChangeModel : PageModel
    {
        [BindProperty]

        public Input Input{ get; set; }
        public MqttLib client;
        public string topic = "lamp123456789";
        

        public IActionResult OnPost()
        {
            client = new MqttLib();
            client.StartConnection();
            client.Subscribe(topic);
            client.Publish(topic,Input.Color,1,true);
            //client.CloseConnection();
            return RedirectToPage("/Sent");
        }
        public void OnGet()
        {
            
        }
    }
}