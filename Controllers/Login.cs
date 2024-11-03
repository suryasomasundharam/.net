using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newproject2.EmployeeDBContext;
using newproject2.Models;
using System.IO;
using System.Web;

namespace newproject2.Controllers
{
    public class Login : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly EmployeeDetailsDBContext _context;

        public Login(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, EmployeeDetailsDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        /*  [HttpPost]
          public async Task<IActionResult> Register(Userlogin model)
          {
              if (ModelState.IsValid)
              {
                  var user = new IdentityUser
                  {
                      UserName = model.username,
                  };

                  var result = await _userManager.CreateAsync(user, model.Password);

                  if (result.Succeeded)
                  {

                          // Process and save the uploaded image
                          byte[] imageData = null;
                          using (var binaryReader = new BinaryReader(model.img.OpenReadStream()))
                          {
                              imageData = binaryReader.ReadBytes((int)ImageFile.Length);
                          }

                          // Save the image data to your desired storage (e.g., database, file system)
                          // You can add the image data to your user model or create a separate entity for storing images

                          // Example: Assuming you have a 'User' entity with an 'ImageData' property
                          var user = new User
                          {
                              // Set other user properties
                              ImageData = imageData
                          };
                          await _signInManager.SignInAsync(user, isPersistent: false);
                      _context.login!.Add(model);
                      _context.SaveChanges();

                      return RedirectToAction("Index", "Home");
                  }

                  foreach (var error in result.Errors)
                  {
                      ModelState.AddModelError("", error.Description);
                  }

                  ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

              }
              return View(model);
          }
  */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Userlogin userlogin, IFormFile img)
        {
         
            
                if (img != null && img.Length > 0)
                {
                    var fileName = Path.GetFileName(img.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", fileName);
              

                using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }

                    userlogin.img = "/" + fileName;
                }
            var user = new IdentityUser
            {
                UserName = userlogin.username,
            };
            var result = await _userManager.CreateAsync(user, userlogin.Password);
            await _signInManager.SignInAsync(user, isPersistent: false);
            _context.login!.Add(userlogin);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            
               return View(userlogin);

        }
       
        public async Task<IActionResult> Profile(string? username)
        {
          /*  var user = await _context.login.FindAsync(username);*/
            var user = await _context.login.FirstOrDefaultAsync(u => u.username == username);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Register(Userlogin model, IFormFile imageFile)
         {
             {
                 if (model.Password == model.ConfirmPassword)
                 {
                     // Process the uploaded image file
                     byte[] imageData = null;
                     if (imageFile != null && imageFile.Length > 0)
                     {
                         using (var memoryStream = new MemoryStream())
                         {
                             await imageFile.CopyToAsync(memoryStream);
                             imageData = memoryStream.ToArray();
                         }
                     }

                     // Create a new user instance
                     var user = new Userlogin
                     {
                         firstname = model.firstname,
                         lastname = model.lastname,
                         username = model.username,
                         Password = model.Password, // You may want to hash the password before storing
                         ConfirmPassword=model.ConfirmPassword,
                         img = imageData
                     };

                     // Save the user data to the database
                     _context.login.Add(user); // Assuming you have a 'Users' table in your database context
                     await _context.SaveChangesAsync();

                     // Redirect to a success page or perform additional logic
                     return RedirectToAction("SuccessPage", "Index");
                 }
                 else
                 {
                     ModelState.AddModelError("", "Passwords do not match.");
                 }
             }
             // If there are validation errors, return the view with the model errors
             return View(model);
         }
 */
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logins()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logins(loginfirst user)
        {
            if (ModelState.IsValid)
            {
           /*     var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);*/
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}
