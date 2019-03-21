using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerRotationSystem : ComponentSystem
{
    public struct Filter
    {
        public Transform transform;
        public RotationComponent rotationComponent;
    }
    protected override void OnUpdate()
    {
        var mousePos = Input.mousePosition;
        var camRay = Camera.main.ScreenPointToRay(mousePos);
        
    }

   
}
