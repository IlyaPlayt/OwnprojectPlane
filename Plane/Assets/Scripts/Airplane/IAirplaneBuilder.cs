using UnityEngine;

namespace Sample.Airplane
{
    public interface IAirplaneBuilder

    {
        IAirplaneBuilder ChangeSpeed(float speed);
        IAirplaneBuilder ChangeColor(Color color);

        GameObject Build(IPrototype prototype);


    }
}