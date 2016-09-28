using System;
using System.Collections.Generic;
using System.Text;

namespace SoSolitario.Model
{
    // La classe fornisce i metodi per la gestione delle fasi di gioco
    // e la preparazione del tavolo da gioco del solitario
    public class PartitaSolitario
    {
        // Lista carte selezionate dall'utente
        public List<int> selezionate;

        // Numero di carte per fila sul tavolo da gioco
        private int carteFila = 10;

        // Variabile che tiene traccia dei suggerimenti di cui ha fatto uso l'utente
        private int suggerimenti = 3;

        // Proprietà numero carte per fila
        public int CartePerFila
        {
            get { return carteFila; }
            set {

                if (value > 0)
                    this.carteFila = value;
                else
                    throw new Exception("Valore negativo!");
            }
        }

        // Proprietà che restituisce il numero di suggerimenti
        public int Suggerimenti
        {
            get { return this.suggerimenti; }
        }

        // Costruttore della classe PartitaSolitario 
        public PartitaSolitario(Mazzo mazzo)
        {
            // Mescoliamo il mazzo di carte
            mazzo.mescolaMazzo();

            // Inizializziamo la lista delle carte da analizzare
            this.selezionate = new List<int>();
        }

        // Metodo che controlla se le carte selezionate dall'utente rispettano i vincoli di distanza
        // e restituisce:
        // -> -1 carta già stata selezionata dall'utente
        // -> 0  unico elemento nella lista
        // -> 1  distanza tra la prima e la seconda carta è corretta
        // -> 2  distanza tra la prima e la seconda carta non è corretta
        public int cartaSelezionata(int indiceCarta)
        {
            // Il valore che ritorniamo  
            int azione;

            // Controllo che nella lista non sia già stata inserita la carta corrispondente all'indice  
            if (!trovaElementoSelezionato(indiceCarta))
            {
                // Aggiungo l'indice della carta alla lista
                this.selezionate.Add(indiceCarta); 
                    
                // Se il numero della lista è uguale a due allora controlliamo se la distanza tra le due carte selezionata è corretta
                if (this.selezionate.Count == 2)
                {
                    azione = this.distanzaCarteCorretta(this.selezionate[0], this.selezionate[1]) ? 1 : 2;
                    return azione;
                }
                return azione = 0;
             }
             else
                return azione = -1;
        }

        // Metodo che controlla se le due carte selezionate hanno indice che corrisponde a i e i+2
        private bool distanzaCarteCorretta(int ind1, int ind2)
        {
            // Se la differenza tra ind1 e ind2 è uguale a più o meno due ritorna true
            return (Math.Abs(ind1 - ind2) == 2)? true : false;   
        }


        // Metodo che controlla se le due carte hanno lo stesso numero o seme 
        public bool coppiaCorretta(Carta c1, Carta c2)
        {
            return (c1.NumeroCarta == c2.NumeroCarta || c1.SemeCarta == c2.SemeCarta) ? true : false;
        }

    
        // Metodo che restituisce l'indice della carta da eliminare
        public int cartaDaEliminare(Carta c1, Carta c2, int i1, int i2)
        {
            // Se le due carte hanno lo stesso colore o lo stesso seme allora ritorniamo l'indice di i1 o i2 
            if (coppiaCorretta(c1,c2))
            {
                // Ritorniamo i2 oppure i1 a seconda della grandezza dell'indice
                return (i1 > i2) ? i2 : i1;
            }
            else
                // Nessuna delle carte può essere eliminata
                return -1;
        }

        // Metodo per settare la dimensione del tavolo in base al mazzo scelto dall'utente
        // X rappresenta la dimensione di larghezza della carta
        // Y rappresenta la dimensione di altezza della carta
        // numeroCarte il numero di carte presenti nel mazzo
        // offset ci indica di quanto le carte saranno distanziate le une dalle altre 
        public List<int> dimensioneTavolo(int numeroCarte, int X, int Y, int offset)
        {     
            // Memorizziamo in dimensioni la larghezza e l'altezza del tavolo
            List<int> dimensioni = new List<int>();

            // Numero di file che possono essere presenti sul tavolo da gioco
            double numeroFile = fileMassime(numeroCarte);
           
            // Dimensione del tavolo in larghezza
            int spaziofilaTavolo = ((carteFila)*(X + offset));
            int spazioMazzoTavolo = X + 3*offset;
            int larghezzaTavolo =  spaziofilaTavolo + spazioMazzoTavolo ;
            dimensioni.Add(larghezzaTavolo);

            // Dimensione del tavolo in altezza
            int altezzaTavolo = (int)(numeroFile * (Y + 3*offset));
            dimensioni.Add(altezzaTavolo);

            return dimensioni;
        }

        // Metodo per restituire il numero di file di carte massime da mostrare
        private double fileMassime(int numeroCarte)
        {
            double numeroFile;
            double numFileArrontondato;

            //Calcoliamo il numero di file massime 
            if (numeroCarte > 0)
            {
                // Se l'operazione di modulo del num di carte del mazzo con il numero di carte per file
                // da zero, il numero è divisibile per il numero di file e quindi non necessitiamo di arrotondare
                if (numeroCarte % carteFila == 0)
                    numeroFile = numeroCarte / carteFila;
                else
                    numeroFile = (double) numeroCarte / carteFila;

                // Con la funzione Math.Ceiling andiamo ad ottenere il valore arrotondato in eccesso 
                numFileArrontondato = Math.Ceiling(numeroFile);
                return numFileArrontondato;
            }
            else
                return numFileArrontondato = -1;

        }

        // Metodo che decrementa la variabile suggerimenti
        public void usaSuggerimento()
        {
            // Decremento il numero di suggerimenti
            this.suggerimenti--;
        }

        // Metodo che controlla se all'interno di una lista è presente una carta tramite indice
        private bool trovaElementoSelezionato(int valore)
        {
            // Cerco nella lista se c'è presente la carta tra quelle selezionate
            foreach (var sel in this.selezionate.FindAll(x => x == valore))
                return true;
            return false;
        }
    }
}
