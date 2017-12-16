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
            float dLat = DegreesToRadians(latitudeB) - DegreesToRadians(latitudeA);
            float dLon = DegreesToRadians(longitudeB) - DegreesToRadians(longitudeA);
            float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2)
                + Mathf.Cos(DegreesToRadians(latitudeA))
                * Mathf.Cos(DegreesToRadians(latitudeB))
                * Mathf.Sin(dLon / 2)
                * Mathf.Sin(dLon / 2);
            float c = (float)(2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));
            float d = Constants.Constants.EarthRadius * c;
            return d * 1000f; // meters
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitudeA"></param>
        /// <param name="longitudeA"></param>
        /// <param name="latitudeB"></param>
        /// <param name="longitudeB"></param>
        /// <returns></returns>
        public float GetBearing(float latitudeA, float longitudeA, float latitudeB, float longitudeB)
        {
            float y = Mathf.Sin(DegreesToRadians(longitudeB - longitudeA));
            float x = Mathf.Cos(DegreesToRadians(latitudeA)) * Mathf.Sin(DegreesToRadians(latitudeB))
                - Mathf.Sin(DegreesToRadians(latitudeA)) * Mathf.Cos(DegreesToRadians(latitudeB))
                * Mathf.Cos(DegreesToRadians(longitudeB - longitudeA));
            float dLat = DegreesToRadians(latitudeB) - DegreesToRadians(latitudeA);
            return RadiansToDegrees(Mathf.Atan2(y, x));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        private float DegreesToRadians(float radians)
        {
            return radians * Mathf.PI / 180.0f;
        }


        private float RadiansToDegrees(float radians)
        {
            return radians * 180.0f / Mathf.PI;
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

        /// <summary>
        /// Calculates the transform position for a waypoint based on its lat long and the cameras lat long
        /// The objective is to place the waypoint a short distance from the camera in the same direction as the remote GPS
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <returns></returns>
        public Vector3 getRelativePosition(float localLatitude, float localLongitude, float remoteLatitude, float remoteLongitude)
        {
            float deltaLatitude = localLatitude - remoteLatitude;
            float deltaLongitude = localLongitude - remoteLongitude;
            Vector3 deltaPosition = new Vector3(LatitudeToMeters(deltaLatitude), 1, LongitudeToMeters(deltaLongitude));
            Vector3 remotePosition = new Vector3(LatitudeToMeters(remoteLatitude), 1, LongitudeToMeters(remoteLongitude));

            //we should use the current GPS to calculate the camera's position, but the demo has the camera starting at 0,0,0 for now.
            Vector3 localPosition = new Vector3(LatitudeToMeters(localLatitude), 1, LongitudeToMeters(localLongitude));
            Vector3 demoPosition = new Vector3(0, 1, 0);

            return getPointOnLine(demoPosition, deltaPosition, 1f);
        }

        /// <summary>
        /// Calculate the number of meters per degree of latitude at a given latitude.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private float LatitudeToMeters(float degrees)
        {
            return 111132.92f - 559.82f * Mathf.Cos(2 * degrees) + 1.175f * Mathf.Cos(4 * degrees) - 0.0023f * Mathf.Cos(6 * degrees);

        }

        /// <summary>
        /// Calculate the number of meters per degree of longitude at a given longitude.
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private float LongitudeToMeters(float degrees)
        {
            return 111412.84f * Mathf.Cos(degrees) - 93.5f * Mathf.Cos(3 * degrees) + 0.118f * Mathf.Cos(5 * degrees);

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
            Vector3 returnMe = pointA + (unitVector * distance);
            return returnMe;
        }
    }
}
