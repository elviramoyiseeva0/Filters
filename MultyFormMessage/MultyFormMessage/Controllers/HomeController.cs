using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using MultyFormMessage.Models;
using MultyFormMessage.Services;

[Authorize]
[CustomExceptionFilter]
public class HomeController : Controller
{
    private readonly IEmailSender _emailSender;

    public HomeController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetFiles(string to, string subject, string content)
    {
        var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
        var message = new Message(new List<string> { to }, subject, content, files);

        _emailSender.SendEmail(message);

        return Content("Sent");
    }
}