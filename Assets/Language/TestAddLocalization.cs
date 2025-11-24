using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public class TestAddLocalization : MonoBehaviour
{
    public LocalizeStringEvent locEvent;
    public TextMeshProUGUI tmp;

    [ContextMenu("Setup Localization Event")]
    public void Setup()
    {
        LocalizationEventUtility.AddPersistentTextListener(locEvent, tmp);
    }
}
