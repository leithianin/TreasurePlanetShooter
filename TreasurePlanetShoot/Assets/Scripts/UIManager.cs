﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void EndLevel()
    {
        Debug.Log("EndGame");
    }

    public void LoseLevel()
    {

    }
}
