using System;
using Microsoft.Speech.Recognition;
using System.IO;
using System.Globalization;

//Fonte: http://ellismis.com/2012/03/17/converting-or-transcribing-audio-to-text-using-c-and-net-system-speech/
namespace EllisMIS.Audio.Transcription.Microsoft
{
    public class Dictation : IDisposable
    {
        #region Local Variables

        private SpeechRecognitionEngine _speechRecognitionEngine = null;
        private Grammar _grammar = null;
        private bool _disposed = false;
        
        #endregion

        #region Constructors

        public Dictation(CultureInfo idioma)
        {
            ConstructorSetup(idioma);
        }

        public Dictation(CultureInfo idioma, GrammarBuilder grammarBuilder)
        {
            _grammar = new Grammar(grammarBuilder);
            ConstructorSetup(idioma);
        }

        #endregion

        /// <summary>
        /// Transcribe a .wav file
        /// </summary>
        /// <param name="targetWavFile"></param>
        public void Start(string targetWavFile, GrammarBuilder grammarBuilder)
        {
            _speechRecognitionEngine.SetInputToWaveFile(targetWavFile);
            StartSetup(grammarBuilder);
        }

        private void StartSetup(GrammarBuilder grammarBuilder)
        {
            _grammar = new Grammar(grammarBuilder);      
            
            _speechRecognitionEngine.LoadGrammar(_grammar);
            _speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            _speechRecognitionEngine.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
            _speechRecognitionEngine.SpeechHypothesized -= new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);

            _speechRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
            _speechRecognitionEngine.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);
        }

        public void Stop()
        {
            _speechRecognitionEngine.UnloadGrammar(_grammar);
            _speechRecognitionEngine.RecognizeAsyncStop();
        }

        private void ConstructorSetup(CultureInfo idioma)
        {           
            _speechRecognitionEngine = new SpeechRecognitionEngine(idioma);
            _speechRecognitionEngine.UnloadAllGrammars();
       }

        private void SpeechHypothesizing(object sender, SpeechHypothesizedEventArgs e)
        {
            OnSpeechHypothesizingEvent(e);
        }

        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            OnSpeechRecognizedEvent(e);
        }

        public delegate void SpeechRecognizedEventHandler(object sender, SpeechRecognizedEventArgs e);
        public delegate void SpeechHypothesizingEventHandler(object sender, SpeechHypothesizedEventArgs e);

        /// <summary>
        /// The final results of the audio transcription
        /// </summary>
        public event SpeechRecognizedEventHandler SpeechRecognizedEvent;
        public event SpeechHypothesizingEventHandler SpeechHypothesizingEvent;


        protected void OnSpeechRecognizedEvent(SpeechRecognizedEventArgs e)
        {
            if (SpeechRecognizedEvent != null)            
                SpeechRecognizedEvent(this, e);            
        }

        protected void OnSpeechHypothesizingEvent(SpeechHypothesizedEventArgs e)
        {
            if (SpeechHypothesizingEvent != null)
            {
                SpeechHypothesizingEvent(this, e);
            }
        }
      
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    Stop();
                    _speechRecognitionEngine.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
                    _speechRecognitionEngine.SpeechHypothesized -= new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);

                    _grammar = null;
                    _speechRecognitionEngine.UnloadAllGrammars();
                    _speechRecognitionEngine.Dispose();
                }

                // Note disposing has been done.
                _disposed = true;
            }
        }
    }
}
