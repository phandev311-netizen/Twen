using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyTween
{
    public static class UIPanelTween
    {
        #region Open / Close
        public static Sequence Open(RectTransform target, CanvasGroup canvasGroup = null, float? duration = null, Ease? ease = null)
        {
            target.DOKill();
            target.localScale = UIEase.InitialPopupScale;

            float dur = duration ?? UIEase.Normal;
            Ease easeType = ease ?? UIEase.PopupEase;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(target.DOScale(UIEase.PopupScale, dur).SetEase(easeType));

            if (canvasGroup != null)
            {
                canvasGroup.DOKill();
                canvasGroup.alpha = UIEase.Hidden;
                sequence.Join(canvasGroup.DOFade(UIEase.Visible, dur).SetEase(UIEase.FadeEase));
            }

            return sequence.SetUpdate(true);
        }
        public static Sequence Close(RectTransform target, CanvasGroup canvasGroup = null, float? duration = null, Ease? ease = null, Action onComplete = null)
        {
            target.DOKill();

            float dur = duration ?? UIEase.Fast;
            Ease easeType = ease ?? UIEase.CloseEase;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(target.DOScale(UIEase.InitialPopupScale, dur).SetEase(easeType));

            if (canvasGroup != null)
            {
                canvasGroup.DOKill();
                sequence.Join(canvasGroup.DOFade(UIEase.Hidden, dur).SetEase(UIEase.FadeEase));
            }

            if (onComplete != null)
                sequence.OnComplete(() => onComplete());

            return sequence.SetUpdate(true);
        }

        #endregion

        #region Fade
        public static Tween FadeIn(CanvasGroup target, float? duration = null, Ease? ease = null)
        {
            target.DOKill();
            return target.DOFade(UIEase.Visible, duration ?? UIEase.Normal)
                .SetEase(ease ?? UIEase.FadeEase)
                .SetUpdate(true);
        }
        public static Tween FadeOut(CanvasGroup target, float? duration = null, Ease? ease = null)
        {
            target.DOKill();
            return target.DOFade(UIEase.Hidden, duration ?? UIEase.Normal)
                .SetEase(ease ?? UIEase.FadeEase)
                .SetUpdate(true);
        }

        #endregion

        #region Scale
        public static Tween Popup(Transform target, float? duration = null, Ease? ease = null, float? scale = null)
        {
            target.DOKill();
            target.localScale = UIEase.InitialPopupScale;
            return target.DOScale(scale ?? UIEase.PopupScale, duration ?? UIEase.Normal)
                .SetEase(ease ?? UIEase.PopupEase)
                .SetUpdate(true);
        }
        public static Tween Pop(Transform target, float? strength = null, float? duration = null)
        {
            target.DOKill();
            return target.DOPunchScale(Vector3.one * (strength ?? UIEase.PunchScale), duration ?? UIEase.Fast, 1)
                .SetUpdate(true);
        }
        public static Tween Punch(Transform target, Vector3? punch = null, float? duration = null, int? vibrato = null, float elasticity = 1f)
        {
            target.DOKill();
            Vector3 punchVector = punch ?? Vector3.one * UIEase.PunchScale;
            return target.DOPunchScale(punchVector, duration ?? UIEase.Fast, vibrato ?? UIEase.Vibrato, elasticity)
                .SetUpdate(true);
        }

        public static Tween Pulse(Transform target, float? scaleMultiplier = null, float? duration = null, int loops = UIEase.InfiniteLoops)
        {
            target.DOKill();
            Vector3 originalScale = target.localScale;
            return target.DOScale(originalScale * (scaleMultiplier ?? UIEase.HoverScale), duration ?? UIEase.Slow)
                .SetEase(Ease.InOutSine)
                .SetLoops(loops, LoopType.Yoyo)
                .SetUpdate(true);
        }

        #endregion

        #region Movement
        public static Tween Move(RectTransform target, Vector2 targetPosition, float? duration = null, Ease? ease = null)
        {
            target.DOKill();
            return target.DOAnchorPos(targetPosition, duration ?? UIEase.Normal)
                .SetEase(ease ?? UIEase.MoveEase)
                .SetUpdate(true);
        }
        public static Sequence SlideLeft(RectTransform target, float? distance = null, float? duration = null, Ease? ease = null)
            => SlideFromOffset(target, new Vector2(-(distance ?? UIEase.SlideDistance), 0f), duration, ease);

        public static Sequence SlideRight(RectTransform target, float? distance = null, float? duration = null, Ease? ease = null)
            => SlideFromOffset(target, new Vector2(distance ?? UIEase.SlideDistance, 0f), duration, ease);

        public static Sequence SlideTop(RectTransform target, float? distance = null, float? duration = null, Ease? ease = null)
            => SlideFromOffset(target, new Vector2(0f, distance ?? UIEase.SlideDistance), duration, ease);
        public static Sequence SlideBottom(RectTransform target, float? distance = null, float? duration = null, Ease? ease = null)
            => SlideFromOffset(target, new Vector2(0f, -(distance ?? UIEase.SlideDistance)), duration, ease);

        private static Sequence SlideFromOffset(RectTransform target, Vector2 offset, float? duration, Ease? ease)
        {
            target.DOKill();
            Vector2 finalPosition = target.anchoredPosition;
            target.anchoredPosition = finalPosition + offset;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(target.DOAnchorPos(finalPosition, duration ?? UIEase.Normal).SetEase(ease ?? UIEase.MoveEase));
            return sequence.SetUpdate(true);
        }

        #endregion

        #region Rotation

        public static Tween Rotate(Transform target, float? angle = null, float? duration = null, Ease? ease = null, bool loop = false)
        {
            target.DOKill();
            Tween tween = target.DORotate(new Vector3(0f, 0f, angle ?? UIEase.RotationAngle), duration ?? UIEase.Normal, RotateMode.FastBeyond360)
                .SetEase(ease ?? UIEase.ElasticEase)
                .SetUpdate(true);

            if (loop)
                tween.SetLoops(UIEase.InfiniteLoops, LoopType.Restart);

            return tween;
        }

        #endregion

        #region Shake
        public static Tween Shake(Transform target, float? strength = null, float? duration = null, int? vibrato = null)
        {
            target.DOKill();
            return target.DOShakePosition(duration ?? UIEase.ShakeDuration, strength ?? UIEase.ShakeStrength, vibrato ?? UIEase.Vibrato)
                .SetUpdate(true);
        }

        #endregion

        #region Bounce
        public static Sequence Bounce(RectTransform target, float? height = null, float? duration = null)
        {
            target.DOKill();
            Vector2 originalPosition = target.anchoredPosition;
            float bounceHeight = height ?? UIEase.MoveOffset;
            float halfDuration = (duration ?? UIEase.Normal) * 0.5f;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(target.DOAnchorPosY(originalPosition.y + bounceHeight, halfDuration).SetEase(UIEase.BounceEase));
            sequence.Append(target.DOAnchorPosY(originalPosition.y, halfDuration).SetEase(UIEase.BounceEase));
            return sequence.SetUpdate(true);
        }

        #endregion

        #region Alpha Effects
        public static Tween Blink(CanvasGroup target, int loops = UIEase.InfiniteLoops, float? duration = null)
        {
            target.DOKill();
            return target.DOFade(UIEase.Hidden, duration ?? UIEase.Fast)
                .SetEase(UIEase.FadeEase)
                .SetLoops(loops, LoopType.Yoyo)
                .SetUpdate(true);
        }
        public static Tween Flash(Graphic target, Color? flashColor = null, float? duration = null, int loops = 1)
        {
            target.DOKill();
            Color originalColor = target.color;
            Color color = flashColor ?? Color.white;

            return target.DOColor(color, duration ?? UIEase.Fast)
                .SetLoops(loops * 2, LoopType.Yoyo)
                .SetEase(UIEase.FadeEase)
                .SetUpdate(true)
                .OnComplete(() => target.color = originalColor);
        }

        #endregion

        #region Fill / Progress
        public static Tween FillAmount(Image target, float targetFill, float? duration = null, Ease? ease = null)
        {
            target.DOKill();
            return target.DOFillAmount(Mathf.Clamp01(targetFill), duration ?? UIEase.Normal)
                .SetEase(ease ?? UIEase.MoveEase)
                .SetUpdate(true);
        }

        #endregion

        #region Text
        public static Tween CountText(TMP_Text target, int from, int to, float? duration = null)
        {
            target.DOKill();

            int current = from;
            target.text = FormatNumber(current);

            return DOTween.To(() => current, value =>
            {
                current = value;
                target.text = FormatNumber(current);
            }, to, duration ?? UIEase.Normal)
            .SetEase(Ease.Linear)
            .SetUpdate(true);
        }
        public static Tween TypeWriter(TMP_Text target, string fullText, float? characterInterval = null)
        {
            target.DOKill();
            target.text = fullText;
            target.maxVisibleCharacters = 0;

            int totalCharacters = fullText.Length;
            float interval = characterInterval ?? UIEase.CharacterInterval;
            float totalDuration = Mathf.Max(totalCharacters * interval, UIEase.Instant);

            return DOTween.To(
                    () => target.maxVisibleCharacters,
                    value => target.maxVisibleCharacters = value,
                    totalCharacters,
                    totalDuration)
                .SetEase(Ease.Linear)
                .SetUpdate(true);
        }

        #endregion

        #region Composite / Feedback Effects
        public static Sequence Notification(RectTransform target, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.Normal;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(Popup(target, dur * 0.6f));
            sequence.Append(Shake(target, UIEase.ShakeStrength * 0.5f, dur * 0.4f));
            return sequence.SetUpdate(true);
        }

        public static Sequence Warning(RectTransform target, Graphic colorTarget = null, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.Normal;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(Shake(target, UIEase.ShakeStrength, dur));

            if (colorTarget != null)
                sequence.Join(Flash(colorTarget, Color.red, dur * 0.5f));

            return sequence.SetUpdate(true);
        }

        public static Sequence Reward(RectTransform target, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.Slow;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(Popup(target, dur * 0.5f, UIEase.ElasticEase));
            sequence.Join(Rotate(target, UIEase.RotationAngle, dur * 0.5f));
            return sequence.SetUpdate(true);
        }

        public static Sequence LevelUp(RectTransform target, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.Slow;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(Popup(target, dur * 0.4f, UIEase.PopupEase, UIEase.HoverScale));
            sequence.Append(Pulse(target, UIEase.HoverScale, dur * 0.6f, 2));
            return sequence.SetUpdate(true);
        }

        public static Sequence GameOver(CanvasGroup target, RectTransform shakeTarget = null, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.VerySlow;

            Sequence sequence = DOTween.Sequence();
            sequence.Join(FadeIn(target, dur));

            if (shakeTarget != null)
                sequence.Join(Shake(shakeTarget, UIEase.ShakeStrength, dur));

            return sequence.SetUpdate(true);
        }

        public static Sequence Victory(RectTransform target, float? duration = null)
        {
            target.DOKill();
            float dur = duration ?? UIEase.Slow;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(Bounce(target, UIEase.MoveOffset, dur * 0.6f));
            sequence.Append(Punch(target, Vector3.one * UIEase.PunchScale, dur * 0.4f));
            return sequence.SetUpdate(true);
        }

        public static Tween Loading(Transform target, float? duration = null)
        {
            target.DOKill();
            return target.DORotate(new Vector3(0f, 0f, -UIEase.RotationAngle), duration ?? UIEase.Slow, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(UIEase.InfiniteLoops, LoopType.Restart)
                .SetUpdate(true);
        }

        #endregion

        public static string FormatNumber(double value)
        {
            if (value >= 1_000_000_000)
                return (value % 1_000_000_000 == 0)
                    ? $"{value / 1_000_000_000:0}B"
                    : $"{value / 1_000_000_000:0.#}B";

            if (value >= 1_000_000)
                return (value % 1_000_000 == 0)
                    ? $"{value / 1_000_000:0}M"
                    : $"{value / 1_000_000:0.#}M";

            return value.ToString("N0").Replace(",", ".");
        }
    }
    
}
