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
            string nomFichier = "../../Sauvegardes\\Z_NouvellePartie.txt";

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
                        IHM.AfficherEcranChargement(boutonCourantMenu_2);
                        Bouton = Console.ReadKey();
                        switch (Bouton.Key)
                        {
                            case ConsoleKey.LeftArrow:
                            case ConsoleKey.UpArrow:
                                boutonCourantMenu_2 = (boutonCourantMenu_2 -= 1) % 2;
                                break;
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.DownArrow:
                                boutonCourantMenu_2 = (boutonCourantMenu_2 += 1) % 2;
                                break;
                            case ConsoleKey.Enter:
                                if (boutonCourantMenu_2 == 0) etat = "JEUX";
                                else etat = "CHOIX_PARTIE";
                                break;
                        }
                        if (boutonCourantMenu_2 < 0) boutonCourantMenu_2 = Math.Abs(boutonCourantMenu_2 + 2);
                        break;
                    case "CHOIX_PARTIE":
                        nomFichier = IHM.AfficherPageChargement();
                        etat = "JEUX";
                        break;
                    case "JEUX":
                        Utilisables.InitialiserPartie(nomFichier, ref plateau, ref piecesJouables);
                        IHM.InitialiserEcranJeux();

                        int caseCourante = -1;
                        int pieceCourante = -1;
                        IHM.AfficherEcranJeux(plateau, piecesJouables, caseCourante, pieceCourante);
                        int tour = 0;
                        bool gagner = false;
                        //============================================================================================================
                        //                           Départ de la Boucle de jeux pour un Player vs Ordi
                        //============================================================================================================
                        bool sauvegarde = false;
                        int[] piecesVides = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                        while (!gagner)
                        {
                            if (piecesJouables.SequenceEqual(piecesVides)) IHM.AfficherEgalite();
                            // Tour de l'ordinateur
                            if (tour % 2 == 0)
                            {
                                int idPiece = Utilisables.ChoisirPiece(piecesJouables, sauvegarde, plateau);
                                IHM.AfficherEcranJeux(piecesJouables);
                                sauvegarde = IA.PoserPiece(out int position, idPiece, plateau);
                                IHM.AfficherEcranJeux(plateau);
                                gagner = Utilisables.TesterVictoire(idPiece, position, plateau);
                                if (gagner) etat = "PERDU";
                            }
                            // Tour du joueur
                            else
                            {
                                int idPiece = IA.ChoisirPiece(piecesJouables);
                                sauvegarde = false;
                                IHM.AfficherEcranJeux(piecesJouables);
                                sauvegarde = Utilisables.PoserPiece(out int position, idPiece, plateau, sauvegarde, piecesJouables);
                                IHM.AfficherEcranJeux(plateau);
                                gagner = Utilisables.TesterVictoire(idPiece, position, plateau);
                                if(gagner) etat = "GAGNER";
                            }
                            tour++;
                        }
                        break;
                    case "GAGNER":
                        IHM.AfficherEcranVictoire(true);
                        etat = "REJOUER";
                        break;
                    case "PERDU":
                        IHM.AfficherEcranVictoire(false);
                        etat = "REJOUER";
                        break;
                    case "REJOUER":
                        etat = IHM.AfficherRejouer() ? "MENU_2" : "FIN";
                        break;
                    case "FIN":
                        quitter = true;
                        break;
                }
            }
        }
    }
}
