using UnityEngine;

namespace Sample.Airplane
{
    [CreateAssetMenu]
    public class AirplaneParameters : ScriptableObject
    {
        [SerializeField] private Color planeColor;

        [SerializeField] private float planeSpeed;
        //TODO: придумать ка заносить новую модель

        public Color PlaneColor => planeColor;

        public float PlaneSpeed
        {
            get => planeSpeed;
        }
    }
}