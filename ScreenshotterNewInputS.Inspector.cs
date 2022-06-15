using System.IO;
using UnityEditor;
using UnityEngine;

namespace LocalScripts.Screenshotter
{
#if UNITY_EDITOR

    [CustomEditor(typeof(ScreenshotterNewInputS))]
    [CanEditMultipleObjects()]
    public class ScreenshotterNewInputS_Inspector : Editor
    {

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            GUILayout.Label("   Folder format: World1/Level3");

            ScreenshotterNewInputS c = (ScreenshotterNewInputS)target;

            // Space
            GUILayout.Space(20);

            // Open the root folder
            if (GUILayout.Button("Root Directory"))
            {

                // Check if the folder exist or create it
                if (!Directory.Exists(ScreenshotterNewInputS.DataPath))
                    Directory.CreateDirectory(ScreenshotterNewInputS.DataPath);

                // Open the folder
                Application.OpenURL(ScreenshotterNewInputS.DataPath);

            }

            // Open the folder
            if (GUILayout.Button("Custom Directory"))
            {

                // Check if the folder exist or create it
                if (!Directory.Exists($"{ScreenshotterNewInputS.DataPath}/{c.Folder}/"))
                    Directory.CreateDirectory($"{ScreenshotterNewInputS.DataPath}/{c.Folder}/");

                // Open the folder
                Application.OpenURL($"{ScreenshotterNewInputS.DataPath}/{c.Folder}/");

            }

            // Space
            GUILayout.Space(20);

            // Warnings
            GUILayout.Label("UseKey and UsePad only works in Editor");

            // Space
            GUILayout.Space(20);


        }

    }

#endif
}