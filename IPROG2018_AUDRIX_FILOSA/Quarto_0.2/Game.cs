using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto_02
{
    public class Game
    {

        //================================variables=================================
        public static string[,] board = new string[4, 4]; //Tableau représentant les cases du plateau
        public static int[][] pieces_jouables = new int[16][]; //Tableau contenant les pièces jouables
        public static int[][] pieces_jouees = new int[16][]; //Tableau contenant les pièces déja jouées
        public static bool win = false;
        public static int turn = 0;
        //===========================================================================

        static void Main(string[] args)
        {
            IHM.InitGraphics();
            IHM.IntroScreen();
            string[] gameParams = IHM.Param();
            int level = 0; //Devra prendre la valeur aassocié dans les paramètre de jeu.
            Utilisables.InitGame(gameParams, pieces_jouables, board/*, file*/);
            int turn = 0;
            bool menu = true;
            bool newgame = true;
            int currentMenuButton = 1;
            while (menu)                                                                   //Menu de jeu règles, jouer
            {
                IHM.DisplayMenu(currentMenuButton);
                System.ConsoleKeyInfo Button = Console.ReadKey();
                if (Button.Key == ConsoleKey.LeftArrow) currentMenuButton = (currentMenuButton -= 1) % 3;
                else if (Button.Key == ConsoleKey.RightArrow) currentMenuButton = (currentMenuButton += 1) % 3;
                else if (Button.Key == ConsoleKey.Enter)
                {
                    if (currentMenuButton == 2) Environment.Exit(0);
                    else if (currentMenuButton == 1) menu = false;
                    else { Console.Clear(); IHM.DisplayRulesScreen(); }
                }

                if (currentMenuButton < 0) currentMenuButton = Math.Abs(currentMenuButton+3)%3;
            }


            //IHM.DisplayBoard(board);
            int currentLSButton = 1;
            while(newgame)                                                              // Menu de jeu, charger, nouvelle partie
            {
                IHM.DisplayLoadScreen(currentLSButton);
                System.ConsoleKeyInfo Button = Console.ReadKey();
                if (Button.Key == ConsoleKey.LeftArrow) currentLSButton = (currentLSButton -= 1) % 3;
                else if (Button.Key == ConsoleKey.RightArrow) currentLSButton = (currentLSButton += 1) % 3;
                else if (Button.Key == ConsoleKey.Enter)
                {
                    if (currentLSButton == 2) Environment.Exit(0);
                    else if  (currentLSButton == 1) newgame = false; 
                    else { Console.Clear(); IHM.DisplayRulesScreen(); }
                }

                if (currentLSButton < 0) currentLSButton = Math.Abs(currentLSButton + 3) % 3;


            }
            int currentPiece = 0;
            int currentDrop = 0;
            bool madeChoice = false;
            bool putDown = false;
            int[] chosenPiece = new int[5];

            while (!win)
            {
                if (turn % 2 == 0)
                {
                    while (!madeChoice)
                    {
                        IHM.DisplayBoard(board, -1);
                        IHM.DisplayPieces(pieces_jouables, currentPiece);

                        System.ConsoleKeyInfo Button = Console.ReadKey();
                        if (Button.Key == ConsoleKey.LeftArrow) currentPiece = (currentPiece -= 1) % pieces_jouables.GetLength(0);
                        else if (Button.Key == ConsoleKey.RightArrow) currentPiece = (currentPiece += 1) % pieces_jouables.GetLength(0);
                        else if (Button.Key == ConsoleKey.Enter)
                        {
                            chosenPiece = pieces_jouables[currentPiece];
                            //pieces_jouables = Utilisables.Choice(currentPiece, pieces_jouables, pieces_jouees);
                            madeChoice = true;
                        }

                        else if (Button.Key == ConsoleKey.P)                                // Pause
                        {
                            bool pause = true;
                            int currentPButton = 0;
                            while (pause)
                            {
                                IHM.DisplayPauseMenu(board, currentPButton);
                                System.ConsoleKeyInfo ButtonP = Console.ReadKey();
                                if (ButtonP.Key == ConsoleKey.LeftArrow) currentPButton = (currentPButton -= 1) % 2;
                                else if (ButtonP.Key == ConsoleKey.RightArrow) currentPButton = (currentPButton += 1) % 2;
                                else if (ButtonP.Key == ConsoleKey.Enter)
                                {
                                    if (currentPButton == 1) Environment.Exit(0);
                                    else if (currentPButton == 0) pause = false;
                                }

                                if (currentPButton < 0) currentPButton = Math.Abs(currentPButton + 2) % 2;

                            }

                        }

                        if (currentPiece < 0) currentPiece = Math.Abs(currentPiece + pieces_jouables.GetLength(0)) % pieces_jouables.GetLength(0);
                    }
                    madeChoice = false;

                    int ComputerDown = Utilisables.rn.Next(0, board.GetLength(0) * board.GetLength(1));
                    int x, y;
                    Utilisables.Pos2Coord(out  x, out y, ComputerDown, board);
                        
                    while (board[x, y] != "    ")
                    {
                        //Console.Write("puuuute");
                        ComputerDown = Utilisables.rn.Next(0, board.GetLength(0) * board.GetLength(1));
                        Utilisables.Pos2Coord(out x, out y, ComputerDown, board);
                    }


                    Utilisables.Add2Board(chosenPiece, board, ComputerDown);
                    //Console.Beep(494, 100); //si
                    pieces_jouables = Utilisables.Choice(currentPiece, pieces_jouables, pieces_jouees);

                    IHM.DisplayBoard(board, -1);
                    win = Utilisables.TestWinCondition(ComputerDown, board, level);
                    


                }

                else if(turn % 2 == 1)
                {
                    currentPiece = Utilisables.ComputerSelect(pieces_jouables);
                    chosenPiece = pieces_jouables[currentPiece];
                    IHM.ShowComputerSelection(pieces_jouables, currentPiece);
                    //pieces_jouables = Utilisables.Choice(currentPiece, pieces_jouables, pieces_jouees);
                    while (!putDown)
                    {
                        IHM.DisplayBoard(board, currentDrop);
                        IHM.ShowComputerSelection(pieces_jouables, currentPiece);

                        System.ConsoleKeyInfo Button = Console.ReadKey();
                        //Console.WriteLine(board.GetLength(0) * board.GetLength(1));
                        //Console.ReadKey();
                        if (Button.Key == ConsoleKey.LeftArrow) currentDrop = (currentDrop -= 1) % (board.GetLength(0) * board.GetLength(1));
                        else if (Button.Key == ConsoleKey.RightArrow) currentDrop = (currentDrop += 1) % (board.GetLength(0) * board.GetLength(1));
                        else if (Button.Key == ConsoleKey.UpArrow) currentDrop = (currentDrop -= 4) % (board.GetLength(0) * board.GetLength(1));
                        else if (Button.Key == ConsoleKey.DownArrow) currentDrop = (currentDrop += 4) % (board.GetLength(0) * board.GetLength(1));
                        else if (Button.Key == ConsoleKey.Enter && Utilisables.CaseFull(board, currentDrop))
                        {
                            Utilisables.Add2Board(chosenPiece, board, currentDrop);
                            Console.Beep(494, 100); //si
                            //pieces_jouables = Utilisables.Choice(currentPiece, pieces_jouables, pieces_jouees);
                            putDown = true;
                            pieces_jouables = Utilisables.Choice(currentPiece, pieces_jouables, pieces_jouees);
                        }
                        else if (Button.Key == ConsoleKey.P)                                // Pause
                        {
                            bool pause = true;
                            int currentPButton = 0;
                            while (pause)
                            {
                                IHM.DisplayPauseMenu(board, currentPButton);
                                System.ConsoleKeyInfo ButtonP = Console.ReadKey();
                                if (ButtonP.Key == ConsoleKey.LeftArrow) currentPButton = (currentPButton -= 1) % 2;
                                else if (ButtonP.Key == ConsoleKey.RightArrow) currentPButton = (currentPButton += 1) % 2;
                                else if (ButtonP.Key == ConsoleKey.Enter)
                                {
                                    if (currentPButton == 1) Environment.Exit(0);
                                    else if (currentPButton == 0) pause = false;
                                }

                                if (currentPButton < 0) currentPButton = Math.Abs(currentPButton + 2) % 2;

                            }

                        }
                        if (currentDrop < 0) currentDrop = Math.Abs(currentDrop + (board.GetLength(0) * board.GetLength(1))) % (board.GetLength(0) * board.GetLength(1));
                    }
                    putDown = false;

                    win = Utilisables.TestWinCondition(currentDrop, board, level);
                    IHM.DisplayBoard(board, -1);

                    

                }

                turn++;
               
                
                
               
               
                /*if (loose == "égalité")
                {
                    Console.WriteLine(loose);
                    win = true;
                    break;
                }*/
            }

            if (turn % 2 == 0) IHM.WinScreen(0);
            else IHM.WinScreen(1);
        }
    }
}