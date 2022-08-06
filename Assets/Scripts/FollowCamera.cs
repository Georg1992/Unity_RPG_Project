using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    void Update()
    {
        this.transform.position = target.transform.position;
    }
}
