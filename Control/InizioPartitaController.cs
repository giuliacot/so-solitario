using System;
using System.Windows.Forms;
using System.Drawing;
// Libreria esterna
using SoSolitario.View;

namespace SoSolitario.Control
{
    // Classe controller per l'inizio della partita
    class InizioPartitaController
    {
        // Attributi della classe
        private IniziaPartita viewIniziale;

        // Costruttore
        public InizioPartitaController()
        {
            this.viewIniziale = new IniziaPartita();
            //Inizializziamo il gestore degli eventi
            inizializzaEventi();
        }

        // Inizializza eventi del form
        public void inizializzaEventi()
        {
            //Creo gestore evento click 
            this.viewIniziale.Piacentine.MouseClick += new MouseEventHandler(this.piacentine_Click);
            this.viewIniziale.Normale.MouseClick += new MouseEventHandler(this.normale_Click);

        }

        // Metodo che visualizza il primo form di scelta del mazzo 
        public void mostraIniziaPartita()
        {
            this.viewIniziale.Piacentine.Image = (Image)Properties.Resources.inizioPiacentine;
            this.viewIniziale.Normale.Image = (Image)Properties.Resources.inizioNormali;
            this.viewIniziale.ShowDialog();
          
        }

        //Metodo dell'evento click sul bottone Piacentine
        private void piacentine_Click(object sender, EventArgs e)
        {

            //Inizializziamo il form che visualizzerà il tavolo
            TavoloController controller = new TavoloController(true);
            controller.mostraTavolo();

        }

        //Metodo dell'evento click sul bottone Normale
        private void normale_Click(object sender, EventArgs e)
        {
            //Inizializziamo il form che visualizzerà il tavolo
            TavoloController controller = new TavoloController(false);
            controller.mostraTavolo();
        }
    }    
}

