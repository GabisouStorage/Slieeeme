using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoCircularVentilador : MonoBehaviour {

    Rigidbody2D RB2D;

   
    public float tempoPorVolta = 4;
    public float tempoDecorrido;
    float grausPorSegundo;

    

    private void Start()
    {
         RB2D = gameObject.GetComponent<Rigidbody2D>();
      
    }


    private void Update()
    {
        if (tempoDecorrido >= tempoPorVolta)
        {
            RB2D.transform.Rotate(0, 0, 90);
            tempoDecorrido = 0;
        }
        else
        {
            tempoDecorrido = tempoDecorrido + Time.deltaTime;
        }

        ventiladorController vc = gameObject.GetComponent<ventiladorController>();

        /*
        if (vc.contagemRodadas == 3) {
            vc.contagemRodadas = 0;
        }
       else
        {
            vc.contagemRodadas++;
        }
        */
    }
}
