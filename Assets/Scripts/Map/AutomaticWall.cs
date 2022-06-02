using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWall : MonoBehaviour
{
    [SerializeField] private GameObject movingWall; //the wall that shall be moved
    [SerializeField] private GameObject alphaWall; //alpha wall to prevent player walking into moving wall
    [SerializeField] private float maximumOpening = 5f; //Z, max opening position wall
    [SerializeField] private float maximumClosing = 0; //Z, position wall if closed
    [SerializeField] private float movementSpeed = 8f; //speed of wall movement
    bool playerIsHere = true; //player is in entrance area (is starting there)

    // Update is called once per frame
    private void Update()
    {
        if (!playerIsHere) //player is not in entrance anymore and in front of the moving wall
        {
            if (movingWall.transform.position.z > maximumClosing) //if wall open
            {
                movingWall.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }

            alphaWall.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //wenn Spieler weg geht
        {
            playerIsHere = false;
        }
    }
}
