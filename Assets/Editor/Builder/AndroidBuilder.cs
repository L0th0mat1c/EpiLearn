using UnityEditor;
class AndroidBuilder
{
 static void ProductionBuild()
 {
  BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
  buildPlayerOptions.scenes = new[] { "./Assets/_T-VIR-901/Scenes/LilianScene.unity" };
  buildPlayerOptions.locationPathName = "C:/Users/er-on/Documents/Workspace/T-VIR-901-TLS_1/builds/OutputApkName.apk";
  buildPlayerOptions.target = BuildTarget.Android;
  buildPlayerOptions.options = BuildOptions.None;
  BuildPipeline.BuildPlayer(buildPlayerOptions);
 }
}