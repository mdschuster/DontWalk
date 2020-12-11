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

/// <summary>
/// Class that contains all the information for the Player character
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    /// <summary>
    /// Current Player speed
    /// </summary>
    public float speed = 0f;

    /// <summary>
    /// Contains the attached rigidbody
    /// </summary>
    new private Rigidbody rigidbody = null;

    /// <summary>
    /// Move vector that is applied to the rigidbody
    /// </summary>
    private Vector3 moveAmount = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveAmount = Vector3.zero;
        float value = Input.GetAxisRaw("Horizontal");
        moveAmount = new Vector3(value, 0f, 0f);
        moveAmount = moveAmount.normalized;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.MovePosition(this.transform.position + moveAmount * speed * Time.deltaTime);
    }
}
