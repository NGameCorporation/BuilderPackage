using UnityEditor;
using UnityEditor.Build.Reporting;

namespace BuilderAssembly.Editor
{
    public static class Builder
    {
        [MenuItem("📦Build/Android")]
        public static void BuildAndroid()
        {
            BuildReport report = BuildPipeline.BuildPlayer(
                new BuildPlayerOptions
                {
                    scenes = new[] { "Assets/Scenes/SampleScene.unity" },
                    locationPathName = "./artifacts/Build.apk",
                    target = BuildTarget.Android,
                    options = BuildOptions.None
                });

            BuildSummary summary = report.summary;

            switch (summary.result)
            {
                case BuildResult.Succeeded:
                    UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
                    break;
                case BuildResult.Failed:
                    UnityEngine.Debug.LogError("Build failed");
                    break;
            }
        }
    }
}