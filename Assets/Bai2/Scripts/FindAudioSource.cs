using UnityEngine;
using System.Collections.Generic;
using Frank;

namespace UDA.Audio
{
    public class FindAudioSource : Singleton<FindAudioSource>
    {
        public List<AudioSource> audioSources = new List<AudioSource>();
        float vollum;

        [ContextMenu("Refresh Audio Source List")]
        public void RefreshList()
        {
            audioSources.Clear();

            AudioSource[] foundSources = FindObjectsOfType<AudioSource>(true);

            audioSources.AddRange(foundSources);
        }

        private void Start()
        {
            //RefreshList();
            vollum = 1f;
            SetVolumeAll(vollum);
            SoundSetting.Instance.slider.value = vollum;
        }

        public void SetVolumeAll(float volume)
        {
            volume = Mathf.Clamp01(volume);

            foreach (var src in audioSources)
            {
                if (src != null)
                    src.volume = volume;
            }
        }

    }
}
