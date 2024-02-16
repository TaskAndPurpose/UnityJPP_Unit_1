// This class controls the behavior of a truck in the game. It allows the player to control the truck's movement and rotation using input from the keyboard or another input device. The truck can move forward and backward along its local Z-axis and rotate around its vertical Y-axis. This behavior is achieved by accessing input values for both horizontal and vertical axes, allowing for smooth and intuitive control of the truck's movements.

// The truck's movement is handled in the Update method, which is called once per frame. Inside this method, the MoveForwardAndRotate function is invoked. This function retrieves input from the player controls using the GetInput method and then utilizes these input values to move the truck forward/backward and rotate it accordingly. The movement and rotation are performed by separate functions, making the code modular and easy to understand.

// The Truck class also contains helper functions such as GetInput, MoveForward, and Rotate, which are responsible for specific aspects of the truck's behavior. By breaking down the movement and rotation logic into smaller, more manageable functions, the code becomes more organized and maintainable. Additionally, using Time.deltaTime ensures that the truck's movement remains consistent across different devices and frame rates, providing a smoother gameplay experience.



// We're importing functionality from the Unity Engine so we can use it in our code.
using UnityEngine;

// This class controls the behavior of a truck in the game.
public class Truck : MonoBehaviour
{
    // This is a variable that holds the ID for the input controls of the truck.
    public string inputID;
    
    // These are variables that hold references to components attached to our truck object.
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _turnSpeed = 10f;

    // This method is called once per frame.
    private void Update()
    {
        // Inside the Update method, we call another method called MoveForwardAndRotate to handle moving and rotating the truck.
        MoveForwardAndRotate();
    }

    // This is a method (a function) we've created to handle moving and rotating the truck.
    private void MoveForwardAndRotate()
    {
        // We're calling a separate function to get the input from the player controls.
        Vector2 input = GetInput();
        
        // We're using the input values to move and rotate the truck.
        MoveForward(input.y);
        Rotate(input.x);
    }
    
    // This function gets the input (horizontal and vertical) from the player controls.
    private Vector2 GetInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal" + inputID);
        float verticalInput = Input.GetAxis("Vertical"+ inputID);
        return new Vector2(horizontalInput, verticalInput);
    }
    
    // This function moves the truck forward or backward based on the player's vertical input.
    private void MoveForward(float verticalInput)
    {
        this.transform.Translate(Vector3.forward * _speed * Time.deltaTime * verticalInput);
    }
    
    // This function rotates the truck based on the player's horizontal input.
    private void Rotate(float horizontalInput)
    {
        this.transform.Rotate(Vector3.up, _turnSpeed * horizontalInput * Time.deltaTime);
    }
}
