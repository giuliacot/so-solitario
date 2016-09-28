using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

// Librerie esterne
using SoSolitario.Model;
using SoSolitario.View;


namespace SoSolitario.Control
{
    // Controller tra view Tavolo e model Carta-Mazzo-Partita
    class TavoloController
    {
        // Attributi del tavolo
        private Tavolo tavolo;
        private Mazzo mazzo;
        private Regole regole;

        // Indica che tipo di mazzo è stato scelto dall'utente
        private bool tipologiaMazzo;

        // Istanza della partita
        private PartitaSolitario partita;

        // Offset distanza tra le carte sul tavolo
        private int offset; 

        // Numero di file sul tavolo da gioco
        private int file = 0;

        // Contatore carte scoperte
        private int carteScoperte;

        // Lista che salva la dimensione del tavolo
        private List<int> dimensioneTavolo;

        // Costruttore della classe 
        public TavoloController(bool tipologiaMazzo)
        {
            // Istanza tavolo
            this.tavolo = new Tavolo();

            // Attributo che ci determinata la tipologia di mazzo scelta dall'utente
            this.tipologiaMazzo = tipologiaMazzo;

            // Lista che conterrà le dimensioni del tavolo calcolate dinamicamente in base al mazzo
            this.dimensioneTavolo = new List<int>();

            try
            {
                // Settiamo lo sfondo del tavolo da gioco
                this.tavolo.BackgroundImage = Properties.Resources.sfondo10;

                // Organizziamo il tavolo
                preparaMazzo(this.tipologiaMazzo);

                // Calcolo dell'offset in base alla dimensione della carta
                decimal offset = this.mazzo.Larghezza / 5;
                   
                // Setto offset 
                this.offset = (int)Math.Ceiling(offset);

                // Settiamo la dimensione desiderate del tavolo da gioco
                dimensioneTavolo = partita.dimensioneTavolo(this.mazzo.carte.Count, this.mazzo.Larghezza, this.mazzo.Altezza, this.offset);

                // Modifico dimensioni del tavolo
                this.tavolo.cambiaSize(dimensioneTavolo[0], dimensioneTavolo[1]);

                // Posizionamento mazzo 
                this.tavolo.cambiaPosizioneMazzo(dimensioneTavolo[0] - mazzo.Larghezza - (2 * this.offset), this.offset);

                // Metodo che inizializza gli eventi
                inizializzaTavolo();
            }
            catch (Exception e)
            {
                // Liberiamo la memoria dall'immagine di background
                if (this.tavolo.MazzoImg.Image != null)
                    this.tavolo.MazzoImg.Image.Dispose();
                MessageBox.Show("Errore nel caricamento del tavolo! " + e);
            }
         
        }

        // Metodo per visualizzare il form tavolo
        public void mostraTavolo()
        {
            this.tavolo.ShowDialog();
        }

        // Metodo inizializza eventi del tavolo
        public void inizializzaTavolo() 
        {
            // Evento click sul mazzo
            this.tavolo.MazzoImg.MouseClick += new MouseEventHandler(this.vediCarta_MouseClick);
            // Evento del bottone suggerimenti
            this.tavolo.suggerimentoBtn.Click += new EventHandler(this.mostraSuggerimento_Click);
            // Evento bottone inizia nuova partita
            this.tavolo.iniziaNuova.Click += new EventHandler(this.nuovaPartita_Click);
            // Evento bottone regole del gioco
            this.tavolo.istruzionibtn.Click += new EventHandler(this.regoleGioco_Click);
           
        }

        // Metodo evento nuova partita
        private void nuovaPartita_Click(object sender, EventArgs e)
        {
            // Se il numero di carte scoperte è diverso da zero, effettuiamo una dispose sulle pictureBox
            if (this.tavolo.carteScoperte.Count != 0)
            {
                // Azzeriamo la lista di carte scoperte
                for (int i = 0; i < carteScoperte; i++)
                    this.tavolo.carteScoperte[i].imgCarta.Dispose();

                // Puliamo l'array delle carte scoperte
                this.tavolo.carteScoperte.Clear();
                // Azzeriamo il numero di carte scoperte
                this.carteScoperte = this.tavolo.carteScoperte.Count;
                // Organizziamo il tavolo
                preparaMazzo(this.tipologiaMazzo);
                // Metodo che rende visibile il mazzo

            }

           this.tavolo.MazzoImg.Visible = true;
           this.tavolo.suggerimentoBtn.Enabled = false;
        }

