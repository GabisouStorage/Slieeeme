using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

    //métodos para checar se a layer de um objeto pertence a uma layermask
    public static bool CheckLayerMask(LayerMask mask, GameObject gameObject)
    {
        return (mask.value & 1 << gameObject.layer) == 1 << gameObject.layer;
    }

    public static bool CheckLayerMask(LayerMask mask, Collider2D coll)
    {
        return (mask.value & 1 << coll.gameObject.layer) == 1 << coll.gameObject.layer;
    }
}
