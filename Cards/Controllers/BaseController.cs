using Cards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cards.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Context _context = null;

        protected SetRepository SetRepository { get; set; }
        protected CardRepository CardRepository { get; set; }
        protected SubjectRepository SubjectRepository { get; set; }

        public BaseController()
        {
            _context = new Context();
            SetRepository = new SetRepository(_context);
            CardRepository = new CardRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
        }

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}