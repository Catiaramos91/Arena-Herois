using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace ArenaHerois
{
    public class Program
    {
        static List<(string Nome, string Classe, int vitorias, int Fugas, int Pontuacao)> listaCampanhas = new();

        static void Main(string[] args)
        {
            int opcao;
            bool entradaValida;
            bool sair = false;
            
            Console.WriteLine(@"
              |
              |
              + \
              \\.G_.*=.
               `(#'/.\|     *********************
                .>' (_--.   ** ARENA DE HERÓIS **
             _=/d   ,^\     *********************
            ~~ \)-'   '
               / |   a:f
              '  '
            ");


            while (!sair)
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine(" 1 –     Nova Campanha");
                Console.WriteLine(" 2 –     Ver Quadro de Honra");
                Console.WriteLine(" 0 –     Sair");

                //validação de inputs no menu principal
                do
                {
                    entradaValida = int.TryParse(Console.ReadLine(), out opcao);

                    if (!entradaValida || opcao < 0 || opcao > 2)
                    {
                        Console.WriteLine("Opção inválida. Introduza 1, 2 ou 0");
                    }
                    else if (opcao == 1) //Jogar campanha
                    {
                        criarHeroi();
                    }
                    else if (opcao == 2) //Ver quadro de honra
                    {
                        quadroDeHonra();
                    }
                    else //Sair do jogo
                    {
                        Console.WriteLine("A sair...");
                        sair = true;
                    }
                }
                while (!entradaValida || opcao < 0 || opcao > 2);
            }
        }

        //Função que cria o Herói
        static void criarHeroi()
        {
            string? nomeHeroi;
            int opcaoClasse;
            bool entradaValida;

            Console.Write("Introduza o nome do Herói: ");
            nomeHeroi = Console.ReadLine();

            //Caso o nome seja nulo, atribui um nome padrão
            if (string.IsNullOrWhiteSpace(nomeHeroi))
            { 
                nomeHeroi = "Sir Pica‑Pau da Lança";
            }

            //Menu de escolha de classe e respectiva validação
            Console.WriteLine("\nEscolha a Classe: ");
            Console.WriteLine(" 1 -     Guerreiro");
            Console.WriteLine(" 2 -     Mago ");

            do
            {
                entradaValida = int.TryParse(Console.ReadLine(), out opcaoClasse);

                switch (opcaoClasse)
                {
                    case 1:
                        //classe GUERREIRO
                        Guerreiro guerreiro = new Guerreiro(nomeHeroi, 120, 12, 20); 
                        Console.WriteLine("\n---HERÓI CRIADO---");
                        guerreiro.Apresentar();
                        Console.WriteLine("--------------------");
                        jogarCampanha(guerreiro);
                        break;

                    case 2:
                        //classe MAGO
                        Mago mago = new Mago(nomeHeroi, 80, 5, 30);
                        Console.WriteLine("\n---HERÓI CRIADO---");
                        mago.Apresentar();
                        Console.WriteLine("--------------------");
                        jogarCampanha(mago);
                        break;

                    default:
                        entradaValida = false;
                        Console.WriteLine("Opção inválida. Introduza 1 ou 2");
                        break;
                }

            }
            while (!entradaValida);
            
        }

        //Função que começa uma nova campanha
        static void jogarCampanha(Heroi heroi)
        {
            bool entradaValida;
            int opcaoCombate, ataqueEspecial, recuperarVida;
            int batalhasVencidas = 0;
            int pontuacaoCampanha = 0;
            int fugas = 0;
            int turnosDecorridos = 0;

            Inimigo inimigo = Inimigo.GerarParaBatalha(batalhasVencidas);

            Console.WriteLine($"\n***** COMEÇA A BATALHA!! #1 *****\n");

            while (heroi.EstaVivo(heroi.VidaAtual) && inimigo.EstaVivo(inimigo.VidaAtual))
            {
                do
                {
                    Console.ResetColor();

                    Console.WriteLine("\nEscolha uma das seguintes opções:");
                    Console.WriteLine(" 1 -     Atacar");
                    Console.WriteLine(" 2 -     Ataque Especial");
                    Console.WriteLine(" 3 -     Fugir e Curar");

                    entradaValida = int.TryParse(Console.ReadLine(), out opcaoCombate);

                    if (opcaoCombate == 1) //Ataque normal
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        //Heroi ataca Inimigo
                        heroi.Atacar(inimigo);
                        Console.WriteLine($"     {inimigo.Nome} recebe dano!!    <\n");
                        inimigo.EstaVivo(inimigo.VidaAtual);

                        Console.WriteLine(" ---HERÓI---");
                        heroi.Apresentar();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" ---INIMIGO---");
                        inimigo.Apresentar();

                        turnosDecorridos++;

                        if (inimigo.EstaVivo(inimigo.VidaAtual)) 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            //Inimigo ataca se este ainda estiver vivo
                            inimigo.Atacar(heroi);
                            Console.WriteLine($"     {heroi.Nome} recebe dano!!    <\n");
                            heroi.EstaVivo(heroi.VidaAtual);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" ---HERÓI---");
                            heroi.Apresentar();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" ---INIMIGO---");
                            inimigo.Apresentar();

                            //Caso o herói morrer
                            if (!heroi.EstaVivo(heroi.VidaAtual))
                            {
                                Console.WriteLine($">   {heroi.Nome} morreu!! :´(");
                                Console.WriteLine($">   {heroi.Nome} Perdeu a Batalha! - Turnos decorridos: {turnosDecorridos}\n");
                            }

                            Console.ResetColor();
                           
                        }
                        
                    }
                    else if (opcaoCombate == 2) //Ataque Especial
                    {
                        ataqueEspecial = Random.Shared.Next(0, 100);

                        if (ataqueEspecial < 60)
                        {
                            //Sucesso
                            heroi.AtacarEspecial(inimigo);
                        }
                        else
                        {
                            // falha: 0 dano e o inimigo contra-ataca com +50% de dano nesse turno

                            Console.WriteLine($"\n> O ataque especial falha!!! :O");
                            inimigo.AtacarEspecial(heroi);

                            //Caso o herói morrer
                            if (!heroi.EstaVivo(heroi.VidaAtual))
                            {
                                turnosDecorridos++;
                                Console.WriteLine($">   {heroi.Nome} morreu!! :´(\n");
                                Console.WriteLine($">   {heroi.Nome} Perdeu a Batalha! - Turnos decorridos: {turnosDecorridos}\n");
                                turnosDecorridos = 0;
                            }
                            
                        }
                        turnosDecorridos++;

                        Console.ForegroundColor = ConsoleColor.Green;
                        heroi.Apresentar();

                        Console.ForegroundColor = ConsoleColor.Red;
                        inimigo.Apresentar();

                        Console.ResetColor();
                    }
                    else if (opcaoCombate == 3) //Fugir e Curar
                    {
                        /*o herói escapa do alcance do inimigo nesse turno e recupera um valor 
                         * aleatório entre 0 e (VidaMaxima − VidaAtual); o inimigo não ataca, 
                         * mas cada uso desconta 10 pontos da pontuação final da campanha*/

                        Console.ForegroundColor= ConsoleColor.Green;

                        Console.WriteLine($"\n + {heroi.Nome} foge! + ");
                        Console.WriteLine(" + O herói bebe um Elixir da Vida Serena... + ");

                        recuperarVida = Random.Shared.Next(0, (heroi.VidaMaxima - heroi.VidaAtual));
                        heroi.Curar(recuperarVida);

                        Console.WriteLine($" + ... e recupera {recuperarVida} pts de vida! + \n");
                        heroi.Apresentar();

                        fugas++;
                        turnosDecorridos++;
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida. Introduza 1, 2 ou 3\n");
                    }

                    /*Se o inimigo morrer, conta +1 vitória sem recuperar vida e tem um novo
                     * inimigo mais forte*/
                    if (!inimigo.EstaVivo(inimigo.VidaAtual))
                    {
                        
                        Console.WriteLine($">   {inimigo.Nome} morreu!! :D");
                        Console.WriteLine($">   {heroi.Nome} Ganhou a Batalha! - Turnos decorridos: {turnosDecorridos}\n");
                        batalhasVencidas ++;
                        turnosDecorridos = 0;

                        Console.ResetColor();

                        inimigo = Inimigo.GerarParaBatalha(batalhasVencidas);
                        Console.WriteLine($"\n***** COMEÇA A BATALHA!! #{batalhasVencidas+1} *****\n");

                        Console.ForegroundColor = ConsoleColor.Green;
                        heroi.Apresentar();

                        Console.ForegroundColor = ConsoleColor.Red;
                        inimigo.Apresentar();
                    }

                    pontuacaoCampanha = batalhasVencidas * 10 - fugas * 10;
                }
                while (!entradaValida || opcaoCombate <1 || opcaoCombate > 3);

            }

            listaCampanhas.Add((heroi.Nome, heroi.GetType().Name, batalhasVencidas, fugas, pontuacaoCampanha));
        }

        //Função que mostra o quadro de honra
        static void quadroDeHonra()
        {
            var topo = listaCampanhas.OrderByDescending(c => c.Pontuacao).Select(c => c).Take(3);
            int posicao = 1;
            Console.WriteLine("***** QUADRO DE HONRA *****\n");
     
            foreach (var c in topo) 
            {
                Console.WriteLine($"#{posicao++}    {c.Nome}    {c.Classe}  {c.vitorias}V   {c.Fugas}F  {c.Pontuacao}");
            }
        }
        }

        

}


