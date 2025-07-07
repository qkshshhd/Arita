using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float moveX;

    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.IsPressed())
        {
            moveX = -1;
        }else if (Keyboard.current.dKey.IsPressed())
        {
            moveX = 1;
        }
        else moveX = 0;

        transform.position += moveX * moveSpeed * Time.deltaTime * Vector3.right;


        if (Keyboard.current.leftShiftKey.IsPressed())
        {
            moveSpeed *= 2;
        }
    }
}
