using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ArenaHerois
{
    internal class Guerreiro : Heroi
    {
        public Guerreiro(string nome, int vidaMaxima, int danoMin, int danoMax) : base(nome, vidaMaxima, danoMin, danoMax)
        {
        }

        public override void Atacar(Heroi alvo)
        {

            int danoAtaque =  Random.Shared.Next(DanoMin, DanoMax + 1);
            Console.WriteLine($"\n>  {Nome} faz Corte Raso!! :    {danoAtaque}pts");

            alvo.ReceberDano(danoAtaque);

        }

        public override void AtacarEspecial(Heroi alvo)
        {
            int danoAtaque = Random.Shared.Next(DanoMin, DanoMax + 1) * 2;

            Console.WriteLine($"\n>  {Nome} faz um Ataque Especial...");
            Console.WriteLine($"\n>  {Nome} faz Golpe Quebra‑Mundo!!!   {danoAtaque}pts\n");

            alvo.ReceberDano(danoAtaque);
        }
    }
}
