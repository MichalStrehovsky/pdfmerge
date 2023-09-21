# pdfmerge

Simple CLI tool to merge PDF files.

This is a small demo of building CLI apps in .NET using [Native AOT](https://learn.microsoft.com/dotnet/core/deploying/native-aot/).

Highlights:

* Build small, selfcontained executables. The pdfmerge tool is 2 MB in size with _no dependencies_ at runtime. Drop the executable on a new Linux/Windows/macOS machine with a clean OS install and it will just work. See the csproj for details on this configuration.
* Use Github actions to manage your release: [CI pipeline](.github/workflows/ci.yml) set up to run on PRs but also manually-triggerable from the Actions tab in Github to help you create tagged releases with a couple clicks
