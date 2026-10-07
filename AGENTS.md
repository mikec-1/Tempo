# Tempo: agent instructions

Tempo is a WPF music player UI (Spotify-style, UI only, mock data). The full
design and the list of build steps are in TEMPO_SPEC.md. Read it when starting
a new task.

## Environment
- Windows, PowerShell 5.1. Run commands ONE AT A TIME. Never use `&&`.
- .NET 10 SDK, plain WPF (net10.0-windows, UseWPF). NOT WinUI. No NuGet packages.
- This folder is already a git repository. Never run `git init`.
- Never run `git reset`, `git rebase`, `git commit --amend` or anything else
  that rewrites history. Only add new commits.

## Commands
- Build: `dotnet build -nodeReuse:false`
- Commit: `git add -A`, then separately `git commit -m "<what changed>"`
- Crash details: read `bin\Debug\net10.0-windows\crash.log`

## Project structure
- Views/ : MainWindow and all UserControls (namespace Tempo.Views)
- ViewModels/ : one ViewModel per view, all inherit ViewModelBase
- Models/, Services/MockDataService.cs, Utils/RelayCommand.cs, Converters/
- Resources/SharedStyles.xaml : shared colors and styles

## Conventions
- MainViewModel owns one MockDataService and a property for each child
  ViewModel. MainWindow passes them down with DataContext="{Binding X}".
- Never create data or set DataContext in a UserControl's code-behind.
- Buttons use Command bindings to RelayCommand, not Click handlers.
- Mock data must be fixed (no Random) and realistic.

## Rules learned from past mistakes
- `dotnet build` does NOT catch XAML errors. They only appear when the app runs.
  Check every XAML change for these:
  - Every xmlns prefix you use (e.g. `views:`) is declared at the top of the file.
  - Every StaticResource is defined ABOVE where it's used, and each x:Key is
    used only once per resource dictionary.
  - App.xaml has StartupUri="Views/MainWindow.xaml".
  - A Template setter must reference a ControlTemplate, never a Style.
  - MinWidth/MinHeight/MaxWidth/MaxHeight must be numbers, never "Auto".
- ScrollBars: use ONE implicit ScrollBar style with an Orientation="Horizontal"
  trigger that switches to the horizontal template.
- Array and list indexes must stay in range (use `% array.Length` for colors).
- Custom control templates must replace the default Windows look completely
  (Button, RepeatButton, ScrollBar, Thumb): no borders or blue hover left over.
- An element with Visibility="Collapsed" can't receive mouse events. Use
  Opacity="0" for hover-reveal effects.
- Don't leave unused fields or empty event handlers.

## Workflow
- Do one step or fix at a time, then build and fix ALL errors. Don't add
  extra features I didn't ask for in the same change.
- Commit after each successful build.
- Then STOP and tell me what changed, so I can run and test the app.
- Never claim something works just because the build passed.
- If the same error fails 3 times, stop and explain the problem.
- When you fix a bug caused by a mistake that could happen again, end your
  summary with "Proposed rule: <one line>". Do NOT edit AGENTS.md yourself.
  If I reply "add the rule", add that line to "Rules learned from past mistakes".
