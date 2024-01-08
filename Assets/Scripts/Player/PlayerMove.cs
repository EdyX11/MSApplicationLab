 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] characters;
    public int currentChar_index;
    public float moveSpeed = 5.0f;
    public float leftRightSpeed = 4;
    static public bool canMove= false;
   static public bool isJumping = false;
    public bool comingDown = false;
 

    public float maxMoveSpeed = 20.0f;
    public float initialYPosition;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    void Start()
    {
        initialYPosition=transform.position.y;
        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (canMove)
        {
            if (isMovingLeft || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }

            if (isMovingRight || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }

            // Handle Jumping Logic
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) /*|| SwipeManager.swipeUp*/)
            {
                if (!isJumping)
                {
                    isJumping = true;
                    characters[currentChar_index].GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }

            // Handle Jump Movement
            if (isJumping)
            {
                if (!comingDown)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * 4, Space.World);
                }
            }

            // Additional movement logic, if any, can go here
        }
    }

    private void MoveLeft()
    {
        if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
    }

    private void MoveRight()
    {
        if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }

    public void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    public void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
    }

    public void StopMovingRight()
    {
        isMovingRight = false;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            characters[currentChar_index].GetComponent<Animator>().Play("Jump");
            StartCoroutine(JumpSequence());
        }
    }
    IEnumerator JumpSequence()
{
    float jumpTime = 1.1f; 
    float jumpHeight = 2.0f; 

    float elapsedTime = 0f;
    while (elapsedTime < jumpTime)
    {
        float jumpProgress = elapsedTime / jumpTime;
        float jumpHeightOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;

        transform.position = new Vector3(
            transform.position.x,
            initialYPosition + jumpHeightOffset,
            transform.position.z
        );

        elapsedTime += Time.deltaTime;
        yield return null;
    }

    isJumping = false;
    characters[currentChar_index].GetComponent<Animator>().Play("Standard Run");
}
}
