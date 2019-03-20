using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem  {


     struct Filter
    {
        public Rigidbody rigidbody;
        public InputComponent inputComponent;
    }
    protected override void OnUpdate()
    {
        var deltaTime = Time.deltaTime;
        foreach (var item in GetEntities<Filter>())
        {
            var moveVector = new Vector3(item.inputComponent.Hori, 0, item.inputComponent.Vert);
            var movePos = item.rigidbody.position + moveVector * 3f * deltaTime;
            item.rigidbody.MovePosition(movePos);

        }
    }
}
