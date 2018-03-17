After a long period of not touching .NET or C#, I wanted to dive back in.

I was interested in setting up some continuous testing.

I found this doc: https://docs.microsoft.com/aspnet/core/tutorials/dotnet-watch

Also, I had to include `<RuntimeFrameworkVersion>2.0.6</RuntimeFrameworkVersion>` in the csproj file for the tests.

run `dotnet --info` to match the appriopriate runtime version.
