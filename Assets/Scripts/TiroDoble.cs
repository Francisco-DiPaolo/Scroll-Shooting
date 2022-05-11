using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroDoble : PowerUp
{
    public override void effect()
    {
        base.effect();
        player.tipoPowerUp = "tiroDoble";
    }
}
