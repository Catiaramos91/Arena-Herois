# Arena-Herois
Jogo de RPG por turnos em consola, desenvolvido em C# com .NET, no âmbito da UC 00605 - Programar para a web, na vertente backend.

## Descrição do Projeto
O jogador cria o seu herói e enfrenta uma sucessão de inimigos cada vez mais fortes, em combate por turnos, decidindo a cada ronda se ataca, arrisca um ataque especial ou foge para recuperar fôlego. A campanha termina quando o herói cai, e a pontuação final entra no Quadro de Honra da sessão.
 
## Funcionalidades
 
- **Duas classes de herói** — Guerreiro e Mago, cada um com características próprias
- **Combate por turnos** — Atacar, Ataque Especial ou Fugir e Curar
- **Progressão de dificuldade** — Os inimigos ficam mais fortes a cada vitória
- **Quadro de Honra** — Top 3 campanhas da sessão, ordenado por pontuação
- **Menu principal** — Iniciar nova campanha ou consultar o Quadro de Honra

## Estrutura do Projeto
 
```
arena-herois/
├── Program.cs
├── Heroi.cs             (classe abstrata)
├── Guerreiro.cs         (subclasse de Heroi)
├── Mago.cs              (subclasse de Heroi)
├── Inimigo.cs           (subclasse de Heroi)
└── IApresentavel.cs     (interface)
```
 
## Tecnologias Utilizadas
 
- C#
- .NET 10 (Console App)
- LINQ
- Programação Orientada a Objetos (herança, polimorfismo, encapsulamento, interfaces)
