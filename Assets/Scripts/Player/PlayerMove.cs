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
    public bool isJumping = false;
    public bool comingDown = false;
    //public GameObject playerObject;
    public float maxMoveSpeed = 20.0f;
    public float initialYPosition;
    
    void Start()
    {
        initialYPosition=transform.position.y;
        currentChar_index=PlayerPrefs.GetInt("Selected Charachter", 0);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow )/*|| SwipeManager.swipeLeft*/)
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) /*|| SwipeManager.swipeRight*/)
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) /*|| SwipeManager.swipeUp*/)
            {
                if( isJumping == false )
                {
                    isJumping = true;
                    characters[currentChar_index].GetComponent <Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                    //playerObject.GetComponent <Animator>().Play("Standard Run");
                }

            }
            /* move speed increase with time, need to lower it to chunk spawn 
            if(moveSpeed < maxMoveSpeed)
            moveSpeed = moveSpeed + Time.deltaTime;
            */
        }



        if(isJumping == true)
        {
            if(comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 4, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -4, Space.World);
            }
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
