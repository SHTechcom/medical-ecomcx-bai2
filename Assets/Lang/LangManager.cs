using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public enum LangType
{
    vn,
    en
}

[System.Serializable]
public class Lang
{
    public string key;
    public string[] langs;
}

public class LangManager : MonoBehaviour
{
    private static LangManager _instance;
    public static LangManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<LangManager>(FindObjectsInactive.Include);
            }
            if (_instance == null)
            {
                _instance = new GameObject(nameof(LangManager)).AddComponent<LangManager>();
            }
            return _instance;
        }
    }

    public LangItem[] items;
    public LangType langType;
    public Lang[] langs;
    private Dictionary<string, Lang> langsDict = new Dictionary<string, Lang>();

    private void Reset()
    {
        items = FindObjectsOfType<LangItem>(true);
    }

    private void Start()
    {
        Init();
        // todo: register event UI
    }

    public void Init()
    {
        langsDict = new Dictionary<string, Lang>();
        foreach (var lang in langs)
        {
            if(!langsDict.ContainsKey(lang.key))
            {
                langsDict.Add(lang.key, lang);
            }
        }

        langType = LangType.vn;
        items.ForEach(i => i.Init());
        Set(langType);
    }

    public void SwitchLang()
    {
        if ((int)langType >= 2)
        {
            langType = 0;
        }
        else
        {
            this.langType++;
        }
        Set(langType);
        //todo: set ui: icon,text,...
    }

    public void Set(LangType langType)
    {
        this.langType = langType;
        items.ForEach(i =>
        {
            string content = null;
            if(!langsDict.ContainsKey(i.key))
            {
                content = $"Not contain key: {i.key}";
            }
            content = langsDict[i.key].langs[(int)langType];
            i.Change(content);
        });
    }

    //API call from code
    public string GetLang(string key)
    {
        string content = null;
        if (!langsDict.ContainsKey(key))
        {
            content = $"Not contain key: {key}";
        }
        content = langsDict[key].langs[(int)langType];
        return content;
    }
}
