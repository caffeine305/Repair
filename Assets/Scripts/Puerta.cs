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
    public void cambiarStatus(bool tieneEnergia)
    {
        // this.gameObject.SetActive(!visible);
        if(tieneEnergia)
        {
            AudioSource sonido = this.gameObject.GetComponent<AudioSource>();
            sonido.Play(0);
            Destroy(this.gameObject);
        }
    }
}
