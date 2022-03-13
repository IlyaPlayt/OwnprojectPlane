using UnityEngine;

namespace Sample.Airplane
{
    public class AirplaneFactory: IAirplaneFactory
    {
        [SerializeField] private AirplaneParameters _airplanesParametersParameters;
        [SerializeField] private PrimitiveAirplane _primitiveAirplane;


        public GameObject Create(int index)
        {
            var planeBuilder = new AirplaneBuilder().ChangeColor(_airplanesParametersParameters.PlaneColor)
                .ChangeSpeed(_airplanesParametersParameters.PlaneSpeed);

            return planeBuilder.Build(_primitiveAirplane);
        }
    }
}