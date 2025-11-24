using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum LanguageType
{
    vn, en
}

[System.Serializable]
public struct Language
{
    public LanguageType type;
    public string content;
}

public class LanguageItem : MonoBehaviour
{
    public TMP_Text txt;
    public TMP_Text Txt
    {
        get
        {
            if(txt == null)
            {
                txt = GetComponent<TMP_Text>();
            }
            return txt;
        }
    }
    public LanguageType currentType;
    public List<Language> languages = new List<Language>();

    private void Reset()
    {
        txt = GetComponent<TMP_Text>();
    }

    public void Change(LanguageType type)
    {
        currentType = type;
        for (int i = 0; i < languages.Count; i++)
        {
            if (languages[i].type == currentType)
            {
                Txt.text = languages[i].content;
                return;
            }
        }
    }
}
