using System.Collections.Generic;

namespace ObjModelGenerator
{
    public class Face : List<int>
    {
        public Face()
        {

        }

        public Face(IEnumerable<int> input)
        {
            this.AddRange(input);
        }
    }
}