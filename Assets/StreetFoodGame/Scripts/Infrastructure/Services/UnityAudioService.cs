using System.Collections.Generic;

using UnityEngine;

using StreetFoodGame.Domain.Enums;

using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services {
    public class UnityAudioService : IAudioService {
        private readonly AudioPlayer audioPlayer;
        private readonly Dictionary<SoundId, AudioClip> _audioClips;

        public UnityAudioService(AudioPlayer audioPlayer, Dictionary<SoundId, AudioClip> audioClips) {
            this.audioPlayer = audioPlayer;
            _audioClips = audioClips;
        }
        
        public void CrossFadeAudio(AudioSourceType sourceType, SoundId id, float duration) {
            switch (sourceType) {
                case AudioSourceType.BGM:
                    audioPlayer.CrossFadeBGM(_audioClips[id], 1f, duration);
                    break;
                case AudioSourceType.AMBIENT:
                    audioPlayer.CrossFadeAmbient(_audioClips[id], 1f, duration);
                    break;
            }
        }

        public void PlayAudio(AudioSourceType sourceType, SoundId id, bool loop = false) {
            switch (sourceType) {
                case AudioSourceType.BGM:
                    audioPlayer.PlayBGM(_audioClips[id], 1f, loop);
                    break;
                case AudioSourceType.AMBIENT:
                    audioPlayer.PlayAmbient(_audioClips[id], 1f, loop);
                    break;
                case AudioSourceType.SFX:
                    audioPlayer.PlaySFX(_audioClips[id], 1f);
                    break;
            }
        }

        public void StopAudio(AudioSourceType sourceType, SoundId id) {
            switch (sourceType) {
                case AudioSourceType.BGM:
                    audioPlayer.StopBGM();
                    break;
                case AudioSourceType.AMBIENT:
                    audioPlayer.StopAmbient();
                    break;
            }
        }
    }
}