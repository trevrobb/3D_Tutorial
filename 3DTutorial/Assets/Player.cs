using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    float _mouseSensitivity = 5f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] RuntimeData _runtimeData;
    float jumpAmount = 10;
    public float playerMoney = 0;
    [SerializeField] GameObject coin;
    public static Player instance;
 
    bool isGround = true;
    float groundY = 0.4f;
    Vector3 velocity = Vector3.zero;
    float gravity = 15f;
    [SerializeField] TextMeshProUGUI _moneyText;

    Vector3 moveDirection;

    private void Awake()
    {
        instance = this;
    }
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
       
        if (GetComponent<CharacterController>().isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= _moveSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpAmount;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime);

    }
    
    public void IncreaseScore()
    {
        playerMoney += 10;
        _moneyText.text = "Money: " + playerMoney.ToString();
    }
}
