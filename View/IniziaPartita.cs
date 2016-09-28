using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoSolitario.View
{
    public partial class IniziaPartita : Form
    {
        public IniziaPartita()
        {
            InitializeComponent();
        }

       //Definiamo le proprietà per richiamare gli elementi grafici nel controller
        public PictureBox Piacentine
        {
            get { return this.piacentinePic;}
        }

        public PictureBox Normale
        { 
            get { return this.normaliPic; }
        }
    }
}
