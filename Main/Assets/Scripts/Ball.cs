using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

    //public float lifeTime = 10f;
    public bool inWindZone = false;
    public GameObject windZone;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        if (inWindZone) {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    void Update(){
   
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
        if (other.gameObject.tag == "DestroyBall"){
            Destruction();
            //SpawnNewObject();
        }
    }

    private void Destruction(){
        Destroy(this.gameObject);
    }
    private void SpawnNewObject(){
        //GameObject car = 
        Instantiate(Resources.Load("SportCar"), spawnPosition, spawnRotation);
    }


    //Used code that might come back into play
    /*
    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "destroyer") {
            Destruction();
            SpawnNewObject();
        }s
    }

    private void OnCollisionExit(Collision other){
    if (other.gameObject.tag == "windArea"){
        inWindZone = false;
    }
    if (other.gameObject.tag == "DestroyBall"){
        Destruction();
        SpawnNewObject();
    }
    }
    //Inside update function  
    if (lifeTime > 0) {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destruction();
        }
    }*/


}
