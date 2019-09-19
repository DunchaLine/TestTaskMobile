using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float _cameraY, _cameraX;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _cameraX = Input.GetAxis("Mouse X");
            _cameraY = Input.GetAxis("Mouse Y");
            transform.Rotate(_cameraY, 0, _cameraX);
        }
    }
}
