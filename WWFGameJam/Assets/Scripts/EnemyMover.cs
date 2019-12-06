﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private PlayerController player;
    [SerializeField]
    private float Speed = 4f;

    private float currentSpeed;

    private Vector3 target;

    public bool WalkForward = true;

    private Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = player.transform.position;
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Speed * Time.deltaTime;
        if(WalkForward == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startposition, currentSpeed);
        }
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, currentSpeed);
        
    }

}
