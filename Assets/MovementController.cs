using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 0.1f;
    public float hp = 100;
    private float points = 0;
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
        }
        else {
            points += 1 * Time.deltaTime;
            hp -= 1 * Time.deltaTime;
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float angle = Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(direction * speed * (1 + Time.deltaTime));
            }
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vegetal")
        {
            Debug.Log(other.gameObject.name + " m'a mangé.");
            hp += 20;
            other.gameObject.SetActive(false);
        }

    }
}
