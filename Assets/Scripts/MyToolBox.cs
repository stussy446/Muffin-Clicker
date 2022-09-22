using UnityEngine;

/// <summary>
/// Provides methods to get information from vectors
/// </summary>
public static class MyToolBox 
{
    /// <summary>
    /// Returns a random vector2 based on randomly generated x and y positions
    /// </summary>
    /// <param name="xMin">lowest  allowable x value</param>
    /// <param name="xMax">highest allowable x value</param>
    /// <param name="yMin">lowest  allowable y value</param>
    /// <param name="yMax">highest allowable y value</param>
    /// <returns>returns generated vector2</returns>
    public static Vector2 GetRandomVector2(float xMin, float xMax, float yMin,
        float yMax)
    {
        Vector2 value = new Vector2();
        value.x = Random.Range(xMin, xMax);
        value.y = Random.Range(yMin, yMax);

        return value;

    }
}
