using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchufeSalida : MonoBehaviour
{
    public bool tieneEnergia = true;
    GameObject cableConectado = null;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(this.cableConectado != null)
        {
            // le mete o quita energia al cable
            this.cableConectado.GetComponent<CableComponent>().tieneEnergia = this.tieneEnergia;
            if (tieneEnergia)
            {   
                // colorea el inicio, el cable, y el fin.
                this.cableConectado.GetComponent<Renderer>().material = gameObject.GetComponentInParent<Renderer>().material;
                this.cableConectado.GetComponent<CableComponent>().cableMaterial = gameObject.GetComponentInParent<Renderer>().material;
                this.cableConectado.GetComponent<CableComponent>().line.material = gameObject.GetComponentInParent<Renderer>().material;

            }
            else
            {
                // colorea el inicio, el cable, y el fin.
                this.cableConectado.GetComponent<Renderer>().material = this.cableConectado.GetComponent<CableComponent>().defaultCableMaterial;
                this.cableConectado.GetComponent<CableComponent>().cableMaterial = this.cableConectado.GetComponent<CableComponent>().defaultCableMaterial;
                this.cableConectado.GetComponent<CableComponent>().line.material = this.cableConectado.GetComponent<CableComponent>().defaultCableMaterial;

            }

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // detecta un inicio de cable y, si existe, entonces lo conecta al enchufe
        if(collision.gameObject.GetComponent<CableStart>() != null)
        {
            GameObject inicioCable = collision.gameObject.GetComponent<CableStart>().gameObject;
            Debug.Log("Se detectó un cable de entrada");
            // obliga al inicio del cable a conectarse con el enchufe
            Vector3 posicionEnchufe = this.gameObject.transform.position;
            inicioCable.transform.position = posicionEnchufe;
            if (tieneEnergia)
            {
                // le mete energia al cable
                inicioCable.GetComponent<CableComponent>().tieneEnergia = this.tieneEnergia;
                // colorea el inicio, el cable, y el fin.
                inicioCable.GetComponent<Renderer>().material = gameObject.GetComponentInParent<Renderer>().material;
                inicioCable.GetComponent<CableComponent>().cableMaterial = gameObject.GetComponentInParent<Renderer>().material;
                inicioCable.GetComponent<CableComponent>().line.material = gameObject.GetComponentInParent<Renderer>().material;
                
                GameObject finCable = inicioCable.GetComponent<CableComponent>().endPoint.gameObject;
                finCable.GetComponent<Renderer>().material = gameObject.GetComponentInParent<Renderer>().material;
                this.cableConectado = collision.gameObject.GetComponent<CableStart>().gameObject;

            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // al salir el cable, dejarlo tal cual como estaba.
        // detecta un inicio de cable y, si existe, entonces lo conecta al enchufe
        if (collision.gameObject.GetComponent<CableStart>() != null)
        {
            GameObject inicioCable = collision.gameObject.GetComponent<CableStart>().gameObject;
            Debug.Log("Se detectó la salida de un cable de entrada");
            // le quita la energia al cable 
            inicioCable.GetComponent<CableComponent>().tieneEnergia = false;
            // colorea el inicio, el cable, y el fin
            inicioCable.GetComponent<Renderer>().material = inicioCable.GetComponent<CableComponent>().defaultCableMaterial;
            inicioCable.GetComponent<CableComponent>().cableMaterial = inicioCable.GetComponent<CableComponent>().defaultCableMaterial;
            inicioCable.GetComponent<CableComponent>().line.material = inicioCable.GetComponent<CableComponent>().defaultCableMaterial;
            GameObject finCable = inicioCable.GetComponent<CableComponent>().endPoint.gameObject;
            finCable.GetComponent<Renderer>().material = inicioCable.GetComponent<CableComponent>().defaultCableMaterial;
            this.cableConectado = null;
        }
    }
}
