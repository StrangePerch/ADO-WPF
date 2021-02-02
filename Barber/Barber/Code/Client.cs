using System.Data.Linq.Mapping;

namespace Barber
{
    public class Client  // класс ORM - отображение (mapping) таблицы Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
    }
}