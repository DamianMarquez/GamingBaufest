using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlerScript : MonoBehaviour
{
    [SerializeField] Canvas joinGame;
    [SerializeField] Canvas HostGame;
    [SerializeField] string Scena;
    void Start()
    {
        joinGame.enabled = false;
    }
    
    public void IniciarPartida(){
        SceneManager.LoadScene( Scena, LoadSceneMode.Additive);
    }

    public void enableJoin(){
        joinGame.enabled = true;
        HostGame.enabled = false;
    }
    public void disableJoin(){
        joinGame.enabled = false;
        HostGame.enabled = true;
    }
    // Update is called once per frame

}
