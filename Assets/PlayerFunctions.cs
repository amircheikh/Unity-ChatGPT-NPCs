using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFunctions : MonoBehaviour
{
    private GameObject playerCamera;
    private GameObject mainUI;
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");    
        mainUI = GameObject.FindGameObjectWithTag("MainUI");
    }

    public void DisablePlayer()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponentInChildren<MouseLook>().enabled = false;

        Cursor.lockState = CursorLockMode.None;

        mainUI.GetComponentInChildren<TMP_Text>().enabled = false;
        //mainUI.SetActive(false);
        playerCamera.SetActive(false);
    }

    public void EnablePlayer()
    {
        playerCamera.SetActive(true);
        //mainUI.SetActive(true);
        mainUI.GetComponentInChildren<TMP_Text>().enabled = true;


        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponentInChildren<MouseLook>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;        
    }

}
