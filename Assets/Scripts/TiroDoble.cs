using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDoble : PowerUp
{
    public override void effect()
    {
        base.effect();
        StartCoroutine(PowerUpDuration(duration));
        player.fireRate = 5;
    }

    public override IEnumerator PowerUpDuration(float time)
    {
        float temp = player.fireRate;
        yield return new WaitForSeconds(time);
        player.fireRate = temp;
        Destroy(gameObject);
    }
}
