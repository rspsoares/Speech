namespace Speech
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWavFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btSelecionar = new System.Windows.Forms.Button();
            this.tbNomeArquivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btOuvir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWavFile
            // 
            this.btnWavFile.Location = new System.Drawing.Point(326, 50);
            this.btnWavFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnWavFile.Name = "btnWavFile";
            this.btnWavFile.Size = new System.Drawing.Size(115, 23);
            this.btnWavFile.TabIndex = 0;
            this.btnWavFile.Text = "Transcrever arquivo";
            this.btnWavFile.UseVisualStyleBackColor = true;
            this.btnWavFile.Click += new System.EventHandler(this.btnWavFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(436, 170);
            this.textBox1.TabIndex = 4;
            // 
            // btSelecionar
            // 
            this.btSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelecionar.Location = new System.Drawing.Point(420, 22);
            this.btSelecionar.Name = "btSelecionar";
            this.btSelecionar.Size = new System.Drawing.Size(28, 23);
            this.btSelecionar.TabIndex = 5;
            this.btSelecionar.Text = "...";
            this.btSelecionar.UseVisualStyleBackColor = true;
            this.btSelecionar.Click += new System.EventHandler(this.btSelecionar_Click);
            // 
            // tbNomeArquivo
            // 
            this.tbNomeArquivo.Enabled = false;
            this.tbNomeArquivo.Location = new System.Drawing.Point(12, 25);
            this.tbNomeArquivo.Name = "tbNomeArquivo";
            this.tbNomeArquivo.Size = new System.Drawing.Size(402, 20);
            this.tbNomeArquivo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selecionar arquivo .WAV";
            // 
            // btOuvir
            // 
            this.btOuvir.Location = new System.Drawing.Point(12, 50);
            this.btOuvir.Name = "btOuvir";
            this.btOuvir.Size = new System.Drawing.Size(78, 23);
            this.btOuvir.TabIndex = 8;
            this.btOuvir.Text = "Ouvir arquivo";
            this.btOuvir.UseVisualStyleBackColor = true;
            this.btOuvir.Click += new System.EventHandler(this.btOuvir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 264);
            this.Controls.Add(this.btOuvir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNomeArquivo);
            this.Controls.Add(this.btSelecionar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnWavFile);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reconhecimento arquivo WAV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWavFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSelecionar;
        private System.Windows.Forms.TextBox tbNomeArquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOuvir;
    }
}

