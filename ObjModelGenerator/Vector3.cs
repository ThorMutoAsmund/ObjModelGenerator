namespace ObjModelGenerator
{
    public struct Vector3
    {
        public double x, y, z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 With(double? x = null, double? y = null, double? z = null)
        {
            return new Vector3(
                x.HasValue ? x.Value : this.x,
                y.HasValue ? y.Value : this.y,
                z.HasValue ? z.Value : this.z
            );
        }
        public Vector3 Add(double? x = null, double? y = null, double? z = null)
        {
            return new Vector3(
                x.HasValue ? this.x + x.Value : this.x,
                y.HasValue ? this.y + y.Value : this.y,
                z.HasValue ? this.z + z.Value : this.z
            );
        }
    }
}