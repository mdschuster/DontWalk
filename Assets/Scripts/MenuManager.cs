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
/// Class that handels main menu clicks and canvas fade
/// </summary>
public class MenuManager : MonoBehaviour
{

    /// <summary>
    /// Menu menu canvas group. Contains all main menu items
    /// </summary>
    public CanvasGroup mainMenuCanvasGroup;

    /// <summary>
    /// Gameobject that contains the gameplay UI
    /// </summary>
    public GameObject gameUI;

    /// <summary>
    /// Spawn Manager object
    /// </summary>
    public SpawnManager spawnManager;

    /// <summary>
    /// Player character gameobject
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// Function to run when clicking the Start button
    /// </summary>
    public void onStartClick()
    {
        spawnManager.setSpawnPed(true);
        Player.SetActive(true);
        StartCoroutine("mainFadeOut");
    }

    /// <summary>
    /// Main menu canvas fade function
    /// </summary>
    /// <returns>IEnumerator null until canvas alpha is close to 0</returns>
    private IEnumerator mainFadeOut()
    {
        float t = 0.5f;

        while (mainMenuCanvasGroup.alpha > 0f)
        {
            mainMenuCanvasGroup.alpha = Mathf.Lerp(mainMenuCanvasGroup.alpha, 0f, Time.deltaTime / t);
            if (mainMenuCanvasGroup.alpha < 0.1)
            {
                mainMenuCanvasGroup.alpha = 0.0f;
            }
            yield return null;
        }
        mainMenuCanvasGroup.alpha = 0f;
        gameUI.SetActive(true);
    }
}
