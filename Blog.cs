using System.Collections.Generic;

namespace BlogsAssignment{
    public class Blog{
    public int BlogId {get; set;}
    
    public string Url {get; set;}

    public int Rating{get; set;}

    public virtual List<Post> Posts{get; set;}
}
}
