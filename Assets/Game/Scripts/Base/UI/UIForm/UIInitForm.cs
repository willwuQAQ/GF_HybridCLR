using Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class UIInitForm : UIFormLogic
{
    private static UIInitForm instance;

    [HideInInspector]
    public LoadingForm UILoadingForm;
    [HideInInspector]
    public NativeDialogForm UIDialogForm;

    private Transform m_trans_loadingForm;
    private Transform m_trans_dialogForm;

    public static UIInitForm Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;

        m_trans_loadingForm = transform.Find("LoadingForm");
        m_trans_dialogForm = transform.Find("NativeDialogForm");

        UILoadingForm = m_trans_loadingForm.GetComponent<LoadingForm>();
        UIDialogForm = m_trans_dialogForm.GetComponent<NativeDialogForm>();

        CloseAllView();
    }

    private void CloseAllView()
    {
        m_trans_loadingForm.gameObject.SetActive(false);
        m_trans_dialogForm.gameObject.SetActive(false);
    }

    public void OpenUIDialogForm(DialogParams userData)
    {
        m_trans_dialogForm.gameObject.SetActive(true);
        UIDialogForm.OnOpen(userData);
    }

    public void CloseUIDialogForm()
    {
        m_trans_dialogForm.gameObject.SetActive(false);
    }


    public void OpenLoadingForm(bool isOpen)
    {
        m_trans_loadingForm.gameObject.SetActive(isOpen);
        m_trans_dialogForm.gameObject.SetActive(false);
    }

    public void RefreshLoadingProgress(float totalProgress, string tip = "")
    {
        UILoadingForm.SetProgress(totalProgress, tip);
    }
}
