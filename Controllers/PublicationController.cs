using Board.Core.Models;
using Board.Core.Models.Domains;
using Board.Core.Service;
using Board.Core.ViewModels;
using Board.Persistence.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace Board.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly ICategoryService _categoryService;
        private readonly IFileModelService _fileModelService;
        private UserManager<ApplicationUser> _userManager;
     


        public PublicationController(IPublicationService publicationService,
                                      ICategoryService categoryService, 
                                      IFileModelService fileModelService, 
                                      UserManager<ApplicationUser> userManager)
                                     
        {
            _publicationService = publicationService;
            _categoryService = categoryService;
            _fileModelService = fileModelService;
            _userManager= userManager;
            
        }



        [AllowAnonymous]
        public IActionResult PublicationsAll()
        {
           
            var tupleList = new Tuple<int, string>(0, "");

            var imagesFromFiles = new List<Tuple<int, string>>();

            var vm = new PublicationsViewModel();

            

            foreach (var item in _publicationService.GetAll())
            {
                
                
                    var pubId = item.Id;
                    var userId = item.UserId;

                    var ImagesPublication = _fileModelService.GetImages(userId, pubId);
                    foreach (var image in ImagesPublication)
                    {

                        tupleList = Tuple.Create(pubId, image);
                        imagesFromFiles.Add(tupleList);

                    }

                    vm.FilterPublications = new FilterPublications();
                    vm.Publications = _publicationService.GetAll();
                    vm.Categories = _categoryService.Get();
                    vm.ImagesFromFiles = imagesFromFiles;
                    

                
               
            }

            return View(vm);
        }
        public IActionResult Publications()
        {
            var userId = User.GetUserId();
            var tupleList = new Tuple<int, string>(0, "");
           
            var imagesFromFiles = new List<Tuple<int,string>>();

            foreach (var item in _publicationService.Get(userId))
            {
                var pubId = item.Id;
              

                var ImagesPublication = _fileModelService.GetImages(userId, pubId);
                foreach (var image in ImagesPublication)
                {

                    tupleList = Tuple.Create(pubId, image);
                    imagesFromFiles.Add(tupleList);

                }

            }

            var vm = new PublicationsViewModel
            {
                FilterPublications = new FilterPublications(),
                Publications = _publicationService.Get(userId),
                Categories = _categoryService.Get(),
                ImagesFromFiles=imagesFromFiles

            };


            return View(vm);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult PublicationsAll(PublicationsViewModel viewModel)
        {
      
            var tupleList = new Tuple<int, string>(0, "");

            var imagesFromFiles = new List<Tuple<int, string>>();

            var publications = _publicationService.GetAll(viewModel.FilterPublications.Title,
                                            viewModel.FilterPublications.CategoryId);
                                            

          

            foreach (var item in _publicationService.GetAll())
            {
                var pubId = item.Id;
                var userId = item.UserId;
                var ImagesPublication = _fileModelService.GetImages(userId, pubId);
                foreach (var image in ImagesPublication)
                {

                    tupleList = Tuple.Create(pubId, image);
                    imagesFromFiles.Add(tupleList);

                }

            }

            var vm = new PublicationsViewModel
            {
                FilterPublications = new FilterPublications(),
                Publications = publications,
                Categories = _categoryService.Get(),
                ImagesFromFiles = imagesFromFiles

            };

            return PartialView("_PublicationsAllTable", vm);
        }

        [HttpPost]
        public IActionResult Publications(PublicationsViewModel viewModel)
        {
            var userId = User.GetUserId();
            
            var imagesFromFiles = new List<Tuple<int, string>>();


            var publications = _publicationService.Get(userId,
                                            viewModel.FilterPublications.Title,
                                            viewModel.FilterPublications.CategoryId,
                                            viewModel.FilterPublications.IsExecuted);

            foreach (var item in _publicationService.Get(userId))
            {
                var pubId = item.Id;

                var ImagesPublication = _fileModelService.GetImages(userId, pubId);
                foreach (var image in ImagesPublication)
                {

                   var tupleList = Tuple.Create(pubId, image);
                    imagesFromFiles.Add(tupleList);

                }

            }

            var vm = new PublicationsViewModel
            {
                FilterPublications = new FilterPublications(),
                Publications = publications,
                Categories = _categoryService.Get(),
                ImagesFromFiles = imagesFromFiles

            };

            return PartialView("_PublicationsTable", vm);
        }

        public IActionResult Publication(int id )
        {
            var userId = User.GetUserId();
            var publication = new Publication();
            var filesList = new List<string>();
            

            if (id == 0)
            {
                new Publication { Id = 0, UserId = userId, PublicationDate = DateTime.Today };
            }
            else
            {
               publication= _publicationService.Get(id, userId);
               filesList= _fileModelService.GetImages(userId, id);
               
            }

            var vm = new PublicationViewModel
            {
                Publication = publication,
                Heading = id == 0 ? "Dodawanie nowego zadania" : "Edytowanie ogłoszenia",
                Categories = _categoryService.Get(),
               FilesList=filesList

            };

            vm.CategoriesList = new List<SelectListItem>();
           var CategoriesData = _categoryService.Get();
           

            foreach (var category in CategoriesData)
            {
                vm.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = (category.Id).ToString() });
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Publication(PublicationViewModel viewModel)
        {
            var userId = User.GetUserId();
            viewModel.Publication.UserId = userId;
            var id = viewModel.Publication.Id;
           
            var listImages= _fileModelService.IFileModelToFileModel(viewModel.FileModels,  id);

            var FilesList = new List<string>();

            foreach (var image in listImages)
            {

                var myImageBase64 = Convert.ToBase64String(image.DataFiles);
                FilesList.Add(myImageBase64);

            }
           


            ModelState.ClearValidationState("FileModels");
            ModelState.MarkFieldValid("FileModels");
            if (!ModelState.IsValid)
                {
          
                var vm = new PublicationViewModel
                    {
                        Publication = viewModel.Publication,
                        Heading = viewModel.Publication.Id == 0 ? "Dodawanie nowego ogłoszenia" : "Edytowanie ogłoszenia",
                        FilesList = FilesList
                    };

                    vm.CategoriesList = new List<SelectListItem>();
                    var CategoriesData = _categoryService.Get();

                    foreach (var category in CategoriesData)
                    {
                        vm.CategoriesList.Add(new SelectListItem { Text = category.Name, Value = (category.Id).ToString() });
                    }

                    return View("Publication", vm);
                }


            if (viewModel.Publication.Id == 0)
            {
                _publicationService.Add(viewModel.Publication);
                var publicatioId = viewModel.Publication.Id;
                _fileModelService.AddImages(viewModel.FileModels, publicatioId);

            }
            else
            {
                viewModel.FilesList = FilesList;
                _publicationService.Update(viewModel);
                _fileModelService.AddImages(viewModel.FileModels, id);

            }


            return RedirectToAction("Publications");
        }

        public IActionResult SendInfo(int id)
        {
      

            if (!User.Identity.IsAuthenticated)
                {
                    RedirectToAction("_LoginPartial");
                }

           
            var publication = _publicationService.Get(id);
            var userIdOfPublication = publication.UserId;
            var publicationOwnerEmail = GetUser(userIdOfPublication);
         
            
            var vm = new PublicationViewModel
            {
             Publication= new Publication
              {
                 Title=publication.Title,
                 User = new ApplicationUser { Email = publicationOwnerEmail.Email }
             }
               
            };
            return View(vm);
           
           
        }
        [HttpPost]
        public IActionResult SendInfo(PublicationViewModel viewModel)
        {
            var senderId = User.GetUserId();
            var senderEmail = GetUser(senderId).Email;
            string recipient = viewModel.Publication.User.Email;
            string subject = viewModel.Publication.Title;
            string body = viewModel.Info;

            SmtpClient smtp = new SmtpClient();

             smtp.Port = 465;
            smtp.Host = "smtp.wp.pl";
            smtp.EnableSsl = true;
           

            NetworkCredential credential = new NetworkCredential();
            credential.UserName= "tomaszgaltest@wp.pl";
            credential.Password= "Skier96100?";
            smtp.Credentials = credential;

         
                
                smtp.Send("tomaszgaltest@wp.pl", recipient, subject, body);
                smtp.Dispose();
          

            return RedirectToAction("PublicationsAll");

        }

      
       

        public ApplicationUser GetUser(string userid)
        {
            
           
            var user = _userManager.FindByIdAsync(userid);
            var usermail = user.Result;
            return usermail;
        }

        public IActionResult Categories()
        {
           
            var categories = _categoryService.Get();
            return View(categories);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _publicationService.Delete(id, userId);

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }


        public IActionResult Publish(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _publicationService.Publish(id, userId);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }
        public IActionResult Remove(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _publicationService.Remove(id, userId);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        public IActionResult RemovePicture(int id, int picNumber)
        {
            try
            {
                var userId = User.GetUserId();
                _fileModelService.RemovePicture( userId,id,picNumber);

               
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }
    }
}

