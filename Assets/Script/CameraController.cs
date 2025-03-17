using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100.0f;
    [SerializeField] private float _clampAngle = 80.0f; //

    [SerializeField] private float _rotY = 0.0f; // rotation around the up/Y axis
    [SerializeField] private float _rotX = 0.0f; // rotation around the right/X axis

    

    // Start is called before the first frame update
    void Start()
    {
        var rot = transform.localRotation.eulerAngles;
        _rotY = -rot.y;
        _rotX = -rot.x;

    }

    // Update is called once per frame
    void Update()
    {

        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _rotY += mouseX * _mouseSensitivity * Time.deltaTime;
        _rotX -= mouseY * _mouseSensitivity * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_clampAngle, _clampAngle);

        var localRotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
        transform.rotation = localRotation;

        

    }
}