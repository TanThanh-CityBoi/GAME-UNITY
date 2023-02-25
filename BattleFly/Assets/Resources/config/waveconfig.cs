using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Config", fileName ="Config")]
public class waveconfig : ScriptableObject
{
    public List<WaveConfigData> configs;
}

[System.Serializable]
public class WaveConfigData
{
    public int wave;//index wave
    public int count;//so luong eneymy tren wave
    public float timeDelay;// thoi gian chuyen qua wave moi
    public float timer; // thoi giua hai lan tao enemy
    public List<EnemyData> enemyDatas;
}

[System.Serializable]
public class EnemyData
{
    public int enemyId;
    public GameObject prefab;
}
