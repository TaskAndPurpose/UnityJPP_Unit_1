/* 
   TankMovement.cs
   
   This script controls the movement of a tank in a Unity game. It allows the tank to move forward, backward, 
   and rotate left or right based on user input.
*/

using UnityEngine;

public class TankMovement : MonoBehaviour
{
    // reference to the tank's rigidbody component
    public Rigidbody tankRigidbody; // Public variable to hold a reference to the tank's rigidbody
    
    // movement variables
    public float moveSpeed = 10f; // Public variable to control the speed at which the tank moves
    public float turnSpeed = 180f; // Public variable to control the speed at which the tank rotates
    
    // input variables
    private float moveInput; // Private variable to store the horizontal input for movement
    private float turnInput; // Private variable to store the vertical input for rotation
    
    // Tank Movement
    
    // Method to retrieve input from the player
    private void GetInput()
    {
        // Cache input values
        moveInput = Input.GetAxisRaw("Vertical"); // Retrieve horizontal input from player
        turnInput = Input.GetAxisRaw("Horizontal"); // Retrieve vertical input from player
    }

    // Method to drive the tank based on input
    private void DriveTank()
    {
        ApplyMovement(); // Apply movement based on input
        ApplyRotation(); // Apply rotation based on input
    }

    // Method to apply movement to the tank
    private void ApplyMovement()
    {
        // Apply movement
        float moveAmount = moveInput * moveSpeed * Time.fixedDeltaTime; // Calculate the amount of movement
        Vector3 movement = transform.forward * moveAmount; // Calculate the movement vector
        tankRigidbody.MovePosition(tankRigidbody.position + movement); // Move the tank's position
    }

    // Method to apply rotation to the tank
    private void ApplyRotation()
    {
        // Apply rotation
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime; // Calculate the amount of rotation
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f); // Calculate the rotation quaternion
        tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation); // Rotate the tank
    }
    
    // MonoBehaviour
    
    // Method called when the script instance is being loaded
    private void Start()
    {
        tankRigidbody = GetComponent<Rigidbody>(); // Get the tank's rigidbody component
        if (tankRigidbody == null) // Check if the tank's rigidbody is not found
        {
            Debug.LogError("Tank Rigidbody not found!"); // Log an error message
        }
    }
    
    // Method called once per frame
    private void Update()
    {
        GetInput(); // Retrieve input from the player
    }

    // Method called at fixed intervals for physics updates
    private void FixedUpdate()
    {
        DriveTank(); // Drive the tank based on input
    }
}

