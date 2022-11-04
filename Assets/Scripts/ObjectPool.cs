using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<Bullet> poolingObjBullet = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjBullet.Enqueue(CreateNewObject());
        }
    }

    private Bullet CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    
    public static Bullet GetObject()
    {
        if(Instance.poolingObjBullet.Count > 0)
        {
            var obj = Instance.poolingObjBullet.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObjct(Bullet obj)
    {
        obj.transform.SetParent(Instance.transform);
        obj.transform.position = Instance.transform.position;
        obj.gameObject.SetActive(false);
        Instance.poolingObjBullet.Enqueue(obj);
    }
}
