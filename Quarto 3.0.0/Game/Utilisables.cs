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
    }
}
