using System;
using tpmodul8_1302210095;

public class Program
{
    
    private static void Main(string[] args)
    {
        float suhu;
        int fever_since;

        UICovidConfig UIconfig = new UICovidConfig();
        CovidConfig config = UIconfig.config;

        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai {0}",config.satuan_suhu);
        string input1 = Console.ReadLine();
        suhu = Convert.ToSingle(input1);

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        string input2 = Console.ReadLine();
        fever_since = Convert.ToInt32(input2);

        config.UbahSatuan();

        bool isCelcius = config.satuan_suhu == "celcius";
        bool isFahrenheit = config.satuan_suhu == "fahrenheit";


        bool normalTemp = true;
        if (isCelcius) { normalTemp = suhu >= 36.5 && suhu <= 37.5; }
        if (isFahrenheit) { normalTemp = suhu >= 97.7 && suhu <= 99.5; }

        bool isCovid = !normalTemp && fever_since > config.batas_hari_demam;

        Console.WriteLine(config.batas_hari_demam);
        Console.WriteLine(config.satuan_suhu);

        if (isCovid)
        {
            Console.WriteLine(config.pesan_ditolak);
        }
        else
        {
            Console.WriteLine(config.pesan_diterima);
        }

    }
}
