using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using NLayerLibrary.BLL.Interfaces;
using NLayerLibrary.BLL.DTO;
using NLayerLibrary.BLL.Infrastructure;
using NLayerLibrary.BLL.Services;
using NLayerLibrary.DAL.Entities;

namespace NLayerLibrary.Web.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        BookService bookService;

        public BookController(BookService service)
        {
            bookService = service;
        }

        [HttpGet]
        public Task<IndexViewModel> GetBook(int page=1,int pagesize=3)
        {
            return bookService.GetAll(page,pagesize); 
        }

        [HttpGet("get-by-id/{id}")]
        
        public Book GetBookById(int id)
        {
            return bookService.GetById(id);
        }

        [HttpGet("/get-by-isbn/{ISBN}")]
        public Book GetByISBN(string ISBN)
        {
            return bookService.GetByISBN(ISBN);
        }

        [HttpPut("{id}")]
        public Book PutBook(int id,BookDTO bookDTO)
        {
            return bookService.Update(id, bookDTO);
        }

        [HttpPost]
        public Book CreateBook(BookDTO bookDTO)
        {
            return bookService.Create(bookDTO);
        }

        [HttpDelete]
        public Book DeleteBook(int id)
        {
            return bookService.Delete(id);
        }
    }
}
