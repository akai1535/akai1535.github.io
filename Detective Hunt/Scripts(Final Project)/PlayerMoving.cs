﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {

//Variables 
public float movementSpeed;
public GameObject Camera;

public GameObject playerObj;
public GameObject bulletSpawnPoint;
public float waitTime;
public GameObject bullet;

private Transform bulletSpawed;

public float points;

public float maxHealth;
public float health = 0;



//methods

void Start()
{
	health = maxHealth;
}

void Update()
{
	//Player facing mouse
	Plane playerPlane = new Plane(Vector3.up, transform.position);
	Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
	float hitDist = 0.0f;

	if(playerPlane.Raycast(ray, out hitDist)){
		
		Vector3 targetPoint = ray.GetPoint(hitDist);
		Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
		targetRotation.x = 0;
		targetRotation.z = 0;
		playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation,7f * Time.deltaTime);
	}
	//Player Movement
	if(Input.GetKey(KeyCode.W))
	transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

	if(Input.GetKey(KeyCode.A))
	transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

	if(Input.GetKey(KeyCode.S))
	transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

	if(Input.GetKey(KeyCode.D))
	transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);


	//shooting
	if(Input.GetMouseButtonDown(0)){

		Shoot();
	}

	//player health
	if (health <=0)
		Die();
	
}

void Shoot()
{
bulletSpawed  = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
bulletSpawed.rotation = bulletSpawnPoint.transform.rotation;
}

public void Die(){

}

}
