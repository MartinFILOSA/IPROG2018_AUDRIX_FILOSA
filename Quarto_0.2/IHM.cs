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
            else Console.ForegroundColor = ConsoleColor.DarkGray;
            string[] lines = CreateButton(text);
            if (position == "left") foreach (string line in lines) { DisplayLeftText(line, startLevel); startLevel++;}
            else if (position == "center") foreach (string line in lines) { DisplayCenteredText(line, startLevel); startLevel++; }
            else foreach (string line in lines) { DisplayRightText(line, startLevel); startLevel++; }
            Console.BackgroundColor = ConsoleColor.White;
        }

        public static string[] CreateButton(string text)                            // Fonction qui permet la création des boutons du menu
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            char horizontalLine = '\u2500';
            char topLeftCorner = '\u250C';
            char topRightCorner = '\u2510';
            char bottomLeftCorner = '\u2514';
            char bottomRightCorner = '\u2518';
            char verticalLine = '\u2502';

            string[] lines = new string[3];
            lines[0] = new String(topLeftCorner, 1) + new String(horizontalLine ,text.Length+2) + new String(topRightCorner, 1);
            //lines[1] = verticalLine + new String(' ', text.Length+2) +verticalLine;
            lines[1] = Convert.ToString(verticalLine) + ' ' + text + ' ' + Convert.ToString(verticalLine);
            //lines[3] = lines[1];
            lines[2] = new String(bottomLeftCorner, 1) + new String(horizontalLine, text.Length + 2) + new String(bottomRightCorner, 1); ;

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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            DisplayCenteredText("Welcome on Quarto !", 1);
            DisplayCenteredText("The rules are simple...", 3);
            DisplayCenteredText("You place the pieces but you don't get to choose them...", 5);
            DisplayCenteredText("Your opponent does it for you", 7);
            DisplayButtons(new string[] { "Rules", "Play", "Exit" }, current, 15);

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
