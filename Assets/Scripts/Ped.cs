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
/// Contains all information to create the Pedestrian
/// </summary>
public class Ped : MonoBehaviour
{

    /// <summary>
    /// Constant speed of the ped
    /// </summary>
    public float speed = 0.1f;

    /// <summary>
    /// variable containing the rigidbody
    /// </summary>
    new private Rigidbody rigidbody = null;

    /// <summary>
    /// Gameobject that plays the ped death sound on instantiation
    /// </summary>
    public GameObject deathSound;

    /// <summary>
    /// Gameobject that plays the ped death particle system on instantiation
    /// </summary>
    public GameObject Death = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "despawner")
        {
            GameManager.instance().addSaved();
            Destroy(this.gameObject);
        }
        if (other.tag == "car")
        {
            GameManager.instance().addDead();
            Instantiate(Death, this.transform.position + Vector3.up * .2f, Quaternion.identity);
            Instantiate(deathSound, this.transform.position + Vector3.up * .2f, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

