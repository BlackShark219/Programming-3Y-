using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using TestMVC.Models.ViewModels;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        Photo_GalleryEntities6 db = new Photo_GalleryEntities6();

        static int GalleryNumber=0;
        static int PictureNumber = 0;
        static bool LoggedIN = false;
        public ActionResult Index(int? ID)
        {   
            var user = db.Users.Where(x => x.ID == ID).FirstOrDefault();
            var gall = db.GALLERY_LIST.OrderBy(x => x.Gallery_Number);
            ViewBag.Gall = gall;
            ViewBag.LoggedIN = LoggedIN;
            if (ID == null)
            {
                return View(new User());
            }
            else
            {              
                return View(user);
            }

        }

        public ActionResult Quit()
        {
            LoggedIN = false;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DisplayGal(int id)
        {
            var gall = db.GALLERY_LIST.Where(g => g.ID == id).FirstOrDefault();
            ViewBag.Pictures = db.PICTURE_LIST.Where(x => x.Gallery_ID == gall.Gallery_Number).OrderBy(x=>x.Picture_Number);
            ViewBag.LoggedIN = LoggedIN;
            return View(new ViewModelUpload() {Galname=gall.Gallery_Name,GalNum=gall.Gallery_Number,GalID=gall.ID});
           
        }


        private void WriteToLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\WORK\log.txt", true))
            {
                sw.WriteLine(DateTime.Now + " | " + message);
            }
        }

        public ActionResult Validate(string login, string password)
        {   
            Object[] inf;
            
            var users = db.Users;
            foreach (var x in users)
            {
                if (x.Login == login && x.Password == password)
                {
                    LoggedIN = true;
                    inf = new Object[] { x.ID, true};
                    WriteToLog("in if");
                    return Json(inf, JsonRequestBehavior.AllowGet);

                }
            }
            LoggedIN = false;
            inf = new Object[] { false };
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddGalery(string Galname)
        {
            Object[] inf;
            if (db.GALLERY_LIST.Count()!=0)
            {
                GalleryNumber = db.GALLERY_LIST.Select(x => x.Gallery_Number).Max();
                GalleryNumber++;
            }

            var d = db.GALLERY_LIST.Select(x =>x.Gallery_Name).ToList();
            if (d.Contains(Galname))
            {
                inf = new Object[] { false };
                return Json(inf, JsonRequestBehavior.AllowGet);
            }
            else
            {

                GALLERY_LIST t = new GALLERY_LIST()
                {
                    Gallery_Name = Galname,
                    Gallery_Number = GalleryNumber++,
                };
                db.GALLERY_LIST.Add(t);
                db.SaveChanges();
                var c = db.GALLERY_LIST.Select(x => x.Gallery_Number).ToArray();
                Array.Sort(c);
                inf = new Object[] { true, t.ID, c,t.Gallery_Number};

                return Json(inf, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult DeleteGal(int id)
        {
            var delgall = db.GALLERY_LIST.FirstOrDefault(g => g.ID == id);
            var delpic = db.PICTURE_LIST.Where(g => g.Gallery_ID == delgall.Gallery_Number).ToList();
            foreach (var x in delpic)
            {
                db.PICTURE_LIST.Remove(x);
            }
            db.GALLERY_LIST.Remove(delgall);
            db.SaveChanges();
            string inf = "Gallery was deleted";
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UPGal(int id, int previd)
        {
            var upgall = db.GALLERY_LIST.Where(g => g.ID == id).FirstOrDefault();
            var prevgall = db.GALLERY_LIST.Where(g => g.ID == previd).FirstOrDefault();
            upgall.Gallery_Number -= 1;
            prevgall.Gallery_Number += 1;
            db.SaveChanges();
            Object[] inf = new Object[] { upgall.Gallery_Number, prevgall.Gallery_Number };
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DOWNGal(int id, int nid)
        {
            var upgall = db.GALLERY_LIST.Where(g => g.ID == id).FirstOrDefault();
            var ngall = db.GALLERY_LIST.Where(g => g.ID == nid).FirstOrDefault();
            upgall.Gallery_Number += 1;
            ngall.Gallery_Number -= 1;
            db.SaveChanges();
            Object[] inf = new Object[] { upgall.Gallery_Number,ngall.Gallery_Number};
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Upload(ViewModelUpload info,HttpPostedFileBase image)
        {   
            if(db.PICTURE_LIST.Count()!= 0)
            {
                PictureNumber = db.PICTURE_LIST.Select(x => x.Picture_Number).Max();
                PictureNumber++;
            }
            var picture = new PICTURE_LIST();
            if (image != null)
            {
                using (MemoryStream target = new MemoryStream())
                {   
                    image.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    var Format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    picture.Full_Version = data;
                    picture.Picture_Number = PictureNumber++;
                    picture.Description = info.Description;
                    picture.Gallery_ID = info.GalNum;
                    Image thumbnail = Image.FromStream(target).GetThumbnailImage(200, 150, null, IntPtr.Zero);
                    using (var ms = new MemoryStream())
                    {
                        thumbnail.Save(ms,Format);
                        picture.Mini_Version = ms.ToArray();
                    }
                }
            }
            db.PICTURE_LIST.Add(picture);
            db.SaveChanges();
            return RedirectToAction("DisplayGal", "Home",new {id=info.GalID});
        }

        public ActionResult ShowMini(int id)
        {
            var imageData = db.PICTURE_LIST.Where(d => d.ID == id).Select(m => m.Mini_Version).FirstOrDefault();
            return File(imageData, "image/jpg");
        }
        
        public ActionResult DisplayFull(int id)
        {
            ViewBag.ButtonN = true;
            ViewBag.ButtonP = true;
            var Pic = db.PICTURE_LIST.FirstOrDefault(x => x.ID == id);
            var Gal = db.GALLERY_LIST.FirstOrDefault(x=>x.Gallery_Number==Pic.Gallery_ID);
            ViewBag.GalID = Gal.ID;
            var list = db.PICTURE_LIST.OrderBy(x => x.Picture_Number).ToList();
            var nextId = list.IndexOf(db.PICTURE_LIST.Where(x => x.ID == id).FirstOrDefault()) + 1;
            var prevId = list.IndexOf(db.PICTURE_LIST.Where(x => x.ID == id).FirstOrDefault()) - 1;
            if (list.IndexOf(db.PICTURE_LIST.Where(x => x.ID == id).FirstOrDefault()) != 0)
            {
                ViewBag.Prev = list[prevId].ID;
            }
            else
            {
                ViewBag.ButtonP = false;
            }
            if (nextId < list.Count())
            {
                ViewBag.Next = list[nextId].ID;
            }
            else
            {
                ViewBag.ButtonN = false;
            }
            ViewBag.ID = id;
            return View();
        }
        public ActionResult ShowFull(int id)
        {
            var imageData = db.PICTURE_LIST.Where(d => d.ID == id).Select(m => m.Full_Version).FirstOrDefault();
            return File(imageData, "image / jpg");
        }
        public ActionResult DeletePic(int id)
        {
            var delpic = db.PICTURE_LIST.Where(g => g.ID == id).FirstOrDefault();
            db.PICTURE_LIST.Remove(delpic);
            db.SaveChanges();
            string inf = "Picture was deleted";
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UPPic(int id, int previd)
        {
            var uppic = db.PICTURE_LIST.Where(g => g.ID == id).FirstOrDefault();
            var prevpic = db.PICTURE_LIST.Where(g => g.ID == previd).FirstOrDefault();
            uppic.Picture_Number -= 1;
            prevpic.Picture_Number += 1;
            db.SaveChanges();
            Object[] inf = new Object[] { uppic.Picture_Number, prevpic.Picture_Number };
            return Json(inf, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DOWNPic(int id, int nid)
        {
            var upgall = db.PICTURE_LIST.Where(g => g.ID == id).FirstOrDefault();
            var ngall = db.PICTURE_LIST.Where(g => g.ID == nid).FirstOrDefault();
            upgall.Picture_Number += 1;
            ngall.Picture_Number -= 1;
            db.SaveChanges();
            Object[] inf = new Object[] { upgall.Picture_Number, ngall.Picture_Number };
            return Json(inf, JsonRequestBehavior.AllowGet);
        }
    }
}