using System;
using System.Collections.Generic;
using System.Text;

namespace SoSolitario.Model
{
    // Enumerazione che restituisce il valore di stringa delle carte
    public enum CartaFrancese { Asso, Due, Tre, Quattro, Cinque, Sei, Sette, Otto, Nove, Dieci, Jack, Donna, Re };

    // Enumerazione che restituisce il nome del seme
    public enum SemeFrancese { fiori = 1, cuori = 2, picche = 3, quadri = 4 };

    // Classe mazzo piacentine figlio della classe astratta mazzo
    public class MazzoNormale : Mazzo
    {
        // Numero semi nel mazzo normale 
        private const int NUMSEMI = 4;

        // Numero di carte per seme
        private const int NUMCARTESEME = 13;

        // Costruttore della classe MazzoNormale
        public MazzoNormale()
        {
            // Inizializza un nuovo mazzo e lo mescola
            nuovoMazzo();
        }

        // Metodo che ritorna la stringa della carta 
        public override string ottieniValoreCarta(int numeroCarta)
        {
            if (numeroCarta <= NUMCARTESEME)
            {
                CartaFrancese val;
                val = (CartaFrancese)numeroCarta;
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
                SemeFrancese s;
                s = (SemeFrancese)semeCarta;
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