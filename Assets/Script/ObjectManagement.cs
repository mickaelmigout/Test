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
        for (int i = 0; i < CoinList.Count; i++) //Pour compter les pi�ces ramasser
        {

        }

        foreach (GameObject go in CoinList)
        {

        }
        GameObject.FindGameObjectsWithTag("Coin");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))  //Pour v�rifi� que l'objet est une pi�ce
        {
            CoinList.Add(other.gameObject);  //Ajoute la pi�ce � la liste et donc +1 pour i la valeur de la liste

            other.gameObject.SetActive(false); //D�sactiver la pi�ce pour faire comme si elle a �t� rammass�

            if (CoinList.Count == 3)  //Quand on a rammas� toutes les pi�ces
            {
                LevelComplete();
            }
        }

        //if (other.CompareTag("Trap"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Je recharge la scene et les �l�ments sont r�initialis�
        //    Debug.Log("Ca marche pas beaucoup");
        //    foreach (GameObject go in CoinList) //En rechargant ce n'est plus n�cessaire
        //    {
        //        go.SetActive(true);
        //        Debug.Log("C'est Reset");
        //        CoinList.Clear();
        //    }
        //}   Le rechargement de la sc�ne se fait sur les pi�ges maintenant
    }

    private void LevelComplete()
    {
        Debug.Log("Niveau termin� !");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
