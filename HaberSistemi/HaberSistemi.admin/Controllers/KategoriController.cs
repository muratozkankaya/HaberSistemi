using HaberSistemi.admin.Class;
using HaberSistemi.Core.Infrastructure;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.admin.Controllers
{
    public class KategoriController : Controller
    {
        #region Kategori
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        #endregion
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(_kategoriRepository.GetAll().ToList());
        }
        #region Kategori Ekle
        [HttpGet]
        public ActionResult Ekle()
        {
            SetKategoriListele();
            return View();
            
        }
        
        [HttpPost]
       public JsonResult Ekle(Kategori kategori)
        {
            try
            {
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori Ekleme İşleminiz Başarılı" });
            }
            catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Kategori Eklerken Hata Oluştu!!" });

            }
            
        }
        #endregion


        #region Set Kategori
        public void SetKategoriListele()
        {
            var KategoriList = _kategoriRepository.GetMany(x => x.ParentID == 0).ToList();
            ViewBag.Kategori = KategoriList;
        }
        #endregion
    }
}