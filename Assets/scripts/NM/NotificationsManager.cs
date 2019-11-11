using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationsManager : MonoBehaviour {

	private Dictionary<string,List<Component>> Listeners = new Dictionary<string,List<Component>>();
	///////////////////////////////
	public void AddListener(Component Listener,string NotifcationName)
	{
		if (!Listeners.ContainsKey (NotifcationName)) {
			Listeners.Add (NotifcationName, new List<Component> ());
		}
		Listeners [NotifcationName].Add (Listener);
	}
	public void RemoveListener (Component Listener,string NotificationName)
	{
		if (!Listeners.ContainsKey (NotificationName)) {
			return;
		}
		for( int i=Listeners[NotificationName].Count-1;i>0;i--)
		{
			if(Listeners[NotificationName][i].GetInstanceID()==Listener.GetInstanceID())
			{
				Listeners[NotificationName].RemoveAt(i);
			}
		}
	}
	public void PostNotification(Component Sender,string NotificationName)
	{
		if (!Listeners.ContainsKey (NotificationName))
			return;
		foreach (Component Listener in Listeners[NotificationName]) {
			Listener.SendMessage (NotificationName, Sender, SendMessageOptions.DontRequireReceiver);
		}
	}
	public void RemoveNullListeners()
	{
		Dictionary<string,List<Component>> TemporaryListeners = new  Dictionary<string,List<Component>> ();
		foreach (KeyValuePair<string,List<Component>> Pair in Listeners)
		{
			for (int i=Pair.Value.Count-1;i>0;i--)
			{
				if (Pair.Value[i]==null)
				{
					Pair.Value.RemoveAt (i);
				}
			}
			if (Pair.Value.Count>1)
			{
				TemporaryListeners.Add(Pair.Key,Pair.Value);
			}
		}
		Listeners=TemporaryListeners;
	}
	public void ClearListeners()
	{
		Listeners.Clear ();
	}
	void OnLevelWadLoaded()
	{
		RemoveNullListeners ();
	}
}
