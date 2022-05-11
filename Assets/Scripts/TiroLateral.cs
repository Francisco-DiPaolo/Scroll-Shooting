using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLateral : PowerUp
{
    public override void effect()
    {
        base.effect();
        player.tipoPowerUp = "tiroLateral";
    }
}
