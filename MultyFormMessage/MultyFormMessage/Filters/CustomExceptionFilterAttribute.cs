using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string actionName = context.ActionDescriptor.DisplayName;
        string exceptionStack = context.Exception.StackTrace;
        string exceptionMessage = context.Exception.Message;

        context.Result = new ContentResult
        {
            Content = $"Method {actionName} threw an exception: \n {exceptionMessage} \n {exceptionStack}"
        };

        context.ExceptionHandled = true;
    }
}