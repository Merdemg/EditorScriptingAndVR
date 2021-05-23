# EditorScriptingAndVR

Unity 2020.2.1f1


Go to Window -> TestingContent to see the custom editor window. It reads the list of game object names from a scriptable object, found in Resources/ContentToTest

Click VALIDATE to check if there is a game object in scene with the name to validate. If there is, there will be a green check mark next to the name.


If there is not, you will see a pop up message, asking if you would like to create one. YES creates an empty game object with the name. NO does nothing but puts a red cross next to the name of the object to indicate it was not found in the scene.


VR - Oculus set up is also done. Project is ready for Oculus development. There's an avatar prefab in scene with HMD camera and controllers. There's a variant of it with cube hands in prefabs folder.
