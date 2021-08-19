using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebProject.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TestWebProject.Controllers
{
    public abstract class _CommonController<T> : Controller where T : _CommonController<T>
    {
        private OrderContext _context;

        protected OrderContext Context => _context ??= HttpContext.RequestServices.GetService<OrderContext>();
    }
}
