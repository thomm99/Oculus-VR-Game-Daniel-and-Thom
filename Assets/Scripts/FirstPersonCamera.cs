using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
 public Transform character;

void LateUpdate()
{
    transform.position = character.position;
}
}
