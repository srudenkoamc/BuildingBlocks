using System;
using System.Collections.Generic;
using Elements;
using Elements.GeoJSON;
using Elements.Geometry;

namespace Location
{
    public static class Location
    {
        private const string _mapboxToken = "pk.eyJ1IjoiaWtlb3VnaCIsImEiOiJjamc4ZzFucnoxdmQ0MnBxZDY5dW8za3c4In0.fQy46phspOdUtJleHvrqlg";
        private const string _mapboxBaseUri = "https://api.mapbox.com";

        /// <summary>
        /// The Location function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A LocationOutputs instance containing computed results and the model with any new elements.</returns>
        public static LocationOutputs Execute(Dictionary<string, Model> inputModels, LocationInputs input)
        {
            var origin = input.Origin.Coordinates;
            var outputModel = new Model(new Position(origin.Latitude, origin.Longitude), new Dictionary<Guid, Element>());
            var zoom = 16;

            // Temp origin for testing.
            // var origin = new Elements.GeoJSON.Position(34.0, 118.0);
            var offset = SiteMaker.LatLonToMeters(origin.Latitude, origin.Longitude);
            var x = SiteMaker.Long2Tile(origin.Longitude, zoom);
            var y = SiteMaker.Lat2Tile(origin.Latitude, zoom);

            var tileSize = SiteMaker.GetTileSizeMeters(zoom);
            var tileCenter = SiteMaker.TileIdToCenterWebMercator(x, y, zoom);
            var localOrigin = tileCenter - new Vector3(tileSize / 2, tileSize / 2) - offset;

            // Get the topo tile containing the origin.
            var o = GetTopoTile(x, y, origin.Latitude, origin.Longitude, offset);
            var ray = new Ray(Vector3.Origin, Vector3.ZAxis);
            ray.Intersects(o, out IntersectionResult result);

            var worldToLocalTransform = new Transform(new Vector3(0,0,-result.Point.Z));
            o.Transform = worldToLocalTransform;
            
            outputModel.AddElement(o);

            // Determine which quadrant the local origin is in
            // and load the tiles that are closest
            if (localOrigin.X < tileCenter.X && localOrigin.Y < tileCenter.Y)
            {
                // lower left
                var w = GetTopoTile(x - 1, y, origin.Latitude, origin.Longitude, offset);
                w.Transform = worldToLocalTransform;
                var sw = GetTopoTile(x - 1, y - 1, origin.Latitude, origin.Longitude, offset);
                sw.Transform = worldToLocalTransform;
                var s = GetTopoTile(x, y - 1, origin.Latitude, origin.Longitude, offset);
                s.Transform = worldToLocalTransform;
                outputModel.AddElements(new[] { w, sw, s });
            }
            else if (localOrigin.X > tileCenter.X && localOrigin.Y < tileCenter.Y)
            {
                // lower right
                var e = GetTopoTile(x + 1, y, origin.Latitude, origin.Longitude, offset);
                e.Transform = worldToLocalTransform;
                var se = GetTopoTile(x + 1, y - 1, origin.Latitude, origin.Longitude, offset);
                se.Transform = worldToLocalTransform;
                var s = GetTopoTile(x, y - 1, origin.Latitude, origin.Longitude, offset);
                s.Transform= worldToLocalTransform;
                outputModel.AddElements(new[] { e, se, s });
            }
            else if (localOrigin.X > tileCenter.X && localOrigin.Y > tileCenter.Y)
            {
                // upper right
                var n = GetTopoTile(x, y + 1, origin.Latitude, origin.Longitude, offset);
                n.Transform = worldToLocalTransform;
                var se = GetTopoTile(x + 1, y + 1, origin.Latitude, origin.Longitude, offset);
                se.Transform = worldToLocalTransform;
                var e = GetTopoTile(x + 1, y, origin.Latitude, origin.Longitude, offset);
                e.Transform = worldToLocalTransform;
                outputModel.AddElements(new[] { n, se, e });
            }
            else if (localOrigin.X < tileCenter.X && localOrigin.Y > tileCenter.Y)
            {
                // upper left
                var n = GetTopoTile(x, y + 1, origin.Latitude, origin.Longitude, offset);
                n.Transform = worldToLocalTransform;
                var nw = GetTopoTile(x - 1, y + 1, origin.Latitude, origin.Longitude, offset);
                nw.Transform = worldToLocalTransform;
                var w = GetTopoTile(x - 1, y, origin.Latitude, origin.Longitude, offset);
                w.Transform = worldToLocalTransform;
                outputModel.AddElements(new[] { n, nw, w });
            }

            // Draw something at the origin
            var m = new Mass(Marker(Vector3.Origin, new Vector3(15.0, 15.0), 1.0), 
                             1.0, 
                             new Material("Origin", Colors.Black, 0.0f, 0.0f));
            outputModel.AddElement(m);

            var projectOrigin = new Origin(origin, result.Point.Z, new Transform(), Guid.NewGuid(), "Origin");
            outputModel.AddElement(projectOrigin);

            var outputs = new LocationOutputs(origin.Latitude, origin.Longitude, result.Point.Z)
            {
                model = outputModel
            };
            return outputs;
        }

