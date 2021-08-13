using EzPaymentBot.Dao.Models;
using EzPaymentBot.Dao.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EzPaymentBot.Contoller
{
    public class TelegramChannelRepositoryController
    {
        public DataContext db;

        public TelegramChannelRepositoryController(DataContext context)
        {
            db = context;
        }

        public string ChannelsToString(List<TelegramChannel> channels)
        {
            string result = string.Empty;
            foreach(TelegramChannel ch in channels)
            {
                result += $"{ch.Name} - {ch.Links}\n";
            }
            return result;
        }

        // for channel selection keys to delete 
        public List<string> ChannelsNameToList(List<TelegramChannel> channels)
        {
            List<string> result = new List<string>();
            foreach (TelegramChannel ch in channels)
            {
                result.Add(ch.Name);
            }
            return result;
        }

        public TelegramChannel StringToChannel(List<string> arr)
        {
            return new TelegramChannel() { Name = arr[0], Links = arr[1] };
        }

        public async void AddChannels(TelegramChannel channel)
        {
            db.Channels.Add(channel);
            await db.SaveChangesAsync();
        }

        public async void DeleteChannels(TelegramChannel channel)
        {
            db.Channels.Remove(channel);
            await db.SaveChangesAsync();
        }

        public async TelegramChannel FindChannels(string name)
        {
            //TelegramChannel channel = db.Channels.Include(u => u.Name == name); //.FirstOrDefaultAsync(ch => ch.Name == name);
            TelegramChannel channel = DataContext.
        }
    }
}
