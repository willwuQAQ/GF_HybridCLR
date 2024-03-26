public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	// GameFramework.dll
	// UnityEngine.CoreModule.dll
	// UnityGameFramework.Runtime.dll
	// mscorlib.dll
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// GameFramework.DataTable.IDataTable<object>
	// GameFramework.Fsm.FsmState<object>
	// GameFramework.Fsm.IFsm<object>
	// GameFramework.GameFrameworkAction<object>
	// GameFramework.ObjectPool.IObjectPool<object>
	// GameFramework.Variable<byte>
	// System.Collections.Generic.Dictionary<System.Collections.Generic.KeyValuePair<Game.Hotfix.CampType,Game.Hotfix.RelationType>,object>
	// System.Collections.Generic.Dictionary<Game.Hotfix.GameMode,object>
	// System.Collections.Generic.Dictionary<object,byte>
	// System.Collections.Generic.Dictionary<System.Collections.Generic.KeyValuePair<Game.Hotfix.CampType,Game.Hotfix.CampType>,Game.Hotfix.RelationType>
	// System.Collections.Generic.Dictionary.Enumerator<object,byte>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.KeyValuePair<Game.Hotfix.CampType,Game.Hotfix.RelationType>
	// System.Collections.Generic.KeyValuePair<Game.Hotfix.CampType,Game.Hotfix.CampType>
	// System.Collections.Generic.KeyValuePair<object,byte>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.List<Game.Hotfix.CampType>
	// System.EventHandler<object>
	// System.Nullable<int>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskCompletionSource<object>
	// System.Threading.Tasks.TaskCompletionSource<byte>
	// }}

	public void RefMethods()
	{
		// System.Void GameFramework.Fsm.FsmState<object>.ChangeState<object>(GameFramework.Fsm.IFsm<object>)
		// object GameFramework.Fsm.IFsm<object>.GetData<object>(string)
		// System.Void GameFramework.Fsm.IFsm<object>.SetData<object>(string,object)
		// object GameFramework.GameFrameworkEntry.GetModule<object>()
		// System.Void GameFramework.Procedure.IProcedureManager.StartProcedure<object>()
		// object GameFramework.ReferencePool.Acquire<object>()
		// string GameFramework.Utility.Text.Format<int>(string,int)
		// string GameFramework.Utility.Text.Format<object,object,object>(string,object,object,object)
		// string GameFramework.Utility.Text.Format<object>(string,object)
		// string GameFramework.Utility.Text.Format<object,object>(string,object,object)
		// object[] System.Array.Empty<object>()
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23>(Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>>(Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>&)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInParent<object>()
		// System.Void UnityEngine.Component.GetComponentsInChildren<object>(bool,System.Collections.Generic.List<object>)
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.Object.FindObjectOfType<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityExtension.GetOrAddComponent<object>(UnityEngine.GameObject)
		// GameFramework.DataTable.IDataTable<object> UnityGameFramework.Runtime.DataTableComponent.GetDataTable<object>()
		// bool UnityGameFramework.Runtime.FsmComponent.DestroyFsm<object>()
		// System.Void UnityGameFramework.Runtime.Log.Error<object>(string,object)
		// System.Void UnityGameFramework.Runtime.Log.Error<object,object>(string,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Error<object,object,object>(string,object,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object,object,object,object>(string,object,object,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object,object>(string,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object>(string,object)
		// System.Void UnityGameFramework.Runtime.Log.Warning<object>(string,object)
		// GameFramework.ObjectPool.IObjectPool<object> UnityGameFramework.Runtime.ObjectPoolComponent.CreateSingleSpawnObjectPool<object>(string,int)
	}
}