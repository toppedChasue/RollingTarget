using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    //나타나면 플레이어쪽으로 날아오기


    public Transform startPos;
    Transform playerPos;

    [SerializeField] float maxSpeed;
    float currentSpeed;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        startPos = this.transform;
        rigid.velocity = Vector3.up * 20f;
        //rigid.velocity = Vector3.right * Random.Range(-5, 5);

        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        playerPos = obj.transform;
    }

    private void Update()
    {
        StartCoroutine(ActiveExp());

    }

    IEnumerator ActiveExp()
    {
        yield return new WaitUntil(() => rigid.velocity.y < 0f);

        yield return new WaitForSeconds(0.1f);

        MovetoPlayer();
        
    }

    void MovetoPlayer()
    {
        if (currentSpeed <= maxSpeed)
            currentSpeed += maxSpeed * Time.deltaTime;

        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        Vector3 pos = (playerPos.position - transform.position).normalized;

        transform.LookAt(pos);
        transform.forward = Vector3.Lerp(transform.forward, pos, 0.25f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
