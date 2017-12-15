using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.DAQRI.Scripts
{
    class VectorController
    {
        /// <summary>
        /// generally used geo measurement function
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public Vector3 GetDistance(GPSCoordinatePair one, GPSCoordinatePair two)
        {
            Vector3 returnMe = new Vector3();

            float dLat = RadiansToDegrees(two.Latitude) - RadiansToDegrees(one.Latitude);
            float dLon = RadiansToDegrees(two.Longitude) - RadiansToDegrees(one.Longitude);
            float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(RadiansToDegrees(one.Latitude)) * Mathf.Cos(RadiansToDegrees(two.Latitude)) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
            float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
            float d = Constants.EarthRadius * c;
            return d * 1000; // meters

            returnMe.x = 0;
            returnMe.y = 0;
            returnMe.z = 0;

            return returnMe;
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

        }

        private Vector3 getPointOnLine(Vector3 pointA, Vector3 pointB, float distance)
        {
            Vector3 vector = pointA - pointB;
            float vectorLength = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
            Vector3 unitVector = vector / vectorLength;
            return pointA + (unitVector * distance);
        }

    }
}
