using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(5, 20)]public float speed;

    public int power;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            ObjectPool.ReturnObjct(this);
        }

        if(other.gameObject.CompareTag("Target"))
        {
            ObjectPool.ReturnObjct(this);
        }

    }
}
