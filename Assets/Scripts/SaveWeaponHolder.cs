using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWeaponHolder : MonoBehaviour
{
    private static SaveWeaponHolder instance = null;

    // keep gameobject with weapon references
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
