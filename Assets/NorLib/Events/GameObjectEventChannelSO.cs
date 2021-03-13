using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "NorLib/Events/GameObject Event Channel")]
public class GameObjectEventChannelSO : EventChannelBaseSO
{
	public event UnityAction<GameObject> OnEventRaised = delegate { };
	public void RaiseEvent(GameObject value)
	{
		OnEventRaised.Invoke(value);
	}

	public void AddListener(UnityAction<GameObject> action)
	{
		OnEventRaised += action;
	}

	public void RemoveListener(UnityAction<GameObject> action)
	{
		OnEventRaised -= action;
	}
}
