using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using YoutubeVideos.Models;
using QuickDBS;

namespace YoutubeVideos.Pages
{
    public class VideoAddModel : PageModel
    {
        private readonly IQuickDBS db;

        [BindProperty]
        public Video? Model { get; set; }

        public string errorMessage { get;set; } = string.Empty;

        public VideoAddModel(IQuickDBS _db)
        {
            db = _db;
        }

        public void OnGet() {
            errorMessage = string.Empty;
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid)
                return Page();
            
            try {
                db.Create<Video>(Model);
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return Page();
            }            
        }
    }
}