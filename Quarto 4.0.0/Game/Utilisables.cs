using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class Utilisables
    {
        // fonction permettant d'initialiser le tableau de jeu et les pieces jouables
        internal static void InitialiserPartie(string nomFichier, ref int[,] plateau, ref int[] piecesJouables)
        {
            //Console.WriteLine(nomFichier);
            string[] lines = System.IO.File.ReadAllLines(@nomFichier); // permet de lire le fichier de sauvegarde (.txt)
            // Boucle d'initialisation du plateau
            string[] etat = lines[0].Split(' ');
            for (int i = 0; i < etat.Length; i++)
            {
                Utilisables.Pos2Coord(out int x, out int y, i);
                plateau[x, y] = Convert.ToInt32(etat[i]);
            }
            // Boucle d'initialisation des pièces
            etat = lines[1].Split(' ');
            for (int i = 0; i < etat.Length; i++) piecesJouables[i] = Convert.ToInt32(etat[i]);
        }

        internal static void Pos2Coord(out int x, out int y, int pos)
        {
            x = pos / 4;
            y = pos % 4;
        }

        internal static int Coor2Pos(int x, int y)
        {
            int position = x * 4 + y;
            return position;
        }

        internal static int ChoisirPiece(int[] piecesJouables, bool sauvegarde, int[,] plateau)
        {
            bool choix = false;
            int colonneCourante = 0;
            int ligneCourante = 0;
            int indice = -1;
            int pieceCourante = 0;
            while (indice == -1)
            {
                indice = piecesJouables[pieceCourante];
                if (piecesJouables[pieceCourante] < 0) pieceCourante++;
            }
            Utilisables.Pos2Coord(out ligneCourante, out colonneCourante, pieceCourante);
            IHM.AfficherEcranJeux(piecesJouables, pieceCourante);
            while (!choix)
            {
                bool pause = false;
                System.ConsoleKeyInfo mouvement = Console.ReadKey();
                if (mouvement.Key == ConsoleKey.LeftArrow) colonneCourante = (colonneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.RightArrow) colonneCourante = (colonneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.UpArrow) ligneCourante = (ligneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.DownArrow) ligneCourante = (ligneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.Enter && piecesJouables[pieceCourante] != -1)
                {
                    piecesJouables[pieceCourante] = -1;
                    choix = true;
                    sauvegarde = false;
                }
                else if (mouvement.Key == ConsoleKey.P)
                {
                    sauvegarde = IHM.AfficherMenuPause(sauvegarde, plateau, piecesJouables);
                    pause = true;
                }
                else if (mouvement.Key == ConsoleKey.Escape && sauvegarde == true) Environment.Exit(0);
                else if (mouvement.Key == ConsoleKey.Escape && sauvegarde == false) IHM.AfficherQuitter(plateau, piecesJouables, -1, pieceCourante);

                if (colonneCourante < 0) colonneCourante = Math.Abs(colonneCourante + 4) % 4;
                if (ligneCourante < 0) ligneCourante = Math.Abs(ligneCourante + 4) % 4;
                pieceCourante = Coor2Pos(ligneCourante, colonneCourante);
                //if(piecesJouables[pieceCourante] >= 0) 
                if (pause) IHM.AfficherEcranJeux(plateau, piecesJouables, -1, pieceCourante);
                else IHM.AfficherEcranJeux(piecesJouables, pieceCourante);

            }
            return pieceCourante;
        }

        internal static bool PoserPiece(out int position, int idPiece, int[,] plateau, bool sauvegarde, int[] piecesJouables)
        {
            bool choix = false;

            int colonneCourante = 0;
            int ligneCourante = 0;
            int caseCourante = 0;
            int indice = 0;
            Utilisables.Pos2Coord(out int x, out int y, indice);


            while (plateau[x, y] != -1)
            {
                indice++;
                Utilisables.Pos2Coord(out x, out y, indice);
                if (plateau[x, y] == -1) caseCourante = indice;
            }
            Utilisables.Pos2Coord(out ligneCourante, out colonneCourante, caseCourante);
            IHM.AfficherEcranJeux(plateau, caseCourante);
            while (!choix)
            {
                bool pause = false;
                System.ConsoleKeyInfo mouvement = Console.ReadKey();
                if (mouvement.Key == ConsoleKey.LeftArrow) colonneCourante = (colonneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.RightArrow) colonneCourante = (colonneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.UpArrow) ligneCourante = (ligneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.DownArrow) ligneCourante = (ligneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.Enter && plateau[ligneCourante, colonneCourante] == -1)
                {
                    plateau[ligneCourante, colonneCourante] = idPiece;
                    choix = true;
                    sauvegarde = false;
                    IHM.EffacerChoixOrdi();
                }
                else if (mouvement.Key == ConsoleKey.P)
                {
                    sauvegarde = IHM.AfficherMenuPause(sauvegarde, plateau, piecesJouables);
                    pause = true;
                }
                else if (mouvement.Key == ConsoleKey.Escape && sauvegarde == true) Environment.Exit(0);
                else if (mouvement.Key == ConsoleKey.Escape && sauvegarde == false) IHM.AfficherQuitter(plateau, piecesJouables, caseCourante, -1, idPiece);
                if (colonneCourante < 0) colonneCourante = Math.Abs(colonneCourante + 4) % 4;
                if (ligneCourante < 0) ligneCourante = Math.Abs(ligneCourante + 4) % 4;
                caseCourante = Coor2Pos(ligneCourante, colonneCourante);
                if (pause)
                {
                    IHM.AfficherEcranJeux(plateau, piecesJouables, caseCourante);
                    IHM.AfficherChoixOrdi(idPiece);
                }
                else IHM.AfficherEcranJeux(plateau, caseCourante);
            }
            position = caseCourante;
            return sauvegarde;
        }

        internal static bool TesterVictoire(int idPiece, int position, int [,] plateau)
        {
            int[][] piecesCalcul = new int[16][];
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

            Pos2Coord(out int ligne, out int colonne, position);
            char diagonale;
            bool gagner = false;

            if (LignePleine(ligne, plateau))
            {
                int[] res = new int[] { 0, 0, 0, 0 };
                for (int i = 0; i < plateau.GetLength(1); i++)
                    for (int j = 0; j < res.Length; j++)
                        res[j] += piecesCalcul[plateau[ligne,i]][j];
                if (Array.Exists(res, element => element == 4)) gagner = true;
                if (Array.Exists(res, element => element == 0)) gagner = true;

            }
            if (ColonnePleine(colonne, plateau))
            {
                int[] res = new int[] { 0, 0, 0, 0 };
                for (int i = 0; i < plateau.GetLength(1); i++)
                    for (int j = 0; j < res.Length; j++)
                        res[j] += piecesCalcul[plateau[i, colonne]][j];
                if (Array.Exists(res, element => element == 4)) gagner = true;
                if (Array.Exists(res, element => element == 0)) gagner = true;
            }
            if (DiagonalePleine(out diagonale, position, plateau))
            {
                int[] res = new int[] { 0, 0, 0, 0 };
                if (diagonale == 'd')
                {
                    for (int i = 0; i < plateau.GetLength(0); i++)
                        for (int j = 0; j < res.Length; j++)
                            res[j] += piecesCalcul[plateau[i, i]][j];
                }
                else if (diagonale == 'm')
                {
                    for (int i = 0; i < plateau.GetLength(0); i++)
                        for (int j = 0; j < res.Length; j++)
                            res[j] += piecesCalcul[plateau[i, 3 - i]][j];
                }
                if (Array.Exists(res, element => element == 4)) gagner = true;
                if (Array.Exists(res, element => element == 0)) gagner = true;
            }
            return gagner;
        }

        public static bool LignePleine(int ligne, int[,] plateau)
        {
            bool pleine = true;
            for (int i = 0; i < plateau.GetLength(1); i++) if (plateau[ligne, i] == -1) pleine = false;
            return pleine;
        }

        public static bool ColonnePleine(int colonne, int[,] plateau)
        {
            bool pleine = true;
            for (int i = 0; i < plateau.GetLength(0); i++) if (plateau[i, colonne] == -1) pleine = false;
            return pleine;
        }

        public static bool DiagonalePleine(out char diagonale, int position, int[,] plateau)
        {
            diagonale = 'd';
            bool pleine = true;
            int[] diagoDsc = new int[] { 0, 5, 10, 15 };
            int[] diagoAsc = new int[] { 3, 6, 9, 12 };
            if (Array.Exists(diagoDsc, element => element == position))
            {
                diagonale = 'd';
                for (int i = 0; i < plateau.GetLength(0); i++) if (plateau[i, i] == -1) pleine = false;
            }
            else if (Array.Exists(diagoAsc, element => element == position))
            {
                diagonale = 'm';
                for (int i = 0; i < plateau.GetLength(0); i++) if (plateau[i, 3 - i] == -1) pleine = false;
            }
            else pleine = false;
            return pleine;
        }
        
        internal static void JouerMusiqueIntro()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "../../Musiques\\ETFC.wav";
            player.Play();
        }

        internal static void SauvegarderPartie(int[,] plateau, int[] piecesJouables)
        {
            string nom = FaireNom();
            string ligne1 = "", ligne2 = "";
            foreach (int piece in plateau)
            {
                ligne1 += Convert.ToString(piece) + " ";
            }
            foreach (int piece in piecesJouables)
            {
                ligne2 += Convert.ToString(piece) + " ";
            }
            string[] donnees = { ligne1.Substring(0, ligne1.Length - 1), ligne2.Substring(0, ligne2.Length - 1) };
            System.IO.File.WriteAllLines(@"../../Sauvegardes\\" + nom + ".txt", donnees);
        }

        private static string FaireNom()
        {
            DateTime info = System.DateTime.Now;
            string[] dateHeure = Convert.ToString(info).Split(' ');
            string date = dateHeure[0].Replace('/', '-');
            string heure = dateHeure[1].Replace(':', '-').Substring(0, dateHeure[1].Length - 3);
            string nom = "PvO_" + Convert.ToString(date) + "_" + heure;
            return nom;
        }
    }
}