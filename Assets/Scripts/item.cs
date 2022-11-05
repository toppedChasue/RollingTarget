using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    //아이템 이름, 효과, 움직임, 

    public Transform playerPos;

    public Transform startPos;

    [Range(0,1)]
    public float t;

    LineRenderer lineRenderer;

    private void Start()
    {
        //startPos = transform;
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 point = Vector3.Slerp(startPos.position, playerPos.position, i / (float)(lineRenderer.positionCount - 1));
            lineRenderer.SetPosition(i, point) ;
        }
       

        //transform.position = Vector3.Slerp(startPos.position, playerPos.position, t);
    }


}
