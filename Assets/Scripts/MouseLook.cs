using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  [SerializeField] public Transform character;
  Camera childCamera;
  public KeyCode crouchKey = KeyCode.LeftControl;
  [SerializeField] GameObject parentObject;

  bool isCrouching = false;
  [SerializeField] public float sensitivity = 100f;
  float xRotation = 0f;
 [SerializeField] public float crouchScale = 0.5f;
  public Vector3 crouchCameraOffset = new Vector3(0, -1, 0);
  public float crouchDamping = 10.0f;
 
 
 
 
 void Awake() 
{
  parentObject = gameObject;
   Debug.Log("Parent object: " + parentObject.name);
   childCamera = parentObject.GetComponentInChildren<Camera>();
   Debug.Log("Child camera: " + childCamera.name);
   Cursor.lockState = CursorLockMode.Locked;   
}


void Update()
{
    
  CameraUpdatesToMouse();
  Crouch();
    

}


public void CameraUpdatesToMouse()
{
float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    character.Rotate(Vector3.up * mouseX);
}

public void Crouch()
{
    if (Input.GetKeyDown(crouchKey))
    {
        isCrouching = !isCrouching;
    }

    Vector3 targetPos = childCamera.transform.position;
    if (isCrouching)
    {
        Debug.Log("Crouched!");
        targetPos += crouchCameraOffset;
    }
    else
    {
        targetPos -= crouchCameraOffset;
    }

    childCamera.transform.position = Vector3.Lerp(childCamera.transform.position, targetPos, Time.deltaTime * crouchDamping);

}

}
