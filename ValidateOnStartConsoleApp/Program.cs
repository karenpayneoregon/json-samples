
using Microsoft.Extensions.Options;
using ValidateOnStartConsoleApp.Classes;
using ValidateOnStartConsoleApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidateOnStartConsoleApp.Classes.Configuration;

namespace ValidateOnStartConsoleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();


        try
        {
            ApplicationValidation.ValidateOnStart<ConnectionStrings>(nameof(ConnectionStrings), cs => cs.MainConnection);
        }
        catch (Exception ex)
        {
        }

        //try
        //{
        //    ApplicationValidation.ValidateOnStart();
        //}
        //catch (Exception ex)
        //{
        //}

        if (ConnectionHelpers.SectionExist())
        {
            var test1 = ConnectionHelpers.HasMainConnection();
            var test2 = ConnectionHelpers.HasSecondaryConnection();
        }
        else
        {

        }

        ExitPrompt();
    }
}