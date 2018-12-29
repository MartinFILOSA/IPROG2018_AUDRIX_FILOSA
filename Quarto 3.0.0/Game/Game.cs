using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Game
    {
        public static void Main(string[] args)
        {
            int[,] plateau = new int[4, 4]; // variable représentant l'état du plateu de jeux pendant la partie
            int[] piecesJouables = new int[16]; // variable contenant l'identifiant des pieces encore disponibles
            //int[] piecesJouees = new int[16]; // variable contenant l'identifiant des pieces déjà placées sur le plateau
            bool victoire = false; // paramètre qui maintiens la boucle de jeu: tant qu'il n'y a pas de victoire
            int turn = 0; //compteur de tour qui permet de gerer qui joue (J1 vs J2) ou (Joueur vs Ordinateur)

            IHM.InitialiserGraphiques();
            IHM.AfficherIntro();
            //============================================================================================================
            //                                  Affichage du menu principal du jeu
            //============================================================================================================
            int boutonCourantMenu = 1; // Initialisation du bouton courant du menu
            bool menu = true;
            // Boucle permettant d'afficher le menu de manière interactive
            while (menu)      
            {
                IHM.AfficherMenu(boutonCourantMenu);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();

                // Définition des touches permettants de parcourir les boutons du menu
                if (Bouton.Key == ConsoleKey.LeftArrow) boutonCourantMenu = (boutonCourantMenu -= 1) % 3;
                else if (Bouton.Key == ConsoleKey.RightArrow) boutonCourantMenu = (boutonCourantMenu += 1) % 3;

                // Action à réaliser quand un bouton est selectionné
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (boutonCourantMenu == 2) Environment.Exit(0); // Bouton Quitter
                    else if (boutonCourantMenu == 1) menu = false;   // Bouton Jouer
                    else { Console.Clear(); IHM.AfficherRegles(); }  // Bouton Règles
                }
                if (boutonCourantMenu < 0) boutonCourantMenu = Math.Abs(boutonCourantMenu + 3) % 3; // Permet de réaliser le "modulo négatif"
            }
            //============================================================================================================
            //                                  Affichage du menu de chargement de partie
            //============================================================================================================
            int BoutonChargerCourant = 1;
            bool nouveauJeux = true;
            bool charger = false;
            while (nouveauJeux)                                                        // Menu de jeu, charger, nouvelle partie
            {
                IHM.AfficherEcranChargement(BoutonChargerCourant);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                if (Bouton.Key == ConsoleKey.LeftArrow) BoutonChargerCourant = (BoutonChargerCourant -= 1) % 2;
                else if (Bouton.Key == ConsoleKey.RightArrow) BoutonChargerCourant = (BoutonChargerCourant += 1) % 2;
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (BoutonChargerCourant == 0) nouveauJeux = false;
                    else
                    {
                        charger = true;
                        nouveauJeux = false;
                    }
                }
                if (BoutonChargerCourant < 0) BoutonChargerCourant = Math.Abs(BoutonChargerCourant + 2) % 2;
            }
            //============================================================================================================
            string nomFichier = "../../Sauvegardes\\NouvellePartie.txt";
            
            if (charger == true) // Si on charge un sauvegarde
            {
                nomFichier = IHM.AfficherPageChargement();         
            }
            // Initialisation du tableau et des pieces pour la partie
            Utilisables.InitialiserPartie(nomFichier, ref plateau, ref piecesJouables);

            IHM.InitialiserEcranJeux();
            int caseCourante = -1;
            int pieceCourante = -1;
            IHM.AfficherEcranJeux(plateau, piecesJouables, caseCourante, pieceCourante);
            int tour = 0;
            bool gagner = false;
            
            while (!gagner)
            {
                // Tour de l'ordinateur
                if(tour % 2 == 0)
                {
                    int idPiece = Utilisables.ChoisirPiece(piecesJouables);
                    IHM.AfficherEcranJeux(piecesJouables);
                    IA.PoserPiece(idPiece, plateau);
                    IHM.AfficherEcranJeux(plateau);
                }
                // Tour du joueur
                else
                {
                    int idPiece = IA.ChoisirPiece(piecesJouables);
                    IHM.AfficherEcranJeux(piecesJouables);
                    Utilisables.PoserPiece(idPiece, plateau);
                    IHM.AfficherEcranJeux(plateau);
                }
                tour++;
            }

            Console.Read();





        }
    }
}
