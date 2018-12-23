using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto_02
{
    public class IHM
    {
        public static void InitGraphics()
        {
            Console.SetWindowSize(150, 60);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayButtons(string[] buttonsText, int current, int height)
        {
            for(int i = 0; i < buttonsText.Length; i++)
            {
                bool currentButton = false;
                if (i == current) currentButton = true;
                if (i % 3 == 0) DisplayButton("left",buttonsText[i], currentButton, height);
                else if (i % 3 == 1) DisplayButton("center", buttonsText[i], currentButton, height);
                else if (i % 3 == 2) DisplayButton("right", buttonsText[i], currentButton, height);
            }
        }

        public static void DisplayButton(string position, string text, bool current, int height)            // Fonction qui permet l'affichage des boutons
        {
            int startLevel = height;
            Console.BackgroundColor = ConsoleColor.White;
            if (current) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.Black;
            string[] lines = CreateButton(text);
            if (position == "left") foreach (string line in lines) { DisplayLeftText(line, startLevel); startLevel++;}
            else if (position == "center") foreach (string line in lines) { DisplayCenteredText(line, startLevel); startLevel++; }
            else foreach (string line in lines) { DisplayRightText(line, startLevel); startLevel++; }
            Console.BackgroundColor = ConsoleColor.White;
        }

        public static string[] CreateButton(string text)                            // Fonction qui permet la création des boutons du menu
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';

            string[] lines = new string[5];
            lines[0] = new String(topLeftCorner, 1) + new String(horizontalLine ,text.Length+4) + new String(topRightCorner, 1);
            lines[1] = verticalLine + new String(' ', text.Length+4) +verticalLine;
            lines[2] = Convert.ToString(verticalLine) + "  " + text + "  " + Convert.ToString(verticalLine);
            lines[3] = lines[1];
            lines[4] = new String(bottomLeftCorner, 1) + new String(horizontalLine, text.Length + 4) + new String(bottomRightCorner, 1); ;

            return lines;
        }


        public static void DisplayCenteredText(string text, int height)             // Fonction qui permet de centrer le texte
        {
            int width = Console.WindowWidth;
            int start = (width - text.Length) / 2;
            Console.SetCursorPosition(start, height);
            Console.Write(text);
        }

        public static void DisplayLeftText(string text, int height)                 // Fonction qui permet de mettre le texte sur la gauche
        {
            int width = Console.WindowWidth;
            int start = (width - text.Length) / 4;
            Console.SetCursorPosition(start, height);
            Console.Write(text);
        }

        public static void DisplayRightText(string text, int height)                // Fonction qui permet de mettre le texte sur la droite
        {
            int width = Console.WindowWidth;
            int start = ((width - text.Length)/4)*3;
            Console.SetCursorPosition(start, height);
            Console.Write(text);
        }

        public static void IntroScreen()
        {

        }

        public static string[] Param()
        {
            string[] gameParams = new string[] { "  " };
            return gameParams;
        }

        public static void ParseNDisplay(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(@filePath);

            foreach (string line in lines)
            {
                Console.WriteLine(line + "\n");
            }
        }

        public static void DisplayRulesScreen()                         // Affichage des règles
        {
            while (true)
            {
                DisplayCenteredText("Règles", 1);
                DisplayCenteredText("rules...", 3);
                DisplayCenteredText("rules...", 5);
                DisplayCenteredText("Press enter to return to menu or escape to quit", 15);
                System.ConsoleKeyInfo Button = Console.ReadKey();
                if (Button.Key == ConsoleKey.Enter) { Console.Clear(); break; }
                if (Button.Key == ConsoleKey.Escape) Environment.Exit(0);
                
            }
        }

        public static void DisplayMenu(int current)                         // Affichage du menu d'acceuil
        {
            //ParseNDisplay("C:\\Users\\simon\\Desktop\\Cours 1A\\Projets\\IHM\\Quarto_0.2\\DisplayMenu.txt");
            //Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            char block = '\u2588';
            char darkShadow = '\u2593';
            char shadow =  '\u2592';
            char lightShadow = '\u2591';

            //========================================================Q=============================================================
            Console.SetCursorPosition(35, 5);
            Console.Write(new String(block, 7));
            Console.SetCursorPosition(34, 6);
            Console.Write(new String(block, 9));
            Console.SetCursorPosition(33, 7);
            Console.Write(new String(block, 2) + new String(shadow, 4) + "  " + new String(block, 3));
            Console.SetCursorPosition(33, 8);
            Console.Write(new String(block, 2) + new String(shadow, 1) + "      " + new String(block, 2) + new String(shadow, 1));
            Console.SetCursorPosition(33, 9);
            Console.Write(new String(block, 2) + new String(shadow, 1) + "      " + new String(block, 2) + new String(shadow, 1));
            Console.SetCursorPosition(33, 10);
            Console.Write(new String(block, 2) + new String(shadow, 1) + "      " + new String(block, 2) + new String(shadow, 1));
            Console.SetCursorPosition(33, 11);
            Console.Write(new String(block, 2) + "   " + new String(block, 2) + "  " + new String(block, 2)+ new String(shadow, 1));
            Console.SetCursorPosition(34, 12);
            Console.Write(new String(block, 9) + new String(shadow, 1));
            Console.SetCursorPosition(35, 13);
            Console.Write(new String(block, 7));
            Console.SetCursorPosition(41, 14);
            Console.Write(new String(block, 2));

            //========================================================U=============================================================
            Console.SetCursorPosition(50, 5);
            Console.Write(new String(block, 2) + new String(' ', 6) + new String(block, 2) + new String(shadow, 1));
            for(int i = 6; i < 12; i++)
            { 
                Console.SetCursorPosition(50, i);
                Console.Write(new String(block, 2) + new String(shadow, 1) + new String(' ', 5) + new String(block, 2) + new String(shadow, 1));
            }
            Console.SetCursorPosition(50, 12);
            Console.Write(new String(block, 10) + new String(shadow, 1));
            Console.SetCursorPosition(52, 13);
            Console.Write(new String(block, 6) + new String(shadow, 1));

            //========================================================A=============================================================

            Console.SetCursorPosition(67, 5);
            Console.Write(new String(block, 6));
            Console.SetCursorPosition(65, 6);
            Console.Write(new String(block, 2) + "      " + new String(block, 2) + new String(shadow, 1));
            for (int i = 7; i < 14; i++)
            {
                Console.SetCursorPosition(65, i);
                Console.Write(new String(block, 2) + new String(shadow,1) + "     " + new String(block, 2) + new String(shadow, 1));
            }
            Console.SetCursorPosition(65, 9);
            Console.Write(new String(block, 8));
            Console.SetCursorPosition(68, 10);
            Console.Write(new String(shadow, 3));

            //========================================================R=============================================================

            Console.SetCursorPosition(82, 5);
            Console.Write(new String(block, 6));
            Console.SetCursorPosition(80, 6);
            Console.Write(new String(block, 2) + "      " + new String(block, 2) + new String(shadow, 1));
            for (int i = 7; i < 14; i++)
            {
                Console.SetCursorPosition(80, i);
                Console.Write(new String(block, 2) + new String(shadow, 1) + "     " + new String(block, 2) + new String(shadow, 1));
            }
            Console.SetCursorPosition(80, 9);
            Console.Write(new String(block, 8) + new String(' ', 4));
            Console.SetCursorPosition(83, 10);
            Console.Write(new String(shadow, 3));

            //========================================================T=============================================================

            for (int i = 3; i < 14; i++)
            {
                Console.SetCursorPosition(94, i);
                Console.Write(new String(block, 2) + new String(shadow, 1));
            }
            Console.SetCursorPosition(35, 3);
            Console.Write(new String(block, 80));
            /*Console.SetCursorPosition(10, 3);
            Console.Write(new String(shadow, 85));*/

            Console.SetCursorPosition(45, 15);
            Console.Write(new String(block, 70));
            Console.SetCursorPosition(46, 16);
            Console.Write(new String(shadow, 70));

            //========================================================O=============================================================

            Console.SetCursorPosition(102, 5);
            Console.Write(new String(block, 6));
            Console.SetCursorPosition(100, 6);
            Console.Write(new String(block, 2) + "      " + new String(block, 2) + new String(shadow, 1));
            for (int i = 7; i < 13; i++)
            {
                Console.SetCursorPosition(100, i);
                Console.Write(new String(block, 2) + new String(shadow, 1) + "     " + new String(block, 2) + new String(shadow, 1));
            }

            Console.SetCursorPosition(102, 13);
            Console.Write(new String(block, 6));

            //=====================================================LOCK=UP===========================================================

            for(int i = 3; i < 16; i++)
            {
                Console.SetCursorPosition(115, i);
                Console.Write(new String(block, 1));
            }

            for (int i = 4; i < 17; i++)
            {
                Console.SetCursorPosition(116, i);
                Console.Write(new String(shadow, 1));
            }
            /*DisplayCenteredText("Welcome on Quarto !", 1);
            DisplayCenteredText("The rules are simple...", 3);
            DisplayCenteredText("You place the pieces but you don't get to choose them...", 5);
            DisplayCenteredText("Your opponent does it for you", 7);*/

            DisplayButtons(new string[] { "Rules", "Play", "Exit" }, current, 25);

            Console.ForegroundColor = ConsoleColor.Black;

            //========================================================E=============================================================

            Console.SetCursorPosition(64, 40);
            Console.Write(new String(block, 4));
            for(int i = 40; i < 44; i++)
            {
                Console.SetCursorPosition(64, i);
                Console.Write(Convert.ToString(block));
            }
            Console.SetCursorPosition(64, 44);
            Console.Write(new String(block, 4));
            Console.SetCursorPosition(64, 42);
            Console.Write(new String(block,2));

            //========================================================N=============================================================

            for (int i = 40; i < 45; i++)
            {
                Console.SetCursorPosition(70, i);
                Console.Write(Convert.ToString(block) +"   "+ Convert.ToString(block));
            }
            for (int i = 0; i < 3; i++)
                for(int j = 0; j < 5; j++)
                {
                    if(i == j)
                    {
                        Console.SetCursorPosition(71+i, 41+j);
                        Console.Write(Convert.ToString(block));

                    }
                }

            //========================================================S=============================================================

            for(int i = 40; i < 45; i += 2)
            {
                Console.SetCursorPosition(77, i);
                Console.Write(new String(block, 4));
            }

            Console.SetCursorPosition(77, 41);
            Console.Write(Convert.ToString(block));

            Console.SetCursorPosition(80, 43);
            Console.Write(Convert.ToString(block));

            //========================================================C=============================================================

            for(int i = 40; i < 45; i++)
            {
                Console.SetCursorPosition(83, i);
                Console.Write(Convert.ToString(block));
            }
            for (int i = 84; i < 88; i++)
            {
                Console.SetCursorPosition(i, 40);
                Console.Write(Convert.ToString(block));
                Console.SetCursorPosition(i, 44);
                Console.Write(Convert.ToString(block));
            }

            Console.SetCursorPosition(87, 41);
            Console.Write(Convert.ToString(block));
            Console.SetCursorPosition(87, 43);
            Console.Write(Convert.ToString(block));

            //========================================================LOGO==========================================================

            /*char line = '\u2550';
            char diagUp = '\u2571';
            char diagDown = '\u2572';
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(92, 42);
            Console.Write(new String(line, 11));
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 7; j++)
                {
                    if (i == j)
                    {
                        Console.SetCursorPosition(90 + i, 38 - j);
                        Console.Write(Convert.ToString(diagUp));

                    }
                }
            Console.ForegroundColor = ConsoleColor.Green;
            
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 7; j++)
                {
                    if (i == j)
                    {
                        Console.SetCursorPosition(95 - i, 52 - j);
                        Console.Write(Convert.ToString(diagDown));

                    }
                }*/

            //======================================================AUTHORS=========================================================
            Console.ForegroundColor = ConsoleColor.Black;
            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';
            DisplayCenteredText(Convert.ToString(topLeftCorner) + new String(horizontalLine, 70)+ Convert.ToString(topRightCorner), 48);
            DisplayCenteredText("Ce jeux à été réalisé par AUDRIX Simon et FILOSA Martin", 50);
            DisplayCenteredText("Dans le cadre d'un projet informatique de première année", 52);
            DisplayCenteredText("Dernière modification le: 23/12/2018 à 23:11", 54);
            DisplayCenteredText(Convert.ToString(bottomLeftCorner) + new String(horizontalLine, 70) + Convert.ToString(bottomRightCorner), 56);

            for (int i = 49; i < 56; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write(Convert.ToString(verticalLine));
                Console.SetCursorPosition(110, i);
                Console.Write(Convert.ToString(verticalLine));
            }

            //======================================================VERSIONS=========================================================
            Console.SetCursorPosition(125,0);
            Console.Write("VERSION : 2.0.4 - CD-Menu");

        }

        public static void DisplayLoadScreen(int currentLSButton)       // Affichage menu de jeu : Charger ou recommencer une partie
        {
            Console.Clear();
            DisplayCenteredText("Voulez vous commencer une nouvelle partie ?", 2);
            DisplayButtons(new string[] { "Load", "New", "Exit" }, currentLSButton, 15);

        }

        public static void DisplayGameScreen(string[,] board, int current)         // Affichage de l'interface de jeu
        {
            Console.Clear();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            for (int i = 0; i < width / 2; i++)
                for (int j = 0; j < height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(width / 2, (height / 2) -20);
            for (int l = width / 2; l < width; l++)
                Console.Write(Convert.ToString('\u2500'));

            DisplayBoard(board,current);
            //DisplayPieces(0);
        }

        public static void DisplayPieces(int[][] pieces_jouables, int current)  //Selection de pièces par le joueur
        {
            Console.WriteLine("\n\n ");
            for(int i = 0; i < pieces_jouables.GetLength(0); i++)
            {
                if (i == current)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(" | " + pieces_jouables[i][0] + " | ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public static void ShowComputerSelection(int[][] pieces_jouables, int current)  // Selection de l'ordinateur
        {
            for (int i = 0; i < pieces_jouables.GetLength(0); i++)
            {
                if (i == current)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(" | " + pieces_jouables[i][0] + " | ");

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public static void DisplayBoard(string[,] board, int current)       // Affichage du plateau de jeu
        {

            int x = 10;
            int y = (Console.WindowHeight/2)-25;
            string caseFull = "            ";
            string caseEmpty = "              ";
            for (int i = 0; i <= 3; i++)
            {
                x = 10;
                for (int j = 0; j <= 3; j++)                // On affiche chaque ligne à la suite
                {
                    ConsoleColor empty = ConsoleColor.White;
                    ConsoleColor currentPlace = ConsoleColor.DarkRed;

                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(caseEmpty);
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //==============PieceSpotForNow===============
                    Console.SetCursorPosition(x, y + 4);
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    Console.Write("    " + board[i, j] + "    ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 6);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 7);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                        Console.BackgroundColor = currentPlace;
                    else Console.BackgroundColor = empty;
                    //============================================
                    Console.SetCursorPosition(x, y + 8);
                    Console.Write(caseFull);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");




                    x += caseEmpty.Length;
                }
                y += 8;
            }
            Console.SetCursorPosition(0, y);
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine(caseEmpty + " " + caseEmpty + " " + caseEmpty + " " + caseEmpty + " " + caseEmpty);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public static void DisplayPauseMenu(string[,] board, int currentPauseButton)        // Affichage du menu de pause
        {
            Console.Clear();
            DisplayCenteredText("PAUSE", 5);
            DisplayButtons(new string[] { "Continue", "Save" }, currentPauseButton, 15);
        }

        public static void WinScreen(int who)
        {
            if (who == 1) Console.Write("\n + L'ordinateur à gagné");
            else Console.Write("\n + Bravo tu as gagné");
        }
    }
}
