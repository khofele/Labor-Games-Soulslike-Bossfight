using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWeaponHolder : MonoBehaviour
{
    private static SaveWeaponHolder instance = null;

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
