using System;
using System.Windows;
using System.Windows.Input;

namespace Barber.Windows
{
    public class Journal_Item
    {
        public LinqJournal journal;
        
        public string Client_Name;
        
        public string Client_Surname;
        
        public string Barber_Name;
        
        public string Barber_Surname;

        public string Client_FullName => Client_Name + ' ' + Client_Surname;

        public string Barber_FullName => Barber_Name + ' ' + Barber_Surname;

        public override string ToString()
        {
            return $"{Client_FullName} - {Barber_FullName} {Moment}";
        }

        public DateTime Moment;
    }
}