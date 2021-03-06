using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivate : MonoBehaviour {

    [Header("Enemies")]
    [Tooltip("The enemies inside this room")]
    public List<GameObject> myEnemies = new List<GameObject>();

    [Header("Tags")]
    [Tooltip("Player tag")]
    public string playerTag = "Player";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //if other is the player
        if (other.gameObject.CompareTag(playerTag))
        {
            //for all enemies
            for (int i = 0; i < myEnemies.Count; i++)
            {
                //activate all enemies enemystate script
                myEnemies[i].GetComponent<EnemyState>().SetIsActive(true);
            }
        }
    }
}
