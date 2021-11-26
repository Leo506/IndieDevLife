using UnityEditor;

public class CreateAssetBundle
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles() {
       BuildPipeline.BuildAssetBundles("Assets/StreamingAssets/AssetBundles/", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
