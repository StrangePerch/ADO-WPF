using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Navigation;

namespace Barber
{
    public class BarberShop : DataContext
    {
        public Table<LinqClient> Clients; 
        
        public BarberShop(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
            Clients = GetTable<LinqClient>();
        }

        public BarberShop(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping)
        {
        }

        public BarberShop(IDbConnection connection) : base(connection)
        {
        }

        public BarberShop(IDbConnection connection, MappingSource mapping) : base(connection, mapping)
        {
        }
    }

    [Table(Name = "Clients")]
    public class LinqClient
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "surname")]
        public string Surname { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "phone")]
        public string Phone { get; set; }

        [Column(Name = "genderId")]
        public int GenderId { get; set; }
        
        public string FullName => Name + " " + Surname;

        //[Column(Name = "genderDescription")]
        //public string GenderDescription { get; set; }
    }

}