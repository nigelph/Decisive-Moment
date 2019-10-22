using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class MonsterRespawnTest{

    [Test]
    public void MonsterRespawn_Test()
    {

        //ARRANGE
        RespawnLogic respawnLogic = new RespawnLogic();
        GameObject minotaurAlive;
        GameObject minotaurDead;
        GameObject minotaurTestAlive;
        GameObject minotaurTestDead;

        minotaurAlive = GameObject.Find("Minotaur (" + 1 + ")");
        minotaurDead = GameObject.Find("Minotaur (" + 2 + ")");
        minotaurTestAlive = GameObject.Find("Minotaur (" + 3 + ")");
        minotaurTestDead = GameObject.Find("Minotaur (" + 4 + ")");

        minotaurTestAlive.GetComponent<MinotaurPatrol>().dead = false;
        minotaurTestDead.GetComponent<MinotaurPatrol>().dead = true;
        
        //ACT
        respawnLogic.respawnMonster(minotaurDead);
        respawnLogic.killMonster(minotaurAlive);
        
        //ASSERT
        Assert.That(minotaurDead.GetComponent<MinotaurPatrol>().dead, Is.EqualTo(minotaurTestAlive.GetComponent<MinotaurPatrol>().dead));
        Assert.That(minotaurAlive.GetComponent<MinotaurPatrol>().dead, Is.EqualTo(minotaurTestDead.GetComponent<MinotaurPatrol>().dead));

    }
}
