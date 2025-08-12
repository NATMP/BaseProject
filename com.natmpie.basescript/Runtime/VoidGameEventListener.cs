using UnityEngine;
using System;

public class VoidGameEventListener : MonoBehaviour
{
    [SerializeField] private VoidGameEvent gameEvent;
    public Action Response;

    private void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.RegisterListener(OnEventRaised);
    }

    private void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.UnregisterListener(OnEventRaised);
    }

    private void OnEventRaised()
    {
        Response?.Invoke();
    }
}