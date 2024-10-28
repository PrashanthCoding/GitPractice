// Simple Calculator API

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("add/{a}/{b}")]
    public IActionResult Add(int a, int b)
    {
        return Ok(a + b);
    }

    [HttpGet("subtract/{a}/{b}")]
    public IActionResult Subtract(int a, int b)
    {
        return Ok(a - b);
    }

    [HttpGet("multiply/{a}/{b}")]
    public IActionResult Multiply(int a, int b)
    {
        return Ok(a * b);
    }

    [HttpGet("divide/{a}/{b}")]
    public IActionResult Divide(int a, int b)
    {
        if (b == 0) return BadRequest("Division by zero is not allowed.");
        return Ok((double)a / b);
    }
}


// ToDo List API

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private static List<ToDoItem> toDoItems = new List<ToDoItem>();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(toDoItems);
    }

    [HttpPost]
    public IActionResult Create(ToDoItem item)
    {
        item.Id = toDoItems.Count + 1;
        toDoItems.Add(item);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = toDoItems.FirstOrDefault(i => i.Id == id);
        if (item == null) return NotFound();
        toDoItems.Remove(item);
        return NoContent();
    }
}


// Weather API

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet("{city}")]
    public IActionResult GetWeather(string city)
    {
        // In a real application, this would call a weather service.
        return Ok($"The weather in {city} is sunny.");
    }
}


// User Registration API

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static List<User> users = new List<User>();

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Username and password are required.");

        users.Add(user);
        return Ok("User registered successfully.");
    }
}


// Books API

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new List<Book>();

    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(books);
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        book.Id = books.Count + 1;
        books.Add(book);
        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }
}


// Simple Authentication API

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        if (user.Username == "admin" && user.Password == "password")
            return Ok("Login successful!");

        return Unauthorized("Invalid credentials.");
    }
}


// File Upload API
[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file.Length <= 0) return BadRequest("No file uploaded.");

        var path = Path.Combine("uploads", file.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok("File uploaded successfully.");
    }
}

