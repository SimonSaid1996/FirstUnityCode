using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;  //observer class to detect player' character
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;   //to detect if the player is nearby

    void OnTriggerEnter(Collider other){        //to detect if the player is in range
        if(other.transform == player){
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other){       //to record player leaving the range
        if(other.transform == player){
            m_IsPlayerInRange = false;
        }
    }

    void Update(){          //to check if there is a wall in between
        if( m_IsPlayerInRange){         //check a line starting from a point, called Ray
            Vector3 direction = player.position - transform.position +Vector3.up;
            Ray ray = new Ray(transform.position, direction);       //initialize a ray of beam to check if a wall in middle
            RaycastHit raycastHit;
            if( Physics.Raycast(ray, out raycastHit) ){     //uses the out parameter to return information
                if(raycastHit.collider.transform ==player ){       //to check what has been hit, hit player here
                    gameEnding.CaughtPlayer();
                }
            }
        
        }
    }

}
