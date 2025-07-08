using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float MoveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
