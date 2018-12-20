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
            //char cube = Convert.ToChar("\u9632");
            char cube = '#';
            string[] lines = new string[5];
            lines[0] = new String(cube ,text.Length+4);
            lines[1] = cube + new String(' ', text.Length+2) +cube;
            lines[2] = Convert.ToString(cube) + ' ' + text + ' ' + Convert.ToString(cube);
            lines[3] = lines[1];
            lines[4] = lines[0];

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

        public static void DisplayGameScreen(string[,] board, int[][] pieces_jouables, int current)         // Affichage de l'interface de jeu
        {
            Console.Clear();
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
                Console.ForegroundColor = ConsoleColor.DarkGray;
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
                //else Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" | " + pieces_jouables[i][0] + " | ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public static void DisplayBoard(string[,] board, int current)       // Affichage du plateau de jeu
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 10);
            /*for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                { 
                    if (Utilisables.Coord2Pos(i, j, board) == current) Console.BackgroundColor = ConsoleColor.DarkRed;
                    else Console.BackgroundColor = ConsoleColor.White;
                    Console.Write((board[i, j]) + " ");
                }
                Console.Write("\n");
            }*/
            int x = 0;
            int y = 0;
            for (int i = 0; i <= 3; i++)
            {
                x = 0;
                //Console.SetCursorPosition(x, y);
                for (int j = 0; j <= 3; j++)                // On affiche chaque ligne à la suite
                {
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write("==========");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("|        |");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("|        |");

                    Console.SetCursorPosition(x, y + 3);                        // On modifie uniquement le texte 
                    Console.Write("|  ");
                    if (Utilisables.Coord2Pos(i, j, board) == current)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(board[i, j]);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  |");

                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("|        |");
                    Console.SetCursorPosition(x, y + 5);
                    Console.Write("|        |");
                    Console.SetCursorPosition(x, y + 6);
                    
                    x += 9;
                    
                    //Console.WriteLine();
                }
                y += 6;
            }
            Console.SetCursorPosition(0, y);
            Console.WriteLine(@"=====================================");
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
