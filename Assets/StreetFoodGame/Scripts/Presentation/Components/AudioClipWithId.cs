using System;

using UnityEngine;

using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Presentation.Components {
    [Serializable]
    public class AudioClipWithId {
        public SoundId id;
        public AudioClip clip;
    }
}