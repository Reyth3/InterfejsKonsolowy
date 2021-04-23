using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    public class Osoba
    {
        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }

        public static List<Osoba> Osoby = new List<Osoba>()
        {
            new Osoba("Jan", "Kowalski", 21),
            new Osoba("Jacek", "Nowak", 33),
            new Osoba("Wiesław", "Cytryna", 39)
        };

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }

        public static explicit operator ListViewItem(Osoba o)
        {
            return new ListViewItem(new string[] { o.Imie, o.Nazwisko, o.Wiek.ToString() });
        }
    
    }
}
