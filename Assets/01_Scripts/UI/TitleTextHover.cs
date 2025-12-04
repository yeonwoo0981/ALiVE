using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using NotImplementedException = System.NotImplementedException;

namespace _01_Scripts.UI
{
    public class TitleTextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private RectTransform _rectTransform;
        private float _originSize;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            
            _originSize = _rectTransform.sizeDelta.x;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                new Vector2(250f, _rectTransform.sizeDelta.x),
                0.2f
            ).SetEase(Ease.Flash);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                new Vector2(_originSize, _rectTransform.sizeDelta.y),
                0.2f)
                .SetEase(Ease.Flash);
        }

        private void OnDisable()
        {
            _rectTransform.DOKill();
        }
    }
}