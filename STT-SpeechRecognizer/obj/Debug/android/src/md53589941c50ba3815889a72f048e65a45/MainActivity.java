package md53589941c50ba3815889a72f048e65a45;


public class MainActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		android.speech.RecognitionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBeginningOfSpeech:()V:GetOnBeginningOfSpeechHandler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onBufferReceived:([B)V:GetOnBufferReceived_arrayBHandler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onEndOfSpeech:()V:GetOnEndOfSpeechHandler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onError:(I)V:GetOnError_IHandler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onEvent:(ILandroid/os/Bundle;)V:GetOnEvent_ILandroid_os_Bundle_Handler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onPartialResults:(Landroid/os/Bundle;)V:GetOnPartialResults_Landroid_os_Bundle_Handler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onReadyForSpeech:(Landroid/os/Bundle;)V:GetOnReadyForSpeech_Landroid_os_Bundle_Handler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onResults:(Landroid/os/Bundle;)V:GetOnResults_Landroid_os_Bundle_Handler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onRmsChanged:(F)V:GetOnRmsChanged_FHandler:Android.Speech.IRecognitionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("STT_SpeechRecognizer.MainActivity, STT-SpeechRecognizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("STT_SpeechRecognizer.MainActivity, STT-SpeechRecognizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBeginningOfSpeech ()
	{
		n_onBeginningOfSpeech ();
	}

	private native void n_onBeginningOfSpeech ();


	public void onBufferReceived (byte[] p0)
	{
		n_onBufferReceived (p0);
	}

	private native void n_onBufferReceived (byte[] p0);


	public void onEndOfSpeech ()
	{
		n_onEndOfSpeech ();
	}

	private native void n_onEndOfSpeech ();


	public void onError (int p0)
	{
		n_onError (p0);
	}

	private native void n_onError (int p0);


	public void onEvent (int p0, android.os.Bundle p1)
	{
		n_onEvent (p0, p1);
	}

	private native void n_onEvent (int p0, android.os.Bundle p1);


	public void onPartialResults (android.os.Bundle p0)
	{
		n_onPartialResults (p0);
	}

	private native void n_onPartialResults (android.os.Bundle p0);


	public void onReadyForSpeech (android.os.Bundle p0)
	{
		n_onReadyForSpeech (p0);
	}

	private native void n_onReadyForSpeech (android.os.Bundle p0);


	public void onResults (android.os.Bundle p0)
	{
		n_onResults (p0);
	}

	private native void n_onResults (android.os.Bundle p0);


	public void onRmsChanged (float p0)
	{
		n_onRmsChanged (p0);
	}

	private native void n_onRmsChanged (float p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
