using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Humanizer;

namespace BlogHumanizer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public List<Blog> blogs;

        public ValuesController()
        {
            blogs = new List<Blog>
            {
                new Blog()
                {
                    Title ="MOET IK ECHT KOMEN ?",
                    Date = DateTime.UtcNow - 10.Hours(),
                    Description = "In de meeste beroepen ben je dagelijks op je werk. Je komt s’ochtends aan, neemt een bak koffie en je vertrekt weer als je 8 uur hebt gewerkt ! Elke dag ben je een half uur tot een uur kwijt die tijd kan je ook aan gezin, familie of vrienden kunnen besteden.",
                    Readers = 100
                },
                new Blog()
                {
                    Title = "GottaCleanEmAll",
                            Date = DateTime.UtcNow - 10.Days() + 8.Hours(),
                            Description = "Het is alweer even geleden dat ik het over machine learning heb gehad ! Het wordt tijd dat ik er mee verder ga.",
                            Readers = 1000
                },
                new Blog()
                {
            Title = "Meneer van Dalen wacht op antwoord!",
                            Date = DateTime.UtcNow - 30.Seconds() + 1.Weeks(),
                            Description = "Opeens viel het kwartje vrijdag! ",
                            Readers = 1
                },
                new Blog()
                {
                    Title = "The Expandables",
                    Date = DateTime.UtcNow,
                    Description = "Dit is alweer de laatste blog over de basis data structuren. We behandelen de broertjes short en long van de int en het zusje van de string char.",
                    Readers =666
                }
                ,
                new Blog()
                {
                Title = "nieuwe blog",
                    Date = DateTime.UtcNow - 5.Weeks() + 36.Hours(),
                    Description = "In de meeste beroepen ben je dagelijks op je werk. Je komt s’ochtends aan, neemt een bak koffie en je vertrekt weer als je 8 uur hebt gewerkt ! Elke dag ben je een half uur tot een uur kwijt die tijd kan je ook aan gezin, familie of vrienden kunnen besteden.",
                    Readers = 54
                }
            };

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            DateTime First = DateTime.UtcNow;

            return blogs.Select(x =>
                    new {
                        Date = x.Date.Humanize(),
                        Description = x.Description.Truncate(150),
                        title = x.Title.Humanize(),
                        TimePostedFromNow = (First - x.Date).Humanize(),
                        readers = x.Readers.ToWords(),
                        GreekReader = (x.Readers + 10).ToRoman(),
                        normalGreekReaders = (x.Readers + 10).ToRoman().FromRoman().ToOrdinalWords(),
                        RoundedReaders = (x.Readers + 1000).ToMetric()
                    });
        }


    }
}
