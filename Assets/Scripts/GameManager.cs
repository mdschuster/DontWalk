/*
Copyright (c) 2020, Micah Schuster
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main game manager. Singleton. Currently only used to handle UI.
/// </summary>
public class GameManager : MonoBehaviour
{
    //Singleton Section
    private static GameManager _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    /// <summary>
    /// Count of peds saved
    /// </summary>
    private int saved = 0;

    /// <summary>
    /// Count of peds killed
    /// </summary>
    private int dead = 0;

    /// <summary>
    /// UI Text object that displays the number of peds killed
    /// </summary>
    public Text deadText;

    /// <summary>
    /// UI Text object that displays the number of peds saved
    /// </summary>
    public Text savedText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        savedText.text = saved.ToString();
        deadText.text = dead.ToString();
    }

    /// <summary>
    /// Increments saved value and changes UI Text
    /// </summary>
    public void addSaved()
    {
        saved++;
        savedText.text = saved.ToString();
    }

    /// <summary>
    /// Increments dead value and changes UI Text
    /// </summary>
    public void addDead()
    {
        dead++;
        deadText.text = dead.ToString();
    }
}
