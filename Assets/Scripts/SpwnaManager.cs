using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnaManager : MonoBehaviour
{
    //�ʿ��Ѱ�
    //������ġ, �����ӵ�, ��������, 

    public GameObject[] spwanPonit;
    public float spwanTime; //���⿡ �����ϸ�
    public float currentTime; //0���ͽ���
    public int spwanCount; //���� ��ұ�?\

    public GameObject targetPrefab; //Ÿ�������ճֱ�

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
