using FMOD;
using ReiHook.Features.Visuals;
using TheForest.Utils;
using System.Collections.Generic;
using UnityEngine;
using TheForest.Graphics;

namespace ReiHook.Utilities
{
    public static class Render
    {
        public static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < Screen.height - 5f && position.z > 0.01f;
        }

        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        private class RingArray
        {
            public Vector2[] Positions { get; private set; }

            public RingArray(int numSegments)
            {
                Positions = new Vector2[numSegments];
                var stepSize = 360f / numSegments;
                for (int i = 0; i < numSegments; i++)
                {
                    var rad = Mathf.Deg2Rad * stepSize * i;
                    Positions[i] = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
                }
            }
        }

        private static Dictionary<int, RingArray> ringDict = new Dictionary<int, RingArray>();

        public static Color Color
        {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
        {
            Color = color;
            DrawLine(from, to, thickness);
        }
        public static void DrawLine(Vector2 from, Vector2 to, float thickness)
        {
            var delta = (to - from).normalized;
            var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            GUIUtility.RotateAroundPivot(angle, from);
            DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
            GUIUtility.RotateAroundPivot(-angle, from);
        }

        public static void pepeLine(Vector3 start, Vector3 end, Color color, float width)
        {
            if (start == Vector3.zero || end == Vector3.zero)
                return;

            Vector2 d = end - start;
            float a = Mathf.Rad2Deg * Mathf.Atan((d.y != 0 ? d.y : d.y + 0.01f) / (d.x != 0 ? d.x : d.x + 0.01f));
            if (d.x < 0)
                a += 180;

            int width2 = (int)Mathf.Ceil(width / 2);

            GUIUtility.RotateAroundPivot(a, start);
            GUI.DrawTexture(new Rect(start.x, start.y - width2, d.magnitude, width), Texture2D.whiteTexture);
            GUIUtility.RotateAroundPivot(-a, start);
        }

        public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
        {
            Color = color;
            DrawBox(position, size, thickness, centered);
        }
        public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
        {
            var upperLeft = centered ? position - size / 2f : position;
            GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
        }

        public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
        {
            Color = color;
            DrawCross(position, size, thickness);
        }
        public static void DrawCross(Vector2 position, Vector2 size, float thickness)
        {
            GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
        }

        public static void DrawDot(Vector2 position, Color color)
        {
            Color = color;
            DrawDot(position);
        }
        public static void DrawDot(Vector2 position)
        {
            DrawBox(position - Vector2.one, Vector2.one * 2f, 1f);
        }

        public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12, FontStyle fontStyle = FontStyle.Bold, int depth = 1)
        {
            __style.fontSize = size;
            __style.richText = true;
            __style.normal.textColor = color;
            __style.fontStyle = fontStyle;

            __outlineStyle.fontSize = size;
            __outlineStyle.richText = true;
            __outlineStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
            __outlineStyle.fontStyle = fontStyle;

            GUIContent content = new GUIContent(text);
            GUIContent content2 = new GUIContent(text);
            if (center)
            {
                //GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                pos.x -= __style.CalcSize(content).x / 2f;
            }
            switch (depth)
            {
                case 0:
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 1:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 2:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
                case 3:
                    GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), content2, __outlineStyle);
                    GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, __style);
                    break;
            }
        }

        public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
        {
            DrawCircle(position, radius, numSides, Color.white, centered, thickness);
        }
        public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
        {
            RingArray arr;
            if (ringDict.ContainsKey(numSides))
                arr = ringDict[numSides];
            else
                arr = ringDict[numSides] = new RingArray(numSides);


            var center = centered ? position : position + Vector2.one * radius;

            for (int i = 0; i < numSides - 1; i++)
                DrawLine(center + arr.Positions[i] * radius, center + arr.Positions[i + 1] * radius, thickness, color);

            DrawLine(center + arr.Positions[0] * radius, center + arr.Positions[arr.Positions.Length - 1] * radius, thickness, color);
        }
        public static Vector3 WorldToScreenPoint(Vector3 wp)
        {
            if (wp == null) return wp;
            Matrix4x4 mat = WaterEngine.Camera.projectionMatrix * WaterEngine.Camera.worldToCameraMatrix;
            Vector4 temp = mat * new Vector4(wp.x, wp.y, wp.z, 1f);
            if (temp.w < 0.1f)
                return Vector3.zero;
            float invw = 1.0f / temp.w;
            temp.x *= invw;
            temp.y *= invw;
            Vector2 Center = new Vector2((0.5f * WaterEngine.Camera.pixelWidth), (0.5f * WaterEngine.Camera.pixelHeight));
            Center.x += 0.5f * temp.x * WaterEngine.Camera.pixelWidth + 0.5f;
            Center.y -= 0.5f * temp.y * WaterEngine.Camera.pixelHeight + 0.5f;
            return new Vector3(Center.x, Center.y, wp.z);
        }

        private static GUIStyle __style = new GUIStyle();
        private static GUIStyle __outlineStyle = new GUIStyle();
    }
}
