using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public CharacterController controller;
   

   [SerializeField] float walkSpeed = 3f;
   [SerializeField] float runSpeed = 6f;
void Update()
{
    float horizontalMovement = Input.GetAxis("Horizontal");
    float verticalMovement = Input.GetAxis("Vertical");
    bool isRunning = Input.GetKey(KeyCode.LeftShift);
    Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;

    if (isRunning)
    {
    controller.Move(movement * runSpeed * Time.deltaTime);
    }
    else
    {
    controller.Move(movement * walkSpeed * Time.deltaTime);
    }

}
}
