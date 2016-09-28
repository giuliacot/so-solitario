namespace SoSolitario.View
{
    partial class Regole
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.istruzioniPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.istruzioniPic)).BeginInit();
            this.SuspendLayout();
            // 
            // istruzioniPic
            // 
            this.istruzioniPic.Location = new System.Drawing.Point(0, -10);
            this.istruzioniPic.Name = "istruzioniPic";
            this.istruzioniPic.Size = new System.Drawing.Size(100, 50);
            this.istruzioniPic.TabIndex = 0;
            this.istruzioniPic.TabStop = false;
            // 
            // regole
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.istruzioniPic);
            this.Name = "regole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Regole del gioco";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.istruzioniPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox istruzioniPic;
    }
}