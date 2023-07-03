using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpbarFixedWidthBehaviour : MonoBehaviour
{
    public float duration = 0.6f;
    public RectTransform bar;
    public RectTransform bar_shadow;

    public CanvasGroup cg;
    public bool hideIfFull;
    public float powerScaleValue = 1;
    public float length;

    public void Hide()
    {
        cg.alpha = 0;
    }

    public void Show()
    {
        cg.alpha = 1;
    }

    public void Set(float percentage, bool instant = false)
    {
        if (percentage == 1 && hideIfFull)
        {
            Hide();
            return;
        }

        var endValue = percentage;
        if (powerScaleValue != 1)
            endValue = Mathf.Pow(percentage, powerScaleValue);

        var barSize = new Vector2(length * endValue, bar.sizeDelta.y);

        if (bar_shadow != null)
        {
            if (!instant && duration > 0)
            {
                bar_shadow.DOKill();
                bar_shadow.sizeDelta = bar.sizeDelta;
                bar_shadow.DOSizeDelta(barSize, duration).SetEase(Ease.InCubic);
            }
            else
                bar_shadow.sizeDelta = barSize;
        }

        bar.sizeDelta = barSize;
        Show();
    }
}