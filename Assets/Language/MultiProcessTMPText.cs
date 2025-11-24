using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class MultiProcessTMPText : MonoBehaviour
{
    public List<TMP_Text> list = new List<TMP_Text>();

    [Button]
    public void FindAllText()
    {
        list = FindObjectsOfType<TMP_Text>(true).ToList();
    }

    [Button]
    public void SetEvent()
    {
        list.ForEach(i =>
        {
            if (!i.gameObject.TryGetComponent<LocalizeStringEvent>(out var localizeStringEvent))
            {
                localizeStringEvent = i.gameObject.AddComponent<LocalizeStringEvent>();
            }
            localizeStringEvent.StringReference = new LocalizedString("Table", i.text);
        });
    }
}
