using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnaManager : MonoBehaviour
{
    //필요한것
    //스폰위치, 스폰속도, 스폰갯수, 

    public GameObject[] spwanPonit;
    public float spwanTime; //여기에 도달하면
    public float currentTime; //0부터시작
    public int spwanCount; //스폰 몇개할까?\

    public GameObject targetPrefab; //타겟프리팹넣기

    private void Update()
    {
        Spwan();
    }

    void Spwan()
    {
        currentTime += Time.deltaTime;

        if (spwanCount <= 0)
        {
            currentTime = 0;
            return;
        }

        if (currentTime >= spwanTime && spwanCount > 0)
        {
            int ran = Random.Range(0, 3);

            currentTime = 0;
            Instantiate(targetPrefab, spwanPonit[ran].transform.position, Quaternion.identity);

            spwanCount--;
        }
    }
}
