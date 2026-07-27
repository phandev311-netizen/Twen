using DG.Tweening;
using UnityEngine;

namespace MyTween
{
    public static class UIEase
    {
        #region Durations
        public const float Instant = 0f;
        public const float Fast = 0.15f;
        public const float Normal = 0.3f;
        public const float Slow = 0.5f;
        public const float VerySlow = 0.8f;

        #endregion

        #region Eases
        public const Ease PopupEase = Ease.OutBack;
        public const Ease CloseEase = Ease.InBack;
        public const Ease FadeEase = Ease.Linear;
        public const Ease MoveEase = Ease.OutCubic;
        public const Ease BounceEase = Ease.OutBounce;
        public const Ease ElasticEase = Ease.OutElastic;
        public const Ease ShakeEase = Ease.Linear;

        #endregion

        #region Scale
        public const float PopupScale = 1f;
        public const float HoverScale = 1.1f;
        public const float ClickScale = 0.9f;
        public const float PunchScale = 0.3f;
        public static readonly Vector3 InitialPopupScale = Vector3.zero;

        #endregion

        #region Alpha
        public const float Visible = 1f;
        public const float Hidden = 0f;

        #endregion

        #region Movement
        public const float SlideDistance = 500f;
        public const float MoveOffset = 50f;

        #endregion

        #region Rotation
        public const float RotationAngle = 360f;

        #endregion

        #region Shake

        public const float ShakeStrength = 20f;
        public const float ShakeDuration = 0.5f;
        public const int Vibrato = 10;

        #endregion

        #region Loops
        public const int InfiniteLoops = -1;

        #endregion

        #region Text
        public const float CharacterInterval = 0.05f;

        #endregion
    }
}
