using System;
using System.Collections.Generic;
using System.Text;

namespace ArenaHerois
{
    public abstract class Heroi : IApresentavel
    {
        public string Nome { get; set; }
        public int VidaMaxima { get; set; }

        public int VidaAtual { get; private set; }

        public int DanoMin { get; set; }

        public int DanoMax { get; set; }

        public Heroi(string nome, int vidaMaxima, int danoMin, int danoMax)
        {
            Nome = nome;
            VidaMaxima = vidaMaxima;
            VidaAtual = vidaMaxima; 
            DanoMin = danoMin; 
            DanoMax = danoMax;
        }

        public abstract void Atacar(Heroi alvo);

        public abstract void AtacarEspecial(Heroi alvo);

        //Diminui VidaAtual (não pode ficar negativa)
        public void ReceberDano(int dano)
        {
            VidaAtual -= dano;

            if (VidaAtual < 0)
            {
                VidaAtual = 0;
            }

            EstaVivo(VidaAtual);
        }

        //Aumenta VidaAtual sem ultrapassar VidaMaxima
        public void Curar(int valor)
        {
            VidaAtual += valor;

            if (VidaAtual > VidaMaxima)
            {
                VidaAtual = VidaMaxima;
            }
        }

        //Método EstaVivo() que devolve true se VidaAtual > 0
        public bool EstaVivo(int VidaAtual)
        {
            if (VidaAtual > 0 ) {

                return true;
            }
            else
            {
                return false;
            }
                
        }

        //Função que apresenta o Herói
        public void Apresentar() {
            Console.WriteLine($"  NOME:     {Nome}\n  VIDA:   {VidaAtual}/{VidaMaxima}\n  INTERVALO DE DANO:    {DanoMax - DanoMin}\n");
        }
    }
}
