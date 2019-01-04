using System;
using System.Linq;

namespace Quarto
{
    class Game
    {
        public static void Main(string[] args)
        {
            //Utilisables.JouerMusiqueIntro();
            int[,] plateau = new int[4, 4]; // variable représentant l'état du plateu de jeux pendant la partie
            int[] piecesJouables = new int[16]; // variable contenant l'identifiant des pieces encore disponibles
            string etat = "MENU_1";
            IHM.InitialiserGraphiques();
            IHM.AfficherIntro();
            bool quitter = false;
            int boutonCourantMenu_1 = 1;
            int boutonCourantMenu_2 = 0;
            while (!quitter)
            {
                System.ConsoleKeyInfo Bouton;
                switch (etat)
                {
                    case "MENU_1":
                        IHM.AfficherMenu(boutonCourantMenu_1);
                        Bouton = Console.ReadKey();
                        switch (Bouton.Key)
                        {
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.UpArrow:
                                boutonCourantMenu_1 = (boutonCourantMenu_1 -= 1) % 3;
                                break;
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.DownArrow:
                                boutonCourantMenu_1 = (boutonCourantMenu_1 += 1) % 3;
                                break;
                            case ConsoleKey.Enter:
                                if (boutonCourantMenu_1 == 2) etat = "FIN"; // Bouton Quitter
                                else if (boutonCourantMenu_1 == 1) etat = "MENU_2";   // Bouton Jouer
                                else { Console.Clear(); etat = "REGLES"; }  // Bouton Règles
                                break;
                        }
                        if (boutonCourantMenu_1 < 0) boutonCourantMenu_1 = Math.Abs(boutonCourantMenu_1 + 3);
                        break;
                    case "REGLES":
                        IHM.AfficherRegles();
                        Bouton = Console.ReadKey();
                        if (Bouton.Key == ConsoleKey.Escape) etat = "MENU_1";
                        break;
                    case "MENU_2":

                        break;
                    case "CHOIX_PARTIE":
                        break;
                    case "JEUX":
                        break;
                    case "FIN":
                        quitter = true;
                        break;
                }
            }
        }
    }
}
