using System;
using System.Windows.Forms;
using SoSolitario.Control;

namespace SoSolitario
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //form iniziale
            InizioPartitaController inipartita = new InizioPartitaController();
            //Visualizza il form che consente la scelta tra le due tipologie di mazzo
            inipartita.mostraIniziaPartita();
        }
    }
}
