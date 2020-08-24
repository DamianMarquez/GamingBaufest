using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Controller{
    public class PlayerController : MonoBehaviour
    {


        //UPDATE DEL CONTROLLER - METODO LLAMADO SIEMPRE POR UNITY
        private void Update() {

            InteractWithCombat();
            InteractWithMovement();
        }


        //METODO PARA INTERACTUAR CON COMBATE
        private void InteractWithCombat(){
            
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target != null){

                    if(Input.GetMouseButtonDown(0)){
                        GetComponent<Fighter>().Attack(target);
                    }

                }
            }
        }

        //METODO PARA INTERACTUAR CON MOVIMIENTO
        private void InteractWithMovement(){
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
    }

}