using Codice.Client.BaseCommands;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;


namespace Game.Hotfix
{
    public static class GameHotfixEntry
    {
        public static readonly string[] AOTDLLNames =
        {
            "mscorlib.dll",
            "System.dll",
            "System.Core.dll", // ���ʹ����Linq����Ҫ���
        };

        private static int AOTFlag;
        private static int AOTLoadFlag;

        public static HPBarComponent HPBar
        {
            get;
            private set;
        }

        public static void Start()
        {
#if UNITY_EDITOR
            StartHotfix();
#else
            // Ϊaot assembly����ԭʼmetadata�� ��������aot�����ȸ��¶��С�
            // һ�����غ����AOT���ͺ�����Ӧnativeʵ�ֲ����ڣ����Զ��滻Ϊ����ģʽִ�С�

            // ���Լ�������aot assembly�Ķ�Ӧ��dll����Ҫ��dll������unity build���������ɵĲü����dllһ�£�������ֱ��ʹ��ԭʼdll��
            // ������BuildProcessor������˴�����룬��Щ�ü����dll�ڴ��ʱ�Զ������Ƶ� {��ĿĿ¼}/HybridCLRData/AssembliesPostIl2CppStrip/{Target} Ŀ¼��

            // ע�⣬����Ԫ�����Ǹ�AOT dll����Ԫ���ݣ������Ǹ��ȸ���dll����Ԫ���ݡ�
            // �ȸ���dll��ȱԪ���ݣ�����Ҫ���䣬�������LoadMetadataForAOTAssembly�᷵�ش���
            AOTFlag = AOTDLLNames.Length;
            AOTLoadFlag = 0;
            for (int i = 0; i < AOTFlag; i++) 
            {
                string dllName = AOTDLLNames[i];
                string assetName = Utility.Text.Format("Assets/Game/HybridCLR/Dlls/{0}.bytes", dllName);
                GameEntry.Resource.LoadAsset(assetName, new GameFramework.Resource.LoadAssetCallbacks(OnLoadAOTDLLSuccess, OnLoadAssetFail));
            }
#endif
        }



        private static void StartHotfix()
        {
            GameEntry.BuiltinData.DestroyDialog();

            GameEntry.Fsm.DestroyFsm<IProcedureManager>();

            var procedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();

            ProcedureBase[] procedures =
            {
                new ProcedureChangeScene(),
                new ProcedureMain(),
                new ProcedureMenu(),
                new ProcedurePreload(),
            };

            procedureManager.Initialize(GameFrameworkEntry.GetModule<IFsmManager>(), procedures);
            procedureManager.StartProcedure<ProcedurePreload>();

            GameEntry.Resource.LoadAsset("Assets/GameMain/Game.prefab", new LoadAssetCallbacks(OnLoadAssetSuccess, OnLoadAssetFail));
        }

        private static void OnLoadAssetSuccess(string assetName, object asset, float duration, object userData)
        {
            GameObject game = UnityEngine.Object.Instantiate((GameObject)asset);
            game.name = "Game";

            HPBar = game.GetComponentInChildren<HPBarComponent>();
        }

        private static void OnLoadAOTDLLSuccess(string assetName, object asset, float duration, object userData)
        {
            TextAsset dll = (TextAsset)asset;
            byte[] dllBytes = dll.bytes;
            var err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, HomologousImageMode.SuperSet);
            Log.Info($"LoadMetadataForAOTAssembly:{assetName}. ret:{err}");
            if (++AOTLoadFlag == AOTFlag)
            {
                StartHotfix();
            }
        }

        private static void OnLoadAssetFail(string assetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            Log.Error("Load asset failed. {0}", errorMessage);
        }
    }
}
