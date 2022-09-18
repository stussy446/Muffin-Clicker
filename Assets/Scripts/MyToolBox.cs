using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyToolBox 
{
   public static Vector2 GetRandomVector2()
    {
        Vector2 value = new Vector2();
        value.x = Random.Range(-150, 180);
        value.y = Random.Range(-150, 150);

        return value;

    }
}
