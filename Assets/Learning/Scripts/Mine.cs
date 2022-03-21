using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : AbstractAmmo
{
    override public void DestroyAmmo()
    {
        // TODO: need to make explosive effects for homework
        Destroy(gameObject);
    }
}
