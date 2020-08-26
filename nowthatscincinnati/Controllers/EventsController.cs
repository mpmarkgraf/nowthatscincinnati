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
            Events detailsEvent = _context.Events.Where(e => e.Id == id).Include(e => e.Image).FirstOrDefault();
            return PartialView(detailsEvent);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,Date,Venue,Description,VenueLink,FacebookLink,Upload")] Events newEvent)
        {
            //if (!ModelState.IsValid) // Fix this later
            //{
            //    return PartialView();
            //}

            try
            {
                newEvent.ImageId = UploadImage(newEvent.Upload);

                _context.Add(newEvent);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            Events editEvent = _context.Events.Where(e => e.Id == id).Include(e => e.Image).FirstOrDefault();
            return PartialView(editEvent);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Title,ImageId,Date,Venue,Description,VenueLink,FacebookLink,UserId,Upload")] Events editEvent)
        {
            try
            {
                // If Image isn't updated, only update Event
                if (editEvent.Upload != null)
                {
                    if (editEvent.ImageId != 3)
                        UpdateImage(editEvent.ImageId, editEvent.Upload);
                    else
                        editEvent.ImageId = UploadImage(editEvent.Upload);
                    
                }

                _context.Events.Update(editEvent);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            Events deleteEvent = _context.Events.Where(e => e.Id == id).Include(e => e.Image).FirstOrDefault();
            return PartialView(deleteEvent);
        }

        // POST: Events/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost([Bind("Id,ImageId")] Events deleteEvent)
        {
            try
            {
                _context.Events.Remove(deleteEvent);
                _context.SaveChanges();

                // If image is the default image, don't delete. Change to 1 for Production database
                if (deleteEvent.ImageId != 3)
                {
                    Images image = new Images() { Id = deleteEvent.ImageId };
                    _context.Images.Remove(image);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        private int UploadImage(IFormFile file)
        {
            if (file != null)
            {
                try
                {

                    Images image = new Images
                    {
                        FileName = file.FileName,
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

                }
            }

            return 3; //  Change to 1 for Production database
        }

        private void UpdateImage(int id, IFormFile file)
        {
            Images image = _context.Images.Find(id);

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    image.Stream = ms.ToArray();
                }

                _context.Images.Update(image);
            }
        }
    }
}