        // Metodo che mostra le regole del gioco 
        private void regoleGioco_Click(object sender, EventArgs e)
        {
            // Creo il form regole 
            this.regole = new Regole(); 
            // Riempio la pictureBox con l'immagine delle istruzioni
            this.regole.istruzioni.Image = (Image)Properties.Resources.Istruzioni;
            // Regoliamo la dimensione del form alla dimensione dell'immagine
            this.regole.istruzioni.Size = new Size(Properties.Resources.Istruzioni.Width, Properties.Resources.Istruzioni.Height);
            this.regole.Size = new Size(Properties.Resources.Istruzioni.Width,Properties.Resources.Istruzioni.Height + this.offset);
            // Settiamo la dimensione massima del form a quella dell'immagine delle regole di gioco
            this.regole.MaximumSize = this.regole.Size;
            this.regole.istruzioni.Visible = true;
            // Mostriamo il form
            this.regole.ShowDialog();
        }

        // Gestore evento click sulla pictureBox del mazzo quando il giocatore estrae una carta
        private void vediCarta_MouseClick(object sender, EventArgs e)
        {

            // Creiamo una nuova picture box 
            PictureBox nuovaPic = new PictureBox();

            // Inizializzo evento click sulla nuova carta estratta
            nuovaPic.MouseClick += new MouseEventHandler(this.selezionaCarta_MouseClick);

            try
            {
                // Prendiamo una carta dal mazzo
                Carta nuova = this.mazzo.prendiCarta();

                // Creiamo un elemento cartaTavolo con la pictureBox correlata
                CartaTavolo c = new CartaTavolo(nuovaPic, nuova);

                // Aggiungiamo la carta alla lista di carte scoperte sul tavolo
                this.tavolo.carteScoperte.Add(c);

                // Calcolo la posizione della picture box
                int posizioneOrizzontale = this.carteScoperte % this.partita.CartePerFila;

                // Memorizziamo le coordinate sull'ascissa del punto (per posizionamento pictureBox)
                int x = (this.mazzo.Larghezza + offset) * posizioneOrizzontale;

                // n rappresenterà il numero di fila in cui si deve trovare la carta
                Double n = this.carteScoperte / this.partita.CartePerFila;
                file = (int)Math.Ceiling(n);

                // Memorizziamo le coordinate dell'ordinata del punto (per posizionamento pictureBox)
                int y = (this.mazzo.Altezza + offset) * file;

                // Ricaviamo il nome del file immagine della carta che ci interessa
                string nomeFile;

                // Otteniamo il nome del file immagine a seconda del mazzo che utilizziamo
                nomeFile = ottieniNomeCartaImg(nuova);

                // Associamo alla carta l'immagine della carta estratta
                c.imgCarta.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeFile);

                // Settiamo la dimensione della picturebox della carta
                c.imgCarta.Height = this.mazzo.Altezza;
                c.imgCarta.Width = this.mazzo.Larghezza;

                // Settiamo la posizione della carta pescata
                if (this.carteScoperte == 0)
                    c.imgCarta.Location = new Point(this.offset, this.offset);
                else
                    c.imgCarta.Location = new Point(x + this.offset, y + this.offset);

                // Aggiungiamo la carta al tavolo
                this.tavolo.Controls.Add(c.imgCarta);

                // Rendo visibile la pictureBox 
                c.imgCarta.Visible = true;

                // Incremento il numero di carte scoperte
                this.carteScoperte++;
               
            }
            catch (Exception)
            {
                // Funzione che decreta la vincita o meno dell'utente
                this.tavolo.MazzoImg.Visible = false;
                // Abilitiamo il tasto dei suggerimenti e settiamone le dimensioni
                this.tavolo.suggerimentoBtn.Size = new Size(this.mazzo.Larghezza, this.tavolo.suggerimentoBtn.Height);
                this.tavolo.suggerimentoBtn.Enabled = true;
                MessageBox.Show("Mazzo terminato!");
            }
        }

