using Android.App;
using Android.Widget;
using Android.OS;
using Android.Speech;
using Android.Content;
using Android.Runtime;
using System;
using System.Collections.Generic;
using Android.Media;

namespace STT_SpeechRecognizer
{
    [Activity(Label = "STT_SpeechRecognizer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IRecognitionListener
    {
        SpeechRecognizer sr;
        //Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
        private Button recButton;
        private TextView textBox;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Context context = this;
            // initilize the speech recognizer
            sr = SpeechRecognizer.CreateSpeechRecognizer(this);
            sr.SetRecognitionListener(this);
            
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                AudioManager am = (AudioManager)Application.Context.GetSystemService(Context.AudioService);
                am.SetStreamMute(Stream.Music, true);
            }

            //// initilize the intent
            //intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            //intent.PutExtra(RecognizerIntent.ExtraCallingPackage, Application.Context.PackageName);
            //intent.PutExtra(RecognizerIntent.ExtraPartialResults, true);
            //intent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            //intent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            //intent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 180000000);            

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            recButton = FindViewById<Button>(Resource.Id.btnRecord);
            textBox = FindViewById<TextView>(Resource.Id.textYourText);
            recButton.Click += RecButton_Click;

            // check to see if we can actually record - if we can, assign the event to the button
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                // no microphone, no recording. Disable the button and output an alert
                var alert = new AlertDialog.Builder(recButton.Context);
                alert.SetTitle("You don't seem to have a microphone to record with");
                alert.SetPositiveButton("OK", (sender, e) =>
                {
                    textBox.Text = "No microphone present";
                    recButton.Enabled = false;
                    return;
                });

                alert.Show();
            }            
        }

        private void RecButton_Click(object sender, System.EventArgs e)
        {
            if (recButton.Text == "Start Recording")
            {
                recButton.Text = "End Recording";                
                sr.StartListening(this.CreateSpeechIntent());
            }
            else
            {
                recButton.Text = "Start Recording";
                sr.Destroy();
                sr = SpeechRecognizer.CreateSpeechRecognizer(this);
                sr.SetRecognitionListener(this);
                //sr.StopListening();
            }
        }

        Intent CreateSpeechIntent()
        {
            var intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);

            // message and modal dialog
            //intent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

            intent.PutExtra(RecognizerIntent.ExtraLanguagePreference, Java.Util.Locale.Default);
            intent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            intent.PutExtra(RecognizerIntent.ExtraCallingPackage, Application.Context.PackageName);
            intent.PutExtra(RecognizerIntent.ExtraPartialResults, true);
            intent.PutExtra("android.speech.extra.DICTATION_MODE", true);
            //intent.PutExtra(RecognizerIntent.ExtraPreferOffline, true);

            // end capturing speech if there is 15 seconds of silence
            intent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, "150000");
            intent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, "150000");
            intent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, "3000");


            //intent.PutExtra("android.speech.extra.GET_AUDIO_FORMAT", "audio/AMR");
            //intent.PutExtra("android.speech.extra.GET_AUDIO", true);

            return intent;
        }
        public void OnBeginningOfSpeech()
        {
            //Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "LOG:", "OnBeginningOfSpeech");
        }

        public void OnBufferReceived(byte[] buffer)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnBufferReceived:", buffer.Length.ToString());
        }

        public void OnEndOfSpeech()
        {
            //Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "LOG:", "OnEndOfSpeech");
        }

        public void OnError([GeneratedEnum] SpeechRecognizerError error)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnError:", error.ToString());
            //sr.StopListening();
            //sr.StartListening(intent);
            if (error == Android.Speech.SpeechRecognizerError.NoMatch)
            {
                sr.StartListening(this.CreateSpeechIntent());
            }
            else if (error == Android.Speech.SpeechRecognizerError.SpeechTimeout)
            {
                sr.Destroy();
                sr = SpeechRecognizer.CreateSpeechRecognizer(this);
                sr.SetRecognitionListener(this);
                sr.StartListening(this.CreateSpeechIntent());
            }
        }

        public void OnEvent(int eventType, Bundle @params)
        {
            //Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnEvent:", eventType.ToString());
        }

        public void OnPartialResults(Bundle partialResults)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnPartialResults:", partialResults.ToString());

            //string str = string.Empty;
            IList<string> data = partialResults.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            //IList<string> data = results.GetStringArrayList(RecognizerIntent.ExtraResults);
            //for (int i = 0; i < data.Count; i++)
            //{
            //    //Log.d(TAG, "result " + data.get(i));
            //    str += (!string.IsNullOrWhiteSpace(data[i]))? data[i] + "\n" : "";
            //}
            textBox.Text = (!string.IsNullOrWhiteSpace(data[0])) ? data[0] : "";

        }

        public void OnReadyForSpeech(Bundle @params)
        {
            //Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnReadyForSpeech:", @params.ToString());
        }

        public void OnResults(Bundle results)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnResults:", results.ToString());
            //sr.StopListening();
            //recButton.Text = "Start Recording";
            //IList<string> data = results.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            //textBox.Text += (!string.IsNullOrWhiteSpace(data[0])) ? data[0] : "";


            sr.StartListening(this.CreateSpeechIntent());
        }

        public void OnRmsChanged(float rmsdB)
        {
            //Android.Util.Log.WriteLine(Android.Util.LogPriority.Debug, "OnRmsChanged:", rmsdB.ToString());
        }
    }
}

