using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;

namespace BiliWeb.Backend
{

    /// <summary>
    /// Define an interface which contains the methods for the Example repository.
    /// All CRUDi aspects
    /// </summary>
    public interface IExampleRepository
    {
        ExampleModel Create(ExampleModel data);
        ExampleModel Read(String id);
        ExampleModel Update(ExampleModel data);
        Boolean Delete(String id);
        List<ExampleModel> Index();
    }
}