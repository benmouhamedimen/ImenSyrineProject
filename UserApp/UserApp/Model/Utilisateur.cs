using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Model
{
    class Utilisateur
    {
        public String Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String adresse { get; set; }
        public String motDePasse { get; set; }
        public int cin { get; set; }
        public String dateNaissance { get; set; }
        public int telephone { get; set; }
        public String sexe { get; set; }


    }
}
