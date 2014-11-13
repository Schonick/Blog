using SportClub.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportClub.Controllers
{
    public class UploadFileController : Controller
    {
        private ModelContext db = new ModelContext();
        //
        // GET: /UploadFile/

        public ActionResult Index()
        {
            return View(db.UploadFile.ToList());
        }

        public ActionResult ADDFile()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult ADDFile(HttpPostedFileBase[] fileUpload,UploadFile UpFile)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in fileUpload)
                {
                    if (file == null) continue;
                    var uploadDir = "/Content/UploadFile/";
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(uploadDir) + fileName);
                    if (fileName != null) file.SaveAs(path);
                    UpFile.PatchToFile = "/Content/UploadFile/" + fileName;
                    db.UploadFile.Add(UpFile);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(UpFile);
        }
    }
}
