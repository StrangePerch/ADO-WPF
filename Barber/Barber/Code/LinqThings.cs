using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Navigation;

namespace Barber
{
    public class BarberShop : DataContext
    {
        public Table<LinqClient> Clients;
        public Table<LinqGender> Genders;
        public Table<LinqJournal> Journal;
        public Table<LinqBarber> Barbers;
        public Table<LinqReview> Reviews;


        public BarberShop(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
            Clients = GetTable<LinqClient>();
            Genders = GetTable<LinqGender>();
            Journal = GetTable<LinqJournal>();
            Barbers = GetTable<LinqBarber>();
            Reviews = GetTable<LinqReview>();
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

        public override string ToString()
        {
            return FullName;
        }

        //[Column(Name = "genderDescription")]
        //public string GenderDescription { get; set; }
    }


    [Table(Name = "Genders")]
    public class LinqGender
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [Table(Name = "Journal")]
    public class LinqJournal
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(Name = "id_client")]
        public int id_client { get; set; }
        
        [Column(Name = "id_barber")]
        public int id_barber { get; set; }

        [Column(Name = "moment")]
        public DateTime moment { get; set; }
        

    }

    [Table(Name = "Barbers")]
    public class LinqBarber
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
        
        [Column(Name = "bd")]
        public DateTime BirthDate { get; set; }
        [Column(Name = "EmploymentDate")]
        public DateTime EmploymentDate { get; set; }

        public string FullName => Name + " " + Surname;

        public override string ToString()
        {
            return FullName;
        }
    }

    [Table(Name = "Reviews")]
    public class LinqReview
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id")]
        public int Id { get; set; }

        [Column(Name = "journal_id")]
        public int JournalId { get; set; }

        [Column(Name = "text")]
        public string Text { get; set; }

        [Column(Name = "rating")] 
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"{JournalId}# Rating - {Rating}";
        }
    }



}