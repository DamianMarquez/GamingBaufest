using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : NetworkBehaviour
    {
        public Arma armaEquipada = new Espada();    
        [SerializeField] Mover mover;

        public void Attack(CombatTarget target){
            print ("Atacando");
            
            if(ObjetivoEnRango(target)){
                if(AtaquePega(target)){
                    var danio = CalcularDanio(target);
                    mover.Attack();
                    target.AplicarDanio(danio);
                }
            }
            else
            {
                Debug.Log("Fuera de rango");
            }
            //Si dentro de rango y paso el cooldown de velocidad, 
            //intentar atacar

            

            //Calcular posibilidad de ataque player vs evasion target

            //Si pega, calcular daño (azar?) player vs reduccion target
            //Restar daño a target
        }

        private bool ObjetivoEnRango(CombatTarget target){
            var distance = Vector3.Distance(target.transform.position, this.transform.position);

            Debug.Log("Distancia:" + distance);
            Debug.Log("Rango arma:" + armaEquipada.rango);

            if(distance <= armaEquipada.rango){
                Debug.Log("En Rango");
                return true;
            }
            else{
                return false;
            }
        }

        public bool AtaquePega(CombatTarget target){
            var tiradaDado = Random.Range(1.0f, 100.0f);

            if (tiradaDado <= armaEquipada.posibilidadAtaque - target.armaduraEquipada.evasion){
                return true;
            }

            Debug.Log("Fallo");
            return false;
        }

        public float CalcularDanio(CombatTarget target){
           var danio = Random.Range(armaEquipada.danioMinimo, armaEquipada.danioMaximo);

           var danioTotal = danio - target.armaduraEquipada.defensaFisica;

            if (danioTotal < 0){
                danioTotal = 0;
            }

            Debug.Log("Danio = " + danioTotal);

            return danioTotal;
        }

    }

    //Mover a archivo aparte, o hacer scriptable object.
    public class Espada : Arma
    {
        public Espada(){
            posibilidadAtaque = 75.0f;
            velocidadAtaque = 3.0f;
            rango = 2.0f;
            danioMaximo = 5.0f;
            danioMinimo = 1.0f;
        }
    }
}