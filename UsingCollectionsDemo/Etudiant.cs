using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageCollections
{
    public class Etudiant
    {
        public int NO { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public double NoteCC { get; set; }
        public double NoteDevoir { get; set; }

        public double Moyenne()
        {
            return NoteCC * 0.33 + NoteDevoir * 0.67;
        }

    }
}
