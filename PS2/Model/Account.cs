using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PS2
{
    public class Account : INotifyPropertyChanged
    {
        //Name thats display in list
        [JsonProperty(Order = 3)]
        public string Name { get { return displayName; } 
            set
            {
                if (value != this.displayName)
                {
                    this.displayName = !string.IsNullOrEmpty(value) ? value : "" ;
                    NotifyPropertyChanged();
                }
            } 
        }
        private string displayName;

        //description for specific account (occupations, lvl etc.)
        [JsonProperty(Order = 5)]
        public string Description { get { return this.description; } 
            set {
                if (value != this.description)
                {
                    this.description = !string.IsNullOrEmpty(value) ? value : "";
                    NotifyPropertyChanged();
                }
            }
        }
        private string description;

        [JsonProperty(Order = 1)]
        public string GameAccount { get { return this.gameAccount; } 
            set {
                if (value != this.gameAccount)
                {
                    this.gameAccount = !string.IsNullOrEmpty(value) ? value : "";
                    NotifyPropertyChanged();
                }
            } 
        }
        private string gameAccount;

        [JsonProperty(Order = 2)]
        public string GamePassword { get { return this.gamePassword; }
            set
            {
                if (value != this.gamePassword)
                {
                    this.gamePassword = !string.IsNullOrEmpty(value) ? value : "";
                    NotifyPropertyChanged();
                }

            }
        }
        private string gamePassword;

        [JsonProperty(Order = 4)]
        public string Occupation
        {
            get { return this.occupation; }
            set
            {
                if (value != this.occupation)
                {
                    this.occupation = !string.IsNullOrEmpty(value) ? value : "";
                    NotifyPropertyChanged();
                }
            }
        }
        private string occupation;
        
        [JsonProperty(Order = 6)]
        public string Group { get { return this.group; } 
            set {
                if (value != this.group)
                {
                    this.group = !string.IsNullOrEmpty(value) ? value : "";
                    NotifyPropertyChanged();
                }
            } 
        
        }
        private string group;

        [JsonProperty(Order = 7)]
        public bool UseAltClientPath { get { return this.useAlternativeClientPath; } 
            set {
                if (value != this.useAlternativeClientPath)
                {
                    this.useAlternativeClientPath = value;
                    NotifyPropertyChanged();
                }
            } 
        }
        private bool useAlternativeClientPath = false;

        static internal List<Account> GetAccounts()
        {
            if (Account.AllAccounts.Count == 0)
                Account.AllAccounts = Account.InitializeAccounts();
            return Account.AllAccounts;
        }
        static private List<Account> AllAccounts = new List<Account>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static private List<Account> InitializeAccounts()
        {
            List<Account> accounts = new List<Account>();

            return accounts;
        }

       
        public Account() { }
        public Account(string displayName)
        {
            this.displayName = displayName;
            this.description = "empty descrition";
            this.occupation = "Not set";
        }

        public Account(string displayName, string description)
        {
            this.displayName = displayName;
            this.description = description;
            this.occupation = "Not set";
        }

        public Account(string displayName, string occupation, string description)
        {
            this.displayName = displayName;
            this.description = description;
            this.occupation = occupation;
        }

        public Account(string login, string password, string name,
                string description, string occupation, bool useAltClient)
        {
            this.gameAccount = login;
            this.gamePassword = password;
            this.displayName = name;
            this.description = description;
            this.occupation = occupation;
            this.useAlternativeClientPath = useAltClient;
        }
        public Account(string login, string password, string name,
                string description, string occupation, string group, bool useAltClient)
        {
            this.gameAccount = login;
            this.gamePassword = password;
            this.displayName = name;
            this.description = description;
            this.occupation = occupation;
            this.useAlternativeClientPath = useAltClient;
            this.group = group;
        }


        public override string ToString()
        {
            return "Name:\t\t" + this.Name + "\n" +
                   "Occupation:\t " + this.Occupation + "\n" +
                   "Description: \t" + this.Description;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var objAsCreds = obj as Account;

            if (objAsCreds == null) return false;

            return this.gameAccount == objAsCreds.gameAccount 
                && this.gamePassword == objAsCreds.gamePassword;
        }
        public override int GetHashCode()
        {
            return (this.gameAccount + this.gamePassword).GetHashCode();
        }
    }


}
