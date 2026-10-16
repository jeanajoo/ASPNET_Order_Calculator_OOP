using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Joo_Jeana_HW2.Models;

namespace Joo_Jeana_HW2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public ViewResult CheckoutGroup()
        {
            return View();
        }
    [HttpPost]
    public IActionResult GroupTotals(GroupOrder groupOrder)
    {
        // Requirement 1c: Must buy at least one shirt
        if (groupOrder.NumberOfSweatshirts + groupOrder.NumberOfTShirts == 0)
        {
            ModelState.AddModelError("", "You must order at least one item!");
        }

        if (!ModelState.IsValid)
        {
            return View("CheckoutGroup", groupOrder);
        }

        groupOrder.CustomerType = CustomerTypeEnum.Group;
        groupOrder.CalcTotals();
        return View(groupOrder);
    }
    public IActionResult CheckoutIndividual()
    {
        return View();
    }   
    [HttpPost]
    public IActionResult IndividualTotals(IndividualOrder individualOrder)
    {
        if (!ModelState.IsValid)
        {
            return View("CheckoutIndividual", individualOrder);
        }

        individualOrder.CustomerType = CustomerTypeEnum.Individual;
        individualOrder.CalcTotals();

        return View(individualOrder);
    }
}