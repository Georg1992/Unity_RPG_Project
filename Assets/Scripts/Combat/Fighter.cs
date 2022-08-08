using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{

    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 2f;
        private Transform target;
        void Update()
        {
            if(target == null) return;
            
            if (!GetIsInRange())
            {

                GetComponent<Mover>().StartMoveAction(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("attacking");
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
