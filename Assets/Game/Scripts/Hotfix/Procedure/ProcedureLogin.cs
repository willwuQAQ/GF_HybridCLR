using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using LitJson;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class ProcedureLogin : ProcedureBase
    {
        public bool isLogin = false;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

            GameEntry.Resource.LoadAsset("Assets/Game/DataTables/Network/LoginHttp.json", new GameFramework.Resource.LoadAssetCallbacks(LoadJsonSuccess, LoadJsonFaile));
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!isLogin)
                return;

            procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Menu"));
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        private void LoadJsonFaile(string assetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            throw new NotImplementedException();
        }

        private void LoadJsonSuccess(string assetName, object asset, float duration, object userData)
        {
            TextAsset str = asset as TextAsset;
            RequestData data = Utility.Json.ToObject<RequestData>(str.text);
            string body = Utility.Json.ToJson(data.body);
            Log.Info("login requesr url : {0}, body : {1}", data.url, body);
            GameEntry.WebRequest.AddWebRequest(data.url, System.Text.Encoding.UTF8.GetBytes(body), this);
        }

        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            // 解析版本信息
            byte[] loginInfoBytes = ne.GetWebResponseBytes();
            string loginInfoString = Utility.Converter.GetString(loginInfoBytes);
            var info = Utility.Json.ToObject<LoginResultData>(loginInfoString);
            if (info != null && info.code == 0)
            {
                CustomGameEntry.UserInfo.userId = info.data.user_id;

                isLogin = true;
            }
            else
            {
                Log.Warning("error code {0}, error message is '{1}'.",info.code, info.msg);
            }
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            WebRequestFailureEventArgs ne = (WebRequestFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Warning("Check version failure, error message is '{0}'.", ne.ErrorMessage);
        }
    }
}
