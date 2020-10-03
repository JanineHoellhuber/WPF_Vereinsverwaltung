using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Vereinsverwaltung.Model
{
    public class Mitglieder
    {
        public string Firstname;
        public string Lastname;
        public DateTime Birthdate;
        public string AchievementBadge;


        public string Full_Name()
        {
            return Firstname + " " + Lastname;
        }

      
    }
}
