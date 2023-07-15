using BulyWebRazor_Temp.Data;
using BulyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace BulyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
     
        public Category CategoryList { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                CategoryList = _db.Categories.Find(id);
            }
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) //Validation from model
            {

                _db.Categories.Update(CategoryList);
                _db.SaveChanges();               //Writes in Db
                TempData["Success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

