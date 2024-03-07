using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelPause : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnClose;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnClickRestart);
        btnClose.onClick.AddListener(OnClickClose);

    }

    private void OnDestroy()
    {
        if (btnClose) btnClose.onClick.RemoveAllListeners();

        if (btnRestart) btnRestart.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    private void OnClickRestart()
    {
        m_mngr.RestartLevel();
    }

    private void OnClickClose()
    {
        m_mngr.ShowGameMenu();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
