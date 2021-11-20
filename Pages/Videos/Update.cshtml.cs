using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using YoutubeVideos.Models;
using QuickDBS;

namespace YoutubeVideos.Pages
{
    public class VideoUpdateModel : PageModel
    {
        private readonly IQuickDBS db;

        [BindProperty]
        public Video Model { get; set; }

        public string errorMessage { get;set; } = string.Empty;

        public VideoUpdateModel(IQuickDBS _db)
        {
            db = _db;
        }

        public IActionResult OnGet(long Id) {
            Model = db.GetById<Video>(Id);
            if (Model == null)
                return RedirectToPage("/Videos");
            else
                return Page();
        }

        public IActionResult OnPost(long Id) {
            if (!ModelState.IsValid)
                return Page();
            
            try {               
                if (Model != null)            
                {
                    Model.Id = (int)Id;       
                    var result = db.UpdateById<Video>(Model);
                    if (result)
                        return RedirectToPage("/Videos/Index");
                    else
                    {
                        errorMessage += "Updation failed. Please try again.";
                        return Page();      
                    }
                }              
                else
                {
                    errorMessage += "Model not valid for updation.";
                    return Page();      
                }
            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
                return Page();  
            }
        }
    }
}