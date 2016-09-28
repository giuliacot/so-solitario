using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoSolitario.View;

namespace SoSolitario
{
    // Vista del tavolo da gioco 
    public partial class Tavolo : Form
    {
        //Creiamo un array di carte del tavolo
        public List<CartaTavolo> carteScoperte;

        //Inizializza i componenti del tavolo
        public Tavolo()
        {
            // Inizializzazione lista che mostra le carte scoperte dall'utente
            this.carteScoperte = new List<CartaTavolo>();

            InitializeComponent();
        }

        // Proprietà del tavolo
        public PictureBox MazzoImg
        {
            get { return this.mazzoPic; }
        }

        public Button suggerimentoBtn
        {
            get { return this.suggerimentiBtn; }
        }

        public Button istruzionibtn
        {
            get { return this.istruzioniBtn; }
        }

        public Button iniziaNuova
        {
            get { return this.iniziaNuovaBtn; }
        }

        // Metodo che modificano la dimensione del tavolo 
        public void cambiaSize(int larghezza, int altezza)
        {
            this.SetClientSizeCore(larghezza, altezza);
            this.MaximumSize = new Size(larghezza, altezza);
        }

        // Metodo che modifica la posizione del mazzo 
        public void cambiaPosizioneMazzo(int x, int y)
        {
            this.MazzoImg.Location = new Point(x, y);
        }
    }
}
