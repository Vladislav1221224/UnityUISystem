using UnityEngine;

namespace Project.UI
{
    /// <summary>
    /// Автоматично підлаштовує RectTransform під безпечну зону екрана (SafeArea),
    /// щоб уникнути перекриття важливих UI елементів вирізами, кнопками та індикаторами.
    /// </summary>
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _safeAreaTransform;

        private Rect _lastSafeArea;
        private ScreenOrientation _lastOrientation;

        private void Awake()
        {
            _safeAreaTransform = GetComponent<RectTransform>();
            _lastOrientation = Screen.orientation;

            ApplySafeArea();
        }

        private void Update()
        {
            if (_lastSafeArea != Screen.safeArea || _lastOrientation != Screen.orientation)
            {
                ApplySafeArea();
            }
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _safeAreaTransform.anchorMin = anchorMin;
            _safeAreaTransform.anchorMax = anchorMax;

            _lastSafeArea = safeArea;
            _lastOrientation = Screen.orientation;
        }
    }
}
