using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Timeline;
using UnityEngine;


public class Player : MonoBehaviour
{
    float _mouseSensitivity = 5f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] RuntimeData _runtimeData;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk) {
            Movement();

        }
        

    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);

    }
    void Movement()
    {
        Vector3 sidewaysMove = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector3 forwardMove = transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 move = sidewaysMove + forwardMove;

        GetComponent<CharacterController>().Move(move * _moveSpeed);
    }
}
