using System.Collections.Generic;
using System.Linq;
using demoaspnetcli.interfaces;
using demoaspnetcli.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoaspnetcli.Controllers
{

    public class StudentiController : Controller
    {
        //List<Studente> ListaStudenti = new List<Studente>();
        private IStudenti _DatiStudenti;
        public StudentiController(IStudenti DatiStudenti)
        {
            _DatiStudenti = DatiStudenti;
        }
        public IActionResult Index()
        {

            //return Content("Ciao da StudentiController");
            //return new ObjectResult(ListaStudenti);
            return View(_DatiStudenti.EstraiStudenti());

        }

        public IActionResult Details(int id)
        {
            var Studente = _DatiStudenti.EstraiStudente(id);
            if (Studente == null)
            {
                return Content("Studente non trovato");
            }
            else
            {
                return new ObjectResult(Studente);
            }

        }
        public IActionResult Dettaglio(int id)
        {
            var Studente = _DatiStudenti.EstraiStudente(id);
            if (Studente == null)
            {
                return Content("Studente non trovato");
            }
            else
            {
                return View(Studente);
            }
        }
    }
}