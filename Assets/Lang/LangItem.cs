using TMPro;
using UnityEngine;

public class LangItem : MonoBehaviour
{
    public string key;
    private TMP_Text txt;

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

    public void Init(string key = null)
    {
        if (!string.IsNullOrEmpty(key))
        {
            this.key = key;
            key = this.key;
        }
        else
        {
            key = txt.text;
        }
    }

    public void Change(string value)
    {
        txt.text = value;
    }
}
