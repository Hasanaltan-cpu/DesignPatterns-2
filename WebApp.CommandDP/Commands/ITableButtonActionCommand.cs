using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CommandDP.Commands
{
    public interface ITableButtonActionCommand
    {
       IActionResult Execute();


    }
}
