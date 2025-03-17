using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManagement : MonoBehaviour
{
    public List<GameObject> CoinList;
    public List<int> valeur;
    void Start()
    {
        for (int i = 0; i < CoinList.Count; i++) //Pour compter les pièces ramasser
        {

        }

        foreach (GameObject go in CoinList)
        {

        }
        GameObject.FindGameObjectsWithTag("Coin");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))  //Pour vérifié que l'objet est une pièce
        {
            CoinList.Add(other.gameObject);  //Ajoute la pièce à la liste et donc +1 pour i la valeur de la liste

            other.gameObject.SetActive(false); //Désactiver la pièce pour faire comme si elle a été rammassé

            if (CoinList.Count == 3)  //Quand on a rammasé toutes les pièces
            {
                LevelComplete();
            }
        }

        //if (other.CompareTag("Trap"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Je recharge la scene et les éléments sont réinitialisé
        //    Debug.Log("Ca marche pas beaucoup");
        //    foreach (GameObject go in CoinList) //En rechargant ce n'est plus nécessaire
        //    {
        //        go.SetActive(true);
        //        Debug.Log("C'est Reset");
        //        CoinList.Clear();
        //    }
        //}   Le rechargement de la scène se fait sur les pièges maintenant
    }

    private void LevelComplete()
    {
        Debug.Log("Niveau terminé !");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
