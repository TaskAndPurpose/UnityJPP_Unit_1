/*
 *
 *
This code defines a CameraSwitcher class responsible for toggling between two cameras in a Unity scene. 
It initializes with one camera active and the other inactive. 
The class detects key inputs ('1' to switch cameras and 'R' to reset the scene) and accordingly activates/deactivates the cameras or resets the scene using Unity's SceneManager.
 * 
 */

// We're importing functionality from the Unity Engine so we can use it in our code.
using UnityEngine;

// This is the declaration of a class called CameraSwitcher. Think of a class like a blueprint for creating objects in programming.
public class CameraSwitcher : MonoBehaviour
{
    // These are variables that hold references to our cameras in the scene.
    public Camera _camera1;
    public Camera _camera2;
    
    // This is a method (a function) that we'll use to switch between our cameras.
    private void FlipFlopCameras()
    {
        // This checks if camera1 is currently active.
        if (_camera1.enabled)
        {
            // If camera1 is active, we deactivate it...
            _camera1.enabled = false;
            // ...and activate camera2.
            _camera2.enabled = true;
        }
        else
        {
            // If camera1 is not active, we activate it...
            _camera1.enabled = true;
            // ...and deactivate camera2.
            _camera2.enabled = false;
        }
    }
    
    // This method is called when the object is first created.
    void Start()
    {
        // We make sure camera2 is initially turned off...
        _camera2.enabled = false;
        // ...and camera1 is turned on.
        _camera1.enabled = true;
    }

    // This method is called once per frame.
    void Update()
    {
        // This checks if the key "1" is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // If "1" is pressed, we switch between cameras.
            FlipFlopCameras();
        }
        
        // This checks if the key "R" is pressed.
        if (Input.GetKeyDown(KeyCode.R))
        {
            // If "R" is pressed, we restart the level using the scene manager.
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
