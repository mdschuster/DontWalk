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
/// Contains all information for the car objects
/// </summary>
public class Car : MonoBehaviour
{
    /// <summary>
    /// Current car speed
    /// </summary>
    private float speed = 5f;

    /// <summary>
    /// Maximum allowed speed
    /// </summary>
    public float maxSpeed = 5f;

    /// <summary>
    /// Prefab that contains the Engine Sound when instantiated
    /// </summary>
    public GameObject EngineSound;

    /// <summary>
    /// Prefab that contains the Horn Sound when instantiated
    /// </summary>
    public GameObject HornSound;

    /// <summary>
    /// Attached Rigidbody
    /// </summary>
    new private Rigidbody rigidbody = null;

    /// <summary>
    /// Hit information for ray 1
    /// </summary>
    private RaycastHit ray1HitInfo;

    /// <summary>
    /// Hit information for ray 2
    /// </summary>
    private RaycastHit ray2HitInfo;

    /// <summary>
    /// Layer that the raycast will interact with
    /// </summary>
    public LayerMask rayLayer;

    /// <summary>
    /// Transform used for the origin of ray 1
    /// </summary>
    public Transform LeftRayOrigin;

    /// <summary>
    /// Transform used fro the origin of ray 2
    /// </summary>
    public Transform RightRayOrigin;

    /// <summary>
    /// Flag to enable debug view of the raycasts
    /// </summary>
    public bool debug = false;

    /// <summary>
    /// Debug color for ray 1
    /// </summary>
    private Color ray1Color = Color.green;

    /// <summary>
    /// Debug color for ray 2
    /// </summary>
    private Color ray2Color = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GameObject go = Instantiate(EngineSound, this.transform.position, Quaternion.identity);
        go.transform.parent = this.transform;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        //raycasts
        bool ray1Hit = Physics.Raycast(LeftRayOrigin.position, Vector3.forward, out ray1HitInfo, 0.2f, rayLayer, QueryTriggerInteraction.Ignore);
        bool ray2Hit = Physics.Raycast(RightRayOrigin.position, Vector3.forward, out ray2HitInfo, 0.2f, rayLayer, QueryTriggerInteraction.Ignore);

        if (debug)
        {
            if (ray1Hit)
            {
                ray1Color = Color.red;
            }
            else
            {
                ray1Color = Color.green;
            }
            if (ray2Hit)
            {
                ray2Color = Color.red;
            }
            else
            {
                ray2Color = Color.green;
            }
            Debug.DrawRay(LeftRayOrigin.position, Vector3.forward * 0.2f, ray1Color, 0.1f);
            Debug.DrawRay(RightRayOrigin.position, Vector3.forward * 0.2f, ray2Color, 0.1f);
        }

        if (ray1Hit || ray2Hit)
        {
            speed = 0;
            if (Random.Range(0f, 1f) < .005f)
            {
                Instantiate(HornSound, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            speed = maxSpeed;
        }

    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "despawner")
        {
            Destroy(this.gameObject);
        }
    }
}
