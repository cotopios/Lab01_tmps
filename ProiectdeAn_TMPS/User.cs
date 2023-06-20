using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectdeAn_TMPS
{
    public class User : ILibraryObserver
    {
        public string email { get; set; }
        public string password { get; set; }
        public string repeatPass { get; set; }
        public bool isAdmin { get; set; } = false;
        public string notification = null;
        public User(string email = null, string password = null, string repeatPass = null, bool isAdmin = false)
        {
            this.email = email;
            this.password = password;
            this.repeatPass = repeatPass;
            this.isAdmin = isAdmin;
        }

        public void Update(LibraryItem newItem)
        {
            notification = "Un obiect nou a fost adăugat în bibliotecă: " + newItem.GetType().Name + " -- " + newItem.name;
        }
    }

}
