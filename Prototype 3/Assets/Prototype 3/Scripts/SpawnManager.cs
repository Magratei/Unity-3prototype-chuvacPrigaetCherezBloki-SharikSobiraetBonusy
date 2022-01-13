using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerControllerScript;
    void Start()
    {   //постоянно выполняем метод с определенным интервалом 
        InvokeRepeating("SpavnObstacle", startDelay, repeatDelay);
        //инициалищируем переменную под другой скрип в игровом обьекте плейер что бы доставать с того скрипта переменные
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //мой метод
    private void SpavnObstacle()
    {   //пока мы не коснулись препятствия спавним новые препятствия 
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }

    void Update()
    {
        
    }
}
