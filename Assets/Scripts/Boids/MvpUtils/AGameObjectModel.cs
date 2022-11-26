using Boids.MvpUtils.Impl;
using UnityEngine;

namespace Boids.MvpUtils
{
    public abstract class AGameObjectModel : AModel
    {
        public IModelField<Vector3> Position { get; set; } = new ModelField<Vector3>();
        public IModelField<Vector3> LocalPosition { get; set; } = new ModelField<Vector3>();
        public IModelField<Quaternion> Rotation { get; set; } = new ModelField<Quaternion>();
        public IModelField<Quaternion> LocalRotation { get; set; } = new ModelField<Quaternion>();
        public IModelField<Vector3> LocalScale { get; set; } = new ModelField<Vector3>();
        public IModelField<string> GoTag { get; set; } = new ModelField<string>("Untagged");
        public IModelField<int> Layer { get; set; } = new ModelField<int>();
    }
}