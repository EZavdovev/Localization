using UnityEngine;
using System;
using System.Collections.Generic;
/// <summary>
/// Класс описывает скриптуемый объект для реализации событий
/// </summary>
[CreateAssetMenu(fileName = "SomeEvent", menuName = "Event", order = 0)]
public class ScriptableEvent : ScriptableObject
{
    private List<Action> listeners;
    /// <summary>
    /// Метод добавляет слушателя в список слушателей
    /// </summary>
    /// <param name="listener"> Действие которое хочет совершить слушатель </param>
    public void AddListener(Action listener)
    {
        if (listeners == null)
        {
            listeners = new List<Action>();
        }

        if (listeners.IndexOf(listener) == -1)
        {
            listeners.Add(listener);
        }
    }
    /// <summary>
    /// Метод удаляет слушателя из списка слушателей
    /// </summary>
    /// <param name="listener"> Действие которое слушатель не хочет совершать </param>
    public void RemoveListener(Action listener)
    {
        if (listeners == null)
        {
            return;
        }

        if (listeners.IndexOf(listener) != -1)
        {
            listeners.Remove(listener);
        }
    }
    /// <summary>
    /// Метод обрабатывает список слушателей
    /// </summary>
    public void Dispatch()
    {
        if (listeners == null)
        {
            return;
        }

        for (int i = listeners.Count - 1; i > -1; i--)
        {
            listeners[i]();
        }
    }
}
