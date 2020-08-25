using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nowthatscincinnati.Models;

namespace nowthatscincinnati.Controllers
{
    public class EventsController : Controller
    {
        private nowthatscincinnatiContext _context;

        public EventsController(nowthatscincinnatiContext context)
        {
            _context = context;
        }

        // GET: Events
        public ActionResult Index()
        {
            var events = _context.Events.Include(e => e.Image);

            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,Date,Venue,Description,VenueLink,FacebookLink,Upload")] Events newEvent)
        {
            try
            {
                newEvent.ImageId = UploadImage(newEvent.Upload);

                _context.Add(newEvent);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int UploadImage(IFormFile file)
        {
            try
            {
                Images image = new Images
                {
                    Name = file.FileName,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        image.Stream = ms.ToArray();
                    }
                }

                _context.Images.Add(image);
                _context.SaveChanges();

                return image.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
