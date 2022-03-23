using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : AbstractAmmo
{
    protected override void DestroyAmmo()
    {
        // TODO: need to make explosive effects for homework
        Destroy(gameObject);
    }
}
