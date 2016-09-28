using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoSolitario.Model
{
    // Classe atratta che ci rappresenta il prototipo di mazzo, all'interno implementiamo
    // i metodi che sono comuni a tutti i mazzi
    public abstract class Mazzo
    {
        // Lista delle carte del mazzo
        public List<Carta> carte;

        // Dimensione delle carte del mazzo
        private int larghezzaCarta;
        private int altezzaCarta;
  
        // Metodo che crea un nuovo mazzo
        public void nuovoMazzo()
        {
            // Instanziamo una lista per il mazzo
            this.carte = new List<Carta>();

            // Creiamo un mazzo 
            for (int i = 1; i <= NumeroCartePerSeme; i++)
            {
                for (int j = 1; j <= NumeroSemi; j++)
                {
                    //Creo una nuova carta
                    Carta c = new Carta(i, j);
                    this.carte.Add(c);
                }
            }
        }

        //Metodo per prendere una carta        
        public Carta prendiCarta()
        {
            if (!mazzoVuoto())
            {
                //Selezioniamo dalla lista il primo elemento
                Carta scelta = new Carta();
                scelta = carte.FirstOrDefault();
                carte.Remove(scelta);
                return scelta;
            }
            else
                throw new Exception("Mazzo vuoto, impossibile selezionare una carta! ");
        }

        //Metodo per mescolare le carte
        public void mescolaMazzo()
        {
            //Controlliamo se il mazzo è vuoto, se lo è alziamo un eccezione
            if (!mazzoVuoto())
            {
                //Algoritmo Knuth-Fisher-Yates
                Random rand = new Random();

                for (int i = this.carte.Count - 1; i > 0; i--)
                {
                    int n = rand.Next(i + 1);
                    //Effettuiamo lo swap, selezioniamo le due carte 
                    //swapping               
                    Carta x = new Carta();
                    x = this.carte[i];
                    this.carte[i] = this.carte[n];
                    this.carte[n] = x;

                }
            }
        }

        //Metodo per controllare che il mazzo non sia vuoto
        public bool mazzoVuoto()
        { 
            return this.carte.Count <= 0 ? true : false;
        }

        //Proprietà di larghezza
        public int Larghezza
        {
            get { return this.larghezzaCarta; }
            set
            {
                if (value > 0)
                    this.larghezzaCarta = value;
                else
                    throw new Exception("La larghezza del mazzo non può essere un valore negativo");
            }
        }

        //Proprietà di lunghezza
        public int Altezza
        {
            get { return this.altezzaCarta; }
            set
            {
                if (value > 0)
                    this.altezzaCarta = value;
                else
                    throw new Exception("L'altezza del mazzo non può essere un valore negativo");
            }
        }

        // Metodo per ottenere il valore della carta
        public virtual string ottieniValoreCarta(int numeroCarta)
        {
            string s = numeroCarta.ToString();
            return s;
        }

        // Metodo per ottenere il seme della carta
        public virtual string ottieniSemeCarta(int semeCarta)
        {
            string s = semeCarta.ToString();
            return s;
        }

        // Proprietà da settare nel mazzo specifico
        // Il numero di carte totali
        public abstract int NumeroCarteTotale
        {
            get;
        }

        // Il numero di carte per ogni seme
        public abstract int NumeroCartePerSeme
        {
            get;
        }
        // Il numero di semi del mazzo
        public abstract int NumeroSemi
        {
            get;
        }
    }
}
