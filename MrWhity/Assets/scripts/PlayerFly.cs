using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{

    [Header("Player Flying Settings")]
    private Vector2 targetPos;
    public float Yincrement;
    public float Xincrement;
    public float speed;

    private float HorizontalMove = 0f;
    private bool FacingRight = true;



    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        // Move Y
        if (Input.GetKeyDown(KeyCode.T))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }

        // Move X

        if (Input.GetKeyDown(KeyCode.H))
        {
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
        }

    }
}
