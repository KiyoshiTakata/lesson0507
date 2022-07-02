using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void OnChageValue(float value)
    {
        // TransformクラスをRectTransformにキャスト

        // 構造体(Vector)の変数にアクセスする書き方
        var rect = transform as RectTransform;
        var anchorMax = rect.anchorMax;
        anchorMax.x = value;
        rect.anchorMax = anchorMax;
    }
}
