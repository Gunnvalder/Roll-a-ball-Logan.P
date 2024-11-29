using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Xml.Linq;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI RightOpen;
    public TextMeshProUGUI LeftOpen;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI NextAreaText;

    public GameObject winTextObject;
    public GameObject RestartButtonObject;
    public GameObject RailBrige;
    public GameObject Catcher1;
    public GameObject Catcher2;

    float waitForRightDoor = 5;
    bool rightDoorActivated = false;
    float waitForLeftDoor = 5;
    bool leftDoorActivated = false;
    float WaitForRails = 5;
    bool RailsActive = false;

    public float TimePassed = 0f;
    private bool TimerRunning = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        TimerRunning = true;

        //setting all the text off so its not seen at the start
        winTextObject.SetActive(false);
        RestartButtonObject.SetActive(false);
        RightOpen.gameObject.SetActive(false);
        LeftOpen.gameObject.SetActive(false);
        NextAreaText.gameObject.SetActive(false);
        RailBrige.gameObject.SetActive(false);
        Catcher2.gameObject.SetActive(false);
    }
    private void Update()
    {
        //if the door is active and the timer is still above 0
        if(waitForRightDoor > 0 && rightDoorActivated == true)
        {
            //decrement the timer (countdown)
            waitForRightDoor -= Time.deltaTime;
        }
        //otherwise, if the timer is at or below 0
        else if (waitForRightDoor <= 0)
        {
            rightDoorActivated = false;
            RightOpen.gameObject.SetActive(false);
        }
        if (waitForLeftDoor > 0 && leftDoorActivated == true)
        {
            waitForLeftDoor -= Time.deltaTime;
        }
        else if (waitForLeftDoor <= 0)
        {
            leftDoorActivated = false;
            LeftOpen.gameObject.SetActive(false);
        }
        if (WaitForRails > 0 && RailsActive == true)
        {
            WaitForRails -= Time.deltaTime;
        }
        else if (WaitForRails <= 0)
        {
            RailsActive = false;
            NextAreaText.gameObject.SetActive(false);
        }
        
        if (TimerRunning == true)
        {
            TimePassed += Time.deltaTime;

            UpdateTimer();
        }

    }

    void UpdateTimer()
    {
        if (TimerText != null)
        {
            int min = Mathf.FloorToInt(TimePassed / 60);
            int sec = Mathf.FloorToInt(TimePassed % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        
    }

    void StopTimer()
    {
        if (winTextObject == true)
        {
            
            TimerRunning = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
            transform.localScale *= 1.1f;
            
        }
        if (other.gameObject.CompareTag("DoorButton"))
        {
            GameObject door = GameObject.FindWithTag("Door1");
            door.SetActive(false);
            rightDoorActivated = true;
            RightOpen.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("DoorButton2"))
        {
            GameObject door = GameObject.FindWithTag("Door2");
            door.SetActive(false);
            leftDoorActivated = true;
            LeftOpen.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("ResetScaleButton"))
        {
            GameObject ResetScale = GameObject.FindWithTag("ResetScaleButton");
            transform.localScale /= 1.5f;
            ResetScale.gameObject.SetActive(false);
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        //when count is over 20 the game will end
        if (count >= 20)
        {
            winTextObject.SetActive(true);
            RestartButtonObject.SetActive(true);
            StopTimer();
        }
        if (count >= 12)
        {
            RailsActive = true;
            NextAreaText.gameObject.SetActive(true);
            RailBrige.gameObject.SetActive(true);
            Catcher1.gameObject.SetActive(false);
            Catcher2.gameObject.SetActive(true);
        }
    }
}