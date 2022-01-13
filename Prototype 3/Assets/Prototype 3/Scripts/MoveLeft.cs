using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    void Start()
    {   //инициалищируем переменную под другой скрип в игровом обьекте плейер что бы доставать с того скрипта переменные
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {   //все двигаетс€ вокруг пока мы не коснемс€ преп€тстви€ (берем переменную дл€ проверки из доугого скрипта)
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //уничтожаем обьеты под тегом когда они оказываютс€ на -15 единиц по иксу 
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
