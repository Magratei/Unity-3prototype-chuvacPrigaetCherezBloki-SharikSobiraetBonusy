using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    void Start()
    {   
        startPos = transform.position;
        //инициалимзируем переменную под значение икса боксколайдера разделенного на 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    
    void Update()
    {   //если мы смещаемся на расстояние в половину колайдера то мы возвращаем бекграунд на то же место
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
