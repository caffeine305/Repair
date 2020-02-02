using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool abierta = false;
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void cambiarStatus(bool visible)
    {
        // this.gameObject.SetActive(!visible);
        if(!visible)
        {
            AudioSource sonido = this.gameObject.GetComponent<AudioSource>();
            sonido.Play(0);
            Destroy(this.gameObject);
        }
    }
}
