using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Kill Quest", menuName = "Quests/Kill Quest")]
public class QuestKill : Quest
{   
    [System.Serializable]
    public class Objectives
    {
        public EnemyProfile requiredEnemy;
        public int requiredAmount;
    }

    public Objectives[] objectives;

    public override void InitializeQuest()
    {

        RequiredAmount = new int[objectives.Length];

        for(int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }

        GameManagerScripts.instance.onEnemyDeathCallBack += EnemyDeath;
        base.InitializeQuest();
    }

    private void EnemyDeath(EnemyProfile slainEnemy)
    {
        for(int i = 0; i < objectives.Length; i++)
        {
            if(slainEnemy == objectives[i].requiredEnemy)
            {
                CrurrentAmount[i]++;
                GameManagerScripts.instance.UpdateTracker($"bạn đã giết {CrurrentAmount[i] + "/" + RequiredAmount[i] + " " + slainEnemy.enemyName}");
            }
           
        }

        Evaluate();

    }

    public override string GetObjectiveList()
    {
        string tempObjectiveList = "";
        for(int i = 0; i < objectives.Length; i++)
        {
            tempObjectiveList += $"bạn đã giết {CrurrentAmount[i] + "/" + RequiredAmount[i]} {objectives[i].requiredEnemy.enemyName} \n";
        }

        return tempObjectiveList;
    }
}
