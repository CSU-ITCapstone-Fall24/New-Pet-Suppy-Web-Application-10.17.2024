using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Linq;
using System;
using System.Collections.Generic;
using Pet_Web_Application_10._12._24_F.Models;



namespace Pet_Web_Application_10._12._24_F.Controllers

{
    public class DonateController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;

        [HttpGet]
        public IActionResult Donate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Donate(DonationModel model)
        {
            if (ModelState.IsValid)
            {
                var apiContext = PayPalController.GetAPIContext(_configuration);

                var payment = new Payment
                {
                    intent = "sale",
                    payer = new Payer { payment_method = "paypal" },
                    transactions =
            {
                new Transaction
                {
                    description = "Donation",
                    invoice_number = Guid.NewGuid().ToString(),
                    amount = new Amount
                    {
                        currency = "USD",
                        total = model.Amount.ToString()
                    }
                }
            },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("PaymentSuccess", "Donate", null, Request.Scheme),
                        cancel_url = Url.Action("PaymentCancel", "Donate", null, Request.Scheme)
                    }
                };

                var createdPayment = payment.Create(apiContext);
                var approvalUrl = createdPayment.links.FirstOrDefault(x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase))?.href;

                if (approvalUrl != null)
                {
                    return Redirect(approvalUrl);
                }
                else
                {
                    // Handle the case where approvalUrl is null
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the payment. Please try again.");
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult PaymentSuccess(string paymentId, string Token, string PayerID)
        {
            ArgumentNullException.ThrowIfNull(Token);

            var apiContext = PayPalController.GetAPIContext(_configuration);
            var paymentExecution = new PaymentExecution { payer_id = PayerID };
            var payment = new Payment { id = paymentId };
            _ = payment.Execute(apiContext, paymentExecution);

            // Handle successful payment (e.g., save to database, send email, etc.)

            return View();
        }
    }
}
