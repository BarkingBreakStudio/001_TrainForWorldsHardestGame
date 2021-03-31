using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventTransmitter<T,U> : MonoBehaviour where T : BaseEventChannelSO<U>
{
    [SerializeField] private T channel = default;
    [SerializeField] private U defaultObject = default;

    [ContextMenu("Transmit Event")]
    public void TransmitEvent()
    {
        channel.RaiseEvent(defaultObject);
    }

    public void TransmitEvent(U paramObj)
    {
        channel.RaiseEvent(paramObj);
    }

    public void SetChannel(T channel)
    {
        this.channel = channel;
    }
}
