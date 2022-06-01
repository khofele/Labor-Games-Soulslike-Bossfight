using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWall : MonoBehaviour
{
    public GameObject movingWall; //the wall that shall be moved
    bool playerIsHere = true; //player is in entrance area (is starting there)
    public float maximumOpening = 5f; //Z, max opening position wall
    public float maximumClosing = 0; //Z, position wall if closed
    public float movementSpeed = 8f; //speed of wall movement

    // Update is called once per frame
    private void Update()
    {
        if (!playerIsHere) //player is not in entrance anymore and in front of the moving wall
        {
            if (movingWall.transform.position.z > maximumClosing) //if wall open
            {
                movingWall.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
        }

        //if (playerIsHere) //player goes to wall
        //{
        //    if(movingWall.transform.position.z < maximumOpening) //if wall closed
        //    {
        //        movingWall.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
        //    }
        //}
        //else //player is away
        //{
        //    if (movingWall.transform.position.z > maximumClosing) //if wall open
        //    {
        //        movingWall.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
        //    }
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //wenn Spieler weg geht
        {
            playerIsHere = false;
        }
    }
}
