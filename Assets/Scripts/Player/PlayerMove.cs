 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 10;
    public float leftRightSpeed = 4;
    static public bool canMove= false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    // Variables for gradual speed increase
    public float initialMoveSpeed = 10.0f;
    public float maxMoveSpeed = 20.0f;
    private float currentMoveSpeed;

    void Start()
    {
        currentMoveSpeed = initialMoveSpeed; // Set the initial move speed
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if( isJumping == false )
                {
                    isJumping = true;
                    playerObject.GetComponent <Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }

            }
            if (currentMoveSpeed < maxMoveSpeed)
            {
                currentMoveSpeed += Time.deltaTime; // You can adjust the rate of increase as needed
            }
            Debug.Log("Current Move Speed: " + currentMoveSpeed);
        }



        if(isJumping == true)
        {
            if(comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);// aici 3 sau -3 dicteaza cat de sus se sare - asta poate fi o variabila si putem face super jump power up
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
    }

        IEnumerator JumpSequence()
        {
            yield return new WaitForSeconds(0.45f);
            comingDown=true;
            yield return new WaitForSeconds(0.45f);
            isJumping=false;
            comingDown=false;
            playerObject.GetComponent <Animator>().Play("Standard Run");

        }
}
