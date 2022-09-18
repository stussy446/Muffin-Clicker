using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyToolBox 
{
    public static Vector2 GetRandomVector2(float xMin, float xMax, float yMin,
        float yMax)
    {
        Vector2 value = new Vector2();
        value.x = Random.Range(xMin, xMax);
        value.y = Random.Range(yMin, yMax);

        return value;

    }
}
