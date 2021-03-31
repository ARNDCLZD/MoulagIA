using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject cible;
    public GameObject viande;
    private float speed = 0.5f;

    public float rotationSpeed = 720;

    public float hp = 100;
    private float points = 0;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Total des points : " + points);
            gameObject.SetActive(false);
            Instantiate(viande, gameObject.transform.position, gameObject.transform.rotation);
        }
        else {
            if (hp > 200) hp = 200;
            points += 1 * Time.deltaTime;
            hp -= 1 * Time.deltaTime;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            Debug.Log(direction.magnitude);

            if (direction.magnitude >= 0.1f)
            {
                anim.SetInteger("condition", 1);
                controller.Move(direction * speed * (1 + Time.deltaTime));
                //transform.forward = direction;
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * (1+Time.deltaTime));

            } else anim.SetInteger("condition", 0);
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vegetal")
        {
            Debug.Log(other.gameObject.name + " mangé.");
            hp += 20;
            Destroy(other.gameObject);
        }
        if (other.tag == "Viande")
        {
            Debug.Log(other.gameObject.name + " mangé.");
            hp += 100;
            Destroy(other.gameObject);
        }

    }
}
