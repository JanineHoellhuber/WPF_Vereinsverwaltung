using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace WPF_Vereinsverwaltung.Model
{
    public class Repository
    {
        
        private const string fileName = "Mitglieder.csv";

        private static Repository instance;

        List<Mitglieder> mitglieder;

        private Repository()
        {
            mitglieder = new List<Mitglieder>();
            LoadCdsFromCsv();
        }

        public static Repository GetInstance()
        {
            if (instance == null)
                instance = new Repository();

            return instance;
        }

        private void LoadCdsFromCsv()
        {
            string[][] mitgliederCsv = fileName.ReadStringMatrixFromCsv(true);
            mitglieder = mitgliederCsv
                .Select(line =>
                new Mitglieder
                {
                    Firstname = line[0],
                    Lastname = line[1],
                    Birthdate = Convert.ToDateTime(line[2]),
                    AchievementBadge = line[3]

                }).ToList();
        }

        public void AddMitglied(Mitglieder mg)
        {
            mitglieder.Add(mg);
        }

        public void DeleteMitglieder(Mitglieder mg)
        {
            mitglieder.Remove(mg);
        }

        public List<Mitglieder> GetAllMitglieder()
        {
            return mitglieder.OrderBy(x => x.Firstname).ToList(); //Erstellt neue Liste!
        }
    }
}
