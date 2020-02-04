using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneTimer : MonoBehaviour
{
    private int contador = 75;
    
    void Update()
    {
        
        if(contador<2){
        SceneManager.LoadScene("Title");
        }else{
            contador--;
            }
        Debug.Log(contador);
    }
    
}