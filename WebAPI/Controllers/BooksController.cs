﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _bookservice;

        public BooksController(IBookService bookService)
        {
            _bookservice = bookService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_bookservice.GetAll());
        }
    }
}
