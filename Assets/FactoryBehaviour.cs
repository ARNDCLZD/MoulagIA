using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour
{
    public GameObject entité;
    public int limiteEntité;
    public GameObject végétaux;
    public int limiteVégétaux;

    private float randxEntité, randzEntité, randxVégétaux, randzVégétaux;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3();

        for (int i = 0; i < limiteEntité; i++)
        {
            randxEntité = Random.value * 500;
            randzEntité = Random.value * 400;
            while(randxEntité>100 && randxEntité<400 && randzEntité > 50 && randzEntité < 350)
            {
                randxEntité = Random.value * 500;
                randzEntité = Random.value * 400;
            }
            pos = new Vector3(randxEntité, 0, randzEntité);
            Instantiate(entité, pos, transform.rotation);
            Debug.Log(entité.name + " créé.");
        }


        for (int i = 0; i < limiteVégétaux; i++)
        {
            randxVégétaux = Random.value * 300 + 100;
            randzVégétaux = Random.value * 300 + 50;
            pos = new Vector3(randxVégétaux,0,randzVégétaux);
            Instantiate(végétaux,pos,transform.rotation);
            Debug.Log(végétaux.name + " créé.");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
