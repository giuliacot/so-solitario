using System;
using System.Collections.Generic;
using System.Text;

namespace SoSolitario.Model
{
    // Enumerazione che restituisce il valore di stringa delle carte
    public enum CartaPiacentine { Asso, Due, Tre, Quattro, Cinque, Sei, Sette, Fante, Cavallo, Re};

    // Enumerazione che restituisce il nome del seme
    public enum SemePiacentine { denari = 1, bastoni = 2, spade = 3, coppe = 4 };

    // Classe mazzo piacentine deriva della classe astratta mazzo 
    public class MazzoPiacentine : Mazzo
    {
        // Numero semi nel mazzo normale sono 4 
        private const int NUMSEMI = 4;

        // Numero di carte per seme
        private const int NUMCARTESEME = 10;

        // Costruttore della classe MazzoNormale
        public MazzoPiacentine()
        {  
            nuovoMazzo(); 
        }

        // Metodo che ritorna la stringa della carta 
        public override string ottieniValoreCarta(int numeroCarta)
        {
            if (numeroCarta <= NUMCARTESEME)
            {
                CartaPiacentine val;
                val = (CartaPiacentine)numeroCarta;
                return val.ToString();
            }
            else
                throw new Exception("Numero della carta non riconosciuto");
        }

        // Metodo che ritorna la stringa della carta 
        public override string ottieniSemeCarta(int semeCarta)
        {
            if (semeCarta <= NUMSEMI)
            {
                SemePiacentine s;
                s = (SemePiacentine)semeCarta;
                return s.ToString();
            }
            else
                throw new Exception("Seme della carta non riconosciuto");
        }

        // Metodo che restituisce il numero di carte totali
        public override int NumeroCarteTotale
        {
            get { return NUMCARTESEME * NUMSEMI; }

        }

        // Metodo che restituisce il numero di carte totali
        public override int NumeroCartePerSeme
        {
            get { return NUMCARTESEME; }

        }

        // Metodo che restituisce il numero di carte totali
        public override int NumeroSemi
        {
            get { return NUMSEMI; }

        }
    }
}
