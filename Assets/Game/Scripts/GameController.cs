using System.Collections;
using Game.Scripts.Characters;
using UnityEngine;

// Show menu
// Player selects "Start Game"
// Show game intro
/* Game loop start */
// Load level 1
// Show level 1 intro

/* Level loop start */
// Character 1 Turn
// Character 2 Turn
// ...
// Character N Turn
/* Level loop finish */

// Load level 2
// ...

/* Game loop finish */

// Show game over (success or fail)
public class GameController : MonoBehaviour
{
    public Policeman Player;
    public Gangster Enemy;

    private void Start()
    {
        Enemy.startPoint = Enemy.transform.position.z;
        StartCoroutine(LevelLoop());
    }

    private bool _isAllAlive()
    {
        return Player.health > 0 && Enemy.health > 0;
    }

    private IEnumerator PlayerTurn(Character aim)
    {
        if (_isAllAlive())
        {
            yield return Player.Attack(aim);
        }

        yield return new WaitForSeconds(1f);
    }
    
    private IEnumerator EnemyTurn(Character aim)
    {
        if (_isAllAlive())
        {
            yield return Enemy.Attack(aim);
        }

        yield return new WaitForSeconds(1f);
    }
    
    private IEnumerator GameOver(bool isNotAlive)
    {
        if (isNotAlive)
        {
            yield break;
        }
    }

    private IEnumerator LevelLoop()
    {
        foreach (var element in EndlessList())
        {
            yield return PlayerTurn(Enemy);
            yield return EnemyTurn(Player);
            yield return GameOver(_isAllAlive());
        }
    }
    
    private IEnumerable EndlessList()
    {
        var i = 0;
        while (true)
        {
            i += 1;
            yield return i;
        }
    }
}