# MSDependencyInjectionTest

Since the MS docs use a console app for their tutorials I wanted to test them in a WPF .NET6 desktop project.

Uses tutorial at https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage.

Some steps not in the MS tutorial
- in app.xaml, remove StartupUri.  
- Override OnStartup in App.xaml.cs like so  protected override void OnStartup(StartupEventArgs e).
- Follow the tutorial putting code in the OnStartup method.
- ^^ except for the ExemplifyScoping method which goes in the class but not the Onstartup method.
- All calls to Console.WriteLine replaces with Debug.WrtieLine so that the output goes in to the Output window since WPF desktop apps don't really have a console.

