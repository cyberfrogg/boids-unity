using UnityEngine;

namespace Services.Input.Impl
{
    public class InputService : IInputService
    {
        public Vector2 PointerPosition => UnityEngine.Input.mousePosition;

        public float GetAxis(EInputAxisName axis)
        {
            return UnityEngine.Input.GetAxis(axis.ToString());
        }

        public bool IsButtonDown(EInputActionName action)
        {
            return UnityEngine.Input.GetButtonDown(action.ToString());
        }

        public bool IsButton(EInputActionName action)
        {
            return UnityEngine.Input.GetButton(action.ToString());
        }

        public bool IsButtonUp(EInputActionName action)
        {
            return UnityEngine.Input.GetButtonUp(action.ToString());
        }
    }
}