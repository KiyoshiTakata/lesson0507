using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button titlebutton;

    private void Awake()
    {
        titlebutton.onClick.AddListener(() => { OnTitleTap(); });
    }

    public void OnTitleTap()
    {
        Debug.Log("OnTitleTap");
    }

    public void OnGameTap()
    {
        Debug.Log("OnGameTap");
    }

    public void OnOptionTap()
    {
        Debug.Log("OnOptionTap");
    }
}
