using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XamarinHelloWorld.Models
{
    public class ContactSQLite : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        //backing field para fully implement del get y set.
        private string _firstName;
        private string _lastName;
       
        [MaxLength(50)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;

                //levantar el evento UPDATED
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        [MaxLength(50)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;

                //levantar el evento UPDATED
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        
        public string FullName
        {           
            get { return $"{FirstName} {LastName}"; } //String interpolation de C# 6
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Null conditional operator ? 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
