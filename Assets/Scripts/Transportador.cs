﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transportador : MonoBehaviour
{
    public int numeroEscena;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<movimiento>() != null)
        {
            SceneManager.LoadScene(numeroEscena);
        }
    }
    
}
