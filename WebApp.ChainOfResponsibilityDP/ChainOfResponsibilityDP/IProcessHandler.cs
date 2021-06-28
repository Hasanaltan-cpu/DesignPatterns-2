using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ChainOfResponsibilityDP.ChainOfResponsibilityDP
{
    public interface IProcessHandler
    {
        IProcessHandler SetNext(IProcessHandler processHandler);


        Object handle(Object o);


    }
}
