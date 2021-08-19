using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestWebProject.Models.Entities;
using TestWebProject.Extension;
using TestWebProject.Extension.Enums;

namespace TestWebProject.Controllers
{
    public class OrderController : _CommonController<OrderController>
    {
        public async Task<IActionResult> Index()
        {
            return View(await Context.Orders.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);

            if (order == null)
            {
                order = new Order();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,SenderСity,SenderAddress,RecipientСity,AddressRecipient,CargoWeight,DateOfReceiving")] Order order)
        {
            if (ModelState.IsValid)
            {
                var orderExist = await Context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);

                if (orderExist == null)
                {
                    await Context.AddAsync(order);
                }
                else
                {
                    orderExist.SenderСity = order.SenderСity;
                    orderExist.SenderAddress = order.SenderAddress;
                    orderExist.RecipientСity = order.RecipientСity;
                    orderExist.AddressRecipient = order.AddressRecipient;
                    orderExist.CargoWeight = order.CargoWeight;
                    orderExist.CargoWeight = order.DateOfReceiving.Year;

                    Context.Update(orderExist);
                }
                await Context.SaveChangesAsync();

                this.NotifyMessage(MessageType.Success, "Запись добавлена.");
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();

            this.NotifyMessage(MessageType.Success, "Запись удалена.");

            return RedirectToAction(nameof(Index));
        }
    }
}
