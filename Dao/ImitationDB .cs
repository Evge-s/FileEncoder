using System.Collections.Generic;

namespace EzPaymentBot.Dao
{
    public class ImitationDB
    {
        public List<Model> dbList { get; set; }

        public ImitationDB()
        {
            dbList = new List<Model>
            {
                new Model() { Name = "Азиз Алиев", Links = "https://t.me/joinchat/Ld62ffh-z3I0ZTMy" },
                new Model() { Name = "Chaos Trade", Links = "https://t.me/joinchat/yJgCXjZtg-Q0ZGRi" },
            };
        }

        public string ShowChannels()
        {
            string channels = string.Empty;
            foreach(Model el in dbList)
            {
                channels += $"{el.Name} - {el.Links}\n"; 
            }
            return channels;
        }
    }    
}
