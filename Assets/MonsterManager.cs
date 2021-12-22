using System.Collections.Generic;
using TutorialAssets.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private int monstersAmount = 10;
    [SerializeField] private Transform monsterSpawnPoint;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform queuePoint;
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private float waveDifficulty;
    
    public List<GameObject> monstersList;

    private void Awake()
    {
        for (int i = 0; i < monstersAmount; i++) InstantiateMonster();

        MonsterAttacks(0);
        MoveNextMonsterToQueue();
        
        // Use ref for returning data from a large collection and avoid variable duplicates
        CalculateWaveDifficulty(ref waveDifficulty);
    }

    private void InstantiateMonster()
    {
        var monsterRandIndex = Random.Range(0, monsterPrefabs.Length);
        var monster = Instantiate(monsterPrefabs[monsterRandIndex], monsterSpawnPoint.position, monsterSpawnPoint.rotation);
        monstersList.Add(monster);
    }

    private void CalculateWaveDifficulty(ref float difficulty)
    {
        foreach (var monster in monstersList) 
            difficulty += monster.GetComponent<Points>().points;

        difficulty /= (monstersAmount * 3);
    }

    public void MonsterAttacks(int monsterIndex)
    {
        if (monstersList.Count <= monsterIndex) return;

        var monsterTransform = monstersList[monsterIndex].transform;
        monsterTransform.GetComponent<MonsterController>().ChangeState(MonsterController.MonsterState.Attack);
        monsterTransform.position = attackPoint.position;
        monsterTransform.rotation = attackPoint.rotation;
    }
    
    public void MoveMonsterToQueue(int monsterIndex)
    {
        if (monstersList.Count <= monsterIndex) return;

        var monsterTransform = monstersList[monsterIndex].transform;
        monsterTransform.GetComponent<MonsterController>().ChangeState(MonsterController.MonsterState.Queue);
        monsterTransform.position = queuePoint.position;
        monsterTransform.rotation = queuePoint.rotation;
    }

    public void MoveNextMonsterToQueue() => MoveMonsterToQueue(1);

    public void KillMonster(int monsterIndex)
    {
        // Destroy gameobject and remove it from the list
        Destroy(monstersList[monsterIndex]);
        monstersList.RemoveAt(monsterIndex);
    }
}
