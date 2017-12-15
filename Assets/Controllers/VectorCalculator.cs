using System;
using UnityEngine;

namespace Assets.Controllers
{
    public class VectorController
    {
        /// <summary>
        /// generally used geo measurement function
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public float GetDistance(float latitudeA, float longitudeA, float latitudeB, float longitudeB)
        {
            float dLat = RadiansToDegrees(latitudeB) - RadiansToDegrees(latitudeA);
            float dLon = RadiansToDegrees(longitudeB) - RadiansToDegrees(longitudeA);
            float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(RadiansToDegrees(latitudeA)) * Mathf.Cos(RadiansToDegrees(latitudeB)) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
            float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
            float d = Constants.Constants.EarthRadius * c;
            return d * 1000f; // meters
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        private float RadiansToDegrees(float radians)
        {
            return radians * Mathf.PI / 180;
        }

        /// <summary>
        /// Calculates the angle from sides.
        /// http://www.calculator.net/triangle-calculator.html?vc=90&vx=5&vy=7&va=&vz=&vb=&angleunits=d&x=44&y=27
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        private float calculateAngleFromSides(float sideA, float sideB, float sideC)
        {
            return Mathf.Acos((Mathf.Pow(sideA, 2) + Mathf.Pow(sideB, 2) - Mathf.Pow(sideC, 2)) / (2 * sideA * sideB));
        }

        private Vector3 calculateTransformPosition(float lat, float lon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the point on line.
        /// </summary>
        /// <param name="pointA">The point a.</param>
        /// <param name="pointB">The point b.</param>
        /// <param name="distance">The distance.</param>
        /// <returns></returns>
        private Vector3 getPointOnLine(Vector3 pointA, Vector3 pointB, float distance)
        {
            Vector3 vector = pointA - pointB;
            float vectorLength = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
            Vector3 unitVector = vector / vectorLength;
            return pointA + (unitVector * distance);
        }
    }
}
