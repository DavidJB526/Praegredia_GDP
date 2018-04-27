using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprintAbility : MonoBehaviour {

	// Use this for initialization
	void OnEnable ()
    {
        Player.playerSpeed *= 1.5f;
    }
	

}
