﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;

    
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            MoveToCursor();
        }
        
    }

    private void MoveToCursor(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit){
            this.GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
