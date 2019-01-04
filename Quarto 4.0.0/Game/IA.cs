using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto
{
    class IA
    {
        static Random rn = new Random();

        internal static bool PoserPiece(out int position, int idPiece, int[,] plateau)
        {
            int caseChoisie = rn.Next(0, 16);
            Utilisables.Pos2Coord(out int x, out int y, caseChoisie);
            while (plateau[x,y] >= 0)
            {
                caseChoisie = rn.Next(0, 16);
                Utilisables.Pos2Coord(out x, out y, caseChoisie);
            }
            plateau[x, y] = idPiece;
            IHM.AfficherCaseOrdi(x, y);
            position = caseChoisie;
            return false;
        }

        internal static int ChoisirPiece(int[] piecesJouables)
        {
            int pieceChoisie = rn.Next(0, 16);
            while(piecesJouables[pieceChoisie] == -1)
            {
                pieceChoisie = rn.Next(0, 16);
            }
            IHM.AfficherChoixOrdi(pieceChoisie);
            piecesJouables[pieceChoisie] = -1;
            return pieceChoisie;
        }
    }
}