        private static Topography GetTopoTile(int x, int y, double lat, double lon, Vector3 offset)
        {
            var tmpImagePath = SiteMaker.GetMapImage(lat, lon, x, y, _mapboxBaseUri, _mapboxToken, 512);
            var topo = SiteMaker.CreateTopographyFromMapbox(lat, lon, _mapboxBaseUri, _mapboxToken, offset, x, y, 512, tmpImagePath);
            return topo;
        }

        private static Vector3 GetOriginOnTopography(Topography topo)
        {
            var ray = new Ray(Vector3.Origin, Vector3.ZAxis);
            return null;
        }

        /// <summary>
        /// Creates an X-shaped Polygon within a specified rectangle.
        /// </summary>
        /// <param name="origin">The initial enclosing box corner.</param>
        /// <param name="size">The positive x and y delta defining the size of the enclosing box.</param>
        /// <param name="width">Width of each stroke of the shape.</param>
        /// <returns>
        /// A new Polygon.
        /// </returns>
        public static Elements.Geometry.Polygon Marker(Vector3 origin, Vector3 size, double width)
        {
            var halfWidth = width * 0.5;
            var xAxis = origin.Y + (size.Y * 0.5);
            var yAxis = origin.X + (size.X * 0.5);
            return
                new Elements.Geometry.Polygon
                (
                    new[]
                    {
                        new Vector3(yAxis - halfWidth, Vector3.Origin.Y),
                        new Vector3(yAxis + halfWidth, Vector3.Origin.Y),
                        new Vector3(yAxis + halfWidth, xAxis - halfWidth),
                        new Vector3(size.X, xAxis - halfWidth),
                        new Vector3(size.X, xAxis + halfWidth),
                        new Vector3(yAxis + halfWidth, xAxis + halfWidth),
                        new Vector3(yAxis + halfWidth, size.Y),
                        new Vector3(yAxis - halfWidth, size.Y),
                        new Vector3(yAxis - halfWidth, xAxis + halfWidth),
                        new Vector3(Vector3.Origin.X, xAxis + halfWidth),
                        new Vector3(Vector3.Origin.X, xAxis - halfWidth),
                        new Vector3(yAxis - halfWidth, xAxis - halfWidth)
                    }
                );
        }
    }

    public static class RayExtensions
    {
        public static bool Intersects(this Ray ray, Topography topo, out IntersectionResult xsect)
        {
            xsect = null;
            foreach (var t in topo.Mesh.Triangles)
            {
                if (ray.Intersects(t, out xsect))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class IntersectionResult
    {
        public Vector3 Point { get; }
        public IntersectionResultType Type { get; }
        public IntersectionResult(Vector3 point, IntersectionResultType type)
        {
            this.Point = point;
            this.Type = type;
        }
    }

    public enum IntersectionResultType
    {
        Parallel, Behind, Intersect, DoesNotIntersect, IntersectsAtVertex
    }

    public class Ray
    {
        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
        }

        /// <summary>
        /// https://www.scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-rendering-a-triangle/ray-triangle-intersection-geometric-solution
        /// </summary>
        /// <param name="tri"></param>
        /// <param name="result"></param>
        public bool Intersects(Triangle tri, out IntersectionResult result)
        {
            result = null;
            var D = tri.Normal.Dot(tri.Vertices[0].Position);
            var denom = tri.Normal.Dot(this.Direction);
            if (denom == 0)
            {
                // Ray and triangle are parallel
                result = new IntersectionResult(null, IntersectionResultType.Parallel);
                return false;
            }
            double t = (tri.Normal.Dot(this.Origin) + D) / denom;
            var P = this.Origin + t * this.Direction;
            if (t < 0)
            {
                // Triangle is "behind" the ray.
                result = new IntersectionResult(null, IntersectionResultType.Behind);
                return false;
            }
            var edge0 = tri.Vertices[1].Position - tri.Vertices[0].Position;
            var edge1 = tri.Vertices[2].Position - tri.Vertices[1].Position;
            var edge2 = tri.Vertices[0].Position - tri.Vertices[2].Position;
            var C0 = P - tri.Vertices[0].Position;
            var C1 = P - tri.Vertices[1].Position;
            var C2 = P - tri.Vertices[2].Position;

            if (P.IsAlmostEqualTo(tri.Vertices[0].Position) ||
               P.IsAlmostEqualTo(tri.Vertices[1].Position) ||
               P.IsAlmostEqualTo(tri.Vertices[2].Position))
            {
                // Intersection occurs at a vertex of the triangle.
                result = new IntersectionResult(P, IntersectionResultType.IntersectsAtVertex);
                return true;
            }

            var x1 = tri.Normal.Dot(edge0.Cross(C0));
            var x2 = tri.Normal.Dot(edge1.Cross(C1));
            var x3 = tri.Normal.Dot(edge2.Cross(C2));

            if (x1 > 0 &&
                x2 > 0 &&
                x3 > 0)
            {
                result = new IntersectionResult(P, IntersectionResultType.Intersect);
                return true; // P is inside the triangle
            }
            result = new IntersectionResult(null, IntersectionResultType.DoesNotIntersect);
            return false;
        }
    }
}