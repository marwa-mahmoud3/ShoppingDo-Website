using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web
{
    [HubName("MyHub")]
    public class MyHub : Hub
    {
        ApplicationDbContext context = new ApplicationDbContext();
        AccountAppService accountAppService = new AccountAppService();
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        [HubMethodName("Add")]
        public void Add(string name, string msg)
        {
            string connect = Context.ConnectionId;
            Clients.All.NewUserAdded(name, msg);
        }
        [HubMethodName("ProductComment")]
        public void ProductComment(string name, string comment, int productId)
        {
            Clients.All.Comment(name, comment, productId);
        }
        [HubMethodName("ChangeQuantity")]
        public void ChangeQuantity(int quantity, int id,int value)
        {
            quantity-=value;
            Clients.All.DecreaseQuantity(quantity, id,value);
            var result = context.Products.SingleOrDefault(b => b.ID == id);
            if (result != null)
            {
                result.Quantity = quantity;
                context.SaveChanges();
            }
        }

    }
}