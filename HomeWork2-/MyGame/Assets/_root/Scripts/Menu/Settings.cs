using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private Toggle _muteToggle;
        [SerializeField] private Slider _sliderSoundVolume;
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private AudioMixerGroup _mixerGroup;


        private void Start()
        {
            _sliderSoundVolume.onValueChanged.AddListener(ChangeVolume);
            _muteToggle.onValueChanged.AddListener(ToggleMusic);
        }


        private void ChangeVolume(float volume)
        {
            _mixer.SetFloat(_mixerGroup.name, Mathf.Lerp(-80f, 20f, volume));
        }

        public void ToggleMusic(bool enabled)
        {
            if (enabled)
                _mixer.SetFloat(_mixerGroup.name, -80f);
            else
                _mixer.SetFloat(_mixerGroup.name, 0f);
        }


        private void OnDestroy()
        {
            _sliderSoundVolume.onValueChanged.RemoveAllListeners();
            _muteToggle.onValueChanged.RemoveAllListeners();
        }
    }
}