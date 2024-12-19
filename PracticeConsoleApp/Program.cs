using PracticeConsoleApp.Classes;
using static PracticeConsoleApp.Classes.Samples;
using static PracticeConsoleApp.Classes.SpectreConsoleHelpers;

namespace PracticeConsoleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Samples.ReadGist("https://gist.github.com/karenpayneoregon/5c7da046b54c7e7e8eb80f022fb8ac67/raw");
        await ReadPersonJson();
        await ReadAlbumJsonAsync();
        await PostAlbum();
        ExitPrompt();
    }
}