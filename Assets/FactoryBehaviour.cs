using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour
{
    public GameObject entit�;
    public int limiteEntit�;
    public GameObject v�g�taux;
    public int limiteV�g�taux;

    private float randxEntit�, randzEntit�, randxV�g�taux, randzV�g�taux;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();

        for (int i = 0; i < limiteEntit�; i++)
        {
            randxEntit� = Random.value * 500;
            randzEntit� = Random.value * 400;
            while(randxEntit�>100 && randxEntit�<400 && randzEntit� > 50 && randzEntit� < 350)
            {
                randxEntit� = Random.value * 500;
                randzEntit� = Random.value * 400;
            }
            pos = new Vector3(randxEntit�, 0, randzEntit�);
            Instantiate(entit�, pos, transform.rotation);
            Debug.Log(entit�.name + " cr��.");
        }


        for (int i = 0; i < limiteV�g�taux; i++)
        {
            randxV�g�taux = Random.value * 300 + 100;
            randzV�g�taux = Random.value * 300 + 50;
            pos = new Vector3(randxV�g�taux,0,randzV�g�taux);
            Instantiate(v�g�taux,pos,transform.rotation);
            Debug.Log(v�g�taux.name + " cr��.");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
