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

        protected SetRepository Repository { get; set; }

        public BaseController()
        {
            _context = new Context();
            Repository = new SetRepository(_context);
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