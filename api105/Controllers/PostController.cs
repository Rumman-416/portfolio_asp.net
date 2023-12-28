using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using api105.Models;

[Route("api/projects")]
public class PostController : ControllerBase
{
    private const string JsonFilePath = "Projects.json";

    [HttpGet]
    public ActionResult<IEnumerable<Post>> GetPosts()
    {
        var posts = ReadPostsFromJsonFile();
        return Ok(posts);
    }

    private List<Post> ReadPostsFromJsonFile()
    {
        if (System.IO.File.Exists(JsonFilePath))
        {
            var json = System.IO.File.ReadAllText(JsonFilePath);
            return JsonConvert.DeserializeObject<List<Post>>(json);
        }
        return new List<Post>();
    }
}
