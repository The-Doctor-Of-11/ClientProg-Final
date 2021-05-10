﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;

namespace Project3_FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetFaculty _facultyRepository;
        private readonly IGetStaff _staffRepository;

        public HomeController(IGetFaculty facultyRepository, IGetStaff staffRepository)
        {
            _facultyRepository = facultyRepository;
            _staffRepository = staffRepository;
        }

        public async Task<IActionResult> Index()
        {
            var getAbout = new GetAbout();
            var about = await getAbout.GetAboutInfo();
            var homeViewModel = new HomeViewModel()
            {
                AboutInfo = about,
                Title = "Welcome to the iSchool Home Page!"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> GetFaculty()
        {
            var allFaculty = await _facultyRepository.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var homeViewModel = new HomeViewModel()
            {
                Faculty = allFaculty.ToList(),
                Title = "This is your Faculty"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> GetStaff()
        {
            var allStaff = await _staffRepository.GetAllStaff();
            var sortedStaff = allStaff.OrderBy(s => s.username);
            var homeViewModel = new HomeViewModel()
            {
                Staff = allStaff.ToList(),
                Title = "This is your Staff"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> Under()
        {
            var getUnder = new GetUndergraduate();
            var under = await getUnder.GetUnderGradDegrees();
            var underViewModel = new UndergradViewModel()
            {
                UnderGrads = under,
                Title = "Undergraduate Programs"
            };
            return View(underViewModel);
        }

        public async Task<IActionResult> Grad()
        {
            var getGrad = new GetGraduate();
            var grad = await getGrad.GetGradDegrees();
            var gradViewModel = new GradViewModel()
            {
                Grads = grad,
                Title = "Graduate Programs"
            };
            return View(gradViewModel);
        }

        public async Task<IActionResult> GetMinors()
        {
            var getMinors = new GetMinors();
            var minors = await getMinors.GetAllMinors();
            var minorsViewModel = new MinorsViewModel()
            {
                Minors = minors,
                Title = "Minors"
            };
            return View(minorsViewModel);

        }

        public async Task<IActionResult> GetEmploymentTable()
        {
            var getEmploy = new GetEmployment();
            var employTable = await getEmploy.GetEmploymentTable();
            var employTableViewModel = new EmploymentTableViewModel()
            {
                employmentTable = employTable,
                Title = "Employment Table"
            };
            return View(employTableViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
