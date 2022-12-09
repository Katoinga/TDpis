using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeHA : MonoBehaviour
{
    public GameObject h1, h2, h3;
    public GameObject b1, b2, b3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void cambio1()
    {

        // make this off
        Debug.Log("hola");
        h1.SetActive(false);
        h2.SetActive(true);
        b1.SetActive(false);
        b2.SetActive(true);

    }
    public void cambio2()
    {

        // make this off
        h2.SetActive(false);
        h3.SetActive(true);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(true);

    }
    public void cambio3()
    {

        // make this off
       
        SceneManager.LoadScene("NIVEL1");

    }
    public void cambio4()
    {

        // make this off

        SceneManager.LoadScene("Historia");

    }
    public void test()
    {
        Debug.Log("hola");

    }

    public void RAscene()
    {
        SceneManager.LoadScene("AR-EXTRA");
    }
}
