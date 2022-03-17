using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject rocks;

    private void Start()
    {
        InvokeRepeating("createObstacle", 1f, 2f);
    }
    private void createObstacle()
    {
        Instantiate(rocks);
    }
}
