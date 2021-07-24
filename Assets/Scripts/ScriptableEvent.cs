using UnityEngine;
using System;
using System.Collections.Generic;
/// <summary>
/// ����� ��������� ����������� ������ ��� ���������� �������
/// </summary>
[CreateAssetMenu(fileName = "SomeEvent", menuName = "Event", order = 0)]
public class ScriptableEvent : ScriptableObject
{
    private List<Action> listeners;
    /// <summary>
    /// ����� ��������� ��������� � ������ ����������
    /// </summary>
    /// <param name="listener"> �������� ������� ����� ��������� ��������� </param>
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
    /// ����� ������� ��������� �� ������ ����������
    /// </summary>
    /// <param name="listener"> �������� ������� ��������� �� ����� ��������� </param>
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
    /// ����� ������������ ������ ����������
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
