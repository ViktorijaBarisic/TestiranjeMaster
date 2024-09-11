using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entiteti
{
    public class Osoba
    {

        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public long JMBG { get; set; }

        public DateTime? DatumRodjenja { get; set; }

        public int? Startost
        {
            get { return VratiStarostUMjesecima(); }
            private set { VratiStarostUMjesecima(); }
        }


        public int RodnoMjestoId { get; set; }
        [ForeignKey("RodnoMjestoId")]
        public virtual Mjesto RodnoMjesto { get; set; }


        public int PrebivalisteId { get; set; }
        [ForeignKey("PrebivalisteId")]
        public virtual Mjesto Prebivaliste { get; set; }


        public Osoba() { }

        public Osoba(string ime, string prezime, long jmbg, DateTime datumRodjenja, int rodnoMjestoId, int prebivalisteId)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            DatumRodjenja = datumRodjenja;  
            RodnoMjestoId = rodnoMjestoId;
            PrebivalisteId = prebivalisteId;
        }


        private int? VratiStarostUMjesecima()
        {
            int? starost = null;
            if (DatumRodjenja.HasValue)
            {
                DateTime danasnjiDatum = DateTime.Today;
                DateTime datumRodjenja = DatumRodjenja.Value;
                starost = (danasnjiDatum.Year - datumRodjenja.Year) * 12 + (danasnjiDatum.Month - datumRodjenja.Month);
                if (danasnjiDatum.Day < datumRodjenja.Day) starost--;

            }
            return starost;
        }
    }
}
