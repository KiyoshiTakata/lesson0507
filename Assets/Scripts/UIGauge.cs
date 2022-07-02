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
        // Transform�N���X��RectTransform�ɃL���X�g

        // �\����(Vector)�̕ϐ��ɃA�N�Z�X���鏑����
        var rect = transform as RectTransform;
        var anchorMax = rect.anchorMax;
        anchorMax.x = value;
        rect.anchorMax = anchorMax;
    }
}
