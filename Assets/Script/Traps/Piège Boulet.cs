using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PiègeBoulet : MonoBehaviour
{
    public GameObject TrapPlate; //Pour désigner la plaque dans le plafond qui va retenir les boules

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)  //Pour détecter les objects qui le traverse
    {
        if (other.CompareTag("Player"))  //Pour se déclencher spécifiquement quand la caméra avec le tag "Player" entre en collision
        {
            TrapPlate.SetActive(false);  //On désactive la plaque pour laisser tomber les boules
        }
    }
}
