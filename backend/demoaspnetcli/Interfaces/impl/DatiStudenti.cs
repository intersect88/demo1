using System.Collections.Generic;
using System.Linq;
using demoaspnetcli.Models;

namespace demoaspnetcli.interfaces {

    public class DatiStudenti : IStudenti
    {
    private List<Studente> ListaStudenti = new List<Studente>();

    public DatiStudenti()
    {
            ListaStudenti.Add(new Studente { Nome = "Genny", Cognome = "Paudice", Matricola = 1 });
            ListaStudenti.Add(new Studente { Nome = "Jenny", Cognome = "Raudice", Matricola = 2 });
            ListaStudenti.Add(new Studente { Nome = "Gennarina", Cognome = "Caudice", Matricola = 3 });
    }
        public Studente EstraiStudente(int id)
        {
            return ListaStudenti.Where(studente => studente.Matricola == id).FirstOrDefault();
        }

        public IEnumerable<Studente> EstraiStudenti()
        {
            return ListaStudenti;
        }
    }
}