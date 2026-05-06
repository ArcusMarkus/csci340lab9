using csci340lab9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace csci340lab9.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly csci340lab9.Data.SchoolContext _context;

        public CreateModel(csci340lab9.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                 emptyCourse,
                 "course",   // Prefix for form value.
                 s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Repopulate departments dropdown. emptyCourse.DepartmentID determines the selected item.
            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
      }
}