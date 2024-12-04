using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using System;
using System.Linq;
using Pet_Web_Application_10._12._24_F.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Pet_Web_Application_10._12._24_F.Controllers
{
    public class DonateController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SecretClient _secretClient;

        public DonateController(IConfiguration configuration)
        {
            _configuration = configuration;
            var keyVaultUri = _configuration["KeyVaultUri"];
            if (string.IsNullOrEmpty(keyVaultUri))
            {
                throw new ArgumentNullException(nameof(keyVaultUri), "KeyVaultUri configuration is missing or empty.");
            }
            _secretClient = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
        }

        [HttpGet]
        public IActionResult Donate()
        {
            ViewData["Title"] = "Donate";
            return View();
        }

        [HttpPost]
        public IActionResult Donate(DonationModel model)
        {
            if (ModelState.IsValid)
            {
                var clientId = _secretClient.GetSecret("PayPalClientId").Value.Value;
                var clientSecret = _secretClient.GetSecret("PayPalClientSecret").Value.Value;

                var apiContext = new APIContext(new OAuthTokenCredential(clientId, clientSecret).GetAccessToken());

                var payment = new Payment
                {
                    intent = "sale",
                    payer = new Payer { payment_method = "paypal" },
                    transactions = new List<Transaction>
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
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the payment. Please try again.");
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult PaymentSuccess(string paymentId, string token, string payerId)
        {
            ArgumentNullException.ThrowIfNull(token);

            var clientId = _secretClient.GetSecret("PayPalClientId").Value.Value;
            var clientSecret = _secretClient.GetSecret("PayPalClientSecret").Value.Value;

            var apiContext = new APIContext(new OAuthTokenCredential(clientId, clientSecret).GetAccessToken());
            var paymentExecution = new PaymentExecution { payer_id = payerId };
            var payment = new Payment { id = paymentId };
            _ = payment.Execute(apiContext, paymentExecution);

            // Handle successful payment (e.g., save to database, send email, etc.)

            return View();
        }
    }
}