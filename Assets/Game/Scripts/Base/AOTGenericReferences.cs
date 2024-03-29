using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"GameFramework.dll",
		"System.dll",
		"UnityEngine.CoreModule.dll",
		"UnityGameFramework.Runtime.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// GameFramework.DataTable.IDataTable<object>
	// GameFramework.GameFrameworkAction<object>
	// GameFramework.GameFrameworkLinkedList.Enumerator<object>
	// GameFramework.GameFrameworkLinkedList<object>
	// GameFramework.ObjectPool.IObjectPool<object>
	// GameFramework.Variable<byte>
	// System.Action<byte>
	// System.Action<object,object>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<byte>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.KeyCollection<byte,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,byte>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary.ValueCollection<byte,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,byte>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.Dictionary<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.Dictionary<byte,object>
	// System.Collections.Generic.Dictionary<object,byte>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<byte>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<byte>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<byte>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<byte,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,byte>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<byte>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.IEqualityComparer<byte>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<byte>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,byte>
	// System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<byte,byte>,object>
	// System.Collections.Generic.KeyValuePair<byte,byte>
	// System.Collections.Generic.KeyValuePair<byte,object>
	// System.Collections.Generic.KeyValuePair<int,int>
	// System.Collections.Generic.KeyValuePair<object,byte>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.LinkedList.Enumerator<object>
	// System.Collections.Generic.LinkedList<object>
	// System.Collections.Generic.LinkedListNode<object>
	// System.Collections.Generic.List.Enumerator<byte>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<byte>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<byte,byte>>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<byte>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<byte>
	// System.Comparison<object>
	// System.EventHandler<object>
	// System.Func<byte>
	// System.Func<object,byte>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.Nullable<int>
	// System.Predicate<byte>
	// System.Predicate<object>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<byte>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<byte>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskCompletionSource<byte>
	// System.Threading.Tasks.TaskCompletionSource<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<byte>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<byte>
	// System.Threading.Tasks.TaskFactory<object>
	// }}

	public void RefMethods()
	{
		// GameFramework.DataTable.IDataTable<object> GameFramework.DataTable.IDataTableManager.GetDataTable<object>()
		// System.Void GameFramework.Fsm.Fsm<object>.ChangeState<object>()
		// System.Void GameFramework.Fsm.FsmState<object>.ChangeState<object>(GameFramework.Fsm.IFsm<object>)
		// object GameFramework.Fsm.IFsm<object>.GetData<object>(string)
		// System.Void GameFramework.Fsm.IFsm<object>.SetData<object>(string,object)
		// System.Void GameFramework.GameFrameworkLog.Error<object,object,object>(string,object,object,object)
		// System.Void GameFramework.GameFrameworkLog.Error<object,object>(string,object,object)
		// System.Void GameFramework.GameFrameworkLog.Error<object>(string,object)
		// System.Void GameFramework.GameFrameworkLog.Info<object,object,object,object>(string,object,object,object,object)
		// System.Void GameFramework.GameFrameworkLog.Info<object,object>(string,object,object)
		// System.Void GameFramework.GameFrameworkLog.Info<object>(string,object)
		// System.Void GameFramework.GameFrameworkLog.Warning<object>(string,object)
		// GameFramework.ObjectPool.IObjectPool<object> GameFramework.ObjectPool.IObjectPoolManager.CreateSingleSpawnObjectPool<object>(string,int)
		// System.Void GameFramework.Procedure.IProcedureManager.StartProcedure<object>()
		// string GameFramework.Utility.Text.Format<int>(string,int)
		// string GameFramework.Utility.Text.Format<object,object,object,object>(string,object,object,object,object)
		// string GameFramework.Utility.Text.Format<object,object,object>(string,object,object,object)
		// string GameFramework.Utility.Text.Format<object,object>(string,object,object)
		// string GameFramework.Utility.Text.Format<object>(string,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<int>(string,int)
		// string GameFramework.Utility.Text.ITextHelper.Format<object,object,object,object>(string,object,object,object,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<object,object,object>(string,object,object,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<object,object>(string,object,object)
		// string GameFramework.Utility.Text.ITextHelper.Format<object>(string,object)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23>(System.Runtime.CompilerServices.TaskAwaiter<object>&,Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>>(Game.Hotfix.AwaitUtility.<AwaitLoadAsset>d__24<object>&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23>(Game.Hotfix.AwaitUtility.<AwaitLoadAssets>d__23&)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInParent<object>()
		// System.Void UnityEngine.Component.GetComponentsInChildren<object>(bool,System.Collections.Generic.List<object>)
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// System.Void UnityEngine.GameObject.GetComponentsInChildren<object>(bool,System.Collections.Generic.List<object>)
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.Object.FindObjectOfType<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityExtension.GetOrAddComponent<object>(UnityEngine.GameObject)
		// GameFramework.DataTable.IDataTable<object> UnityGameFramework.Runtime.DataTableComponent.GetDataTable<object>()
		// System.Void UnityGameFramework.Runtime.Log.Error<object,object,object>(string,object,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Error<object,object>(string,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Error<object>(string,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object,object,object,object>(string,object,object,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object,object>(string,object,object)
		// System.Void UnityGameFramework.Runtime.Log.Info<object>(string,object)
		// System.Void UnityGameFramework.Runtime.Log.Warning<object>(string,object)
		// GameFramework.ObjectPool.IObjectPool<object> UnityGameFramework.Runtime.ObjectPoolComponent.CreateSingleSpawnObjectPool<object>(string,int)
	}
}