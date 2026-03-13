using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace StreetFoodGame.Presentation.Components
{
    public class CookingIngredientAnimator : MonoBehaviour
    {
        private Dictionary<string, Tween> activeTweens = new Dictionary<string, Tween>();

        public void PlayIdleAnimation()
        {
            Tween tween = transform.DORotate(new Vector3(0, 0, 25), 0.7f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            activeTweens["Idle"] = tween;
        }

        public void PlayHideAnimation()
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.zero, 0.3f).SetEase(Ease.InBack)
                .OnComplete(() => 
                    {
                        gameObject.SetActive(false);
                        Reset();
                    }
                );
        }

        public void PlayShowAnimation()
        {
            transform.localScale = Vector3.zero;
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.one, 0.3f).SetEase(Ease.OutBack)
                .OnComplete(() => PlayIdleAnimation());
        }

        public void LerpToPosition(Vector3 newPosition)
        {
            DOTween.To(() => transform.position, x => transform.position = x, newPosition, 0.3f).SetEase(Ease.InOutSine);
        }

        private void Reset()
        {
            foreach(var tween in activeTweens.Values)
            {
                tween.Kill();
            }
            activeTweens.Clear();
            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.identity;
        }
    }
}