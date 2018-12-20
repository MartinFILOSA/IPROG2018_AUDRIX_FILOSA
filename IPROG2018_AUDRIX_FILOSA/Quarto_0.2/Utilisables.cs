using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto_02
{
    public class Utilisables
    {
        public static Random rn = new Random();

        public static void InitGame(string[] gameParams, int[][] pieces_jouables, string[,] board/*, string file*/)     //File = fichier de sauvegarde (éventuel)
        {

            //===========Configuration de la partie fct des paramètres d'entrée=============
            InitBoard(board);  //On crée le plateau de jeux sans pièce
            InitPieces(pieces_jouables);   //On crée l'ensemble des pièces jouables
           
        }

        public static void InitBoard(string[,] board)
        {
            
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 3; j++)
                    board[i, j] = "    ";
        }

        public static void InitPieces(int[][] pieces)
        {
            int[][] EnDur = new int[16][];
            EnDur[0] = new int[] {01, 0, 0, 0, 0 };
            EnDur[1] = new int[] {02, 0, 0, 0, 1 };
            EnDur[2] = new int[] {03, 0, 0, 1, 0 };
            EnDur[3] = new int[] {04, 0, 0, 1, 1 };
            EnDur[4] = new int[] {05, 0, 1, 0, 0 };
            EnDur[5] = new int[] {06, 0, 1, 0, 1 };
            EnDur[6] = new int[] {07, 0, 1, 1, 0 };
            EnDur[7] = new int[] {08, 0, 1, 1, 1 };
            EnDur[8] = new int[] {09, 1, 0, 0, 0 };
            EnDur[9] = new int[] {10, 1, 0, 0, 1 };
            EnDur[10] = new int[] {11, 1, 0, 1, 0 };
            EnDur[11] = new int[] {12, 1, 0, 1, 1 };
            EnDur[12] = new int[] {13, 1, 1, 0, 0 };
            EnDur[13] = new int[] {14, 1, 1, 0, 1 };
            EnDur[14] = new int[] {15, 1, 1, 1, 0 };
            EnDur[15] = new int[] {16, 1, 1, 1, 1 };

            for (int i = 0; i < pieces.GetLength(0); i++)

            {
                pieces[i] = EnDur[i];
            }

            string[] piecesGraph = new string[] { "" };
        }

        public static int[][] Choice(int id, int[][] pieces_jouables, int[][] pieces_jouees)
        {
            int[][] newPieces = new int[pieces_jouables.GetLength(0) - 1][];
            int j = 0;
            for (int i = 0; i < pieces_jouables.GetLength(0); i++)
            {
                if (i != id)
                {
                    newPieces[j] = pieces_jouables[i];
                    j++;
                }
                else pieces_jouees[i] = pieces_jouables[i];
            }
            return newPieces;
        }

       /* public static string Win(int turn, string[,] board, int choice, int[][] pieces_jouees)
        {
            string modalite = "";
            if (turn > pieces_jouees.GetLength(0)) modalite =  "égalité";
            return modalite;
        }

        /*public static Piece CreatePiece()
        {
            Piece piece = new Piece();
            piece.param = new int[] { 1, 1, 1, 1 };
            piece.hauteur = piece.param[0];
            piece.couleur = piece.param[1];
            piece.forme = piece.param[2];
            piece.plein = piece.param[3];
            return Piece;
        }*/

        public static void Add2Board(int[] choice, string[,] board, int pos)
        {
            int x, y;
            Pos2Coord(out x, out y, pos, board);
            string piece = "";
            for (int i = 1; i < choice.Length; i++) piece += Convert.ToString(choice[i]);
            board[x, y] = piece;
        }

        public static void Pos2Coord(out int x, out int y, int pos, string[,] board)
        {
            x = pos / board.GetLength(0);
            y = pos % board.GetLength(1);
        }

        public static int Coord2Pos(int x, int y, string[,] board)
        {
            int pos = x * board.GetLength(0) + y;
            return pos;
        }

        public struct Piece
        {
            public int[] param;
            public int hauteur;
            public int couleur;
            public int forme;
            public int plein;
        }

        public static bool LineFull(int line, string[,] board)
        {
            bool full = true;
            for (int i = 0; i < board.GetLength(1); i++) if (board[line, i] == "    ") full = false;
            return full;
        }

        public static bool ColumnFull(int column, string[,] board)
        {
            bool full = true;
            for (int i = 0; i < board.GetLength(0); i++) if (board[i, column] == "    ") full = false;
            return full;
        }

        public static bool DiagFull(out char diag, int pos, string[,] board)
        {
            diag = 'n';
            bool full = true;
            int[] OnDiagDown = new int[] { 0, 5, 10, 15 };
            int[] OnDiagUp = new int[] { 3, 6, 9, 12 };
            if (Array.Exists(OnDiagDown, element => element == pos))
            {
                diag = 'd';
                for (int i = 0; i < board.GetLength(0); i++) if (board[i, i] == "    ") full = false;
            }
            else if (Array.Exists(OnDiagUp, element => element == pos))
            {
                diag = 'u';
                for (int i = 0; i < board.GetLength(0); i++) if (board[i, 3 - i] == "    ") full = false;
            }
            else full = false;
            return full;
        }

        public static int ComputerSelect(int[][] pieces_jouables)
        {
            int choice = rn.Next(0, pieces_jouables.Length);
            return choice;

        }

        public static bool CaseFull(string[,] board, int current)
        {
            bool empty = true;
            int x, y;
            Pos2Coord(out x, out y, current, board);

            if (board[x, y] != "    ")
            {
                empty = false;
            }
            return empty;
        }

        public static bool TestWinCondition(int currentDrop, string[,] board, int level)
        {
            int line, column;
            char diag;
            bool win = false;
            if(level == 0)
            {
                
                Pos2Coord(out line, out column, currentDrop, board);
                if (LineFull(line, board))
                {
                    int[] res = new int[] { 0, 0, 0, 0 };
                    for (int i = 0; i < board.GetLength(1); i++)
                        for (int j = 0; j < res.Length; j++)
                            res[j] += Convert.ToInt32(Convert.ToString(board[line, i][j]));
                    if (Array.Exists(res, element => element == 4)) win = true;
                    if (Array.Exists(res, element => element == 0)) win = true;

                }
                if(ColumnFull(column, board))
                {
                    int[] res = new int[] { 0, 0, 0, 0 };
                    for (int i = 0; i < board.GetLength(1); i++)
                        for (int j = 0; j < res.Length; j++)
                            res[j] += Convert.ToInt32(Convert.ToString(board[i, column][j]));
                    if (Array.Exists(res, element => element == 4)) win = true;
                    if (Array.Exists(res, element => element == 0)) win = true;
                }
                if(DiagFull(out diag, currentDrop, board))
                {
                    int[] res = new int[] { 0, 0, 0, 0 };
                    if (diag == 'd')
                    {
                        for (int i = 0; i < board.GetLength(0); i++)
                            for (int j = 0; j < res.Length; j++)
                                res[j] += Convert.ToInt32(Convert.ToString(board[i, i][j]));
                    }
                    else if (diag == 'u')
                    {
                        for (int i = 0; i < board.GetLength(0); i++)
                            for (int j = 0; j < res.Length; j++)
                                res[j] += Convert.ToInt32(Convert.ToString(board[i, 3 - i][j]));
                    }
                    if (Array.Exists(res, element => element == 4)) win = true;
                    if (Array.Exists(res, element => element == 0)) win = true;
                }

            }
            else if (level == 1)
            {

            }

            if (win) PlayVictoryMusic();
            return win;
            //...
            //throw new NotImplementedException();
        }
        public static void PlayVictoryMusic()
        {
            Console.Beep(262, 800); //do
            Console.Beep(262, 800); //do
            Console.Beep(262, 800); //do
            Console.Beep(294, 800); //ré
            Console.Beep(330, 800); //mi
            Console.Beep(294, 800); //ré
            Console.Beep(262, 800); //do
            Console.Beep(330, 800); //mi
            Console.Beep(294, 800); //ré
            Console.Beep(294, 800); //ré
            Console.Beep(262, 800); //do

            /*Console.Beep(349, 1000); //fa
            Console.Beep(392, 1000); //sol
            Console.Beep(440, 1000); //la
            Console.Beep(494, 1000); //si*/
        }
    }
}