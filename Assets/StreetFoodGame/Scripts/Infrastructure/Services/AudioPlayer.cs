using System;
using System.Collections;

using UnityEngine;

namespace StreetFoodGame.Infrastructure.Services {
    public class AudioPlayer : MonoBehaviour {
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource ambientSource;
        [SerializeField] private AudioSource sfxSource;

        private Coroutine _bgmCrossFadeCoroutine;
        private Coroutine _ambientCrossFadeCoroutine;

        public void PlayBGM(AudioClip clip, float volume = 1f, bool loop = true) {
            bgmSource.clip = clip;
            bgmSource.volume = volume;
            bgmSource.loop = loop;
            bgmSource.Play();
        }

        public void PlayAmbient(AudioClip clip, float volume = 1f, bool loop = true) {
            ambientSource.clip = clip;
            ambientSource.volume = volume;
            ambientSource.loop = loop;
            ambientSource.Play();
        }

        public void PlaySFX(AudioClip clip, float volume = 1f) {
            sfxSource.PlayOneShot(clip, volume);
        }

        public void CrossFadeBGM(AudioClip clip, float duration, float volume = 1f) {
            if (_bgmCrossFadeCoroutine != null) {
                StopCoroutine(_bgmCrossFadeCoroutine);
            }
            
            _bgmCrossFadeCoroutine = StartCoroutine(CoCrossFade(bgmSource, clip, volume, duration));
        }

        public void CrossFadeAmbient(AudioClip clip, float duration, float volume = 1f) {
            if (_ambientCrossFadeCoroutine != null) {
                StopCoroutine(_ambientCrossFadeCoroutine);
            }
            
            _ambientCrossFadeCoroutine = StartCoroutine(CoCrossFade(ambientSource, clip, volume, duration));
        }

        private IEnumerator CoCrossFade(AudioSource audioSource, AudioClip audioClip, float volume, float duration) {
        // Ensure clip is loaded into memory before playing to avoid decompression hitch on first Play
        if (audioClip != null && audioClip.loadState != AudioDataLoadState.Loaded) {
            try {
                audioClip.LoadAudioData();
            } catch (Exception) {
                // LoadAudioData may throw in some contexts; ignore and proceed to wait for state
            }

            float waitTime = 0f;
            float maxWait = 5f; // fallback timeout
            while (audioClip.loadState != AudioDataLoadState.Loaded && waitTime < maxWait) {
                waitTime += Time.deltaTime;
                yield return null;
            }
        }

        float timePos = 0f;
        float beginVolume = audioSource.volume;

        while (timePos < duration) {
            timePos += Time.deltaTime;

            audioSource.volume = beginVolume * (duration - timePos) / duration;

            yield return null;
        }

        timePos = 0f;

        audioSource.clip = audioClip;
        audioSource.Play();

        while (timePos < duration) {
            timePos += Time.deltaTime;

            audioSource.volume = volume * timePos / duration;

            yield return null;
        }

        audioSource.volume = volume;
    }

        public void StopBGM() {
            bgmSource.Stop();
        }

        public void StopAmbient() {
            ambientSource.Stop();
        }
    }
}