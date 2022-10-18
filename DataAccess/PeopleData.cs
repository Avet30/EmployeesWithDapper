using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PeopleData : IPeopleData

    {
        //Access a ISqlDataAccess
        private readonly ISqlDataAccess _db;
        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";

            //charge nos données sans paramètre. Crée un objet vide anonyme
            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }

        //Methode pour insérer des données
        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into dbo.People (FirstName, LastName, EmailAddress, JobTitle, YearsOfExperience)
                            values (@FirstName, @LastName, @EmailAddress, @JobTitle, @YearsOfExperience);";

            //sql = ma requete SQL et person c'est le modele que je passe en
            //parametres de ma methode et ce sont les paramètres pour SaveData
            return _db.SaveDate(sql, person);
        }


    }
}
