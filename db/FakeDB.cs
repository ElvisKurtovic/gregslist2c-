using System.Collections.Generic;
using gregslist2.Models;

namespace gregslist2.db
{
    public class FakeDB
    {

        //NOTE make sure you instantiate your list before you try to access it.
        public static List<Car> Cars { get; set; } = new List<Car>();
    }
}