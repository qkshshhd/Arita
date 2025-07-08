using System;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float MoveSpeed = 10f;
    public float JumpHeight = 5f;
    private float time = 0f;
    public float AttackTime;
    private float AttackLastTime = 0f;
    public float Hp = 10f;
    
    private Vector3 Move;

    private bool CameraCheck = true;
    private bool JumpCheck = false;
    private bool MotionCheck = true;

    public GameObject LeftWall;
    public GameObject Camera;
    public GameObject RightWall;

    public Rigidbody2D Rb;
    public Animator Animator;
    public GameObject Weapon;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Time.timeScale = 0;
        }
        
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MoveSpeed / 2 * Time.deltaTime, 0, 0);
            Animator.SetInteger("motion", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            Animator.SetInteger("motion", 1);
        }
        else
        {
            Animator.SetInteger("motion", 0);
        }
       
        if (Input.GetMouseButtonDown(0) && Time.time - AttackLastTime >= AttackTime)
        {
            Animator.SetInteger("motion", 2);
            Instantiate(Weapon, transform.position + new Vector3(1,0,0), Quaternion.identity);
           AttackLastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Space) && JumpCheck)
        {
            Rb.AddForceY(JumpHeight, ForceMode2D.Impulse);
            JumpCheck = false;
        }
        

        if (CameraCheck)
        {
            Camera.transform.position = new Vector3(gameObject.transform.position.x, 0, -1);
        }

        if (gameObject.transform.position.x - LeftWall.transform.position.x < 9.5)
        {
            CameraCheck = false;
        }else if (gameObject.transform.position.x - RightWall.transform.position.x > -9.5)
        {
            CameraCheck = false;
        }
        else CameraCheck = true;
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpCheck = true;
        }
    }
}
