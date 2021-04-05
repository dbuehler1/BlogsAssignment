using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace BlogsAssignment
{
    public class Menu
    {
        public void displayMenu()
        {
            System.Console.WriteLine("\n \n");
            System.Console.WriteLine("1) Display All Blogs");
            System.Console.WriteLine("2) Add Blog");
            System.Console.WriteLine("3) Create Post");
            System.Console.WriteLine("4) Display Posts");
        }

        public void displayBlogs()
        {
            int count = 0;
            using (var db = new BloggingController())
            {
                foreach (var blog in db.Blogs)
                {
                    count++;
                    System.Console.WriteLine(blog.BlogId + " " + blog.Url);
                    System.Console.WriteLine("");
                }
                System.Console.WriteLine(count + " Blogs returned");
                
            }

        }

        public void addBlog(string title)
        {
            System.Console.WriteLine("");
            if (title == "")
            {
                System.Console.WriteLine("The blog title cannot be blank");
            }
            else
            {
                using (var db = new BloggingController())
                {
                    var blog = new Blog()
                    {
                        Rating = 1,
                        Url = title
                    };
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                }
            }

        }
        public void createPost(int selectedBlog, string title, string content)
        {
            System.Console.WriteLine("");
            if (content == "")
            {
                System.Console.WriteLine("Post Content Cannot be blank");
            }
            else
            {

            }
            if (title == "")
            {
                System.Console.WriteLine("Post title cannot be blank");
            }
            else
            {
                using (var db = new BloggingController())
                {
                    var post = new Post()
                    {
                        BlogId = selectedBlog,
                        Content = content,
                        Title = title
                    };
                    try
                    {
                        db.Posts.Add(post);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("There are no blogs saved with that ID");
                    }
                }
            }

        }

        public void displayPosts()
        {
            System.Console.WriteLine("");
            using (var db = new BloggingController())
            {
                var blogs = db.Blogs
                .Include(b => b.Posts)
                .ToList();
                foreach (var blog in blogs)
                {
                    System.Console.Write("Blog:");
                    System.Console.WriteLine(blog.BlogId + ") " + blog.Url);
                    System.Console.WriteLine("Posts:");
                    foreach (var post in blog.Posts)
                    {
                        System.Console.WriteLine(post.PostId + " " + post.Title + " " + post.Content + " " + post.BlogId);
                    }
                    System.Console.WriteLine("");
                }
                db.SaveChanges();
            }
            //System.Console.WriteLine(count + " Blogs returned");

        }
    }
}