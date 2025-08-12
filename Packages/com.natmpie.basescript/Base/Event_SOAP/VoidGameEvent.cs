using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/Void Game Event")]
public class VoidGameEvent : ScriptableObject
{
    private event Action listeners;

    public void Raise()
    {
        listeners?.Invoke();
    }

    public void RegisterListener(Action listener)
    {
        listeners += listener;
    }

    public void UnregisterListener(Action listener)
    {
        listeners -= listener;
    }
}