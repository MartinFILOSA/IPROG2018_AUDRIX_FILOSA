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

        internal static int ChoisirPiece(int[] piecesJouables, string[] piecesRep)
        {
            int pieceChoisie = rn.Next(0, 16);
            while(piecesJouables[pieceChoisie] == -1)
            {
                pieceChoisie = rn.Next(0, 16);
            }
            IHM.AfficherChoixOrdi(pieceChoisie, piecesRep);
            piecesJouables[pieceChoisie] = -1;
            return pieceChoisie;
        }
        
        internal static int TrouverPos(int idPiece, int[,]plateau, int[][] piecesCalcul)
        {
            int x, y;
            int position = -1;
            for (int i = 0; i < 16; i++)
            {
                Utilisables.Pos2Coord(out x, out y, i);
                if (plateau[x, y] == -1)
                {
                    plateau[x, y] = idPiece;
                    if (Utilisables.TesterVictoire(idPiece, i, plateau, piecesCalcul))
                    {
                        position = i;
                        break;
                    }
                    plateau[x, y] = -1;
                }
            }
            if(position >= 0)
            {
                Utilisables.Pos2Coord(out x, out y, position);
                plateau[x, y] = -1;
            }
            return position;
        }
    
        internal static bool PoserPieceIA(out int position, int idPiece, int[,] plateau, int[][] piecesCalcul)
        {
            int x, y;
            position = TrouverPos(idPiece, plateau, piecesCalcul);
            if (position == -1) PoserPiece(out position, idPiece, plateau);
            else
            {
                Utilisables.Pos2Coord(out x, out y, position);
                plateau[x, y] = idPiece;
                IHM.AfficherCaseOrdi(x, y);
            }
            return false;
        }

        internal static int ChoisirPieceIA(int[] piecesJouables, int[,] plateau, int[][] piecesCalcul, string[] piecesRep)
        {
            int pieceChoisie = -1;
            for(int i = 0; i < 16; i++)
            {
                if(piecesJouables[i] != -1)
                {
                    if (TrouverPos(i, plateau, piecesCalcul) == -1)
                    {
                        pieceChoisie = i;
                        break;
                    }
                }
            }
            if (pieceChoisie == -1) pieceChoisie = ChoisirPiece(piecesJouables, piecesRep);
            else
            {
                IHM.AfficherChoixOrdi(pieceChoisie, piecesRep);
                piecesJouables[pieceChoisie] = -1;
            }
            return pieceChoisie;
        }
    }
}
