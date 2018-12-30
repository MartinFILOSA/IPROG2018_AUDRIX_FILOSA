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
        internal static void InitialiserPartie(string nomFichier, ref int [,] plateau, ref int[] piecesJouables)
        {
            Console.WriteLine(nomFichier);
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

        internal static void Pos2Coord(out int x, out  int y, int pos)
        {
            x = pos / 4;
            y = pos % 4;
        }

        internal static int Coor2Pos(int x, int y)
        {
            int position = x * 4 + y;
            return position;
        }

        internal static int ChoisirPiece(int[] piecesJouables)
        {
            bool choix = false;
            int colonneCourante = 0;
            int ligneCourante = 0;
            int indice = -1;
            int pieceCourante = 0;
            while (indice == -1)
            {
                indice = piecesJouables[pieceCourante];
                if(piecesJouables[pieceCourante] < 0) pieceCourante++;
            }
            IHM.AfficherEcranJeux(piecesJouables, pieceCourante);
            while (!choix)
            {
                System.ConsoleKeyInfo mouvement = Console.ReadKey();
                if (mouvement.Key == ConsoleKey.LeftArrow) colonneCourante = (colonneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.RightArrow) colonneCourante = (colonneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.UpArrow) ligneCourante = (ligneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.DownArrow) ligneCourante = (ligneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.Enter && piecesJouables[pieceCourante] != -1)
                {
                    piecesJouables[pieceCourante] = -1;
                    choix = true;
                }

                if (colonneCourante < 0) colonneCourante = Math.Abs(colonneCourante + 4) % 4;
                if (ligneCourante < 0) ligneCourante = Math.Abs(ligneCourante + 4) % 4;
                pieceCourante = Coor2Pos(ligneCourante, colonneCourante);
                //if(piecesJouables[pieceCourante] >= 0) 
                IHM.AfficherEcranJeux(piecesJouables, pieceCourante);
            }
            return pieceCourante;
        }

        internal static void PoserPiece(int idPiece, int[,] plateau)
        {
            bool choix = false;
            int colonneCourante = 0;
            int ligneCourante = 0;
            int caseCourante = 0;
            int indice = 0;
            Utilisables.Pos2Coord(out int x, out int y, indice);


            while (plateau[x,y] != -1)
            {
                indice++;
                Utilisables.Pos2Coord(out x, out y, indice);
                if (plateau[x, y] == -1) caseCourante = indice;
            }
            Utilisables.Pos2Coord(out ligneCourante, out colonneCourante, caseCourante);
            IHM.AfficherEcranJeux(plateau, caseCourante);
            while (!choix)
            {
                System.ConsoleKeyInfo mouvement = Console.ReadKey();
                if (mouvement.Key == ConsoleKey.LeftArrow) colonneCourante = (colonneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.RightArrow) colonneCourante = (colonneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.UpArrow) ligneCourante = (ligneCourante -= 1) % 4;
                else if (mouvement.Key == ConsoleKey.DownArrow) ligneCourante = (ligneCourante += 1) % 4;
                else if (mouvement.Key == ConsoleKey.Enter && plateau[ligneCourante,colonneCourante] == -1)
                {
                    plateau[ligneCourante, colonneCourante] = idPiece;
                    choix = true;
                    IHM.EffacerChoixOrdi();
                }

                if (colonneCourante < 0) colonneCourante = Math.Abs(colonneCourante + 4) % 4;
                if (ligneCourante < 0) ligneCourante = Math.Abs(ligneCourante + 4) % 4;
                caseCourante = Coor2Pos(ligneCourante, colonneCourante);
                IHM.AfficherEcranJeux(plateau, caseCourante);
            }
        }

        internal static void JouerMusiqueIntro()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "../../Musiques\\ETFC.wav";
            player.Play();  
        }
    }
}
