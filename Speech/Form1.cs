using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EllisMIS.Audio.Transcription.Microsoft;
using System.Media;
using Microsoft.Speech.Recognition;
using System.Threading;
using System.Globalization;

namespace Speech
{
    public partial class Form1 : Form
    {
        private Dictation _transcriber;
        private CultureInfo _idioma;

        public Form1()
        {
            InitializeComponent();
            //_idioma = new CultureInfo("pt-BR");
            _idioma = new CultureInfo("en-US");
        }

        private void btnWavFile_Click(object sender, EventArgs e)
        {
            Choices dicionario = new Choices();
            dicionario.Add(new string[] { "And this is a test of the emergency broadcast system" });            

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(dicionario);
            grammarBuilder.Culture = _idioma;

            if(tbNomeArquivo.Text == string.Empty)            
            {
                MessageBox.Show("Favor selecionar um arquivo WAV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            textBox1.Text = string.Empty;
                        
            if (_transcriber != null)            
                _transcriber.Dispose();

            _transcriber = new Dictation(_idioma);
            SetEvents();
            _transcriber.Start(tbNomeArquivo.Text, grammarBuilder);
        }        

        private void transcriber_SpeechRecognizedEvent(object sender, Microsoft.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            textBox1.Text += Environment.NewLine + "Speech Recognized: " + e.Result.Text;
        }

        private void _transcriber_SpeechHypothesizingEvent(object sender, Microsoft.Speech.Recognition.SpeechHypothesizedEventArgs e)
        {
            //textBox1.Text += Environment.NewLine + "Speech Recognizing: " + e.Result.Text;
        }

        public void SetEvents()
        {
            _transcriber.SpeechRecognizedEvent -= new Dictation.SpeechRecognizedEventHandler(transcriber_SpeechRecognizedEvent);
            _transcriber.SpeechHypothesizingEvent -= new Dictation.SpeechHypothesizingEventHandler(_transcriber_SpeechHypothesizingEvent);
            _transcriber.SpeechRecognizedEvent += new Dictation.SpeechRecognizedEventHandler(transcriber_SpeechRecognizedEvent);
            _transcriber.SpeechHypothesizingEvent += new Dictation.SpeechHypothesizingEventHandler(_transcriber_SpeechHypothesizingEvent);
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "WAV files (*.wav)|*.wav";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Selecione o arquivo de áudio";

            if (dialog.ShowDialog() == DialogResult.OK)
                tbNomeArquivo.Text = dialog.FileName;            
            else
                tbNomeArquivo.Text = string.Empty;
        }

        private void btOuvir_Click(object sender, EventArgs e)
        {
            if (tbNomeArquivo.Text == string.Empty)
            {
                MessageBox.Show("Favor selelecionar um arquivo WAV.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            using (SoundPlayer player = new SoundPlayer(tbNomeArquivo.Text))
                player.PlaySync();            
        }
    }
}
