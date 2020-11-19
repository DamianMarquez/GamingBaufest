using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float updateSpeedSeconds = 0.5f;

    private void Awake()
    {
        GetComponentInParent<CombatTarget>().CambioPorcentajeVida += CambioDeVida;
    }

    private void CambioDeVida(float porcentaje)
    {
        StartCoroutine(CambiarAPorcentaje(porcentaje));
    }

    private IEnumerator CambiarAPorcentaje(float porcentaje)
    {
        float vidaAnterior = healthBarImage.fillAmount;
        float tiempoTranscurrido = 0f;

        while( tiempoTranscurrido < updateSpeedSeconds)
        {
            tiempoTranscurrido += Time.deltaTime;
            healthBarImage.fillAmount = Mathf.Lerp(vidaAnterior, porcentaje, tiempoTranscurrido / updateSpeedSeconds);
            yield return null;
        }

        healthBarImage.fillAmount = porcentaje;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }


}
