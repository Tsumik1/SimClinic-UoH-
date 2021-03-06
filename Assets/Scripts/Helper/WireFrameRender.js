    var P0 : Vector3;
    var P1 : Vector3;
    var P2 : Vector3;
     
    var wires = new Array();
     
    var lineColor : Color;
    var myMesh : GameObject;
     
    static var lineMaterial : Material;
     
    function Start ()
    {
        CreateLineMaterial();
       
        var filter : MeshFilter = myMesh.GetComponent(MeshFilter);
        var mesh = filter.mesh;
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
       
        for (k = 0; k < triangles.length / 3; k++)
        {
            wires.Add (vertices[triangles[k * 3]]);
            wires.Add (vertices[triangles[k * 3 + 1]]);
            wires.Add (vertices[triangles[k * 3 + 2]]); 
        }
       
        wires.Add (vertices[triangles[triangles.length - 2]]);
        wires.Add (vertices[triangles[triangles.length - 1]]);
    }
     
    function OnPostRender()
    {   
        lineMaterial.SetPass(0);
       
        GL.Begin(GL.LINES);
        GL.Color(lineColor);
       
        for (i = 0; i < wires.length / 3; i++)
        {
            P0 = myMesh.transform.TransformPoint (wires[i * 3]);
            P1 = myMesh.transform.TransformPoint (wires[i * 3 + 1]);
            P2 = myMesh.transform.TransformPoint (wires[i * 3 + 2]);
           
            GL.Vertex3(P0.x, P0.y, P0.z);
            GL.Vertex3(P1.x, P1.y, P1.z);
            GL.Vertex3(P2.x, P2.y, P2.z);
            GL.Vertex3(P0.x, P0.y, P0.z);
        }
               
        GL.End();
    }
     
    static function CreateLineMaterial()
    {
        if( !lineMaterial ) {
            lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
                "SubShader { Pass { " +
                "    Blend SrcAlpha OneMinusSrcAlpha " +
                "    ZWrite Off Cull Front Fog { Mode Off } " +
                "} } }" );
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        }
    }