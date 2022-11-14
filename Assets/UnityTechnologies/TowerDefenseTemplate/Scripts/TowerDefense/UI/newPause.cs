using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class newPause : MonoBehaviour
{

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPauseMenu2()
    {
        menu.SetActive(true);
    }
    public void ClosePauseMenu2()
    {
        menu.SetActive(false);
    }
    public void cambiarScena()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}