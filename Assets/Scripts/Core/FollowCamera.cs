using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        void LateUpdate()
        {
            this.transform.position = target.transform.position;
        }
    }
}
