using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Ÿ���� �ʿ��Ѱ�
    //�ʿ��Լ�- ����������(���������� ü�� ���� + �����), ������ �������� ������

    public int rotSpeed;
    public int speed;

    public int Hp;

    public GameObject item;

    SpriteRenderer sprite;
    MeshRenderer mesh;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Move();
        Rotate(rotSpeed);

    }

    void Move()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void Rotate(int rotSpeed)
    {
        transform.Rotate(-rotSpeed, 0, 0);
    }

    public void Damage(int damege)
    {
        Hp -= damege;
        StartCoroutine(Sprite());
        if (Hp <= 0)
            die();
    }

    void die()
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            Damage(bullet.power);
        }
    }

    IEnumerator Sprite()
    {
        mesh.material.color = new Color32(125, 125, 125, 125);
        yield return new WaitForSeconds(0.1f);
        mesh.material.color = new Color32(255, 255, 255, 255);
    }
}
