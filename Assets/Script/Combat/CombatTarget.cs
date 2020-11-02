using UnityEngine;

namespace RPG.Combat{
    public class CombatTarget : MonoBehaviour {

        private float vida = 100;
        public Armadura armaduraEquipada = new ArmaduraCuero();

        public void AplicarDanio(float danio){
            vida = vida-danio;

            Debug.Log("Vida restante =" + vida);
            
            ChequearMuerte();
        }

        private void ChequearMuerte(){
            if(vida <= 0.0f){
                Debug.Log("Muerto");
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