using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchufeEntrada : MonoBehaviour
{
    public bool tieneEnergia = false;
    GameObject cableConectado = null;
    public GameObject puerta;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // si hay un cable, siempre verificar si ese cable trae energia
        if(cableConectado != null && this.cableConectado.GetComponent<Renderer>().material.color == this.GetComponentInParent<Renderer>().material.color)
        {
            tieneEnergia = this.cableConectado.GetComponent<CableEnd>().recibeEnergia;   
        } else
        {
            tieneEnergia = false;
        }
        if(cableConectado!=null)
        {
            this.cableConectado.transform.position = this.gameObject.transform.position;
        }

        // si hay una puerta a la que este componente pueda acceder, entonces activala
        if (this.puerta != null && this.tieneEnergia)
        {
            Debug.Log(this.puerta);
            Debug.Log(this.tieneEnergia);
            this.puerta.GetComponent<Puerta>().cambiarStatus(this.tieneEnergia);
            if (this.tieneEnergia) this.puerta = null;
        }

    }
    
    private void OnTriggerEnter(Collider collision)
    {
        // detecta un fin de cable y, si existe, entonces lo conecta al enchufe
        if (collision.gameObject.GetComponent<CableEnd>() != null)
        {

            GameObject finCable = collision.gameObject.GetComponent<CableEnd>().gameObject;
            Debug.Log("Se detectó un final de cable");
            // obliga al inicio del cable a conectarse con el enchufe
            Vector3 posicionEnchufe = this.transform.position;
            finCable.transform.position = posicionEnchufe;
            // validar si el finCable tiene un material diferente al default y si tiene energia
            finCable.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.gameObject.GetComponent<CableEnd>().estaConectado = true;
            if (finCable.GetComponent<Renderer>().material.color == this.GetComponentInParent<Renderer>().material.color)
            {
                this.tieneEnergia = collision.gameObject.GetComponent<CableEnd>().recibeEnergia;

                this.cableConectado = collision.gameObject.GetComponent<CableEnd>().gameObject;
            }
            AudioSource sonido = this.gameObject.GetComponent<AudioSource>();
            sonido.Play(0);

        }
    }
    
    
    private void OnTriggerExit(Collider collision)
    {
        // detecta un fin de cable y, si existe, entonces lo conecta al enchufe
        if (collision.gameObject.GetComponent<CableEnd>() != null)
        {
            GameObject finCable = collision.gameObject.GetComponent<CableEnd>().gameObject;
            finCable.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Se detectó la salida de un final de cable");
            // validar si el finCable tiene un material diferente al default
            this.tieneEnergia = false;
            if (this.cableConectado != null)
            {
                this.cableConectado = null;
            }

        }
    }

}
