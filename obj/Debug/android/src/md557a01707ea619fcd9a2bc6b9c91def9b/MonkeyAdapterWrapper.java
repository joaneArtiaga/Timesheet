package md557a01707ea619fcd9a2bc6b9c91def9b;


public class MonkeyAdapterWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NavDrawer.Adapters.MonkeyAdapterWrapper, NavDrawer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MonkeyAdapterWrapper.class, __md_methods);
	}


	public MonkeyAdapterWrapper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MonkeyAdapterWrapper.class)
			mono.android.TypeManager.Activate ("NavDrawer.Adapters.MonkeyAdapterWrapper, NavDrawer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
