using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dejarArrastre : MonoBehaviour
{
    public Movimiento mv;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("drag"))
        {
            
            mv.rb.isKinematic = false;
            mv.selectedObject = null;
            mv.movible = false;
        }

    }
}
