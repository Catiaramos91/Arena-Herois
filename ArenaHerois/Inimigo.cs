using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ArenaHerois
{
    public class Inimigo : Heroi
    {
        public Inimigo(string nome, int vidaMaxima,  int danoMin, int danoMax) : base(nome, vidaMaxima, danoMin, danoMax)
        {
        }

        public override void Atacar(Heroi alvo)
        {
            int danoAtaque = Random.Shared.Next(DanoMin, DanoMax + 1);

            Console.WriteLine($"\n>     {Nome} faz Mordida Rápida!!:    {danoAtaque}pts");

            alvo.ReceberDano(danoAtaque);

        }
        public override void AtacarEspecial(Heroi alvo)
        {
            int danoAtaque = Random.Shared.Next(DanoMin, DanoMax + 1);
            int danoCritico = (int)(danoAtaque * 1.5);

            Console.WriteLine($"{Nome} contra-ataca com +50%!!      {danoCritico}pts    <\n");

            alvo.ReceberDano(danoCritico);
        }

        public static Inimigo GerarParaBatalha(int batalhasVencidas)
        {
            string[] nomesInimigo = { "Goblin", "Orc", "Esqueleto", "Lobo Negro" };

            string nome = nomesInimigo[Random.Shared.Next(nomesInimigo.Length)];

            int vidaMaxima = 40 + 8 * batalhasVencidas;

            int danoMin = 6 + batalhasVencidas;

            int danoMax = 10 + batalhasVencidas;

            return new Inimigo(nome, vidaMaxima, danoMin, danoMax);
        }
    }
    
}
    

