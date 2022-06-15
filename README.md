# Unity-Screenshotter
Take screenshots from Unity Game view.
  - New Input System required
  - Tested with Input System v1.2.0

# Instal
  0. You must have the New Input System package
  1. In your UnityProyect/Assets/... create a new folder named /Screenshotter/
  2. Copy there the three C# files (ScreenshotterNewInputS, ScreenshotterNewInputS.Editor, ScreenshotterNewInputS.Inspector)
  3. Wait while Unity compile the scripts
  4. In the top menu bar, a new Menu named "Universal" must appear
  5. Go to the scene where you want to take screenshots
  6. Click in menu Universal->Screenshotter->CreateInScene and a new GameObject must appear
  7. Select and configure the GameObject's ScreenshotterNewInputS component and take screenshots

# Screenshotter settings - Take ScreenShots only in editor
  - UseKey: Press that key to take a screenshot
  - UsePad: Press that button on the gamepad to take a screenshot
  - Omnipresent: If enabled the Screenshotter will be sent to DontDestroyOnLoad and will be available in any scene
  - OneShoot: Take one shot when button is pressed / Take multiple shots while button is held
  - Folder: Subfolder where the images will be saved, this folder is created automatically (Examples: Level1 | World1/Level1)

# Take ScreenShots while playing
The UseKey and UsePad only works in Editor, to take screenshots when the game was exported, you can call this functions from the ScreenshotterNewInputS component
  - TakeScreenshot(string folder, string name)
  - TakeScreenshotInFolder(string folder)
  - TakeScreenshot(string name)
  - TakeScreenshot()

If you dont specify a name, a new random name will ge generated, you can create random names using the static funcion
  - ScreenshotterNewInputS.NewName()

# View the Screenshots
  - Click in Universal->Screenshotter->OpenFolder
  - In the Screenshotter GameObject click on RootDirectory or CustomDirectory
  - Images are saved by default in Application.persistentDataPath + "/Screenshots/"
