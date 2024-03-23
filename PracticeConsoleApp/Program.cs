using static PracticeConsoleApp.Classes.Samples;
using static PracticeConsoleApp.Classes.SpectreConsoleHelpers;

namespace PracticeConsoleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        await ReadPersonJson();
        await ReadAlbumJsonAsync();
        await PostAlbum();
        ExitPrompt();
    }
}