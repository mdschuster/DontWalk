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
/// Contains information to allow spawning of cars and peds
/// </summary>
public class SpawnManager : MonoBehaviour
{

    /// <summary>
    /// List of car prefabs that can spawn
    /// </summary>
    public List<Car> carPrefabs;

    /// <summary>
    /// List of ped prefabs that can spawn
    /// </summary>
    public List<Ped> pedPrefabs;

    /// <summary>
    /// List of car spawn points that is randomly chosen from
    /// </summary>
    public List<GameObject> carSpawnPoints;

    /// <summary>
    /// List of ped spawn points that is randomly chosen from
    /// </summary>
    public List<GameObject> pedSpawnPoints;

    /// <summary>
    /// Time between each car spawn
    /// </summary>
    public float carTimeBetweenSpawns = 0f;

    /// <summary>
    /// Car spawn countdown timer
    /// </summary>
    private float carSpawnTime = 0f;

    /// <summary>
    /// Time between each ped spawn
    /// </summary>
    public float pedTimeBetweenSpawns = 0f;

    /// <summary>
    /// Ped spawn countdown timer
    /// </summary>
    private float pedSpawnTime = 0f;

    /// <summary>
    /// Boolean that determines if peds will spawn
    /// </summary>
    private bool doSpawnPed = false;

    // Update is called once per frame
    void Update()
    {
        spawnCar();
        if (doSpawnPed)
        {
            spawnPed();
        }
    }

    /// <summary>
    /// Setter for doSpawnPed boolean
    /// </summary>
    /// <param name="value">Value to change doSpawnPed to</param>
    public void setSpawnPed(bool value)
    {
        doSpawnPed = value;
    }

    /// <summary>
    /// Spawn car function.
    /// Randomly chooses a car prefab and car spawn point to instantiate the prefab
    /// </summary>
    private void spawnCar()
    {
        if (carSpawnTime <= 0f)
        {
            Instantiate(carPrefabs[Random.Range(0, carPrefabs.Count)], carSpawnPoints[Random.Range(0, carSpawnPoints.Count)].transform.position, Quaternion.identity);

            carSpawnTime = carTimeBetweenSpawns;
        }
        carSpawnTime -= Time.deltaTime;
    }

    /// <summary>
    /// Spawn ped function.
    /// Randomly chooses a ped prefab and ped spawn point to instantiate the prefab.
    /// Applies a small offset from the spawn point to add variability.
    /// </summary>
    private void spawnPed()
    {
        if (pedSpawnTime + Random.Range(0f, 2f) <= 0f)
        {
            Vector3 offset = new Vector3(Random.Range(-0.3f, 0.4f), 0f, Random.Range(-0.3f, 0.3f));
            Instantiate(pedPrefabs[Random.Range(0, pedPrefabs.Count)], pedSpawnPoints[Random.Range(0, pedSpawnPoints.Count)].transform.position - offset, Quaternion.Euler(0f, 90f, 0f));

            pedSpawnTime = pedTimeBetweenSpawns;
        }
        pedSpawnTime -= Time.deltaTime;
    }
}
