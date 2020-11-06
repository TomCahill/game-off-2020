using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public MoveState moveState;
    private float speed;
    private float bob;
    private bool bobUp;
    public float stateTime;
    public float bobTime;
    public bool dead;
    void Start()
    {
        moveState = MoveState.movingLeft;
        speed = 5.0f;
        bob = 1.0f;
        bobUp = true;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dead = true;
            }
        }
        else { 
            Death();
        }

        Movement();
    }

    void Death()
    {
        transform.Rotate(new Vector3(0, 0, 220.0f * Time.deltaTime));
        //transform.localScale *= 0.8f;
    }

    void Movement()
    {
        Vector3 movement = new Vector3(0,0,0);
        float moveSpeed = speed * Time.deltaTime;
        float bobSpeed = bob * Time.deltaTime;

        //direction
        if (moveState == MoveState.movingLeft)
            movement += new Vector3(-moveSpeed, 0, 0);
        else if (moveState == MoveState.movingRight)
            movement += new Vector3(moveSpeed, 0, 0);
        else if (moveState == MoveState.movingBack)
            movement += new Vector3(0, moveSpeed, 0);
        else if (moveState == MoveState.movingForward)
            movement += new Vector3(0, -moveSpeed, 0);
        //Bobbing movement
        if (bobUp)
            movement += new Vector3(0, -bobSpeed, 0);
        else
            movement += new Vector3(0, bobSpeed, 0);

        
        if (!dead)
            transform.position += movement;
            //state transitions
            if (stateTime >= 2.0f)
            {
                if (moveState == MoveState.movingLeft)
                    moveState = MoveState.movingBack;
                else if (moveState == MoveState.movingBack)
                    moveState = MoveState.movingRight;
                else if (moveState == MoveState.movingRight)
                    moveState = MoveState.movingForward;
                else if (moveState == MoveState.movingForward)
                    moveState = MoveState.movingLeft;
                stateTime = 0.0f;
            }

            if (bobTime >= 0.3f) {
                bobUp = !bobUp;
                bobTime = 0.0f;
            }

            stateTime += Time.deltaTime;
            bobTime += Time.deltaTime;
    }

    
}

public enum MoveState
{
    movingLeft = 0,
    movingRight = 1,
    movingBack = 2,
    movingForward = 3
};