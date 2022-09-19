using System.Collections.Generic;
using System.IO;

namespace PS2.Utilities
{
    public class CsvReaderUtility
    {
        public List<Account> ReadAccounts(string fileName)
        {
            using (var file = new StreamReader(fileName))
            {
                string line;
                var accounts = new List<Account>();
                while ((line = file.ReadLine()) != null)
                {
                    int firstComma = line.IndexOf(',');
                    int secondComma = line.IndexOf(',', firstComma + 1);

                    accounts.Add(new Account
                    {
                        GameAccount = line.Substring(0, firstComma),
                        GamePassword = line.Substring(firstComma + 1, secondComma - firstComma - 1),
                        Name = line.Substring(secondComma + 1),
                        Description = "",
                        Occupation = "not set",
                        Group = "",
                        UseAltClientPath = false
                    });
                }
                return accounts;
            }
        }
    }
}
