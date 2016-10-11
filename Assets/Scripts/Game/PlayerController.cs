﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public float fireRate;
    private SpriteRenderer sprites;
	private float nextFire;

    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
	{
        Move();
    }

	void Move ()
	{
        float moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
		float moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

        if (movement.x < 0.0f)
            sprites.flipX = false;
        else if (movement.x > 0.0f)
            sprites.flipX = true;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.zMin, boundary.zMax),
            0.0f); 
	}
}
