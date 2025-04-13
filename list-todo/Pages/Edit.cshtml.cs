using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly TodoContext _context;

        public EditModel(TodoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TodoItem = await _context.TodoItems.FindAsync(id);
            if (TodoItem == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(TodoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
