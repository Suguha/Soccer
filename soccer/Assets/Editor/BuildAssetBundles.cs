using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;

public class BuildAssetBundles : Editor {

	//在Unity编辑器中添加菜单  
	[MenuItem("Custom Editor/Create AssetBundle Main")]  
	static void CreateAssetBundlesMain ()  
	{  
		Caching.CleanCache ();
		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
		//Debug.Log (SelectedAsset.Length);

		foreach (Object obj in SelectedAsset) {
			string sourcePath = AssetDatabase.GetAssetPath (obj);
			string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			if (BuildPipeline.BuildAssetBundle(obj, null, targetPath)) {
				Debug.Log (obj.name + "打包成功");
			} else {
				Debug.Log (obj.name + "打包失败");
			}
		}//BuildPipeline.BuildAssetBundles (obj, SelectedAsset, targetPath)
	}

	[MenuItem("Custom Editor/Create AssetBundles ALL")]
	static void CreateAssetBundlesALL()
	{
		Caching.CleanCache ();

		string Path = Application.dataPath + "/StreamingAssets/ALL.assetbundle";

		Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

		//Debug.Log (buildmap.Length);

		foreach (Object obj in SelectedAsset) {
			Debug.Log ("Create AssetBundles name:" + obj.name);
		}

		if (BuildPipeline.BuildAssetBundle(null, SelectedAsset, Path)) {
			Debug.Log ("打包成功1");
			AssetDatabase.Refresh ();
		}

	}
}
