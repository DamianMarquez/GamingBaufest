using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

namespace RPG.Movement
{
    public class Mover : NetworkBehaviour
    {

        [SerializeField] Transform target;

        Ray lastRay;

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
                UpdateAnimator();

        }
        public NavMeshAgent navMesh;
        public Animator animator;
        public NetworkAnimator networkAnimator;
        public void MoveTo(Vector3 destination)
        {
            navMesh.destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMesh.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }
        [ClientRpc]
        public void Damaged()
        {
            if (isLocalPlayer)
                networkAnimator.SetTrigger("damaged");
        }
        public void Die()
        {
            if (isLocalPlayer)
                networkAnimator.SetTrigger("die");
        }
        public void Attack()
        {
            if (isLocalPlayer)
                networkAnimator.SetTrigger("attack");
        }
    }

}
