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
            Console.SetWindowSize(150, 60); // Taille de la console 150 x 60 pixels
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

        // Fonction permettant d'afficher "l'écran de cahrgement" 
        internal static void AfficherIntro()
        {

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

        // Fonction permettant d'afficher l'écran de menu
        internal static void AfficherMenu(int courant)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = System.Text.Encoding.UTF8; // vérifier ??

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
            string nomVersion = "VERSION : 3.0.2 - NewSkin";
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
            AfficherBouton(new string[] { "Nouvelle", "Charger" }, courant, 25);
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
                // caractères utiles à l'affichage
                char horizontalLine = '\u2550';
                char topLeftCorner = '\u2554';
                char topRightCorner = '\u2557';
                char bottomLeftCorner = '\u255A';
                char bottomRightCorner = '\u255D';
                char verticalLine = '\u2551';

                for(int i = 1; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write(horizontalLine);
                    Console.SetCursorPosition(i, Console.WindowHeight-1);
                    Console.Write(horizontalLine);
                }
                for (int i = 1; i < Console.WindowHeight-1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(verticalLine);
                    Console.SetCursorPosition(Console.WindowWidth-1, i);
                    Console.Write(verticalLine);
                }

                Console.SetCursorPosition(0, 0);
                Console.Write(topLeftCorner);
                Console.SetCursorPosition(Console.WindowWidth-1, 0);
                Console.Write(topRightCorner);
                Console.SetCursorPosition(0, Console.WindowHeight-1);
                Console.Write(bottomLeftCorner);
                Console.SetCursorPosition(Console.WindowWidth-1, Console.WindowHeight-1);
                Console.Write(bottomRightCorner);
                Console.SetCursorPosition(0, 0);

                ConsoleColor[] noir = new ConsoleColor[] { ConsoleColor.Black };
                AfficherTextRegulier(new string[] { "BIENVENU DANS L'INTERFACE DE CHARGEMENT DE QUARTO" }, noir, 3);
                AfficherTextRegulier(new string[] { "Ici, vous pouvez selectionner un fichier" }, noir, 8);
                AfficherTextRegulier(new string[] { "afin de reprendre une partie en cours" }, noir, 9);
                AfficherTextRegulier(new string[] { "Les fichier sont enregistrés de la manière suivante:", "        PvP_JJ/MM/AA_HH_MM " }, new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkRed} , 12);

                DessinerLigneH(6);
                DessinerLigneH(11);
                DessinerLigneH(13);
                int nombreFichierColonne = 20;
                DessinerLigneH(16 + nombreFichierColonne);
                DessinerLigneV(13, nombreFichierColonne + 3, 31);
                DessinerLigneV(13, nombreFichierColonne + 3, 61);
                DessinerLigneV(13, nombreFichierColonne + 3, 91);
                DessinerLigneV(13, nombreFichierColonne + 3, 121);

                //Boucle permettant de choisir son fichier de sauvegarde
                
                while (!choix)
                {
                    if (noms.Length > 1)
                    {
                        int calculCourant = 0;
                        int x = 2;
                        foreach (string nom in noms)
                        {
                            if (nom == "../../Sauvegardes\\NouvellePartie.txt") continue;
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
                        AfficherTextRegulier(new string[] { "Vous ne disposez pas de fichier de sauvegardes" }, noir, 50);
                        AfficherTextRegulier(new string[] { "Appuyer sur n'importequelle touche pour lancer une nouvelle partie" }, noir, 53);
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
            string caseVide = "            ";
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
            string caseVide = "            ";
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
            string[] lignes = piecesRep[id].Split('-');
            int hauteur = 0;
            if (id % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkBlue;
            else Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach(string ligne in lignes)
            {
                Console.SetCursorPosition(x, y + hauteur);
                Console.Write(ligne);
                hauteur--;
            }
            Console.ForegroundColor = ConsoleColor.Black;
            if (estCourante) AfficherBoiteSelection(x, y);
            else EffacerSelection(x, y);
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

        }

        // Fonction permettant de montrer ou l'ordinateur pose sa piece
        internal static void AfficherCaseOrdi(int y, int x)
        {
            int[] casesX = new int[] { 10, 24, 38, 52 };
            int[] casesY = new int[] { 5, 13, 21, 29 };
            x = casesX[x];
            y = casesY[y];
            string caseVide = "            ";
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

    }
}
