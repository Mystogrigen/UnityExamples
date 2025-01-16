using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace UnityExamples
{
  public static class Helpers
  {
      /// <summary>
      /// Useful for staggering something every X frames.
      /// </summary>
      /// <param name="frequency">Frequency in frames you want it delayed</param>
      /// <returns></returns>
      public static bool RateLimiter(int frequency) => Time.frameCount % frequency == 0;

      private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new();
      /// <summary>
      /// Returns a WaitForSeconds object for the specified duration.
      /// </summary>
      /// <param name="seconds">The duration in seconds to wait.</param>
      /// <returns>A WaitForSeconds object.</returns>
      public static WaitForSeconds GetWaitForSeconds(float seconds)
      {
        if (WaitForSecondsDict.TryGetValue(seconds, out var forSeconds))
          return forSeconds;
        
        WaitForSeconds waitForSeconds = new(seconds);
        WaitForSecondsDict.Add(seconds, waitForSeconds);
        
        return WaitForSecondsDict[seconds];
      }
    public static readonly WaitForEndOfFrame EndOfFrame = new();
    private const float LOADWAITTIME = 0.1f;
    public static WaitForSeconds LoadWait => GetWaitForSeconds(LOADWAITTIME);

    /// <summary>
    /// Draws a wire arc.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="dir">The direction from which the anglesRange is taken into account</param>
    /// <param name="anglesRange">The angle range, in degrees.</param>
    /// <param name="radius"></param>
    /// <param name="maxSteps">How many steps to use to draw the arc.</param>
    public static void DrawWireArc(Vector3 position, Vector3 dir, float anglesRange, float radius, float maxSteps = 20)
    {
        var srcAngles = GetAnglesFromDir(position, dir);
        var initialPos = position;
        var posA = initialPos;
        var stepAngles = anglesRange / maxSteps;
        var angle = srcAngles - anglesRange / 2;
        for (var i = 0; i <= maxSteps; i++)
        {
            var rad = Mathf.Deg2Rad * angle;
            var posB = initialPos;
            posB += new Vector3(radius * Mathf.Cos(rad), 0, radius * Mathf.Sin(rad));

            Handles.DrawLine(posA, posB);

            angle += stepAngles;
            posA = posB;
        }
        Handles.DrawLine(posA, initialPos);
    }

    static float GetAnglesFromDir(Vector3 position, Vector3 dir)
    {
        var forwardLimitPos = position + dir;
        var srcAngles = Mathf.Rad2Deg * Mathf.Atan2(forwardLimitPos.z - position.z, forwardLimitPos.x - position.x);

        return srcAngles;
    }
  }
}
