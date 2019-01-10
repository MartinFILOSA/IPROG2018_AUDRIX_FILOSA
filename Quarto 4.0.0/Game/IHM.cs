using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    public class IHM
    {
    
        // Fonction permettant d'initialiser des paramètres graphiques globaux pour la suite du jeu
        internal static void InitialiserGraphiques()
        {
            Console.SetWindowSize(150, 60); // Taille de la console 150 x 60 pixels/ caractères
            Console.BackgroundColor = ConsoleColor.White; // Le fond de la console est blanc
            Console.Clear();
        }

        // Fonction créant les pieces affichables
        internal static string[] CreerPiecesGraphique()
        {
            string bordVertical = "\u2502";
            string bordHorizontal = "\u2500";
            string trou = "_";

            string pieceCarreHautGauche = "\u250C";
            string pieceCarreHautDroit = "\u2510";
            string pieceCarreBasGauche = "\u2514";
            string pieceCarreBasDroit = "\u2518";

            string pieceRondeHautGauche = "\u256D";
            string pieceRondeHautDroit = "\u256E";
            string pieceRondeBasGauche = "\u2570";
            string pieceRondeBasDroit = "\u256F";

            //Définition pour les pièces carrées avec et sans trou
            string CarreHautFermer = pieceCarreHautGauche + new String(Convert.ToChar(bordHorizontal), 3) + pieceCarreHautDroit;
            string CarreHautTrouer = pieceCarreHautGauche + pieceCarreHautDroit + trou + pieceCarreHautGauche + pieceCarreHautDroit;
            string CarreBas = pieceCarreBasGauche + new String(Convert.ToChar(bordHorizontal), 3) + pieceCarreBasDroit;

            //Définition pour les pièces rondes avec et sans trou
            string RondHautFermer = pieceRondeHautGauche + new String(Convert.ToChar(bordHorizontal), 3) + pieceRondeHautDroit;
            string RondHautTrouer = pieceRondeHautGauche + pieceRondeHautDroit + trou + pieceRondeHautGauche + pieceRondeHautDroit;
            string RondBas = pieceRondeBasGauche + new String(Convert.ToChar(bordHorizontal), 3) + pieceRondeBasDroit;

            //Bord général rectiligne
            string ligne = bordVertical + "   " + bordVertical;
            string ligneTrouer = bordVertical + " U " + bordVertical;
            string ligneRond = bordVertical + " O " + bordVertical;


            // on défini ici la représentation graphique de toutes les pieces du jeu
            string[] piecesRep = new string[] {CarreBas +"-"+ligne+"-"+ligne+"-"+CarreHautFermer,
                                               CarreBas +"-"+ligne+"-"+ligne+"-"+CarreHautFermer,
                                               CarreBas +"-"+ligne+"-"+ligne+"-"+CarreHautTrouer,
                                               CarreBas +"-"+ligne+"-"+ligne+"-"+CarreHautTrouer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+RondHautFermer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+RondHautFermer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+RondHautTrouer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+RondHautTrouer,

                                               CarreBas+"-"+ligne+"-"+ligne+"-"+ligne+"-"+CarreHautFermer,
                                               CarreBas+"-"+ligne+"-"+ligne+"-"+ligne+"-"+CarreHautFermer,
                                               CarreBas+"-"+ligne+"-"+ligne+"-"+ligne+"-"+CarreHautTrouer,
                                               CarreBas+"-"+ligne+"-"+ligne+"-"+ligne+"-"+CarreHautTrouer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+ligne+"-"+RondHautFermer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+ligne+"-"+RondHautFermer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+ligne+"-"+RondHautTrouer,
                                               RondBas+"-"+ligneRond+"-"+ligne+"-"+ligne+"-"+RondHautTrouer,
                                        };
            return piecesRep;
        }

        internal static int ChoixNiveau()
        {
            bool choix = false;
            int niveaux = 0;
            Console.Clear();
            AfficherQuarto();

            string[] debutant = { "████████     ████████   ██████    ██    ██   ██████████   ██████    ██    ██   ██████████",
                                  "██     ██    ██         ██   ██   ██    ██       ██      ██    ██   ████  ██       ██    ",
                                  "██     ██    █████      ██████    ██    ██       ██      ████████   ██ ██ ██       ██    ",
                                  "██     ██    ██         ██   ██   ██    ██       ██      ██    ██   ██  ████       ██    ",
                                  "████████     ████████   ██████     ██████        ██      ██    ██   ██    ██       ██    "};

            string[] facile = { "████████    ██████    ████████    ████████    ██        ███████",
                                "██         ██    ██   ██             ██       ██        ██     ",
                                "████       ████████   ██             ██       ██        █████  ",
                                "██         ██    ██   ██             ██       ██        ██     ",
                                "██         ██    ██   ████████    ████████    ███████   ███████"};

            string[] moyen  = { "███    ███   ████████    ███     ███   ████████   ██    ██",
                                "████  ████   ██    ██      ██   ██     ██         ████  ██",
                                "██  ██  ██   ██    ██       ████       █████      ██ ██ ██",
                                "██      ██   ██    ██      ███         ██         ██  ████",
                                "██      ██   ████████     ███          ████████   ██    ██" };

            string[] difficile = { "████████   ████████  ████████   ████████   ████████   ████████    ████████    ██        ███████",
                                   "██     ██     ██     ██         ██            ██      ██             ██       ██        ██     ",
                                   "██     ██     ██     ████       ████          ██      ██             ██       ██        █████  ",
                                   "██     ██     ██     ██         ██            ██      ██             ██       ██        ██     ",
                                   "████████   ████████  ██         ██         ████████   ████████    ████████    ███████   ███████"};

            string[] flecheH = {"    ██    ",
                                "  ██  ██  ",
                                "██      ██"};

            string[] flecheB = {"██      ██",
                                "  ██  ██  ",
                                "    ██    "};


            int hauteur = 31;
            foreach (string ligne in debutant)
            {
                AfficherTexteCentrer(ligne, hauteur);
                hauteur++;
            }

            while (!choix)
            {
                Console.Clear();
                AfficherQuarto();
                hauteur = 26;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach(string ligne in flecheH)
                {
                    AfficherTexteCentrer(ligne, hauteur);
                    hauteur++;
                }
                hauteur = 38;
                foreach (string ligne in flecheB)
                {
                    AfficherTexteCentrer(ligne, hauteur);
                    hauteur++;
                }
                Console.ForegroundColor = ConsoleColor.Black;
                AfficherTexteCentrer("Utiliser les flèches haut et bas pour modifier le niveaux", 22);
                AfficherTexteCentrer("Veuillez selectionner un niveau pour l'ordinateur", 43);
                AfficherTexteCentrer("Appuyer sur entrer pour selectionner le niveaux", 44);
                hauteur = 31;
                switch (niveaux)
                {
                    case 0:
                        
                        foreach (string ligne in debutant)
                        {
                            AfficherTexteCentrer(ligne, hauteur);
                            hauteur++;
                        }
                        break;
                    case 1:
                        foreach (string ligne in facile)
                        {
                            AfficherTexteCentrer(ligne, hauteur);
                            hauteur++;
                        }
                        break;
                    case 2:
                        foreach (string ligne in moyen)
                        {
                            AfficherTexteCentrer(ligne, hauteur);
                            hauteur++;
                        }
                        break;
                    case 3:
                        foreach (string ligne in difficile)
                        {
                            AfficherTexteCentrer(ligne, hauteur);
                            hauteur++;
                        }
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Black;
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                switch (Bouton.Key)
                {
                    case ConsoleKey.UpArrow:
                        niveaux = (niveaux + 1) % 4;
                        break;
                    case ConsoleKey.DownArrow:
                        niveaux = (niveaux - 1) % 4;
                        break;
                    case ConsoleKey.Enter:
                        choix = true;
                        break;
                }
                if (niveaux < 0) niveaux += 4;
            }
            return niveaux;
        }

        internal static bool AfficherRejouer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            AfficherQuarto();
            int courantRejouer = 0;
            bool jouer = true;
            bool choix = false;
            ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };
            while (!choix)
            {
                AfficherTextRegulier(new string[] { "Voulez vous rejouer" }, couleur, 25);
                //DessinerBoite(64, 85, 29, 31);
                AfficherBouton(new string[] { "O U I", "N O N" }, courantRejouer, 35);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                if (Bouton.Key == ConsoleKey.LeftArrow) courantRejouer = (courantRejouer -= 1) % 2;
                else if (Bouton.Key == ConsoleKey.RightArrow) courantRejouer = (courantRejouer += 1) % 2;
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (courantRejouer == 1)
                    {
                        choix = true;
                        jouer = false;
                    }
                    else choix = true;

                }
                if (courantRejouer < 0) courantRejouer = Math.Abs(courantRejouer + 2) % 2;
            }
            
            
            
            return jouer;
        }

        // Fonction permettant d'afficher "l'écran de chargement" 
        internal static void AfficherIntro()
        {

            string[] titre ={"███    ██   ████████   ██               ██ ",
                             "████   ██   ██          ██     ███     ██  ",
                             "██ ██  ██   █████        ██   ██ ██   ██   ",
                             "██  ██ ██   ██            ██ ██   ██ ██    ",
                             "██    ███   ████████       ███     ███     "};

            string[] titre2 = {"████████   ██   ██   █████   ██        ██████    ██████   ████████   ██████   ██████ ",
                               "██          ██ ██    ██  ██  ██       ██    ██   ██  ██   ██         ██  ██   ██     ",
                               "████         ███     █████   ██       ██    ██   █████    ████       █████    ██████ ",
                               "██          ██ ██    ██      ██       ██    ██   ██  ██   ██         ██  ██       ██ ",
                               "████████   ██   ██   ██      ███████   ██████    ██  ██   ████████   ██  ██   ██████ "};


            ConsoleColor[] couleurs = {ConsoleColor.Black, ConsoleColor.DarkRed, ConsoleColor.DarkBlue,
                                       ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.Gray};
            for(int i = 30; i > 10; i--)
            {
                Console.ForegroundColor = couleurs[i%couleurs.Length];
                int start =i;
                foreach (string ligne in titre)
                {
                    AfficherTexteCentrer(ligne, start);
                    start++;
                }
                start = i+8;
                foreach (string ligne in titre2)
                {
                    AfficherTexteCentrer(ligne, start);
                    start++;
                }
                System.Threading.Thread.Sleep(400);
                Console.Clear();
            }
        }

        private static void AfficherTexteCentrer(string ligne, int hauteur)
        {
            Console.SetCursorPosition((Console.WindowWidth-ligne.Length) /2, hauteur);
            Console.Write(ligne);
        }

        // Fonction affichant le titre 
        private static void AfficherQuarto()
        {
            char block = '\u2588';
            char shadow = '\u2592';

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
            Console.Write(new String(block, 2) + "   " + new String(block, 2) + "  " + new String(block, 2) + new String(shadow, 1));
            Console.SetCursorPosition(34, 12);
            Console.Write(new String(block, 9) + new String(shadow, 1));
            Console.SetCursorPosition(35, 13);
            Console.Write(new String(block, 7));
            Console.SetCursorPosition(41, 14);
            Console.Write(new String(block, 2));

            //========================================================U=============================================================
            Console.SetCursorPosition(50, 5);
            Console.Write(new String(block, 2) + new String(' ', 6) + new String(block, 2) + new String(shadow, 1));
            for (int i = 6; i < 12; i++)
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
                Console.Write(new String(block, 2) + new String(shadow, 1) + "     " + new String(block, 2) + new String(shadow, 1));
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

            for (int i = 3; i < 16; i++)
            {
                Console.SetCursorPosition(115, i);
                Console.Write(new String(block, 1));
            }
            for (int i = 4; i < 17; i++)
            {
                Console.SetCursorPosition(116, i);
                Console.Write(new String(shadow, 1));
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
        
        // Fonction qui affiche l'écran de victoire dans le cas d'une égalité
        internal static void AfficherEgalite()
        {
            Console.Clear();
            AfficherQuarto();
            ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };
            AfficherTextRegulier(new string[] { "Egalité ! personne ne gagne..." }, couleur, 25);
            DessinerBoite(64, 85, 29, 31);
            AfficherTextRegulier(new string[] { "MERCI d'avoir joué" }, couleur, 30);
            Console.SetCursorPosition(0, 0);
            System.Threading.Thread.Sleep(8000); // A voir si on laisse quitter
            Environment.Exit(0);
        }

        // Fonction qui affiche l'écran de victoire
        internal static void AfficherEcranVictoire(bool joueur)
        {
            Console.Clear();
            AfficherQuarto();
            ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };
            if (joueur) AfficherTextRegulier(new string[] { "Vous avez gagné !! félicitations" }, couleur, 25);
            else AfficherTextRegulier(new string[] { "L'ordinateur à gagné... Dommage" }, couleur, 25);
            DessinerBoite(64,85,29,31);
            AfficherTextRegulier(new string[] { "MERCI d'avoir joué" }, couleur, 30);
            Console.SetCursorPosition(0, 0);
            AfficherChargement(40, 8);
        }

        private static void AfficherChargement(int hauteur, int duree)
        {
            Console.SetCursorPosition(70,hauteur+1);
            Console.Write("Chargement");
            for (int i = 0; i < duree; i++)
            {
                Console.SetCursorPosition(67+i,hauteur);
                Console.Write(new string('═', i));
                System.Threading.Thread.Sleep(1000);
            }
            
        }

        // Fonction de pause permettant de sauvegarder, quitter ou reprendre le jeux
        internal static bool AfficherMenuPause(bool sauvegarde, int[,] plateau, int[] piecesJouables, int tour)
        {
            
            bool pause = true;
            int courant = 1;
            while (pause)
            {
                Console.Clear();
                Console.Write(sauvegarde);
                AfficherQuarto();
                AfficherBouton(new string[] { "Reprendre", "Sauvegarder", "Quitter" }, courant, 25);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                // Définition des touches permettants de parcourir les boutons du menu
                if (Bouton.Key == ConsoleKey.LeftArrow) courant = (courant -= 1) % 3;
                else if (Bouton.Key == ConsoleKey.RightArrow) courant = (courant += 1) % 3;

                // Action à réaliser quand un bouton est selectionné
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (courant == 2 && sauvegarde == true) Environment.Exit(0); // Bouton Quitter
                    else if (courant == 2 && sauvegarde == false) AfficherQuitter();
                    else if (courant == 1)
                    {
                        Utilisables.SauvegarderPartie(plateau, piecesJouables, tour);
                        sauvegarde = true;
                        string sauvegardeFaite = "Votre partie à bien été enregistrée";
                        string vide = new string(' ', sauvegardeFaite.Length);
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition((Console.WindowWidth - sauvegardeFaite.Length) / 2, 35);
                            Console.Write(sauvegardeFaite);
                            System.Threading.Thread.Sleep(800);
                            Console.SetCursorPosition((Console.WindowWidth - sauvegardeFaite.Length) / 2, 35);
                            Console.Write(vide);
                            System.Threading.Thread.Sleep(200);
                        }
                        //pause = false;
                    }
                    else
                    {
                        InitialiserEcranJeux();
                        pause = false;
                    }  // Bouton Reprendre
                }
                if (courant < 0) courant = Math.Abs(courant + 3) % 3; // Permet de réaliser le "modulo négatif"

                
            }
            return sauvegarde;
        }

        // Notif box: êtes vous sur de vouloir quitter ?
        internal static void AfficherQuitter()
        {
            Console.BackgroundColor = ConsoleColor.White;
            bool sur = false;
            int courantQuitter = 1;
            while (!sur)
            {
                Console.Clear();
                AfficherQuarto();
                ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };
                AfficherTextRegulier(new string[] { "Votre partie en cours n'est pas sauvegardée" }, couleur, 25);
                AfficherTextRegulier(new string[] { "Si vous quittez des coups joués seront perdus" }, couleur, 27);
                AfficherTextRegulier(new string[] { "Etes vous sur de vouloir quitter ?" }, couleur, 31);
                AfficherBouton(new string[] { "O U I", "N O N" }, courantQuitter, 35);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                if (Bouton.Key == ConsoleKey.LeftArrow) courantQuitter = (courantQuitter -= 1) % 2;
                else if (Bouton.Key == ConsoleKey.RightArrow) courantQuitter = (courantQuitter += 1) % 2;
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (courantQuitter == 1) sur = true;
                    else Environment.Exit(0);
                }
                if (courantQuitter < 0) courantQuitter = Math.Abs(courantQuitter + 2) % 2;
            }
        }

        internal static void AfficherQuitter(int[,] plateau, int[] piecesJouables, int caseCourante = -1, int pieceCourante = -1, int idPiece = -1)
        {
            Console.BackgroundColor = ConsoleColor.White;
            bool sur = false;
            int courantQuitter = 1;
            while (!sur)
            {
                Console.Clear();
                AfficherQuarto();
                ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };
                AfficherTextRegulier(new string[] {"Votre partie en cours n'est pas sauvegardée"}, couleur, 25);
                AfficherTextRegulier(new string[] { "Si vous quittez des coups joués seront perdus" }, couleur, 27);
                AfficherTextRegulier(new string[] { "Etes vous sur de vouloir quitter ?" }, couleur, 31);
                AfficherBouton(new string[] { "O U I", "N O N" }, courantQuitter, 35);
                System.ConsoleKeyInfo Bouton = Console.ReadKey();
                if (Bouton.Key == ConsoleKey.LeftArrow) courantQuitter = (courantQuitter -= 1) % 2;
                else if (Bouton.Key == ConsoleKey.RightArrow) courantQuitter = (courantQuitter += 1) % 2;
                else if (Bouton.Key == ConsoleKey.Enter)
                {
                    if (courantQuitter == 1) sur = true;
                    else Environment.Exit(0);
                }
                if (courantQuitter < 0) courantQuitter = Math.Abs(courantQuitter + 2) % 2;
            }
            Console.Clear();
            InitialiserEcranJeux();
            AfficherChoixOrdi(idPiece);
            AfficherEcranJeux(plateau, piecesJouables, caseCourante, pieceCourante);
        }

        // Fonction permettant d'afficher l'écran de menu
        internal static void AfficherMenu(int courant)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = System.Text.Encoding.UTF8; // vérifier ??
            Console.Clear();
            //Quelques symboles et caractères utiles pour l'affichage du menu
            char block = '\u2588';
            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';

            AfficherQuarto();

            //========================================================E=============================================================

            Console.SetCursorPosition(64, 40);
            Console.Write(new String(block, 4));
            for (int i = 40; i < 44; i++)
            {
                Console.SetCursorPosition(64, i);
                Console.Write(Convert.ToString(block));
            }
            Console.SetCursorPosition(64, 44);
            Console.Write(new String(block, 4));
            Console.SetCursorPosition(64, 42);
            Console.Write(new String(block, 2));

            //========================================================N=============================================================

            for (int i = 40; i < 45; i++)
            {
                Console.SetCursorPosition(70, i);
                Console.Write(Convert.ToString(block) + "   " + Convert.ToString(block));
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        Console.SetCursorPosition(71 + i, 41 + j);
                        Console.Write(Convert.ToString(block));
                    }
                }

            //========================================================S=============================================================

            for (int i = 40; i < 45; i += 2)
            {
                Console.SetCursorPosition(77, i);
                Console.Write(new String(block, 4));
            }
            Console.SetCursorPosition(77, 41);
            Console.Write(Convert.ToString(block));
            Console.SetCursorPosition(80, 43);
            Console.Write(Convert.ToString(block));

            //========================================================C=============================================================

            for (int i = 40; i < 45; i++)
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

            //======================================================AUTHORS=========================================================
            Console.ForegroundColor = ConsoleColor.Black;

            string boiteHaut = Convert.ToString(topLeftCorner) + new string(horizontalLine, 70) + Convert.ToString(topRightCorner);
            string boiteBas = Convert.ToString(bottomLeftCorner) + new string(horizontalLine, 70) + Convert.ToString(bottomRightCorner);
            ConsoleColor[] couleur = new ConsoleColor[] { ConsoleColor.Black };

            AfficherTextRegulier(new string[] { boiteHaut }, couleur, 48);
            AfficherTextRegulier(new string[] { "Ce jeux à été réalisé par AUDRIX Simon et FILOSA Martin" }, couleur , 50);
            AfficherTextRegulier(new string[] { "Dans le cadre d'un projet informatique de première année" }, couleur, 52);
            AfficherTextRegulier(new string[] { "Dernière modification le: 23/12/2018 à 23:11" }, couleur, 54);
            AfficherTextRegulier(new string[] { boiteBas }, couleur, 56);
            
            // Créer les bordures de la boite
            for (int i = 49; i < 56; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write(Convert.ToString(verticalLine));
                Console.SetCursorPosition(110, i);
                Console.Write(Convert.ToString(verticalLine));
            }

            //======================================================VERSIONS=========================================================
            string nomVersion = "VERSION : 4.2.3 - MobyDick";
            Console.SetCursorPosition(Console.WindowWidth - (nomVersion.Length + 1), 0);
            Console.Write(nomVersion);

            //========================================================MENU===========================================================

            AfficherBouton(new string[] { "Règles", "Jouer", "Quitter" }, courant, 25);
        }

        // Fonction permettant d'afficher l'écran de choix
        internal static void AfficherEcranChargement(int courant)
        {
            Console.Clear();
            AfficherQuarto();
            AfficherTextRegulier(new string[] { "Voulez vous commencer une nouvelle partie ou charger une partie en cours ?" }, new ConsoleColor[] {ConsoleColor.Black}, 20);
            AfficherBouton(new string[] { "1 Joueur","2 Joueurs", "Charger" }, courant, 25);
        }

        // Fonction permettant de choisir une partie enregistrée
        internal static string AfficherPageChargement()
        {
            int fichierCourant = 0;
            bool choix = false;
            string repertoireSauvegardes = "../../Sauvegardes";
            string[] noms = Directory.GetFiles(repertoireSauvegardes);
            Console.Clear();
            if (noms.Length > 0)
            {
                AfficherCadre();

                ConsoleColor[] noir = new ConsoleColor[] { ConsoleColor.Black };
                AfficherTextRegulier(new string[] { "BIENVENUE DANS L'INTERFACE DE CHARGEMENT DE QUARTO" }, noir, 3);
                AfficherTextRegulier(new string[] { "Ici, vous pouvez selectionner un fichier" }, noir, 8);
                AfficherTextRegulier(new string[] { "afin de reprendre une partie en cours" }, noir, 9);
                AfficherTextRegulier(new string[] { "Les fichiers sont enregistrés de la manière suivante:", "        PvO_JJ-MM-AA_HH-MM " }, new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkRed} , 12);

                DessinerLigneH(6);
                DessinerLigneH(11);
                DessinerLigneH(13);
                int nombreFichierColonne = 20;
                DessinerLigneH(16 + nombreFichierColonne);
                DessinerLigneV(13, nombreFichierColonne + 3, 37);
                DessinerLigneV(13, nombreFichierColonne + 3, 75);
                DessinerLigneV(13, nombreFichierColonne + 3, 113);

                //Boucle permettant de choisir son fichier de sauvegarde
                
                while (!choix)
                {
                    if (noms.Length > 1)
                    {
                        int calculCourant = 0;
                        int x = 2;
                        foreach (string nom in noms)
                        {
                            if (nom == "../../Sauvegardes\\Z_NouvellePartie.txt") continue;
                            if (calculCourant == fichierCourant)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.SetCursorPosition(x, 15 + (calculCourant % nombreFichierColonne));
                            Console.Write("Fichier n° " + calculCourant + "= " + nom.Substring(repertoireSauvegardes.Length + 1, nom.Length - repertoireSauvegardes.Length - 5));
                            calculCourant++;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (calculCourant % nombreFichierColonne == 0) x += 31;
                        }

                        System.ConsoleKeyInfo Bouton = Console.ReadKey();
                        if (Bouton.Key == ConsoleKey.UpArrow) fichierCourant = (fichierCourant -= 1) % (noms.Length-1);
                        else if (Bouton.Key == ConsoleKey.DownArrow) fichierCourant = (fichierCourant += 1) % (noms.Length-1);
                        else if (Bouton.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        if (fichierCourant < 0) fichierCourant = Math.Abs(fichierCourant + (noms.Length-1)) % (noms.Length-1);
                    }
                    else
                    {
                        AfficherTextRegulier(new string[] { "Vous ne disposez pas de fichier de sauvegarde" }, noir, 50);
                        AfficherTextRegulier(new string[] { "Appuyer sur n'importe quelle touche pour lancer une nouvelle partie" }, noir, 53);
                        Console.ReadKey();
                        break;
                    }

                }
            }
            return noms[fichierCourant];
        }

        // Fonction d'initialisation de la fenêtre de jeux
        internal static void InitialiserEcranJeux()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            int hauteur = Console.WindowHeight;
            int largeur = Console.WindowWidth;
            for (int i = 0; i < largeur / 2; i++)
                for (int j = 0; j < hauteur; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(largeur / 2, (hauteur / 2) - 20);
            for (int l = largeur / 2; l < largeur; l++)  Console.Write(Convert.ToString('\u2500'));
        }

        // Fonction permettant l'affichage du plateu des pieces ou des deux
        internal static void AfficherEcranJeux(int[,] plateau, int caseCourante = -1)
        {
            AfficherPlateau(plateau, caseCourante);
        }

        internal static void AfficherEcranJeux(int[] piecesJouables, int pieceCourante = -1)
        {
            AfficherPiecesJouables(piecesJouables, pieceCourante);
        }

        internal static void AfficherEcranJeux(int[,] plateau, int[] piecesJouables, int caseCourante = -1, int pieceCourante = -1)
        {
            AfficherPiecesJouables(piecesJouables, pieceCourante);
            AfficherPlateau(plateau, caseCourante);
        }

        // Fonction permettant d'afficher les pieces encore disponibles
        private static void AfficherPiecesJouables(int[] piecesJouables, int pieceCourante = -1)
        {
            // Les valeurs permettant de placer les emplacements de pieces à l'écran
            int[] piecesX = new int[] { 92, 104, 116, 128 };
            int[] piecesY = new int[] { 18, 28, 38, 48 };
            
            for (int i = 0; i < piecesJouables.Length; i++)
            {
                bool estCourante = false;
                if (i == pieceCourante) estCourante = true;
                int x, y;
                if (piecesJouables[i] >= 0)
                {
                    Utilisables.Pos2Coord(out y, out x, piecesJouables[i]);
                    DessinerPiece(piecesX[x], piecesY[y], piecesJouables[i], estCourante);
                }
                else
                {
                    Utilisables.Pos2Coord(out y, out x, i);
                    EffacerPiece(piecesX[x], piecesY[y], estCourante);
                }
            }
        }

        // Fonction permettant d'afficher le plateau de jeu
        private static void AfficherPlateau(int[,] plateau, int courant = -1)
        {
            int[] casesX = new int[] { 10, 24, 38, 52};
            int[] casesY = new int[] { 5, 13, 21, 29};

            for(int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    bool estCourante = false;
                    if (Utilisables.Coor2Pos(j, i) == courant) estCourante = true;
                    if (plateau[j, i] == -1) DessinerCase(casesX[i], casesY[j], estCourante);
                    else DessinerCase(casesX[i], casesY[j], plateau[j, i], estCourante);
                }
        }

        // Fonction permettant d'afficher une case du tableau
        private static void DessinerCase(int x, int y, bool estCourante = false)
        {
            ConsoleColor vide = ConsoleColor.White;
            ConsoleColor caseCourante = ConsoleColor.DarkRed;
            string caseVide = "             ";
            if (estCourante) Console.BackgroundColor = caseCourante;
            else Console.BackgroundColor = vide;
            for(int i = y; i < y + 7; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(caseVide);
            }

        }

        private static void DessinerCase(int x, int y, int pieceId, bool estCourante = false)
        {
            ConsoleColor vide = ConsoleColor.White;
            ConsoleColor caseCourante = ConsoleColor.DarkGray;
            string caseVide = "             ";
            if (estCourante) Console.BackgroundColor = caseCourante;
            else Console.BackgroundColor = vide;
            for (int i = y; i < y + 7; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(caseVide);
            }
            DessinerPiece(x + 4, y + 5, pieceId);
        }

        // Fonction permettant d'afficher une pièce réferencée par son id n'importe ou sur l'écran
        private static void DessinerPiece(int x, int y, int id, bool estCourante = false)
        {
            string[] piecesRep = CreerPiecesGraphique(); // Peut être améliorer: création unique ??
            if(id >= 0)
            {
                string[] lignes = piecesRep[id].Split('-');
                int hauteur = 0;
                if (id % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkBlue;
                else Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (string ligne in lignes)
                {
                    Console.SetCursorPosition(x, y + hauteur);
                    Console.Write(ligne);
                    hauteur--;
                }
                Console.ForegroundColor = ConsoleColor.Black;
                if (estCourante) AfficherBoiteSelection(x, y);
                else EffacerSelection(x, y);
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void EffacerPiece(int x, int y, bool estCourante = false)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y - i);
                Console.Write("       ");
            }
            if (estCourante) AfficherBoiteSelection(x, y);
            else EffacerSelection(x, y);
        }
        
        // Fonction permettant d'afficher la boite de selection
        private static void AfficherBoiteSelection(int x, int y)
        {
            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';

            string boiteHaut = topLeftCorner + new String(horizontalLine, 7) + topRightCorner;
            string boiteBas = bottomLeftCorner + new String(horizontalLine, 7) + bottomRightCorner;
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write(boiteBas);
            Console.SetCursorPosition(x - 2, y - 5);
            Console.Write(boiteHaut);
            for(int i = y-4; i <= y; i++)
            {
                Console.SetCursorPosition(x - 2, i);
                Console.Write(verticalLine);
                Console.SetCursorPosition(x + 6, i);
                Console.Write(verticalLine);
            }

        }

        // Fonction permettant d'effacer la boite de selection
        private static void EffacerSelection(int x, int y)
        {
            Console.SetCursorPosition(x - 2, y + 1);
            Console.Write("         ");
            Console.SetCursorPosition(x - 2, y - 5);
            Console.Write("         ");
            for (int i = y - 4; i <= y; i++)
            {
                Console.SetCursorPosition(x - 2, i);
                Console.Write(" ");
                Console.SetCursorPosition(x + 6, i);
                Console.Write(" ");
            }
        }

        // Fonction permettant de dessiner une ligne horizontale
        private static void DessinerLigneH(int hauteur)
        {
            char horizontalLine = '\u2550';
            char leftJoint = '\u2560';
            char rightJoint = '\u2563';

            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, hauteur);
                Console.Write(horizontalLine);
            } 
            Console.SetCursorPosition(0, hauteur);
            Console.Write(leftJoint);
            Console.SetCursorPosition(Console.WindowWidth - 1, hauteur);
            Console.Write(rightJoint);
        }

        // Fonction permettant de dessiner une ligne verticale
        private static void DessinerLigneV(int debut, int hauteur, int position)
        {
            char verticalLine = '\u2551';
            char topJoint = '\u2566';
            char bottomJoint = '\u2569';

            for (int i = 0; i < hauteur; i++)
            {
                Console.SetCursorPosition(position, debut + i + 1);
                Console.Write(verticalLine);
            }
            Console.SetCursorPosition(position, debut);
            Console.Write(topJoint);
            Console.SetCursorPosition(position, debut + hauteur);
            Console.Write(bottomJoint);
        }

        // Fonction permettant d'afficher un nombre quelconque de boutons sur une ligne
        private static void AfficherBouton(string[] texts, int courant, int hauteur)
        {
            // caractères utiles à l'affichage des boutons
            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';

            ConsoleColor[] couleurs = new ConsoleColor[texts.Length];
            for(int i = 0; i < texts.Length; i++)
            {
                if (i == courant) couleurs[i] = ConsoleColor.DarkRed;
                else couleurs[i] = ConsoleColor.Black;
            }
            
            string[] lignesHaut = new string[texts.Length];
            string[] lignesDessus = new string[texts.Length];
            string[] lignesTexte = new string[texts.Length];
            string[] lignesDessous = new string[texts.Length];
            string[] lignesBas = new string[texts.Length];

            int rang = 0;
            foreach (string text in texts)
            {
                string ligneHaut = new String(topLeftCorner, 1) + new String(horizontalLine, text.Length + 4) + new String(topRightCorner, 1);
                lignesHaut[rang] = ligneHaut;
                string ligneDessus = verticalLine + new String(' ', text.Length + 4) + verticalLine;
                lignesDessus[rang] = ligneDessus;
                string ligneTexte = Convert.ToString(verticalLine) + "  " + text + "  " + Convert.ToString(verticalLine);
                lignesTexte[rang] = ligneTexte;
                lignesDessous[rang] = lignesDessus[rang];
                string ligneBas = new String(bottomLeftCorner, 1) + new String(horizontalLine, text.Length + 4) + new String(bottomRightCorner, 1);
                lignesBas[rang] = ligneBas;
                rang++;
            }

            AfficherTextRegulier(lignesHaut, couleurs, hauteur);
            AfficherTextRegulier(lignesDessus, couleurs, hauteur + 1);
            AfficherTextRegulier(lignesTexte, couleurs, hauteur + 2);
            AfficherTextRegulier(lignesDessous, couleurs, hauteur + 3);
            AfficherTextRegulier(lignesBas, couleurs, hauteur + 4);

        }

        // Fonction permettant d'afficher plusieur message sur la même ligne réparti équitablement sur l'écran 
        private static void AfficherTextRegulier(string[] messages, ConsoleColor[] couleurs, int hauteur)
        {
            int nombre = messages.Length + 1;
            int width = Console.WindowWidth;
            int position = 0;
            foreach(string message in messages)
            {
                position ++;
                Console.ForegroundColor = couleurs[position - 1];
                int debut = ((width - message.Length) / nombre)*position;
                Console.SetCursorPosition(debut, hauteur);
                Console.Write(message);
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // Fonction permettant d'afficher les règles du jeu
        internal static void AfficherRegles()
        {
            char shadow = '\u2593';
            
            Console.Clear();
            AfficherCadre();
            DessinerLigneV(0, Console.WindowHeight - 1, Console.WindowWidth / 2);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string titre = "Voici le fonctionnement général du Quarto:";
            Console.SetCursorPosition((Console.WindowWidth / 2 - titre.Length) / 2, 3);
            Console.Write(titre);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string[] texts = new string[]
            {
                "Le principe du jeu est simple",
                "Votre objectif est d'aligner entre elles ",
                "quatre pièce ayant une caractéristique commune",
                "tout en sachant que les pièces ont quatre caractéristiques: ",
            };
            int hauteur = 5;
            foreach(string text in texts)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2 - text.Length) / 2, hauteur);
                Console.Write(text);
                hauteur++;
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string carac = "Ronde ou carrée - Bleue ou rouge - Pleine ou creuse - Petite ou grande";
            Console.SetCursorPosition((Console.WindowWidth / 2 - carac.Length) / 2, 10);
            Console.Write(carac);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            texts = new string[] 
            {
                "mais attention, c'est votre adversaire qui choisi",
                " la pièce que vous poser sur le plateau",
                " et vous la sienne...           Choississez bien !"
            };
            hauteur = 12;
            foreach (string text in texts)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2 - text.Length) / 2, hauteur);
                Console.Write(text);
                hauteur++;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string quitter = "Pour quitter les règles pressez esc";
            Console.SetCursorPosition(Console.WindowWidth - (quitter.Length + 2), 1);
            Console.Write(quitter); 
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(83, 5);
            Console.Write("Description de l'interface: ");
            // Dessin de l'écran de jeux
            for(int i = 0; i < 21; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Console.WindowWidth / 2 + 5, 20 + i);
                Console.Write(new string(' ', 31));
                Console.SetCursorPosition(140, 20 + i);
                Console.Write(' ');
                Console.SetCursorPosition(141, 21 + i);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(shadow);
            }
            // Fermeture du cadre à droite
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(110,20);
            Console.Write(new string(' ', 30));
            Console.SetCursorPosition(110,40);
            Console.Write(new string(' ', 31));
            // Ombre de l'interface
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(81, 41);
            Console.Write(new string(shadow, 61));
            // Barre horizontale
            Console.SetCursorPosition(111, 27);
            Console.Write(new string('\u2500', 29));
            // Création des case du tableau
            int[] posX = new int[] {86,91,96,101};
            int[] posY = new int[] {22,25,28,31};
            for (int i = 0; i < 4; i ++)
                for(int j = 0; j < 4; j++)
                {
                    Console.SetCursorPosition(posX[i], posY[j]);
                    Console.Write("    ");
                    Console.SetCursorPosition(posX[i], posY[j]+1);
                    Console.Write("    ");
                }
            // Création de la pièce ordi
            Console.SetCursorPosition(93,36);
            Console.Write("    ");
            Console.SetCursorPosition(93,37);
            Console.Write("    ");
            // Création des pièces
            int[] posPieceX = new int[] { 116, 121, 126, 131 };
            int[] posPieceY = new int[] { 28, 31, 34, 37 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (i % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkBlue;
                    else Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(posPieceX[i], posPieceY[j]);
                    Console.Write("    ");
                    Console.SetCursorPosition(posPieceX[i], posPieceY[j] + 1);
                    Console.Write("    ");
                }
            // numérotation des zones
            // ZONE 1
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string[] bloc1 = new string[]
            {
                "Zone 1: Dans cette zone",
                "située en haut à gauche",
                "de l'écran s'affiche le",
                "plateau de jeu dans lequel",
                "vous pourez déposer vos pièces."
            };
            for (int i = 0; i < bloc1.Length; i++)
            {
                Console.SetCursorPosition(84, 10 + i);
                Console.Write(bloc1[i]);
            }
            DessinerBoite(83, 114, 9, 15);
            // ZONE 2
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string[] bloc2 = new string[]
            {
                "Zone 2: Dans",
                " cette zone ",
                "située en haut",
                "à droite ",
                "de l'écran",
                "s'affiche des",
                "informations",
                "sur la partie",
                "et sur le tour",
                "en cours..."
            };
            for (int i = 0; i < bloc2.Length; i++)
            {
                Console.SetCursorPosition(120, 7 + i);
                Console.Write(bloc2[i]);
            }
            DessinerBoite(119, 134, 6, 18);
            // ZONE 3
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string[] bloc3 = new string[]
            {
                " Zone 3: Dans",
                "  cette zone ",
                " située en bas",
                "  à gauche ",
                " de l'écran",
                " s'affiche que ",
                "  lorsqu'un",
                "  ordinateur",
                "donne une pièce",
                "  a un joueur."
            };
            for (int i = 0; i < bloc3.Length; i++)
            {
                Console.SetCursorPosition(86, 46 + i);
                Console.Write(bloc3[i]);
            }
            DessinerBoite(85, 102, 45, 55);
            // ZONE 4
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string[] bloc4 = new string[]
            {
                "Zone 4: Dans cette zone",
                "située en bas à droite",
                "de l'écran s'affiche les",
                "pièces avec lesquelles",
                "vous pouvez encore jouer"
            };
            for (int i = 0; i < bloc4.Length; i++)
            {
                Console.SetCursorPosition(115, 45 + i);
                Console.Write(bloc4[i]);
            }
            DessinerBoite(114, 140, 44, 50);

            // Description des touches
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 17);
            Console.Write("\u2560"+ new string('\u2550',74)+"\u2563");
            Console.SetCursorPosition(3,19);
            Console.Write("Contrôles du jeux:");
            // Flèches directionelles
            AfficherTouche(5, 21, "▲");
            AfficherTouche(2, 24, "<");
            AfficherTouche(5, 24, "▼");
            AfficherTouche(8, 24, ">");
            Console.SetCursorPosition(11, 22);
            Console.Write("Pour jouer, le joueur 1 utilise");
            Console.SetCursorPosition(13, 23);
            Console.Write("les flèches directionelles pour se déplacer.");
            Console.SetCursorPosition(17, 25);
            Console.Write("Les même contrôles sont utilisés ");
            Console.SetCursorPosition(17, 26);
            Console.Write("lorsque le jouer est seul contre l'ordinateur");
            // Touhces joueur 2
            Console.SetCursorPosition(4,29);
            Console.Write("Si un deuxième joueur est dans la partie,");
            Console.SetCursorPosition(4,30);
            Console.Write("Ce dernier pourra utiliser les touches:");
            AfficherTouche(51, 28,"Z");
            AfficherTouche(48, 31, "Q");
            AfficherTouche(51, 31, "S");
            AfficherTouche(54, 31, "D");
            Console.SetCursorPosition(7, 32);
            Console.Write("Pour se déplacer sur le plateau,");
            Console.SetCursorPosition(8, 33);
            Console.Write("et choisir ses pièces.");
            // Touche commune
            Console.SetCursorPosition(8, 37);
            Console.Write("Attention, la touche entrer est une touche commune au deux joueurs!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(2, 36);
            Console.Write("\u250c" + new string('\u2500',3) + "\u2510");
            Console.SetCursorPosition(2, 37);
            Console.Write("\u2502" + "ent" + "\u2502");
            Console.SetCursorPosition(2, 38);
            Console.Write("\u2514" + "\u2500" + "\u2510" + " " + "\u2502");
            Console.SetCursorPosition(2, 39);
            Console.Write("  " + "\u2502" + " " + "\u2502");
            Console.SetCursorPosition(2, 40);
            Console.Write("  " + "\u2514" + "\u2500" + "\u2518");
            Console.SetCursorPosition(9, 39);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Elle vous permet de selectionner les pièces pour l'adversaire,");
            Console.SetCursorPosition(10, 40);
            Console.Write("et de déposer les pièces que l'on vous donne sur le plateau.");
            // Miscalleneous
            Console.SetCursorPosition(4,43);
            Console.Write("A tout moment, vous pouvez mettre le jeux en pause en appuyant sur");
            AfficherTouche(71, 42, "P");
            Console.SetCursorPosition(4, 44);
            Console.Write("Ce menu vous permet de sauvegarder votre partie en cours.");
            Console.SetCursorPosition(9,48);
            Console.Write("Vous pouvez utiliser la touche echap");
            AfficherTouche(3, 47, "esc");
            Console.SetCursorPosition(10, 49);
            Console.Write("pour quitter le jeux à tout moment");
            // Quitter (2)
            Console.SetCursorPosition((Console.WindowWidth / 2 - quitter.Length) / 2, 55);
            Console.Write(quitter);
        }

        internal static void AfficherInfoTour(int tour, bool condition = false)
        {
            Console.SetCursorPosition(100, 2);
            Console.Write("Tour en cours: " + (tour + 1));
            Console.SetCursorPosition(100, 4);
            if (condition && tour % 2 == 0) Console.Write("Tour du joueur 1");
            else if (condition && tour % 2 == 1) Console.Write("Tour du joueur 2");
            else if (!condition && tour % 2 == 0) Console.Write("Tour de l'ordinateur");
            else Console.Write("Tour du joueur          ");

        

        }

        private static void DessinerBoite(int x1, int x2, int y1, int y2)
        {
            // caractères utiles à l'affichage
            char horizontalLine = '\u2550';
            char topLeftCorner = '\u2554';
            char topRightCorner = '\u2557';
            char bottomLeftCorner = '\u255A';
            char bottomRightCorner = '\u255D';
            char verticalLine = '\u2551';

            for (int i = x1; i < x2; i++)
            {
                Console.SetCursorPosition(i, y1);
                Console.Write(horizontalLine);
                Console.SetCursorPosition(i, y2);
                Console.Write(horizontalLine);
            }
            for (int i = y1; i < y2; i++)
            {
                Console.SetCursorPosition(x1, i);
                Console.Write(verticalLine);
                Console.SetCursorPosition(x2, i);
                Console.Write(verticalLine);
            }

            Console.SetCursorPosition(x1, y1);
            Console.Write(topLeftCorner);
            Console.SetCursorPosition(x2, y1);
            Console.Write(topRightCorner);
            Console.SetCursorPosition(x1, y2);
            Console.Write(bottomLeftCorner);
            Console.SetCursorPosition(x2, y2);
            Console.Write(bottomRightCorner);
            Console.SetCursorPosition(0, 0);
        }

        // Fonction permettant de montrer ou l'ordinateur pose sa piece
        internal static void AfficherCaseOrdi(int y, int x)
        {
            int[] casesX = new int[] { 10, 24, 38, 52 };
            int[] casesY = new int[] { 5, 13, 21, 29 };
            x = casesX[x];
            y = casesY[y];
            string caseVide = "             ";
            for(int j = 0; j < 2; j++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                for (int i = y; i < y + 7; i++)
                {
                    Console.SetCursorPosition(x, i);
                    Console.Write(caseVide);
                }
                System.Threading.Thread.Sleep(200);
                Console.BackgroundColor = ConsoleColor.White;
                for (int i = y; i < y + 7; i++)
                {
                    Console.SetCursorPosition(x, i);
                    Console.Write(caseVide);
                }
                System.Threading.Thread.Sleep(200);
            }
        }

        // Fonction permettant de montrer la pièce choisie par l'ordinateur
        internal static void AfficherChoixOrdi(int pieceChoisie)
        {
            DessinerCase(30, 45);
            DessinerPiece(34, 50, pieceChoisie);
        }

        internal static void EffacerChoixOrdi()
        {
            EffacerPiece(34, 50);
        }

        private static void AfficherCadre()
        {
            int largeur = Console.WindowWidth;
            int hauteur = Console.WindowHeight;
            DessinerBoite(0, largeur - 1, 0, hauteur - 1);
        }

        private static void AfficherTouche(int x, int y, string touche)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.Write("\u250c" + new string('\u2500',touche.Length) + "\u2510");
            Console.SetCursorPosition(x, y+1);
            Console.Write("\u2502" + touche + "\u2502");
            Console.SetCursorPosition(x, y+2);
            Console.Write("\u2514" + new string('\u2500', touche.Length) + "\u2518");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
