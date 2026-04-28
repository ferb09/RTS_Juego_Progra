using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
[SerializeField] private LayerMask mouseFloorLayerMask;
   
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public static Vector3 GetPosition()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        Physics.Raycast
         (ray, // configuracion del rayo de inicio,
         out RaycastHit hit, // info de impacto
          float.MaxValue, // distancia del rayo
           instance.mouseFloorLayerMask ); //capas a interactuar

          return hit.point;
    }
}
