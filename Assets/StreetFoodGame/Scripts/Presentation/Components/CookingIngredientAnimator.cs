using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;

namespace StreetFoodGame.Presentation.Components
{
    public class CookingIngredientAnimator : MonoBehaviour
    {
        public void PlayHideAnimation(Action onComplete = null)
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.zero, 0.3f).SetEase(Ease.InBack)
                .OnComplete(() => 
                    {
                        gameObject.SetActive(false);
                        Reset();
                        onComplete?.Invoke();
                    }
                );
        }

        public void PlayShowAnimation()
        {
            transform.localScale = Vector3.zero;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack));
            sequence.Append(transform.DORotate(new Vector3(0, 0, 25), 0.7f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
        }

        public void LerpToPosition(Vector3 newPosition)
        {
            DOTween.To(() => transform.position, x => transform.position = x, newPosition, 0.3f).SetEase(Ease.InOutSine);
        }

        private void Reset()
        {
            transform.DOKill();
            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.identity;
        }
    }
}