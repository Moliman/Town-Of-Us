powershell Remove-Item 'BepInEx\plugins\TownOfUs.dll'
powershell (new-object System.Net.WebClient).DownloadFile('https://github.com/Moliman/Town-Of-Us/blob/tempsharing/TownOfUs.dll?raw=true','BepInEx\plugins\TownOfUs.dll')
START "" "Among Us.exe"