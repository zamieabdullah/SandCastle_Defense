﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject centerTower;

    public void startGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    
    public void endGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

    public void gameOver()
    {
        if (centerTower == null)
        {
            Debug.Log("center is null");
            SceneManager.LoadScene("LoseScene");
        }
    }

    //for how to play button
    public void goToInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

}
