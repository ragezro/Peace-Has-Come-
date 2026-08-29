using System.Collections.Generic;
using UnityEngine;

namespace PeaceHasCome
{
    /// <summary>
    /// Draws a green ring around each currently active peace zone when toggled on via Config.ToggleZoneRadiusKey (default F8). Ring radius matches the configured peace zone radius exactly.
    /// </summary>
    internal class ZoneRadiusVisualizer : MonoBehaviour
    {
        private const int Segments = 64;
        private const float RefreshIntervalSeconds = 1f;

        private bool _visible;
        private float _refreshTimer;
        private readonly List<GameObject> _activeLines = new List<GameObject>();

        private void Update()
        {
            if (Input.GetKeyDown(Config.ToggleZoneRadiusKey.Value))
            {
                _visible = !_visible;
                if (!_visible) ClearLines();
            }

            if (!_visible) return;

            _refreshTimer -= Time.deltaTime;
            if (_refreshTimer > 0f) return;
            _refreshTimer = RefreshIntervalSeconds;

            RefreshLines();
        }

        private void RefreshLines()
        {
            ClearLines();

            var radius = Config.GetZoneRadiusMeters();

            foreach (var zone in PeaceZoneManager.GetActiveZones())
            {
                var lineObj = new GameObject("PeaceZoneRing");
                lineObj.transform.position = zone.Position;

                var line = lineObj.AddComponent<LineRenderer>();
                line.useWorldSpace = true;
                line.loop = true;
                line.widthMultiplier = 0.2f;
                line.material = new Material(Shader.Find("Sprites/Default"));
                line.startColor = Color.green;
                line.endColor = Color.green;
                line.positionCount = Segments;

                for (var i = 0; i < Segments; i++)
                {
                    var angle = i * Mathf.PI * 2f / Segments;
                    var x = zone.Position.x + Mathf.Cos(angle) * radius;
                    var z = zone.Position.z + Mathf.Sin(angle) * radius;

                    // Sample actual terrain height at this point rather than using the trophy's own height for the whole ring, so it follows the ground contour instead of clipping into or floating above slopes/hills.
                    var y = zone.Position.y;
                    if (ZoneSystem.instance != null &&
                        ZoneSystem.instance.GetGroundHeight(new Vector3(x, zone.Position.y, z), out var groundHeight))
                    {
                        y = groundHeight;
                    }

                    line.SetPosition(i, new Vector3(x, y + 0.5f, z));
                }

                _activeLines.Add(lineObj);
            }
        }

        private void ClearLines()
        {
            foreach (var obj in _activeLines)
            {
                if (obj != null) Destroy(obj);
            }
            _activeLines.Clear();
        }

        private void OnDestroy()
        {
            ClearLines();
        }
    }
}
