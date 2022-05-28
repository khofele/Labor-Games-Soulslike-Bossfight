using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] private LayerMask layerMaskPlayer;
    private bool collision = false;

    public bool Collision { get => collision; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == layerMaskPlayer)
        {
            collision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layerMaskPlayer)
        {
            collision = false;
        }
    }
}
