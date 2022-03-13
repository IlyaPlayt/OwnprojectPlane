using UnityEngine;

namespace Sample.Airplane
{
    public class AirplaneBuilder : IAirplaneBuilder
    {
        private bool changeSpeed;
        private bool changeModel;
        private bool changeColor;

        private float newSpeed;
        private Color newColor;
        private GameObject go;


        public IAirplaneBuilder ChangeSpeed(float speed)
        {
            changeSpeed = true;
            newSpeed = speed;
            return this;
        }


        public IAirplaneBuilder ChangeColor(Color color)
        {
            changeColor = true;
            newColor = color;
            return this;

        }

        public GameObject Build(IPrototype prototype)
        {
            GameObject airplane = prototype.Clone();
            if (changeSpeed)
            {
                airplane.GetComponent<AirplaneController>().forwardSpeed = newSpeed;
            }

            if (changeColor)
            {
                airplane.gameObject.GetComponent<MeshRenderer>().material.color=newColor;
            }
            

            return airplane;


        }
    }
}