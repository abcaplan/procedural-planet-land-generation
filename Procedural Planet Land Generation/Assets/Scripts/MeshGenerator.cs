using UnityEngine;

public static class MeshGenerator {

    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiply, AnimationCurve heightCurve) {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        float topLeftX = (width - 1) / -2f;
        float topLeftZ = (height - 1) / 2f;

        MeshData meshData = new MeshData (width, height);

        for (int y = 0, vertexIndex = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                meshData.vertices[vertexIndex] = new Vector3 (topLeftX + x, heightCurve.Evaluate(heightMap [x, y]) * heightMultiply, topLeftZ - y);
                meshData.uvs[vertexIndex] = new Vector2 (x / (float)width, y / (float)height);

                // Create a square from 2 triangle meshes
                if (x < width - 1 && y < height - 1) {
                    meshData.AddTriangle (vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                    meshData.AddTriangle (vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
                }
                vertexIndex++;
            }
        }
        return meshData;
    }
}

public class MeshData {
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;
    int triangleIndex;

    public MeshData(int meshWidth, int meshHeight) {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangles = new int[(meshWidth-1)*(meshHeight-1)*6];
    }

    public void AddTriangle(int first, int second, int third) {
        triangles[triangleIndex] = first;
        triangles[triangleIndex + 1] = second;
        triangles[triangleIndex + 2] = third;
        triangleIndex += 3;
    }

    public Mesh CreateMesh() {
        Mesh mesh = new Mesh ();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals ();
        return mesh;
    }
}