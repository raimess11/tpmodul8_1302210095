using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302210095
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
        public CovidConfig() { }
        public CovidConfig(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius") { satuan_suhu = "fahrenheit"; }
            else if (satuan_suhu == "fahrenheit") { satuan_suhu = "celcius"; }
        }
    }
    public class UICovidConfig
    {
        public CovidConfig config;
        public const string filepath = "C:\\Users\\rahma\\STUDY\\Telkom University\\semester 4\\Konstruksi Perangkat Lunak\\TP 8\\tpmodul8_1302210095\\" +
                "covid_config.json";
        public UICovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private CovidConfig ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
            return config;
        }
        private void SetDefault()
        {
            config = new CovidConfig();
            config.satuan_suhu = "celcius";
            config.batas_hari_demam = 14;
            config.pesan_ditolak = "Anda tidak diprbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config,options);
            File.WriteAllText(filepath,jsonString);
        }
    }
}
