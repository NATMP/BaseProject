using UnityEngine;
using System;

public abstract class BaseGameEventListener<T, TEvent> : MonoBehaviour
    where TEvent : BaseGameEvent<T>
{
    [SerializeField] protected TEvent gameEvent;
    public Action<T> Response; // Gán logic xử lý từ code

    protected virtual void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.RegisterListener(OnEventRaised);
    }

    protected virtual void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.UnregisterListener(OnEventRaised);
    }

    protected virtual void OnEventRaised(T value)
    {
        Response?.Invoke(value);
    }
}