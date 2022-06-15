using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

namespace LocalScripts.Screenshotter
{
    public class ScreenshotterNewInputS : MonoBehaviour
    {

        public enum HotKey
        {
            zKey,
            xKey,
            cKey,

            vKey,
            bKey,
            nKey,

            mKey,
            qKey,
            wKey,

            oKey,
            pKey,
            yKey,

            None,
        }

        public enum HotPad
        {
            ButtonSouth,
            ButtonNorth,
            ButtonEast,
            ButtonWest,

            LB,
            LT,
            RB,
            RT,

            None,
        }

        // Where all screenshots are saved
        public static string DataPath => Application.persistentDataPath + "/Screenshots/";

#if UNITY_EDITOR
        [Header("Settings")]
        [SerializeField] private HotKey useKey = HotKey.pKey;  // Key that take a screenshot
        [SerializeField] private HotPad usePad = HotPad.None;  // Gamepad button that take a screenshot
        [SerializeField] private bool omnipresent = false;  // Send object to DontDestroyOnLoad
        [SerializeField] private bool oneShot = true;  // Only take one screenshot / Take screenshots while button is held
        [SerializeField] private string folder = "";  // Subfolder to store the images


        public string Folder => folder;

        private bool lastState = false;

#endif


        // Auto take screenshots presing a key, only in Editor mode
#if UNITY_EDITOR

        private void Start()
        {
            // If omnipresent, send to dont destroy on load
            if (omnipresent) DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {

            // Check if the hot key is pressed
            bool keyIsPressed = false;
            if      (useKey == HotKey.zKey) keyIsPressed = Keyboard.current.zKey.isPressed;
            else if (useKey == HotKey.xKey) keyIsPressed = Keyboard.current.xKey.isPressed;
            else if (useKey == HotKey.cKey) keyIsPressed = Keyboard.current.cKey.isPressed;
            else if (useKey == HotKey.vKey) keyIsPressed = Keyboard.current.vKey.isPressed;
            else if (useKey == HotKey.bKey) keyIsPressed = Keyboard.current.bKey.isPressed;
            else if (useKey == HotKey.nKey) keyIsPressed = Keyboard.current.nKey.isPressed;
            else if (useKey == HotKey.mKey) keyIsPressed = Keyboard.current.mKey.isPressed;
            else if (useKey == HotKey.qKey) keyIsPressed = Keyboard.current.qKey.isPressed;
            else if (useKey == HotKey.wKey) keyIsPressed = Keyboard.current.wKey.isPressed;
            else if (useKey == HotKey.oKey) keyIsPressed = Keyboard.current.oKey.isPressed;
            else if (useKey == HotKey.pKey) keyIsPressed = Keyboard.current.pKey.isPressed;
            else if (useKey == HotKey.yKey) keyIsPressed = Keyboard.current.yKey.isPressed;

            // Check if hotPad is pressed
            bool padIsPressed = false;
            if      (usePad == HotPad.ButtonEast) padIsPressed = Gamepad.current.buttonEast.isPressed;
            else if (usePad == HotPad.ButtonNorth) padIsPressed = Gamepad.current.buttonNorth.isPressed;
            else if (usePad == HotPad.ButtonSouth) padIsPressed = Gamepad.current.buttonSouth.isPressed;
            else if (usePad == HotPad.ButtonWest) padIsPressed = Gamepad.current.buttonWest.isPressed;
            else if (usePad == HotPad.LB) padIsPressed = Gamepad.current.leftShoulder.ReadValue() == 1f;
            else if (usePad == HotPad.RB) padIsPressed = Gamepad.current.rightShoulder.ReadValue() == 1f;
            else if (usePad == HotPad.LT) padIsPressed = Gamepad.current.leftTrigger.ReadValue() == 1f;
            else if (usePad == HotPad.RT) padIsPressed = Gamepad.current.rightTrigger.ReadValue() == 1f;

            
            // Take the screenshot
            if ((keyIsPressed || padIsPressed) && lastState == false) TakeScreenshotInFolder(folder);

            // Check last state
            if (oneShot) lastState = keyIsPressed || padIsPressed;

        }
#endif


        // Take a Screenshot
        public static void TakeScreenshot(string folder, string name)  // Master 1
        {
            // Check if the folder exist or create it
            if (!Directory.Exists($"{DataPath}{folder}/"))
                Directory.CreateDirectory($"{DataPath}{folder}/");

            ScreenCapture.CaptureScreenshot($"{DataPath}{folder}/{name}.png");
        }
        public static void TakeScreenshot(string name)  // Slave of 1, Master 2
        {
            TakeScreenshot("", name);
        }
        public static void TakeScreenshotInFolder(string folder)  // Slave of 1
        {
            TakeScreenshot(folder, NewName());
        }
        public static void TakeScreenshot()  // Slave of 2
        {
            TakeScreenshot(NewName());
        }


        // Create a semirandom name for the screenshot
        public static string NewName()
        {
            var moment = DateTime.Now;

            return $"{moment.Year}{moment.Month}{moment.Day}-{moment.Hour}{moment.Minute}{moment.Second}-{NewId()}";
        }


        // Create a randomId to name the screenShoot
        private static string NewId()
        {

            byte[] buffer = Guid.NewGuid().ToByteArray();

            var sid = BitConverter.ToUInt32(buffer, 0).ToString();

            if (sid.Length < 10)
            {
                for (int i = 0; i < 10 - sid.Length; i++)
                {
                    sid = sid + "0";
                }
            }

            if (sid.Length > 10)
            {
                for (int i = 0; i < sid.Length - 10; i++)
                {
                    sid = sid.TrimEnd(sid[sid.Length - 1]);
                }
            }

            return sid;

        }


        // Create a screenshoter in the current scene
        public static void CreateInCurrentScene()
        {
            var go = new GameObject($"Screenshotter - {NewId()}");
            go.AddComponent<ScreenshotterNewInputS>();
        }

    }
}