using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject cubeSpawner;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private bool random;

    public void OnTriggerEnter(Collider other)
    {

        GameObject spawnedCube;
        Quaternion startRotation = Quaternion.Euler(Vector3.zero);


        Vector3 newRotation = new Vector3(90.0f, 90.0f, 0.0f);
        transform.rotation = Quaternion.Euler(newRotation);

        spawnedCube = GameObject.Instantiate(cubeSpawner, spawnPosition, startRotation) as GameObject;
    }

}
