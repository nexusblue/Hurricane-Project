using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

    public float lifeTime = 10f;
    public bool inWindZone = false;
    public GameObject windZone;

    Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inWindZone) {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    // Update is called once per frame
    void Update(){
        if (lifeTime > 0) {
            //lifeTime -= Time.deltaTime;
            if(lifeTime <= 0){
                Destruction();
            }

        }
    }

    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "destroyer") {
            Destruction(); 
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "windArea"){
            windZone = other.gameObject;
            inWindZone = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "windArea"){
            inWindZone = false;
        }
    }


    private void Destruction(){
        //Destroy(this.gameObject);
    }
}
