using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DungeonGenerator))]
public class DungeonGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //DungeonGenerator Generator = (DungeonGenerator)target;


        //if (GUILayout.Button("Generate Dungeon"))
        //{
        //    Generator.GenerateRooms();
        //    for(int i = 0; i < 10; ++i)
        //    {
        //        Generator.CheckRoomCollisions();
        //    }
        //    Generator.GenerateCorridors();
        //}
    }

}
