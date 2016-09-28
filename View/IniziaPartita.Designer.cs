namespace SoSolitario.View
{
    partial class IniziaPartita
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
            this.scelglimazzoLbl = new System.Windows.Forms.Label();
            this.piacentinePic = new System.Windows.Forms.PictureBox();
            this.normaliPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.piacentinePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normaliPic)).BeginInit();
            this.SuspendLayout();
            // 
            // scelglimazzoLbl
            // 
            this.scelglimazzoLbl.AutoSize = true;
            this.scelglimazzoLbl.Location = new System.Drawing.Point(26, 19);
            this.scelglimazzoLbl.Name = "scelglimazzoLbl";
            this.scelglimazzoLbl.Size = new System.Drawing.Size(87, 13);
            this.scelglimazzoLbl.TabIndex = 0;
            this.scelglimazzoLbl.Text = "Scegli un mazzo:";
            // 
            // piacentinePic
            // 
            this.piacentinePic.Location = new System.Drawing.Point(29, 46);
            this.piacentinePic.Name = "piacentinePic";
            this.piacentinePic.Size = new System.Drawing.Size(70, 100);
            this.piacentinePic.TabIndex = 4;
            this.piacentinePic.TabStop = false;
            // 
            // normaliPic
            // 
            this.normaliPic.Location = new System.Drawing.Point(105, 46);
            this.normaliPic.Name = "normaliPic";
            this.normaliPic.Size = new System.Drawing.Size(70, 100);
            this.normaliPic.TabIndex = 5;
            this.normaliPic.TabStop = false;
            // 
            // IniziaPartita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 165);
            this.Controls.Add(this.normaliPic);
            this.Controls.Add(this.piacentinePic);
            this.Controls.Add(this.scelglimazzoLbl);
            this.MaximumSize = new System.Drawing.Size(220, 203);
            this.MinimumSize = new System.Drawing.Size(220, 203);
            this.Name = "IniziaPartita";
            this.Text = "Nuova Partita";
            ((System.ComponentModel.ISupportInitialize)(this.piacentinePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normaliPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scelglimazzoLbl;
       
        private System.Windows.Forms.PictureBox piacentinePic;
        private System.Windows.Forms.PictureBox normaliPic;
    }
}