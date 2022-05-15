using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        var targetMob = collider.transform.root.gameObject.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(Random.Range(1, 2));
    }
}
