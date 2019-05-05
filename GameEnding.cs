using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //to recode the fadeout time
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroupImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;        //the show if player has been caught
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;              //indicator for player exiting the game
    float m_Timer;                      //timeer to check if the game fade ends before finish
    bool m_isPlayerCaught;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other){        //make sure that the ending only triggererd when hit the box
        if( other.gameObject == player){
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer(){
        m_isPlayerCaught = true;
    }

    void Update(){
        if( m_IsPlayerAtExit){          //check whether the indicator has been updated
            EndLevel( exitBackgroupImageCanvasGroup, false, exitAudio );
        }
        else if( m_isPlayerCaught){
            EndLevel( caughtBackgroundImageCanvasGroup, true, caughtAudio );  //not sure why is it end level here, the original is ending level, i guess another canvass output?
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource){        // do restart will auto restart the game in theory
        if(!m_HasAudioPlayed){
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer+= Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;        //feel like this part has issues
        if( m_Timer > fadeDuration+ displayImageDuration){
            if( doRestart)
                SceneManager.LoadScene(0);
            else 
                Application.Quit();
        }
    } 




}
