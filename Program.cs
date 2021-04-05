using System;

namespace BlogsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int menuChoice = 0;
            string userResponse;
            do{
                menu.displayMenu();
                menuChoice = Int32.Parse(Console.ReadLine());
                if(menuChoice == 1){
                    Console.Clear();
                    menu.displayBlogs();
                }
                else if(menuChoice == 2){
                    Console.Clear();
                    System.Console.Write("Enter a blog name: ");
                    userResponse = Console.ReadLine();
                    System.Console.WriteLine("");
                    menu.addBlog(userResponse);
                }
                else if(menuChoice == 3){
                    Console.Clear();
                    System.Console.WriteLine("Select the blog you would like to post to:");
                    menu.displayBlogs();
                    int selectedBlog = Int32.Parse(Console.ReadLine());
                    System.Console.WriteLine("Enter Title: ");
                    string postTitle = Console.ReadLine();
                    System.Console.WriteLine("Enter content for post: ");
                    string postContent = Console.ReadLine();
                    menu.createPost(selectedBlog, postTitle, postContent);
                }
                else if(menuChoice == 4){
                    Console.Clear();
                    menu.displayPosts();
                }
                else{
                    System.Console.WriteLine("Exiting");
                }
            }while(menuChoice > 0 && menuChoice < 5);
            /**using (var db = new BloggingController()){
                var blog = new Blog(){
                    Rating = 1,
                    Url = "some/url"
                };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }**/

            /**using (var db = new BloggingController()){
                var post = new Post(){
                    BlogId = 1,
                    Content = "Some content of great importance",
                    Title = "Very Important"
                };
                db.Posts.Add(post);
                db.SaveChanges();
            }

            using (var db = new BloggingController()){
                foreach (var blog in db.Blogs)
                {
                    System.Console.WriteLine(blog.BlogId + " " + blog.Url);
                }
            }**/


            
            
        }
    }
}
