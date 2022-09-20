using CarteAJouer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDame
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal struct Plateau
    {

        private Pion?[,] cases;

        public Plateau()
        {
            cases = new Pion?[10, 10]; 
            Setup();
        }

        public void Setup()
        {
            for (int i = 0; i < 10; i+= 2)
            {
                for (int j = 0; j < 4; j++)
                {
                    cases[j, i + (j % 2 == 0 ? 1 : 0)] = Pion.BLANC;
                    cases[j+6, i + (j % 2 == 0 ? 1 : 0)] = Pion.NOIR;
                }
            }

        }

        public void Afficher(Position highlightRed, Position? highlightBlue = null, List<Position>? highlightGroup = null)
        {
            Console.WriteLine(" ---------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 10; j++)
                {

                    if(highlightGroup != null)
                        foreach(Position pos in highlightGroup) {
                            if (pos.x == i && pos.y == j)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            }
                        }

                    else if (highlightBlue != null && i == highlightBlue?.x && j == highlightBlue?.y) 
                        Console.BackgroundColor = ConsoleColor.DarkCyan;

                    else if (i == highlightRed.x && j == highlightRed.y)
                        Console.BackgroundColor = ConsoleColor.DarkRed;

                    else if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                        Console.BackgroundColor = ConsoleColor.Black;

                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;


                    if( cases[i, j] != null )
                    {
                        if( (int)cases[i, j] % 2 == 0 )
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    switch (cases[i, j])
                    {
                        case null:
                            Console.Write("   ");
                            break;
                        case Pion.BLANC:
                            Console.Write(" b "); 
                            break;
                        case Pion.NOIR:
                            Console.Write(" n ");
                            break;
                        case Pion.DAME_BLANCHE:
                            Console.Write(" B ");
                            break;
                        case Pion.DAME_NOIRE:
                            Console.Write(" N ");
                            break;
                        default:
                            Console.Write(" ~ ");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write('|');
                }
                Console.WriteLine("\n ---------------------------------------");
            }
        }

        public void Afficher()
        {
            Afficher(new Position(-1,-1));
        }




        public Position SelectionnerCase(Position begin, Position? preselect = null, List<Position>? highlightOptions = null)
        {
            Position pos = begin;
            ConsoleKey keyInfo;
            do
            {
                Console.Clear();
                Afficher(pos, preselect, highlightOptions);
                keyInfo = Console.ReadKey().Key;
                switch (keyInfo)
                {
                    case ConsoleKey.LeftArrow:
                        if (pos.y == 0)
                            pos.y = 9;
                        else
                            pos.y--;
                        break;

                    case ConsoleKey.RightArrow:
                        if (pos.y == 9)
                            pos.y = 0;
                        else
                            pos.y++;
                        break;

                    case ConsoleKey.UpArrow:
                        if (pos.x == 0)
                            pos.x = 9;
                        else
                            pos.x--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos.x == 9)
                            pos.x = 0;
                        else
                            pos.x++;
                        break;
                }
            } while (keyInfo != ConsoleKey.Enter);

            return pos;
        }

        bool HasPionOfTypeAt(Pion type, Position pos)
        {
            return cases[pos.x, pos.y] == type;
        }

        bool CaseIsEmpty(Position pos)
        {
            return cases[pos.x, pos.y] == null;
        }

        bool PionOfPlayerAt(Joueur player, Position pos)
        {
            Pion? pion = cases[pos.x, pos.y];
            return pion != null && ((int)pion) % 2 == (int)player;
        }

        List<Position>? GetOptionsOf(Position pos)
        {
            Pion? pion = cases[pos.x, pos.y];

            switch (pion)
            {
                case Pion.BLANC:
                    List<Position> options = new List<Position>();

                    // nextLeft
                    Position toCheck = new Position(pos.x - 1, pos.y + 1);
                    if (pos.x > 0 && CaseIsEmpty(toCheck))
                    {
                        options.Add(toCheck);
                    }
                    else if (CaseIsEmpty(toCheck = new Position(toCheck.x--, toCheck.y--)))
                    {
                        options.Add(toCheck);
                    }

                    return options;

                default:
                    return null;
            }
        }


    }
}
