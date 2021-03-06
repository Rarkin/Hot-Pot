using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //public int Level = 4; //public for testing
    public GameObject[] Enemy;
    public Transform[] EnemySpawnPoints;

    [Header("Tags")]
    [Tooltip("Dungeon tag")]
    public string dungeonTag = "Dungeon";

    //script refs
    private DungeonManager manager;
    private RoomActivate roomAct;

	// Use this for initialization
	void Start () {
        roomAct = GetComponentInParent<RoomActivate>();
        manager = GameObject.FindGameObjectWithTag(dungeonTag).GetComponent<DungeonManager>();
        if(manager == null)
        {

        }
        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void SpawnEnemies()
    {
        ////int EnemyIndex = Random.Range(0, Enemy.Length);
   
        ////spawn enemies equal to level
        //for (int i = 0; i < manager.currentFloor; i++)
        //{
        //    //spawn an enemy
        //    GameObject enemyClone = Instantiate(Enemy[Random.Range(0, Enemy.Length)], EnemySpawnPoints[i].position, Quaternion.identity);
        //    //Name the enemy
        //    enemyClone.name = "Enemy" + i.ToString();
        //    //scale enemy values by level
        //    //TODO: Refractor
        //    if (enemyClone.GetComponent<AdjustableCircularSpray>())
        //    {
        //        enemyClone.GetComponent<AdjustableCircularSpray>().ScaleShotVars(manager.currentFloor);
        //    }
        //    else if (enemyClone.GetComponent<AllRoundSpray>())
        //    {
        //        enemyClone.GetComponent<AllRoundSpray>().ScaleShotVars(manager.currentFloor);
        //    }
        //    else if (enemyClone.GetComponent<WallSpray>())
        //    {
        //        enemyClone.GetComponent<WallSpray>().ScaleShotVars(manager.currentFloor);
        //    }
        //    else if (enemyClone.GetComponent<Demarcation>())
        //    {
        //        enemyClone.GetComponent<Demarcation>().ScaleShotVars(manager.currentFloor);
        //    }
        //    else if (enemyClone.GetComponent<NightBird>())
        //    {
        //        //enemyClone.GetComponent<NightBird>().ScaleShotVars(manager.currentFloor);
        //    }
        //    else if (enemyClone.GetComponent<AimedProngedShot>()){
        //        enemyClone.GetComponent<AimedProngedShot>().ScaleShotVars(manager.currentFloor);
        //    }
        //    //place new enemy into roomactivate enemy array
        //    roomAct.myEnemies.Add(enemyClone);
        //}
    }
}
