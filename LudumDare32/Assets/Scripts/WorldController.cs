﻿using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

	public Transform checkpointContainer; // note: for code to work, it assumes all checkpoints are children in this object
	public static int totalCheckpoints = 0;
	public static string winner = null;
	public static string winCondition = "";

	void Awake () {
		GetTotalCheckpointCount ();
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start(){		
		InvokeRepeating ("spawnSuperFruit", 16, 10.0f);
	}
	
	void GetTotalCheckpointCount(){		
		foreach (Transform child in checkpointContainer) {
			totalCheckpoints++;
		}
	}

	public static void CheckCheckpointWinCondition(string playerTag){	
		int playerCaptureCount = 0;

		//get count of player's captured Checkpoints
		playerCaptureCount = GameObject.FindGameObjectsWithTag ("Checkpoint_" + playerTag).Length;
				
		//Did player win?
		if(playerCaptureCount >= totalCheckpoints){	
			EndGame(playerTag, "Checkpoint Win Condition");
		}
		Debug.Log (playerTag + " Captured: "+playerCaptureCount + " of "+totalCheckpoints);
	}

	public static void EndGame(string myWinner, string myWinCondition){	
		winner = myWinner;
		winCondition = myWinCondition;
		Application.LoadLevel("endscreen");
	}

}
