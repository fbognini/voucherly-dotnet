using fbognini.Sdk.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Voucherly.Sdk;
using Voucherly.Sdk.Requests;

namespace Voucherly.Checkout.Controllers;

public class PayController : Controller
{
    private readonly ILogger<PayController> _logger;
    private readonly IVoucherlyApiService _VoucherlyApiService;

    public PayController(ILogger<PayController> logger, IVoucherlyApiService VoucherlyApiService)
    {
        _logger = logger;
        _VoucherlyApiService = VoucherlyApiService;
    }

    [HttpPost]
    public async Task<ActionResult> Init()
    {

        var request = new CreatePaymentRequest
        {
            ReferenceId = Guid.NewGuid().ToString(),
            CustomerFirstName = "Mario",
            CustomerLastName = "Red",
            CustomerEmail = "mario.red@gmail.com",
            Lines = new List<CreatePaymentRequest.PaymentLine>()
            {
                new CreatePaymentRequest.PaymentLine()
                {
                    IsFood = true,
                    ProductImage = "https://source.unsplash.com/kcA-c3f_3FE",
                    Quantity = 1,
                    ProductName = "Fresh bowl",
                    UnitAmount = 700,
                }

            },
            Mode = Sdk.Models.Payments.PaymentMode.Payment,
            RedirectSuccessUrl = Url.Action("Success", "Pay", null, HttpContext.Request.Scheme)!,
            RedirectErrorUrl = Url.Action("Error", "Pay", null, HttpContext.Request.Scheme)!,
        };

        try
        {
            var payment = await _VoucherlyApiService.CreatePayment(request);
            return new RedirectResult(payment.CheckoutUrl!);
        }
        catch (ApiException ex)
        {
            return BadRequest(ex.Response);
        }
    }

    public IActionResult Success()
    {
        return View();
    }

	public IActionResult Error()
    {
        return View();
    }
}