using DB_lez06_Task_edicola.Models;
using DB_lez06_Task_edicola.Models.DAL;

namespace DB_lez06_Task_edicola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                
                 * Creare un sistema di gestione edicola.
                 * In un'edicola sono presenti riviste e giocattoli.
                 * Entrambi sono caratterizzati da un codice univoco (assegnato automaticamente all'inserimento nel DB) ed il prezzo.
                 * 
                 * Un gicattolo è caratterizzato almeno da:
                 * - materiale
                 * - età minima
                 * 
                 * La rivista è caratterizzata
                 * - titolo
                 * - casa editrice
                 * 
                 * Creare un sistema che si occupi di:
                 * 1. Inserire riviste o giocattoli
                 * 2. Stampare tutti i prodotti
                 * 3. Stampare solo le riviste (con LINQ)
                 * 4. Stampare solo i giocattoli (con LINQ)
                 * 5. Conta tutti gli elementi (con LINQ)
                 * 5. Cercare un elemento e stamparne i dettagli tramite il codice univoco.
                 */
           
            


            bool insAbi = true;

            while (insAbi)
            {
                Console.WriteLine("Digita il comando per scegliere l'operazione\n" +
                    "I - Inserimento\n" +
                    "S - Stampa\n" +
                    "T - Quantità prodotti\n"+
                    "Q - Esci");
                string? inputUtente = Console.ReadLine();

                switch (inputUtente)
                {
                    case "I":

                        Console.WriteLine("Cosa vuoi inserire,:\n " +
                            "G per giocattoli\n" +
                            "R per rivista");
                         string? inputScelta = Console.ReadLine();
                        switch (inputScelta)
                        {
                            case "G":
                                Console.WriteLine("Inserisci il Nome");
                                string? inNome = Console.ReadLine();

                                Console.WriteLine("Inserisci il Materiale");
                                string? inMateriale = Console.ReadLine();

                                Console.WriteLine("Inserisci il l'età minima ");
                                int inEtaMin = Convert.ToInt32 (Console.ReadLine());

                                Console.WriteLine("Inserisci il Prezzo");
                                double inPrezzo = Convert.ToDouble(Console.ReadLine());

                                Giocattolo gio = new Giocattolo()
                                {
                                    Nome = inNome is not null ? inNome : "N.D",
                                    Materiale = inMateriale is not null ? inMateriale : "N.D",
                                    EtaMin = inEtaMin ,
                                    Prezzo =inPrezzo,
                                };
                                if (GiocattoloDao.GetInstance().Insert(gio))
                                    Console.WriteLine("Giocattolo inserito con successo");
                                else
                                    Console.WriteLine("ERRORE di inserimento");
                                break;
                            case "R":

                                Console.WriteLine("Inserisci il Titolo");
                                string? inTitolo = Console.ReadLine();
                                Console.WriteLine("Inserisci il Prezzo");
                                double inPrezz = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Inserisci il Casa Editrisce ");
                                string? inCasaEd = Console.ReadLine();

                                Rivista riv = new Rivista()
                                {
                                    Titolo = inTitolo is not null ? inTitolo : "N.D.",
                                    Prezzo = inPrezz ,
                                    CasaEditrice = inCasaEd is not null ? inCasaEd : "N.D.",

                                };

                                if (RivistaDao.GetInstance().Insert(riv))
                                    Console.WriteLine("Libro inserito con successo");
                                else
                                    Console.WriteLine("ERRORE di inserimento");

                                break;
                                     default:
                                Console.WriteLine("Non conosco questo comando!");
                                break;


                        }
                     break;

                        
                    case "S":
                        Console.WriteLine("Cosa vuoi Stampare,:\n " +
                            "G per giocattoli\n" +
                            "R per rivista\n" +
                            "T per Tutto");
                        string? scelta = Console.ReadLine();

                        switch (scelta)
                        {

                            case "G":
                                List<Giocattolo> giocattoli = GiocattoloDao.GetInstance().GetAll();
                                var risult = from giocattolo in giocattoli
                                                select giocattolo;

                                foreach (var giocattolo in risult)
                                {
                                    Console.WriteLine($"Rivista: {giocattolo}");


                                }
                                break;

                            case "R":
                                List<Rivista> riviste = RivistaDao.GetInstance().GetAll();
                                var risultato = from rivista in riviste
                                                select rivista;

                                foreach (var revista in risultato)
                                {
                                    Console.WriteLine($"Rivista: {revista}");


                                }
                                break;

                            case "T":
                                List<Giocattolo> el = GiocattoloDao.GetInstance().GetAll();

                                foreach (Giocattolo giocattolo in el)
                                {
                                    Console.WriteLine(giocattolo);
                                }
                                List<Rivista> elnc = RivistaDao.GetInstance().GetAll();

                                foreach (Rivista rivista in elnc)
                                {
                                    Console.WriteLine(rivista);
                                }
                                break;

                            default:
                                Console.WriteLine("Non conosco questo comando!");
                                break;
                        }

                    break;

                    case "T":
                        List<Rivista> rivist = RivistaDao.GetInstance().GetAll();
                        var quantitaRiv = from rivista in rivist
                                          select rivista;
                        var TotRiv = rivist.Count();
                        List<Giocattolo> giocat = GiocattoloDao.GetInstance().GetAll();
                        var quantitaGio = from giocattolo in giocat
                                          select giocattolo;
                        var TotGio = giocat.Count();

                        Console.WriteLine("Totale di Prodotti : " + (TotGio + TotRiv));

                        break;


                    case "Q":
                        insAbi = false;
                        break;
                    default:
                        Console.WriteLine("Non conosco questo comando!");
                        break;
                }
                
            }


        }
    }
}
