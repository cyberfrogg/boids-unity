using UnityEngine;

namespace Boids.MvpUtils
{
    public class AGameObjectPresenter : APresenter
    {
        private AGameObjectView _goView;
        
        protected void InitializeGameObjectModel()
        {
            var model = (AGameObjectModel)Model;
            _goView = (AGameObjectView)View;
            
            _goView.transform.position = model.Position.Value;
            model.Position.Changed += OnPositionChanged;
            
            _goView.transform.localPosition = model.LocalPosition.Value;
            model.LocalPosition.Changed += OnLocalPositionChanged;
            
            _goView.transform.rotation = model.Rotation.Value;
            model.Rotation.Changed += OnRotationChanged;
            
            _goView.transform.localRotation = model.LocalRotation.Value;
            model.LocalRotation.Changed += OnLocalRotationChanged;
            
            _goView.transform.localScale = model.LocalScale.Value;
            model.LocalScale.Changed += OnLocalScaleChanged;
            
            _goView.gameObject.tag = model.GoTag.Value;
            model.GoTag.Changed += OnGoTagChanged;
            
            _goView.gameObject.layer = model.Layer.Value;
            model.Layer.Changed += OnLayerChanged;
        }

        private void OnPositionChanged(Vector3 position)
        {
            _goView.transform.position = position;
        }
        
        private void OnLocalPositionChanged(Vector3 localPosition)
        {
            _goView.transform.localPosition = localPosition;
        }
        
        private void OnRotationChanged(Quaternion rotation)
        {
            _goView.transform.rotation = rotation;
        }
        
        private void OnLocalRotationChanged(Quaternion localRotation)
        {
            _goView.transform.localRotation = localRotation;
        }
        
        private void OnLocalScaleChanged(Vector3 localScale)
        {
            _goView.transform.localScale = localScale;
        }
        
        private void OnGoTagChanged(string goTag)
        {
            _goView.tag = goTag;
        }

        private void OnLayerChanged(int layer)
        {
            _goView.gameObject.layer = layer;
        }
    }
}