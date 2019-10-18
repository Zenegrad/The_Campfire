package md54262e5aab3f64ecaca01cc1a15f6ba60;


public class ListCampgroundsActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("homework_three.ListCampgroundsActivity, homework_three", ListCampgroundsActivity.class, __md_methods);
	}


	public ListCampgroundsActivity ()
	{
		super ();
		if (getClass () == ListCampgroundsActivity.class)
			mono.android.TypeManager.Activate ("homework_three.ListCampgroundsActivity, homework_three", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
