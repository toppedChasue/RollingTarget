using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x;
    public float speed = 5;

    public GameObject bulletPrefab;
    public Transform bulletPos;

    public float curShotDelay;
    public float maxShotDelay;

    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        PlayerMove();
        Shoot(maxShotDelay);
        Reload();
    }

    void PlayerMove()
    {
        Vector3 pos = new Vector3(x, 0, 0);

        pos *= speed;
        rigid.velocity = pos;
    }

    void Shoot(float maxtime)
    {
        if (curShotDelay < maxtime)
            return;

        var bullet = ObjectPool.GetObject();
        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}
