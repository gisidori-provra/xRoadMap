@echo off
xcopy \\srvsitarcgis\sit\xRoadMap\ %homedrive%\xRoadMap\ /s/e/d/i/q/y
start /d %homedrive%\xRoadMap xRoadMap.exe
