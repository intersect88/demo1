using System.Collections.Generic;
using demoaspnetcli.Models;

namespace demoaspnetcli.interfaces {

public interface IStudenti
{
    IEnumerable<Studente> EstraiStudenti();
    Studente EstraiStudente(int id);

}
}