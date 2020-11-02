using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using Mirror;

namespace RPG.Controller
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] Cinemachine.CinemachineVirtualCamera CinemaCamera;
        void Start()
        {
            if (isLocalPlayer)
            {
                asignarCamera();
                FindObjectOfType<RPG.Core.FollowCamera>().target = transform;
            }
        }

        //UPDATE DEL CONTROLLER - METODO LLAMADO SIEMPRE POR UNITY

        private void Update()
        {

            // movement for local player
            if (!isLocalPlayer)
                return;

            InteractWithCombat();
            InteractWithMovement();
        }


        //METODO PARA INTERACTUAR CON COMBATE
        private void InteractWithCombat()
        {

            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                //Cambiar CombatTarget a Enemy? Objetos destruibles?
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<Fighter>().Attack(target);
                    }

                }
            }
        }

        //METODO PARA INTERACTUAR CON MOVIMIENTO

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        private void asignarCamera()
        {
            GameObject ObjectCamera = GameObject.FindWithTag("cinemaMachine");
            CinemaCamera = ObjectCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>();
            CinemaCamera.m_LookAt = this.transform;
            CinemaCamera.m_Follow = this.transform;
        }
    }

}