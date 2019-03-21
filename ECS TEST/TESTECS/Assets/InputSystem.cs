using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
    private struct Data
    {
        public readonly int Length;
        public ComponentArray<InputComponent2> componentArray;
    }
    [Inject] readonly Data _data;
    protected override void OnUpdate()
    {
      var Vertical=  Input.GetAxis("Vertical");
        var Horizontal= Input.GetAxis("Horizontal");
        for (int i = 0; i < _data.Length; i++)
        {
            _data.componentArray[i].Vert = Vertical;
            _data.componentArray[i].Hori = Horizontal;
        }
       
    }

    
}
