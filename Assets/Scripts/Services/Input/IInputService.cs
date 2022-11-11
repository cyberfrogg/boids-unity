using UnityEngine;

namespace Services.Input
{
    public interface IInputService : IService
    {
        Vector2 PointerPosition { get; }
        float GetAxis(EInputAxisName axis);
        bool IsButtonDown(EInputActionName action);
        bool IsButton(EInputActionName action);
        bool IsButtonUp(EInputActionName action);
    }
}