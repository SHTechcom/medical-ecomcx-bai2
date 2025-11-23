using Frank;
using NUnit.Framework;
using System;
using UDA.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : Singleton<SoundSetting>
{
    public Slider slider;
    public Button languageBtn;

    private void Start()
    {
        slider.onValueChanged.AddListener(ChangeVollum);
        languageBtn.onClick.AddListener(ChangeLeaguage);
    }

    private void ChangeLeaguage()
    {
        throw new NotImplementedException();
    }

    private void ChangeVollum(float arg0)
    {
        FindAudioSource.Instance.SetVolumeAll(arg0);
    }
}
