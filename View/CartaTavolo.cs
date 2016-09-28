using System;
using System.Windows.Forms;
using System.Drawing;

namespace SoSolitario.View
{
    // Questa classe rappresenta la carta che si visualizzerà sull'interfaccia grafica
    public class CartaTavolo
    {
        //Attributi
        private PictureBox picBox;
        private Carta c;
        
        public CartaTavolo(PictureBox p, Carta carta)
        {
            this.picBox = p;
            this.c = carta;
        }

        public PictureBox imgCarta
        {
            get { return this.picBox; }
            set { this.picBox = value; }
        }

        public Carta carta
        {
            get { return this.c; }
            set { this.c = value; }
        }

    }
}
