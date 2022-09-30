using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _mouseSensitivity = 10f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        
        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        _currentTilt += mouseY;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);


        //_cam.transform.Rotate(Vector3.right, mouseY * _mouseSensitivity);





    }
}
