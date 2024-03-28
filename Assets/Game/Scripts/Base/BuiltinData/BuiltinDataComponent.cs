﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using Codice.Client.BaseCommands;
using GameFramework;
using GameFramework.Resource;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game
{
    public class BuiltinDataComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;
        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset = null;
        //[SerializeField]
        //private NativeDialogForm m_NativeDialogFormTemplate = null;
        //[SerializeField]
        //private LoadingForm m_LoadingForm = null;

        private BuildInfo m_BuildInfo = null;

        //private NativeDialogForm m_NativeDialogForm;

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }

        //public LoadingForm LoadingForm
        //{
        //    get
        //    {
        //        return m_LoadingForm;
        //    }
        //}

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }
        }


        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not be found or empty.");
                return;
            }

            if (!GameEntry.Localization.ParseData(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }

        /// <summary>
        /// （游戏加载前）打开原生对话框。
        /// </summary>
        /// <param name="dialogParams"></param>
        //public void OpenDialog(DialogParams dialogParams)
        //{
        //    if (m_NativeDialogForm == null)
        //    {
        //        m_NativeDialogForm = Instantiate(m_NativeDialogFormTemplate);
        //    }

        //    m_NativeDialogForm.OnOpen(dialogParams);
        //}

        /// <summary>
        /// （游戏加载后）删除原生对话框。
        /// </summary>
        //public void DestroyDialog()
        //{
        //    if (m_NativeDialogForm == null)
        //    {
        //        return;
        //    }
            
        //    Destroy(m_NativeDialogForm);
        //    m_NativeDialogForm = null;
        //}
    }
}
