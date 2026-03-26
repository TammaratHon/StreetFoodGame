using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Application.Interfaces {
    public interface IAudioService {
        void PlayAudio(AudioSourceType sourceType, SoundId id, bool loop = false);
        void StopAudio(AudioSourceType sourceType, SoundId id);
        void CrossFadeAudio(AudioSourceType sourceType, SoundId id, float duration);
    }
}