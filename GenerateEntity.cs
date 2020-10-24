using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public partial class GenerateEntity
    {
        public GenerateEntity( string entityName)
        {
            this.EntityName = entityName;
        }
        partial void ChangingProperty(string name, string orginalValue, string newValue);

        public string EntityName { get; }
        private string _FirstName ;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                ChangingProperty("FirstName", _FirstName, value);
                _FirstName = value;
            }
        }
        private string _State;
        public string State
        {
            get { return _State; }
            set
            {
                ChangingProperty("State", _State, value);
                _State = value;
            }
        }

    }
}
