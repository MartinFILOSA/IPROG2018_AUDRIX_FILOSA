using System;
using System.Linq;

namespace Quarto
{
    class Game
    {
        //TODO: Afficher ligne gagnante
        //TODO: IA ++
        
        //TODO: Tips Box + (menu de selection si besoin)
        
        //TODO: refonte
        //TODO: Texte réparti devient l'affichage des boutons
        //TODO: Ecran de chargement


        public static void Main(string[] args)
        {
            //Utilisables.JouerMusiqueIntro();
            int[,] plateau = new int[4, 4]; // variable représentant l'état du plateu de jeux pendant la partie
            int[] piecesJouables = new int[16]; // variable contenant l'identifiant des pieces encore disponibles

            int[][] piecesCalcul = new int[16][]; // à mettre en général dans Game et à passer en paramètres !
            piecesCalcul[0] = new int[] { 0, 0, 0, 0 };
            piecesCalcul[1] = new int[] { 0, 0, 0, 1 };
            piecesCalcul[2] = new int[] { 0, 0, 1, 0 };
            piecesCalcul[3] = new int[] { 0, 0, 1, 1 };
            piecesCalcul[4] = new int[] { 0, 1, 0, 0 };
            piecesCalcul[5] = new int[] { 0, 1, 0, 1 };
            piecesCalcul[6] = new int[] { 0, 1, 1, 0 };
            piecesCalcul[7] = new int[] { 0, 1, 1, 1 };
            piecesCalcul[8] = new int[] { 1, 0, 0, 0 };
            piecesCalcul[9] = new int[] { 1, 0, 0, 1 };
            piecesCalcul[10] = new int[] { 1, 0, 1, 0 };
            piecesCalcul[11] = new int[] { 1, 0, 1, 1 };
            piecesCalcul[12] = new int[] { 1, 1, 0, 0 };
            piecesCalcul[13] = new int[] { 1, 1, 0, 1 };
            piecesCalcul[14] = new int[] { 1, 1, 1, 0 };
            piecesCalcul[15] = new int[] { 1, 1, 1, 1 };

            string[] piecesRep = IHM.CreerPiecesGraphique();

            string etat = "MENU_1";
            IHM.InitialiserGraphiques();
            //IHM.AfficherIntro();

            bool quitter = false;
            int nvxOrdi = 0;
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
                                boutonCourantMenu_2 = (boutonCourantMenu_2 -= 1) % 3;
                                break;
                            case ConsoleKey.RightArrow:
                            case ConsoleKey.DownArrow:
                                boutonCourantMenu_2 = (boutonCourantMenu_2 += 1) % 3;
                                break;
                            case ConsoleKey.Enter:
                                if (boutonCourantMenu_2 == 0) etat = "NVX_ORDI";
                                else if (boutonCourantMenu_2 == 1) etat = "JEUX_2";
                                else etat = "CHOIX_PARTIE";
                                break;
                            case ConsoleKey.Backspace:
                                etat = "MENU_1";
                                break;
                        }
                        if (boutonCourantMenu_2 < 0) boutonCourantMenu_2 = Math.Abs(boutonCourantMenu_2 + 3);
                        break;
                    case "CHOIX_PARTIE":
                        nomFichier = IHM.AfficherPageChargement();
                        if (nomFichier.Contains("PvO")) etat = "JEUX";
                        else etat = "JEUX_2";
                        break;
                    case "NVX_ORDI":
                        nvxOrdi = IHM.ChoixNiveau();
                        etat = "JEUX";
                        break;
                    case "JEUX_2":
                        int tour = Utilisables.InitialiserPartie(nomFichier, ref plateau, ref piecesJouables);
                        IHM.InitialiserEcranJeux();
                        etat = Utilisables.JeuxJvJ(plateau, piecesJouables, tour, piecesCalcul, piecesRep);
                        break;
                    case "JEUX":
                        tour = Utilisables.InitialiserPartie(nomFichier, ref plateau, ref piecesJouables);
                        IHM.InitialiserEcranJeux();
                        etat = Utilisables.JeuxJvO(plateau, piecesJouables, tour, piecesCalcul, nvxOrdi, piecesRep);
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
                        nomFichier = "../../Sauvegardes\\Z_NouvellePartie.txt";
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
