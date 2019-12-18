using SMS_Sender.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SMS_Sender.Controllers
{
    public class get_profile_imagesController : ApiController
    {
        [HttpPost]

        public async Task<HttpResponseMessage> Post(int memid, int addedby)
        {
            Mem_Images images = new Mem_Images();
            mrmdbEntities db = new mrmdbEntities();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            //WebClient web = new WebClient();

                            //NetworkCredential nc = new NetworkCredential("zeeshanh184@gmail.com", "Mypass123");

                            //Uri addy = new Uri(@"https://coachacademy.000webhostapp.com/Images/");

                            //web.Credentials=nc;
                            //byte[] arrReturn = web.UploadFile(addy, httpRequest.Files[file].FileName.ToString());

                            var filePath = HttpContext.Current.Server.MapPath("~/FileAtts_Profile/" + memid + "_" + postedFile.FileName + extension);

                         //   var filePath = HttpContext.Current.Server.MapPath("https://coachacademy.000webhostapp.com/Images/" + memid + "_" + postedFile.FileName + extension);
                     
                            postedFile.SaveAs(filePath);
                           

                            images.MemId = memid;
                            images.ImgName = memid + "_" + postedFile.FileName;
                            images.ImgStatusId = 1;
                            images.AddedBy = addedby;
                            images.AddedOn = DateTime.Now;
                            images.UpdateBy = images.AddedBy;
                            images.UpdateOn = DateTime.Now;
                            images.isDel = false;

                            db.Mem_Images.Add(images);
                            db.SaveChanges();

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }  
        }

        //private void SaveFilePathSQLServerEF(
        //  string localFile, string filePath)
        //{
        //    // 1) Move file to folder
        //    File.Move(localFile, filePath);

        //    // 2) Create a File Location object
        //    //var fl = new FileLocation()
        //    //{
        //    //    FilePath = filePath
        //    //};

        //    // 3) Add and save it in database
        //    using (var db = new mrmdbEntities())
        //    {
        //        db.FileLocations.Add(fl);

        //        db.SaveChanges();
        //    }

        //}


    }
}
