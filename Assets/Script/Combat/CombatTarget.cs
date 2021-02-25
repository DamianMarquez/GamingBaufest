using System;
using UnityEngine;
using Mirror;
using RPG.Movement;

namespace RPG.Combat{
    public class CombatTarget : NetworkBehaviour {

        private float vidaActual;
        public Armadura armaduraEquipada = new ArmaduraCuero();
        public float vidaMaxima = 100;
        public event Action<float> CambioPorcentajeVida = delegate { };
        [SerializeField] Mover mover;
        private void OnEnable()
        {
            vidaActual = vidaMaxima;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.AplicarDanio(10);
            }    
        }

        public void AplicarDanio(float danio){
            vidaActual = vidaActual - danio;
            float porcentajeVidaActual = vidaActual / vidaMaxima;
            CambioPorcentajeVida(porcentajeVidaActual);
             
            Debug.Log("Vida restante =" + vidaActual);
            mover.Damaged();
            ChequearMuerte();
        }

        private void ChequearMuerte(){
            if(vidaActual <= 0.0f){
                Debug.Log("Muerto");
                mover.Die();
            }
        }
    }

    //Mover a archivo aparte o hacer scriptable object.

    public class ArmaduraCuero : Armadura {
        public ArmaduraCuero(){
            evasion = 30.0f;
            defensaFisica = 2.0f;
        }
    }
}