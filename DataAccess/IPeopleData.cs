using DataAccess.Models;

namespace DataAccess
{
    public interface IPeopleData
    {
        Task<List<PersonModel>> GetPeople();
        Task InsertPerson(PersonModel person);
    }
}