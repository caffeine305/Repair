using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    void Update()
    {
        if(Input.GetButtonDown("Jump")){
        SceneManager.LoadScene("1-Head");
        }
    }
    
}