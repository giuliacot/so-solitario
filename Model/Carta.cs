using System;
using System.Collections.Generic;
using System.Text;

namespace SoSolitario
{
    // Classe che ci rappresenta l'oggetto carta 
    public class Carta 
    {
        // Attributi della carta
        private int numero;
        private int seme;

        // Costruttore della classe carta con numero e seme selezionati
        public Carta(int num, int s) 
        {
           // Setto i valori della carta 
           this.NumeroCarta = num;
           this.SemeCarta = s;
        }
        
        // Costruttore vuoto
        public Carta()
        {}

        // Proprietà numero di carta
        public int NumeroCarta
        {
            get { return this.numero; }
            set { 
                
                if(value > 0)
                    numero = value;
                else
                    throw new Exception("Il numero della carta deve essere maggiore di zero!");
            } 
        }

        // Proprietà seme della carta
        public int SemeCarta
        {
            get { return this.seme; }
            set
            {
                if (value > 0)
                    seme = value;
                else
                    throw new Exception("Il seme della carta non può essere un valore negativo!");
            } 
        }
    }
}
