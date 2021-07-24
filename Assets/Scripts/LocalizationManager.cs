using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Класс менеджер реализующий работу с локализацией текста
/// </summary>
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public string LanguageCode 
    { 
        get; 
        private set; 
    }

    [SerializeField]
    private ScriptableEvent resourceUpdateDispatcher;

    private const string LOCALIZATION_PREFIX = "Texts";

    private const string RU = "Ru";
    private const string EN = "En";
    private const string FR = "Fr";

    private Dictionary<string, string> resourceCurrentLanguage = new Dictionary<string, string>();
    public Dictionary<string,string> ResourceCurrentLanguage
    {
        get
        {
            return resourceCurrentLanguage;
        }
    }
    /// <summary>
    /// Метод изменяет текст на английский
    /// </summary>
    public void SetEnglish()
    {
        LanguageCode = EN;
        LoadResource(LOCALIZATION_PREFIX);
        resourceUpdateDispatcher.Dispatch();
    }
    /// <summary>
    /// Метод изменяет текст на русский
    /// </summary>
    public void SetRussian()
    {
        LanguageCode = RU;
        LoadResource(LOCALIZATION_PREFIX);
        resourceUpdateDispatcher.Dispatch();
    }
    /// <summary>
    /// Метод изменяет текст на французский
    /// </summary>
    public void SetFrench()
    {
        LanguageCode = FR;
        LoadResource(LOCALIZATION_PREFIX);
        resourceUpdateDispatcher.Dispatch();
    }

    private void LoadResource(string resourceName)
    {
        TextAsset currentLanguageText = Resources.Load(this.LocalizeResourceName(resourceName), typeof(TextAsset)) as TextAsset;

        string[] lines = currentLanguageText.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] pairs = lines[i].Split(new char[] { ' ', '\t' }, 2);
            if (pairs.Length == 2)
            {
                if (resourceCurrentLanguage.ContainsKey(pairs[0].Trim()) == false)
                {
                    resourceCurrentLanguage.Add(pairs[0].Trim(), pairs[1].Trim());
                }
                else
                {
                    resourceCurrentLanguage[pairs[0].Trim()] = pairs[1].Trim();
                }
            }
        }
    }

    private string LocalizeResourceName(string resourceName)
    {
        return resourceName + this.LanguageCode;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            this.LanguageCode = RU;
        }    

        if (Application.systemLanguage == SystemLanguage.English)
        {
            this.LanguageCode = EN;
        }     

        if (Application.systemLanguage == SystemLanguage.French)
        {
            this.LanguageCode = FR;
        }
            
        LoadResource(LOCALIZATION_PREFIX);
        Instance = this;
        resourceUpdateDispatcher.Dispatch();
    }
}
