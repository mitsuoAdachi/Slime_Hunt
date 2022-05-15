using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(Random.Range(1, 3));
    }
}
