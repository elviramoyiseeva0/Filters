using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Models;
using System;
using System.Linq;

namespace TodoList.Filters
{
    public class TimestampResourceFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var taskArgument = context.ActionArguments.Values
                .OfType<TaskItem>()
                .FirstOrDefault();

            if (taskArgument != null)
            {
                taskArgument.UpdatedAt = DateTime.Now;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}