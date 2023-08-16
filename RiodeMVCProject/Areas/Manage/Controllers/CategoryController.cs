﻿using Microsoft.AspNetCore.Mvc;
using RiodeMVCProject.Services.Interfaces;

namespace RiodeMVCProject.Areas.Manage.Controllers;

[Area("Manage")]

public class CategoryController : Controller
{
    readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult>  Index()
    {
        return View(await _categoryService.GetAll());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) return BadRequest();
        await _categoryService.Create(name);
        return RedirectToAction(nameof(Index));
    }

}
