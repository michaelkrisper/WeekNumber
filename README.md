# WeekNumber
Windows 10 system tray area application that displays the current week number

<img src="https://user-images.githubusercontent.com/2292809/120221521-d6a79580-c23e-11eb-99d1-be6210b43fcf.png" data-canonical-src="https://user-images.githubusercontent.com/2292809/120221521-d6a79580-c23e-11eb-99d1-be6210b43fcf.png" alt="WeekNumber" width="150" height="150" />

[![Latest release ZIP](https://img.shields.io/github/v/release/voltura/WeekNumber?label=download%20latest%20release&style=for-the-badge)](https://github.com/voltura/weeknumber/releases/latest/download/WeekNumber.zip)

*- Completely Free and Open Source! Donations are very much appreciated!*

[![Donate](https://img.shields.io/badge/donate_via-paypal_or_card-blue)](https://www.paypal.com/donate?hosted_button_id=7PN65YXN64DBG) __⟵__ _**Press here to donate!**_

[![Github All Releases](https://img.shields.io/github/downloads/voltura/WeekNumber/total.svg)]()
[![License](https://img.shields.io/badge/licence-MIT-green)]()

## Features

Always see the current week number in Windows system tray area in the taskbar and lookup the week number for any other date via right-click on the application icon.

Options to start with Windows, automatically update the application, customize colors, set icon resolution and calendar rules and more. For details see _**Help section**_ below.

The application is tiny and its memory consumption low. 

## Screenshots
#### System tray area icon with default colors
![Taskbar icon](https://user-images.githubusercontent.com/2292809/120904782-473f1f80-c64e-11eb-9256-c3d0ddab2124.png)
#### Context menu - accessible via right-click on icon
![Context menu](https://user-images.githubusercontent.com/2292809/120920695-5d85c380-c6c0-11eb-93f4-3f932b853b03.png)
#### Find out week number for any date
![Weeknumber form](https://user-images.githubusercontent.com/2292809/120904877-e49a5380-c64e-11eb-80b5-c44d6f71fab6.png)
#### Settings menu
![Settings menu](https://user-images.githubusercontent.com/2292809/120920725-8e65f880-c6c0-11eb-8ea8-777f6652203f.png)
#### System tray area icon with customized colors
![Custom colors #1](https://user-images.githubusercontent.com/2292809/118048718-f4d74f80-b37c-11eb-8b36-211250ff25c5.png) ![Custom colors #2](https://user-images.githubusercontent.com/2292809/120920791-e997eb00-c6c0-11eb-889e-9a3e67787033.png) ![Custom colors #3](https://user-images.githubusercontent.com/2292809/120921288-498f9100-c6c3-11eb-8451-d2c3e19fba30.png)
#### Icon color picker, possible to define and use custom colors (both icon text and background can be customized)
![Color picker](https://user-images.githubusercontent.com/2292809/118050315-4e407e00-b37f-11eb-8ac9-17cc1a08aa08.png)
#### More context menu options
![image](https://user-images.githubusercontent.com/2292809/120920906-7642a900-c6c1-11eb-8d08-7a56986010e7.png)
![image](https://user-images.githubusercontent.com/2292809/120920930-91151d80-c6c1-11eb-984b-86469dbf4ff8.png)

## Installation
Download installer and run to install (option to start when installer finishes).
If you downloaded WeekNumber.zip via *Download latest release* first unzip the archive, then run the installer.
To remove the application run the uninstaller or use Windows *Add or remove programs* feature or via the Control Panels *Programs And Features* section. 

### Installation notes
Choose to keep the file downloaded if prompted (it will look similar to this, depends on your web browser and settings)

![Keep file if prompted #1](https://user-images.githubusercontent.com/2292809/120716901-fa7d0c80-c4c6-11eb-9232-f279f959f0a6.png)

![Keep file if prompted #2](https://user-images.githubusercontent.com/2292809/118524536-8c9eba00-b73e-11eb-9c6c-bc8defde0caa.png)

Use below actions to allow the installer to run on your PC when Microsoft SmartScreen is active:

![smartscreen_0](https://user-images.githubusercontent.com/2292809/120404034-c201f500-c345-11eb-9abd-670e927c4a36.png)

![smartscreen_1](https://user-images.githubusercontent.com/2292809/120404043-c4fce580-c345-11eb-945d-a5931bb5b721.png)


#### Distributed / Silent install / uninstall options
To silently install call the installer with /S parameter.
> WeekNumber_{VERSION}_Installer.exe /S

To silently uninstall call the uninstaller with /S parameter.
> Uninstall WeekNumber.exe /S

## Help section
All application features are accessible via right-click on the application icon residing in the Windows system tray area in the taskbar.
If the application icon is not visible then press the ^ symbol on the system tray area, click and hold on the application icon and then drag it to the visible system tray area to pin it there.

### Context menu options:
- **About WeekNumber** - _Displays version information_
- **Check for updated version** - _Checks if newer version is available, option to update if that is the case_
- **Open application web page** - _Opens the default browser and navigates to the application web page_
- **Settings** - _Additional application settings displayed in sub-menus_
   - **Start with Windows** - _If ticked, the application starts automatically when user login to Windows_
   - **Update automatically** - _If ticked, the application will update itself automatically without user interaction_
   - **Application log** - _Application log settings in sub-menus_
      - **Use application log** - _Application writes to a log file if ticked_
      - **Show application log** - _If above is ticked, opens the application log file in a text editor (technical)_
   - **Notifications** - _Control application startup message in sub-menus_
      - **Display startup notification** - _If ticked, the application will show a notification when started_
      
      <img src="https://user-images.githubusercontent.com/2292809/120921660-0b936c80-c6c5-11eb-974b-653954fca5ed.png" width="400">
      
      - **Display new week notification** - _If ticked, a notification will be shown when the week changes_
      
      <img src="https://user-images.githubusercontent.com/2292809/120921898-6da0a180-c6c6-11eb-82f0-4827dfbc2f4c.png" width="400">

      - **Use silent notifications** - _If ticked, any notifications for this application will not trigger system sounds to be played_
   - **Use small / large taskbar buttons** - _Toogles Windows taskbar size and also adjusts the application icon resolution to match. Having trouble seeing the week number? Try using large taskbar buttons_
   - **Calendar** - _Calendar rules used by the application (per default the application uses the systems regional settings to figure this out, but it can be manually overridden here)_
     - **First Day Of Week** - _Calendar rule, select what day a week starts on_
     - **Calendar week rule** - _Additional calendar rule that tells what rule is used for the first week of a year_
   - **Icon** - _Application icon settings_
     - **Icon colors** - _Allows user to change icon background and text (foreground) color or reset colors used back to default in sub-menus_
     - **Icon resolution** - _Possibility to tweak the WeekNumber icon resolution, if the icon is fuzzy setting a higher or lower resolution can help with apperance_
     - **Save icon...** - _Lets user save the current WeekNumber icon displayed to a .ico file_
- **Get week number for date...** - _Get week number for specified date (shows form where date can be entered)_

  <img src="https://user-images.githubusercontent.com/2292809/120921352-907d8680-c6c3-11eb-8a7a-a79d6e903dc9.png" width="400">
- **Exit WeekNumber** - _Closes the application. Start it again from the Windows Start Menu_

## Statistics
[![Open issues](https://img.shields.io/github/issues/voltura/WeekNumber)](https://github.com/voltura/WeekNumber/issues)
[![Code Quality](https://img.shields.io/github/workflow/status/voltura/WeekNumber/CodeQL)]()
[![Website Status](https://img.shields.io/website?url=https%3A%2F%2Fvoltura.github.io%2FWeekNumber%2F)]()

[![Number of programming langauges](https://img.shields.io/github/languages/count/voltura/WeekNumber)]()
[![Top programming language](https://img.shields.io/github/languages/top/voltura/WeekNumber)]()
[![Code size](https://img.shields.io/github/languages/code-size/voltura/WeekNumber)]()
[![Number of repo forks](https://img.shields.io/github/forks/voltura/WeekNumber)]()
[![Number of repo stars](https://img.shields.io/github/stars/voltura/WeekNumber)]()
[![goto counter](https://img.shields.io/github/search/voltura/WeekNumber/goto)]()
[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2Fvoltura%2FWeekNumber%2Fhit-counter&count_bg=%2379C83D&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)]()
![GitHub last commit](https://img.shields.io/github/last-commit/voltura/WeekNumber?color=red)

![Visitors](https://estruyf-github.azurewebsites.net/api/VisitorHit?user=volturaf&repo=WeekNumber&countColorcountColor&countColor=%235690f2)
