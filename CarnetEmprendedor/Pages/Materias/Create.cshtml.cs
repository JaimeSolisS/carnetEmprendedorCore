﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarnetEmprendedor.Data;

namespace CarnetEmprendedor.Pages.Materias
{
    public class CreateModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;

        public CreateModel(CarnetEmprendedor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Materia Materia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Materia.Add(Materia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}