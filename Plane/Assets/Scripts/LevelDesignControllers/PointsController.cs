using UnityEngine;

namespace Sample
{
    public class PointsController: MonoBehaviour

    {
    public Transform[] points;

    public void CreateWay(Transform PointsParent)
    {
        var count = PointsParent.childCount;
        points = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            points[i] = PointsParent.GetChild(i);
        }
    }

    }
}