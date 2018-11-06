using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarnetEmprendedor.Data;
using Microsoft.AspNetCore.Hosting;
using CarnetEmprendedor.Pages.ViewModel;
using System.IO;
using CarnetEmprendedor.Utility;

namespace CarnetEmprendedor.Pages.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly CarnetEmprendedor.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(CarnetEmprendedor.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment; 
        }

        public IActionResult OnGet()
        {
            ViewData["CategoriaEventoId"] = new SelectList(_context.Categoria, "Id", "CategoriaEvento");
              return Page();
           /* EventoVM = new EventoViewModel
            {
                Evento = new Evento(),
                Categoria = _context.Categoria.ToList()
            };
            return Page(); */

        }

       [BindProperty]
        public Evento Evento { get; set; }

        [BindProperty]
        public EventoViewModel EventoVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Evento.Add(Evento);
            await _context.SaveChangesAsync();

            //Image being saved
            string webRoothPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var eventoFromDb = _context.Evento.Find(Evento.Id); 

            if(files[0] != null && files[0].Length > 0)
            {
                var uploads = Path.Combine(webRoothPath, "images");
                var extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));

                using (var fileStream = new FileStream(Path.Combine(uploads, Evento.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                eventoFromDb.Imagen = @"\images\" + Evento.Id + extension;
            }
            else
            {
                var uploads = Path.Combine(webRoothPath, @"\images\" + SD.DefaultEventImage);
                System.IO.File.Copy(uploads, webRoothPath + @"\images\" + Evento.Id + ".jpg");
                eventoFromDb.Imagen = @"\images\" + Evento.Id + ".jpg";
            }
            await _context.SaveChangesAsync();



            return RedirectToPage("./Index");
        }
    }
}