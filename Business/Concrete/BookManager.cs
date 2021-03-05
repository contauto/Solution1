using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework;
using System.Linq;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookdal;

        public BookManager(IBookDal bookDal)
        {
            _bookdal = bookDal;
        }


        public void Add(Book book)
        {
            if (_bookdal.Get(b => b.Name == book.Name&&b.AuthorId==book.AuthorId) == null)
            {
                _bookdal.Add(book);
            }
            else { throw new Exception("Bu kitap adı zaten mevcut"); }
            
        }

        public void Delete(Book book)
        {
            _bookdal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookdal.GetList().ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return _bookdal.GetList(b => b.AuthorId == id).ToList();
        }

        public Book GetById(int id)
        {
            return _bookdal.Get(b => b.Id == id);
        }

        public void Update(Book book)
        {
            _bookdal.Update(book);
        }
    }
}
