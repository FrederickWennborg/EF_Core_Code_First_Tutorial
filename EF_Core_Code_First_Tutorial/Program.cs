using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Data;
using EF_Core_Code_First_Tutorial.Entities;
using EF_Core_Code_First_Tutorial.Menus;
using EF_Core_Code_First_Tutorial.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Channels;

namespace EF_Core_Code_First_Tutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = DataInitializer.Build())
            {
                DataInitializer.InitializeData(dbContext);
                var menu = new Menu(dbContext);
                menu.Start();

            }
        }
    }

}
