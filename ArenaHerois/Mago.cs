using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaHerois
{
    internal class Mago : Heroi
    {
        public Mago(string nome, int vidaMaxima, int danoMin, int danoMax) : base(nome, vidaMaxima, danoMin, danoMax)
        {
        }

        public override void Atacar(Heroi alvo)
        {
            int danoAtaque = Random.Shared.Next(DanoMin, DanoMax + 1);

            Console.WriteLine($"\n>     {Nome} faz Seta Mística!! :   {danoAtaque}pts ");

            alvo.ReceberDano(danoAtaque);
            
        }

        public override void AtacarEspecial(Heroi alvo)
        {
            int danoAtaque = Random.Shared.Next(DanoMin, DanoMax + 1) * 2;

            Console.WriteLine($"\n>  {Nome} faz um Ataque Especial...");
            Console.WriteLine($"\n>  {Nome} faz Tempestade Arcana!!!    {danoAtaque}pts\n");

            alvo.ReceberDano(danoAtaque);
        }
    }
}
