namespace SoSolitario
{
    partial class Tavolo
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
            this.mazzoPic = new System.Windows.Forms.PictureBox();
            this.suggerimentiBtn = new System.Windows.Forms.Button();
            this.istruzioniBtn = new System.Windows.Forms.Button();
            this.iniziaNuovaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mazzoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // mazzoPic
            // 
            this.mazzoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mazzoPic.Location = new System.Drawing.Point(859, 15);
            this.mazzoPic.Name = "mazzoPic";
            this.mazzoPic.Size = new System.Drawing.Size(100, 50);
            this.mazzoPic.TabIndex = 1;
            this.mazzoPic.TabStop = false;
            // 
            // suggerimentiBtn
            // 
            this.suggerimentiBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.suggerimentiBtn.Enabled = false;
            this.suggerimentiBtn.Location = new System.Drawing.Point(852, 473);
            this.suggerimentiBtn.Name = "suggerimentiBtn";
            this.suggerimentiBtn.Size = new System.Drawing.Size(70, 47);
            this.suggerimentiBtn.TabIndex = 3;
            this.suggerimentiBtn.Text = "Aiuto";
            this.suggerimentiBtn.UseVisualStyleBackColor = true;
            // 
            // istruzioniBtn
            // 
            this.istruzioniBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.istruzioniBtn.Location = new System.Drawing.Point(852, 420);
            this.istruzioniBtn.Name = "istruzioniBtn";
            this.istruzioniBtn.Size = new System.Drawing.Size(70, 47);
            this.istruzioniBtn.TabIndex = 4;
            this.istruzioniBtn.Text = "Regole del gioco";
            this.istruzioniBtn.UseVisualStyleBackColor = true;
            // 
            // iniziaNuovaBtn
            // 
            this.iniziaNuovaBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iniziaNuovaBtn.Location = new System.Drawing.Point(852, 367);
            this.iniziaNuovaBtn.Name = "iniziaNuovaBtn";
            this.iniziaNuovaBtn.Size = new System.Drawing.Size(70, 47);
            this.iniziaNuovaBtn.TabIndex = 5;
            this.iniziaNuovaBtn.Text = "Nuova Partita";
            this.iniziaNuovaBtn.UseVisualStyleBackColor = true;
            // 
            // Tavolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(934, 532);
            this.Controls.Add(this.iniziaNuovaBtn);
            this.Controls.Add(this.istruzioniBtn);
            this.Controls.Add(this.suggerimentiBtn);
            this.Controls.Add(this.mazzoPic);
            this.MaximumSize = new System.Drawing.Size(1000, 900);
            this.Name = "Tavolo";
            this.Text = "SoSolitario";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mazzoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mazzoPic;
        private System.Windows.Forms.Button suggerimentiBtn;
        private System.Windows.Forms.Button istruzioniBtn;
        private System.Windows.Forms.Button iniziaNuovaBtn;
    }
}

