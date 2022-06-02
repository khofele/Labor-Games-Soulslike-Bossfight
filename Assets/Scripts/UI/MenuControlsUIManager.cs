using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControlsUIManager : MonoBehaviour
{
    [SerializeField] private Button btnGoBack = null;

    private void Start()
    {
        btnGoBack.onClick.AddListener(GoBack);
    }

    private void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
