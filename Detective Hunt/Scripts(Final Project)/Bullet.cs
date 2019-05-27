using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	public float maxDistance;

	private GameObject triggeringEnemy;
	public float damage;

	private GameObject player;

	void Start(){

		player = GameObject.FindWithTag("Player");
	}

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		maxDistance += 1 * Time.deltaTime;

		if(maxDistance >=5)
			Destroy(this.gameObject);
	}

	public void OnTriggerEnter(Collider other)
{

if(other.tag == "Enemy"){
 triggeringEnemy = other.gameObject;
 
 triggeringEnemy.GetComponent<Enemy>().health -= damage;
Destroy(this.gameObject);
}

if(other.tag == "Player"){

	player.GetComponent<PlayerMoving>().health -=20;
}
}

}
