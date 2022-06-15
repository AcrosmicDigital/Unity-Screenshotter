using UnityEditor;
using UnityEngine;
using System.IO;

namespace LocalScripts.Screenshotter
{
#if UNITY_EDITOR

    public class ScreenshotterNewInputS_Editor : EditorWindow
    {
        [MenuItem("Universal/Screenshotter/Open Folder")]
        public static void ShowWindow()
        {

            // Check if the folder exist or create it
            if (!Directory.Exists(ScreenshotterNewInputS.DataPath))
                Directory.CreateDirectory(ScreenshotterNewInputS.DataPath);

            // Open the folder
            Application.OpenURL(ScreenshotterNewInputS.DataPath);

        }

        [MenuItem("Universal/Screenshotter/Create In Scene")]
        public static void CreateInScene()
        {

            // Create in scene
            ScreenshotterNewInputS.CreateInCurrentScene();

        }

    }

#endif
}