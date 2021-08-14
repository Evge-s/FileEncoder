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
                new Model() { Name = "Азиз Алиев", Links = "https://t.me/joinchat/" },
                new Model() { Name = "Chaos Trade", Links = "https://t.me/joinchat/" },
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
