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
        //��������������� ���������� ��� �������� ���� ������������� ������������ �� 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    
    void Update()
    {   //���� �� ��������� �� ���������� � �������� ��������� �� �� ���������� ��������� �� �� �� �����
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
