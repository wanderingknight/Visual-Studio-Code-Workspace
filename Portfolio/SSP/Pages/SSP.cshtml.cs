using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSP.Pages
{
    public class SSPModel : PageModel
    {
        [BindProperty]
        public int AnzahlGesten {get; set;}

        public void OnPost()
        {
            if (Request.Form["gesten"] == "")
            {
                return;
            }
            //3, 4, 5
            int AnzahlGesten = Int32.Parse(Request.Form["gesten"]);
            this.AnzahlGesten = AnzahlGesten;
            //0, 1, 2, 3, 4
            int GewaehlteGeste = Int32.Parse(Request.Form["geste"]);

            if (GewaehlteGeste >= AnzahlGesten)
            {
                ViewData["text"] = "Kann nicht TODO";
                ViewData["bot-geste"] = -1;
            }
            else
            {
                Random Random = new Random();
                int BotGeste = Random.Next(AnzahlGesten);

                ViewData["bot-geste"] = BotGeste;

                if (BotGeste == GewaehlteGeste)
                {
                    ViewData["text"] = "Unentschieden";
                    return;
                }


                switch (GewaehlteGeste)
                {
                    // Schere
                    case 0:
                        if (BotGeste == 1 || BotGeste == 4)
                        {
                            ViewData["text"] = "Verloren";
                        }
                        else
                        {
                            ViewData["text"] = "Gewonnen";
                        }
                        break;
                    // Stein
                    case 1:
                        if (BotGeste == 2 || BotGeste == 4)
                        {
                            ViewData["text"] = "Verloren";
                        }
                        else
                        {
                            ViewData["text"] = "Gewonnen";
                        }
                        break;
                    // Papier
                    case 2:
                        if (BotGeste == 0 || BotGeste == 3)
                        {
                            ViewData["text"] = "Verloren";
                        }
                        else
                        {
                            ViewData["text"] = "Gewonnen";
                        }
                        break;
                    // Streichholz
                    case 3:
                        if (BotGeste == 1 || BotGeste == 0)
                        {
                            ViewData["text"] = "Verloren";
                        }
                        else
                        {
                            ViewData["text"] = "Gewonnen";
                        }
                        break;
                    // Brunnen
                    case 4:
                        if (BotGeste == 2 || BotGeste == 3)
                        {
                            ViewData["text"] = "Verloren";
                        }
                        else
                        {
                            ViewData["text"] = "Gewonnen";
                        }
                        break;
                }


            }



        }



    }


}
