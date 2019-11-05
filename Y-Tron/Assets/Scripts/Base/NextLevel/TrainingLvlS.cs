﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrainingLvlS : MonoBehaviour
{
    private bool playerOnTrigger = false;
    public GameObject NextText;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            NextText.SetActive(true);
            playerOnTrigger = true;
        }



    }
    void Update()
    {
        if (playerOnTrigger == true)
        {
            Debug.Log("ez");
            if (Input.GetButtonDown("Select"))
            {
                Debug.Log("fire");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        NextText.SetActive(false);
        playerOnTrigger = false;

    }
}
