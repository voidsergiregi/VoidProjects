using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed=5f;
}
class RotatorSystem : ComponentSystem
{
   public struct Components {
        public Rotator rotator;
        public Transform transform;
        }

    protected override void OnUpdate()
        
    {
        float deltatime = Time.deltaTime;
        foreach ( var e in GetEntities<Components>())
        {
            e.transform.Rotate(0f, e.rotator.speed*Mathf.PingPong(-1,1)*deltatime, 0f);
        }
    }
}
