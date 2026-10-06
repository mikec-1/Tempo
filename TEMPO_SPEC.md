# Tempo: build spec

You are working directly in this project folder. You can create and edit files and
run shell commands. Build a lightweight native Windows desktop app: a music player
UI modeled on the layout and feel of Spotify's desktop app. This is UI ONLY. No
audio playback, streaming, accounts, or network calls. All content is mock data.

## Tech requirements
- Plain WPF on .NET 10, C#. NOT WinUI, no Windows App SDK.
- Tempo.csproj must use <TargetFramework>net10.0-windows</TargetFramework>,
  <UseWPF>true</UseWPF>, <OutputType>WinExe</OutputType>, <Nullable>enable</Nullable>.
- Do NOT put RuntimeIdentifier, SelfContained, or PublishSingleFile in the csproj.
  Those go only on the final publish command.
- No NuGet packages. No app.manifest. Do not reference any file that doesn't exist.
- No constructor in App.xaml.cs (WPF calls InitializeComponent automatically).
- Low RAM/CPU, fast startup, smooth scrolling and hover states.

## Branding
- App name: "Tempo". No Spotify name, logo, or assets.
- Simple original logo drawn in XAML. Album art = solid colors or gradients.

## Theme
Dark. Background #121212, panels #181818, hover #282828, primary text #FFFFFF,
secondary text #B3B3B3, accent green #1ED760. Font Segoe UI. 8px rounded corners
on panels and cards. Icons drawn as XAML Path geometry, no image files.

## Layout
Window: custom dark title bar (with working minimize/maximize/close and drag),
resizable, minimum size 1000x650.

1. LEFT SIDEBAR (~280px)
   - Top panel: "Home" and "Search" nav items with icons
   - Bottom panel: "Your Library" header with + button, filter chips
     (Playlists, Artists, Albums), scrollable list of ~20 mock playlists
     (square thumbnail, title, subtitle like "Playlist • 34 songs")

2. MAIN CONTENT AREA (fills remaining space, scrollable)
   - Top bar: back/forward buttons, search box, profile circle on the right
   - "Good evening" header with a grid of 6 quick-access tiles
     (thumbnail left, title right)
   - 3-4 horizontal rows of cards ("Made for you", "Recently played", etc.),
     each card = square art, title, short description
   - Card hover: background lightens, round green play button fades in at the
     bottom-right of the art

3. BOTTOM PLAYER BAR (~90px, full width)
   - Left: track thumbnail, title, artist, heart button
   - Center: shuffle, previous, play/pause (white circle), next, repeat; below
     them a progress bar with times (e.g. 1:24 / 3:45)
   - Right: queue, devices, volume icon and volume slider
   - Play/pause toggles its icon; sliders are draggable; nothing plays audio

## Interactions
- Clicking a sidebar playlist or card opens a playlist view: large header with
  art, title, owner, song count; then a track table (#, Title/Artist, Album,
  Date added, Duration) with row hover highlighting
- Back button returns to Home

## Code structure
MVVM: Models/, ViewModels/ (with ViewModelBase implementing INotifyPropertyChanged),
Views/, Services/MockDataService.cs, Utils/RelayCommand.cs, Converters/.
All colors and styles in Resources/SharedStyles.xaml. Every UserControl has its
.xaml.cs file.

## How to work (important)
- This folder is already a git repository. Do not run git init.
- Work in small steps. Order:
  1. Project file + App + empty dark window that builds and runs
  2. Shared styles and theme
  3. Sidebar
  4. Player bar
  5. Home content area
  6. Playlist view and navigation
- After EVERY step, run `dotnet build`. Fix all errors before moving on.
- After each successful step, run `git add -A`, then as a separate command
  `git commit -m "<step description>"`. Do not chain commands with &&.
- After each step, briefly tell me what you did and whether the build passed.
- Never claim something works unless `dotnet build` succeeded.
- If you fix the same error 3 times without success, stop and tell me.
