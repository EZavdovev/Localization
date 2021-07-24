using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс который добавляет текст в зависимости от текущего языка
/// </summary>
public class LocalizeText : MonoBehaviour
{
    [SerializeField]
    private string textKey;

    [SerializeField]
    private Text localizationText;

    [SerializeField]
    private ScriptableEvent resourceUpdateListener;

    private void OnEnable()
    {
        resourceUpdateListener.AddListener(UpdateText);
        if (LocalizationManager.Instance == null)
        {
            return;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        localizationText.text = LocalizationManager.Instance.ResourceCurrentLanguage[textKey];
    }

    private void OnDisable()
    {
        resourceUpdateListener.RemoveListener(UpdateText);
    }
}
