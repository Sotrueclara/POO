

using System;

class Program
{
    static void Main()
    {
        Televisao tv = new Televisao(55);

        tv.Ligar();
        Console.WriteLine("TV ligada no canal: " + tv.Canal);

        tv.IrParaCanal(45);
        Console.WriteLine("Mudou para canal: " + tv.Canal);

        tv.AumentarVolume();
        Console.WriteLine("Volume atual: " + tv.Volume);

        tv.AtivarMudo();
        Console.WriteLine("Está em mudo? " + tv.EstaEmMudo());

        tv.DesativarMudo();
        Console.WriteLine("Volume restaurado: " + tv.Volume);

        tv.Desligar();
        Console.WriteLine("TV desligada.");
    }
}