        // Metodo che gestisce l'evento di click sulla carta
        private void selezionaCarta_MouseClick(object sender, EventArgs e)
        {
            // Recuperiamo la pictureBox cliccata dall'utente e il suo indice 
            PictureBox selezionata = (PictureBox)sender;

            // Recuperiamo a quale elemento corrisponde la pictureBox
            CartaTavolo cartaSel = this.tavolo.carteScoperte.Find( x => x.imgCarta == selezionata );

            // Recuperiamo l'indice della carta selezionata
            int indice = this.tavolo.carteScoperte.IndexOf(cartaSel);

            //Questa funzione restituisce: 
            // 0 -> primo elemento selezionato dell'utente
            // 1 -> secondo elemento selezionato e distanza corretta
            // 2 -> secondo elemento selezionato ma distanza tra i due non è corretta
            // -1 -> elemento già selezionato
            int azione = this.partita.cartaSelezionata(indice);

            // Rendiamo il bordo della carta 3d
            selezionaCarta(indice);

            switch (azione)
            {
                case 0:
                    break;

                case 1:
                    // Recupero indice delle carte selezionate durante il gioco dall'utente
                    int i1 = this.partita.selezionate[0];
                    int i2 = this.partita.selezionate[1];

                    // Recupero le carte selezionate
                    Carta c1 = this.tavolo.carteScoperte[i1].carta;
                    Carta c2 = this.tavolo.carteScoperte[i2].carta;

                    //Recuperiamo l'indice della carta da eliminare
                    int cartaDaElim = this.partita.cartaDaEliminare(c1, c2, i1, i2);

                    // Se la variabile cartaDaElim non è un valore negativo, questa conterrà il valore della carta da eliminare
                    if (cartaDaElim >= 0)
                    {
                        // Bordo pictureBox normale
                        deselezionaCarta(this.partita.selezionate[0]);
                        deselezionaCarta(this.partita.selezionate[1]);

                        // Troviamo la carta da eliminare
                        CartaTavolo daEliminare = this.tavolo.carteScoperte[cartaDaElim];

                        // Sistema le carte sul tavolo da gioco
                        riorganizzaCarte(daEliminare);

                    }
                    else
                    {
                        // Deselezioniamo le carte 
                        deselezionaCarta(this.partita.selezionate[0]);
                        deselezionaCarta(this.partita.selezionate[1]);
                        // Messaggio al giocatore
                        MessageBox.Show("Naaaaaaa! Non si può eliminare nessuna carta! ",
                                    "Ops!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }

                    // Vuota elementi nell'array delle carte da scambiare
                    this.partita.selezionate.Clear();
                    break;

                case 2:
                    // Non è possibile eliminare le carte
                    deselezionaCarta(this.partita.selezionate[0]);
                    deselezionaCarta(this.partita.selezionate[1]);

                    // Vuoto elementi lista carte selezionate
                    this.partita.selezionate.Clear();
                    MessageBox.Show("Ops scelte le carte a distanza non corretta ",
                                    "Distanza non corretta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;

                case -1:
                    // Deseleziono la stessa carta 
                    selezionata.BorderStyle = BorderStyle.None;

                    // Puliamo la lista che traccia gli indici delle carte da scambiare
                    this.partita.selezionate.Clear();
                    break;

                default:

                    MessageBox.Show("Errore ",
                                   "Ops qualcosa non quadra :(",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    break;
            }
            
        }

        // Metodo per deselezionare la carta tramite indice
        public void deselezionaCarta(int i)
        {
            CartaTavolo c = this.tavolo.carteScoperte[i];
            c.imgCarta.BorderStyle = BorderStyle.None;
        }

        // Metodo per selezionare la carta tramite indice
        public void selezionaCarta(int i)
        {
            CartaTavolo c = this.tavolo.carteScoperte[i];
            c.imgCarta.BorderStyle = BorderStyle.Fixed3D;
        }

        // Metodo per rimpiazzare la vecchia immagine con la nuova e riorganizzare le carte sul tavolo
        public void riorganizzaCarte(CartaTavolo eliminata)
        {
            // Salviamo l'indice della carta che vogliamo eliminare
            int indiceCartaEliminata = this.tavolo.carteScoperte.IndexOf(eliminata);

            // Per ogni carta a partire dall'indice della carta che vogliamo
            // eliminare sostituiamo l'immagine e la carta con il contenuto della picture box successiva
            for (int i = indiceCartaEliminata; i < this.carteScoperte - 1; i++)
            { 
                // Prendo la carta successiva
                CartaTavolo carta = this.tavolo.carteScoperte[i + 1];

                // Inserisco le informazioni della carta i + 1 in i cancellando le informazioni di i 
                this.tavolo.carteScoperte[i].carta = carta.carta;

                // Setto il nome dell'immagine da caricare nella picture box a seconda del mazzo
                string nomeFile = ottieniNomeCartaImg(carta.carta);

                try
                {
                    this.tavolo.carteScoperte[i].imgCarta.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeFile);
                }
                catch (Exception)
                {
                    MessageBox.Show("Problema caricamento immagine");
                }

            }
        
            // Dispose dell'ultimo elemento che sarà la copia dell'ultima carta
            CartaTavolo c = this.tavolo.carteScoperte.LastOrDefault();

            c.imgCarta.Dispose();
            this.tavolo.carteScoperte.Remove(c);
            
            //Decremento il numero di carte scoperte
            this.carteScoperte--;
        }

        // Metodo che ci consente di ottenere il nome del file immagine che rappresenta la carta
        private string ottieniNomeCartaImg(Carta c)
        {
            string nomeRisorsa = "";
            string nRis = "";

            //Recuperiamo il nome del seme della carta del mazzo
            string nomeSeme = this.mazzo.ottieniSemeCarta(c.SemeCarta);

            if (!tipologiaMazzo)
            {
                //Associazione in base al nome dei file
                switch (nomeSeme)
                {
                    case "fiori":
                        nRis = "c";
                        break;
                    case "quadri":
                        nRis = "d";
                        break;
                    case "picche":
                        nRis = "s";
                        break;
                    case "cuori":
                        nRis = "h";
                        break;
                }
                return nomeRisorsa = nRis + c.NumeroCarta;
            }
            else
            {
                switch (nomeSeme)
                {
                    case "denari":
                        nRis = "dp";
                        break;
                    case "coppe":
                        nRis = "cp";
                        break;
                    case "bastoni":
                        nRis = "bp";
                        break;
                    case "spade":
                        nRis = "sp";
                        break;
                }
                return nomeRisorsa = nRis + c.NumeroCarta;
            }
        }

        // Metodo che analizza la lista di carte scoperte in cerca di combinazioni presenti
        // Se ne trova una viene mostrata all'utente, se non ce ne sono il giocatore ha perso
        private void mostraSuggerimento_Click(object sender, EventArgs e)
        {
            // Imposto a falso la flag suggerimento
            bool suggerimento = false;
            // Se l'utente ha a disposizione dei suggerimenti
            if (this.partita.Suggerimenti != 0)
            {
                // Dichiaro le variabili dove salveremo gli indici delle carte interessate
                int i1;
                int i2;

                // Controlliamo in un ciclo for per ogni carta delle carte scoperte se al i+2 c'è almeno un carta
                // che è possibile eliminare, appena ne viene trovata una, interrompo ciclo 
                for (int i = 0; i < this.carteScoperte - 3 && !suggerimento; i++)
                {
                    // Se la coppia selezionata rispetta i requisiti del gioco
                    if (this.partita.coppiaCorretta(this.tavolo.carteScoperte[i].carta, this.tavolo.carteScoperte[i + 2].carta))
                    {
                        // Imposto suggerimento a true per indicare che è stata trovata una coppia
                        suggerimento = true;

                        // Memorizzo gli indici con il quale possibile effettuare lo scambio
                        i1 = i;
                        i2 = i + 2;

                        // Visualizzo momentaneamente all'utente le carte che si possono selezionare
                        selezionaCarta(i1);
                        selezionaCarta(i2);
                        deselezionaCarta(i1);
                        deselezionaCarta(i2);
                    }

                }

                // Se la variabile suggerimento è rimasta falsa, vuol dire che non ci sono più combinazioni
                // disponibili! L'utente ha perso
                if (!suggerimento && this.carteScoperte != 2)
                {
                    MessageBox.Show("Non ci sono più combinazioni disponibili, hai perso :( ",
                                    "Partita persa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    // Disabilito button aiuti
                    this.tavolo.suggerimentoBtn.Enabled = false;
                    // Disabilito la selezione delle carte sul tavolo
                    disabilitaEventiCarteScoperte();
                }

                // Se il numero di carte scoperte è uguale a due il giocatore ha vinto
                else if (!suggerimento && this.carteScoperte == 2)
                    MessageBox.Show("Hai vinto! :)",
                                    "Partita vinta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                else
                    // Decrementiamo il numero di suggerimenti
                    this.partita.usaSuggerimento();

              
          }
          else
          {
                // Controllo se ci sono due solo carte scoperte e se non ci sono suggerimenti l'utente ha vinto
                if (this.carteScoperte != 2)
                     MessageBox.Show("Hai terminato gli aiuti! Hai perso :(",
                                    "Suggerimenti finiti",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                  
                else
                    MessageBox.Show("Hai vinto! :)",
                                   "Partita vinta",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                 
                // Disabilito nuovamente il tasto suggerimenti
                this.tavolo.suggerimentoBtn.Enabled = false;
                // Disabilito la selezione delle carte sul tavolo
                disabilitaEventiCarteScoperte();
            }
        }

        // Metodo che setta il tavolo per iniziare il gioco
        public void preparaMazzo(bool tipologiaMazzo)
        {
            // Se la tipologia è del primo tipo settiamo il mazzo normale
            if (!tipologiaMazzo)
            {
                // Creo istanza mazzo normale 
                this.mazzo = new MazzoNormale();

                // Recuperiamo dimensioni delle carte del mazzo 
                this.mazzo.Altezza = (int)Properties.Resources.dietroCarta.Height;
                this.mazzo.Larghezza = (int)Properties.Resources.dietroCarta.Width;

                // Settiamo le dimensioni delle carte 
                this.tavolo.MazzoImg.Height = mazzo.Altezza;
                this.tavolo.MazzoImg.Width = mazzo.Larghezza;

                // Assegniamo l'immagine alla picturebox del mazzo 
                this.tavolo.MazzoImg.Image = Properties.Resources.dietroCarta;
            }
            else
            {
                // Creo una istanza del mazzo Piacentine 
                this.mazzo = new MazzoPiacentine();

                // Recuperiamo dimensioni delle carte del mazzo 
                this.mazzo.Altezza = (int)Properties.Resources.dietroPiacentine.Height;
                this.mazzo.Larghezza = (int)Properties.Resources.dietroPiacentine.Width;

                // Settiamo le dimensioni delle carte 
                this.tavolo.MazzoImg.Height = mazzo.Altezza;
                this.tavolo.MazzoImg.Width = mazzo.Larghezza;

                // Assegniamo l'immagine alla picturebox del mazzo 
                this.tavolo.MazzoImg.Image = Properties.Resources.dietroPiacentine;
            }

            // Creo un'istanza della partita
            partita = new PartitaSolitario(this.mazzo);

            // TEST_2
            // Si verificherà le condizioni del software in caso di vittoria
            // Per questo motivo abbiamo bisogno di un mazzo nuovo, e non mescolato
            // this.mazzo.nuovoMazzo();
        
        }

        // Metodo per rimuovere gli event handler nelle carte quando l'utente avrà perso
        private void disabilitaEventiCarteScoperte()
        {
            foreach(var c in this.tavolo.carteScoperte )
            {
                 c.imgCarta.MouseClick -= new MouseEventHandler(this.selezionaCarta_MouseClick);
            }
        
        }
    }
}
