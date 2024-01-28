using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncomentDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncomentController : Controller
    {
        private readonly IAnnouncomentService _announcomentService;
        private readonly IMapper _mapper;

        public AnnouncomentController(IAnnouncomentService announcomentService, IMapper mapper)
        {
            _announcomentService = announcomentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //List<Announcoment> announcoments = _announcomentService.TGetList();
            //List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
            //foreach( var item in announcoments)
            //{
            //    AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
            //    announcementListViewModel.ID = item.AnnouncomentID;
            //    announcementListViewModel.Title = item.Title;
            //    announcementListViewModel.Content = item.Content;

            //    model.Add(announcementListViewModel);

            //}
            //return View(model);
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcomentService.TGetList());
            return View(values);
            
            
        }

        [HttpGet]
        public IActionResult AddAnnouncoment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncoment(AnnouncomentAddDto model)
        {
            if(ModelState.IsValid)
            {
                _announcomentService.TAdd(new Announcoment()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcomentService.TGetByID(id);
            _announcomentService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_announcomentService.TGetByID(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcomentService.TUpdate(new Announcoment
                {
                    AnnouncomentID = model.AnnouncomentID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
