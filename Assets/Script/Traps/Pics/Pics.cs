using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pics : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le pi�ge d�tecte le joueur");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Je recharge la scene et les �l�ments sont r�initialis�
        }
    }

}
