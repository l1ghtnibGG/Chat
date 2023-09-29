using ChatApp.Models;
using ChatApp.Models.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatRepository<User> _userRepository;
        private readonly IChatRepository<Tag> _tagRepository;

        public HomeController(ILogger<HomeController> logger, IChatRepository<User> userRepository,
            IChatRepository<Tag> tagRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/LogIn")]
        public IActionResult LogIn([FromForm] User user)
        {
            if (string.IsNullOrEmpty(user.Name))
                return RedirectToAction("Index");

            var existUser = Authorize(user.Name);

            if (existUser != null)
            {
                ViewBag.Tags = existUser.Tags;
                return RedirectToAction("Chat", new { userName = existUser.Name });
            }
                
            user = _userRepository.Add(user);
            return RedirectToAction("Chat", new { userName = user.Name });
        }

        [HttpGet("/Chat/{userName}")]
        public ActionResult Chat(string userName)
        {
            var tags = SearchTags(Authorize(userName));

            return View("Chat", new Tuple<string, List<string>>(userName, tags));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private User? Authorize(string user) => _userRepository.GetValues.FirstOrDefault(x => x.Name == user);

        private List<string> SearchTags(User user) => _userRepository.GetUserTags(user).Select(x => x.Name).ToList();
    }
}