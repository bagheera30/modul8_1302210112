using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302210112
{
    internal class BankTransferConfig
    {
        public string bahasa { get; set; }
        public int transferT { get; set; }
        public int tranferL { get; set; }
        public int tranferH { get; set;}
        public List<string> m {  get; set; }
        public string confirm { get; set; }
        public BankTransferConfig()
        {
            m= new List<string>();
            baca();
        }
        public void transfer()
        {
            if (bahasa == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer: ");
            }
            else
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
            }
            string rt=Console.ReadLine();
            int tr = int.Parse(rt);
            int biaya;
            int total;
            if(tr<=transferT)
            {
                biaya=tranferL;
            }
            else
            {
                biaya = tranferH;
            }
            total = tr+ biaya;
            if(bahasa=="en")
            {
                Console.WriteLine($"Transfer fee= {biaya} ");
                Console.WriteLine($"Total amount = {total} ");
                Console.WriteLine("Select transfer method: ");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {biaya}");
                Console.WriteLine($"Total biaya = {total}");
                Console.WriteLine("Pilih metode transfer: ");
            }
            for(int i=0; i<m.Count; i++)
            {
                Console.WriteLine($"{i+1}.{m[i]}");
            }
            string M=Console.ReadLine();
            if (bahasa == "en")
            {
                Console.WriteLine($"Please type{confirm}");
            }
            else
            {
                Console.WriteLine($"Ketik {confirm}"); 
            }
            string c=Console.ReadLine();
            if (c == confirm)
            {
                if(bahasa== "en") {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine(" Proses transfer berhasil");
                }
            }
            else
            {
                if (bahasa == "en")
                {
                    Console.WriteLine("Transfer is cancelled");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
        private string datas => Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "bank_transfer_config.json");
        public void baca()
        {
            var file = File.ReadAllText(datas);
            JsonElement json=JsonSerializer.Deserialize<JsonElement>(file);
            bahasa = json.GetProperty("lang").GetString();
            transferT = json.GetProperty("transfer").GetProperty("threshold").GetInt32();
            tranferL = json.GetProperty("transfer").GetProperty("low_fee").GetInt32();
            tranferH = json.GetProperty("transfer").GetProperty("high_fee").GetInt32();

            confirm = json.GetProperty("confirmation").GetProperty(bahasa).GetString();
            foreach(var item in json.GetProperty("methods").EnumerateArray().ToList())
            {
                m.Add(item.GetString());
            }


        }
    }
}
