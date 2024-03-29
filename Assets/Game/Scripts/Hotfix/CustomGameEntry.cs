using Game.Hotfix;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameEntry : MonoBehaviour
{
    /// <summary>
    /// 构建数据组件。
    /// </summary>
    public static UserInfoComponent UserInfo
    {
        get;
        private set;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void InitCustomComponent()
    {
        UserInofInit();

    }

    private void UserInofInit()
    {
        UserInfo = new GameObject("UserInfo").AddComponent<UserInfoComponent>();
        UserInfo.transform.parent = transform;
        UserInfo = UnityGameFramework.Runtime.GameEntry.GetComponent<UserInfoComponent>();

    }
}
