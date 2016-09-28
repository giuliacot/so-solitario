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
    public partial class Regole : Form
    {
        public Regole()
        {
            InitializeComponent();
        }

        public PictureBox istruzioni
        {
            get { return this.istruzioniPic; }
        }
    }
}
