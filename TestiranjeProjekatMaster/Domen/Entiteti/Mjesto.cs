using System.ComponentModel.DataAnnotations;

namespace Domen.Entiteti
{
    public class Mjesto
    {
        [Key]
        public int Id { get; set; }

        public string PostanskiBroj { get; set; }    

        public string Naziv { get; set; }

        public int? BrojStanovnika { get; set; }


        public Mjesto() { }

        public Mjesto(string postanskiBroj, string naziv, int? brojStanovnika = null)
        {
            PostanskiBroj = postanskiBroj;
            Naziv = naziv;
            BrojStanovnika = brojStanovnika;
        }
    }
}