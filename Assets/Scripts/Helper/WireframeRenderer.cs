    using System.Linq;
    using UnityEngine;
    using System.Collections.Generic;
     
     
    public class WireframeRenderer : MonoBehaviour
    {
     
        //****************************************************************************************
     
        //  Material options
     
        //****************************************************************************************
     
        public Color LineColor;
        public Color BackgroundColor;
     
        public bool ZWrite = true;
        public bool AWrite = true;
        public bool Blend = true;
     
        public int Fidelity = 3;
     
        public MeshRenderer MeshRenderer;
     
     
        //****************************************************************************************
     
        // Line Data
     
        //****************************************************************************************
     
        private Vector3[] _lines;
        private readonly List<Line> _linesArray = new List<Line>();
     
        private Material _lineMaterial;
     
     
        //*****************************************************************************************
     
        // Helper class, Line is defined as two Points
     
        //*****************************************************************************************
     
        public class Line
        {
     
            public Vector3 PointA;
            public Vector3 PointB;
     
            public Line(Vector3 a, Vector3 b)
            {
                PointA = a;
                PointB = b;
            }
     
            //*****************************************************************************************
     
            // A == B if   Aa&&Ab == Ba&&Bb or Ab&&Ba == Aa && Bb
     
            //*****************************************************************************************
     
            public static bool operator ==(Line lA, Line lB)
            {
     
                if (lA.PointA == lB.PointA && lA.PointB == lB.PointB)
                {
                    return true;
                }
     
                if (lA.PointA == lB.PointB && lA.PointB == lB.PointA)
                {
                    return true;
                }
     
                return false;
     
            }
     
     
     
            //*****************************************************************************************
     
            // A != B if   !(Aa&&Ab == Ba&&Bb or Ab&&Ba == Aa && Bb)
     
            //*****************************************************************************************
     
            public static bool operator !=(Line lA, Line lB)
            {
                return !(lA == lB);
            }
     
        }
     
     
     
        //*****************************************************************************************
     
        // Parse the mesh this is attached to and save the line data
     
        //*****************************************************************************************
     
        public void Start()
        {
            MeshRenderer = gameObject.GetComponent<MeshRenderer>() ?? gameObject.AddComponent<MeshRenderer>();
            MeshRenderer.material = new Material("Shader \"Lines/Background\" { Properties { _Color (\"Main Color\", Color) = (1,1,1,1) } SubShader { Pass {" + (ZWrite ? " ZWrite on " : " ZWrite off ") + (Blend ? " Blend SrcAlpha OneMinusSrcAlpha" : " ") + (AWrite ? " Colormask RGBA " : " ") + "Lighting Off Offset 1, 1 Color[_Color] }}}");
     
            _lineMaterial = new Material("Shader \"Lines/Colored Blended\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha BindChannels { Bind \"Color\",color } ZWrite On Cull Front Fog { Mode Off } } } }");
     
            _lineMaterial.hideFlags = HideFlags.HideAndDontSave;
     
            _lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
     
            var filter = GetComponent<MeshFilter>();
     
            var mesh = filter.sharedMesh;
     
            var vertices = mesh.vertices;
     
            var triangles = mesh.triangles;
     
            for (var i = 0; i < triangles.Length / 3; i++)
            {
     
                var j = i * 3;
                var lineA = new Line(vertices[triangles[j]], vertices[triangles[j + 1]]);
                var lineB = new Line(vertices[triangles[j + 1]], vertices[triangles[j + 2]]);
                var lineC = new Line(vertices[triangles[j + 2]], vertices[triangles[j]]);
     
                switch (Fidelity)
                {
                    case 3:
                        AddLine(lineA);
                        AddLine(lineB);
                        AddLine(lineC);
                        break;
                    case 2:
                        AddLine(lineA);
                        AddLine(lineB);
                        break;
                    case 1:
                        AddLine(lineA);
                        break;
                }
     
            }
     
        }
     
     
     
        //****************************************************************************************
     
        // Adds a line to the array if the equivalent line isn't stored already
     
        //****************************************************************************************
     
        public void AddLine(Line l)
        {
            var found = _linesArray.Any(line => l == line);
            if (!found)
            {
                _linesArray.Add(l);
            }
        }
     
     
     
        //****************************************************************************************
     
        // Deferred rendering of wireframe, this should let materials go first
     
        //****************************************************************************************
     
        public void OnRenderObject()
        {
            MeshRenderer.sharedMaterial.color = BackgroundColor;
     
            _lineMaterial.SetPass(0);
     
            GL.PushMatrix();
            GL.MultMatrix(transform.localToWorldMatrix);
            GL.Begin(GL.LINES);
            GL.Color(LineColor);
     
            foreach (Line line in _linesArray)
            {
                GL.Vertex(line.PointA);
                GL.Vertex(line.PointB);
            }
     
            GL.End();
            GL.PopMatrix();
     
        }
     
    }