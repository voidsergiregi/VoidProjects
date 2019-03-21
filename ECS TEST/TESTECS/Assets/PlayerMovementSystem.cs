using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

class PlayerMovementSystem : ComponentSystem
{
    public struct Filter
    {
        public Rigidbody rigidbody;
        public InputComponent2 InputComponent;
    }
    protected override void OnUpdate()
    {
        var deltaTime = Time.deltaTime;
        foreach (var item in GetEntities<Filter>())
        {
            var moveVector = new Vector3(item.InputComponent.Hori, 0, item.InputComponent.Vert);
            var movePos = item.rigidbody.position + moveVector * 3f * deltaTime;
            item.rigidbody.MovePosition(movePos);
        }
    }
}
