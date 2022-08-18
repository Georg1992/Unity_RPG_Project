using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{

    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 3f;
        [SerializeField] private float weaponDamage = 5;
        [SerializeField] private float timeBetweenAttacks = 1f;
        private Transform target;
        float timeSinceLastAttack;
        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;


            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                DoAttack();
            }
        }

        private void DoAttack()
        {
            if (timeBetweenAttacks < timeSinceLastAttack)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;

            }
        }

        //Animation Event
        void Hit()
        {
            if (target != null)
            {
                Health health = target.GetComponent<Health>();
                health.TakeDamage(weaponDamage);
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("attacking");
        }

        public void Cancel()
        {
            target = null;
        }

    }
}
