@echo off

set i=1
set JJ=3
set j=1

:main
echo Wykonanie dla %i%.txt

:subname

if %j% LSS 10 (
	set name=4x4_0%i%_0000%j%
) else (
if %j% LSS 100 (
	set name=4x4_0%i%_000%j%
) else (
if %j% LSS 1000 (
	set name=4x4_0%i%_00%j%
)
)
)

echo         Podplik %name%

::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs RDUL %name%.txt %name%_bfs_RDUL_sol.txt %name%_bfs_RDUL_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs RDLU %name%.txt %name%_bfs_RDLU_sol.txt %name%_bfs_RDLU_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs DRUL %name%.txt %name%_bfs_DRUL_sol.txt %name%_bfs_DRUL_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs DRLU %name%.txt %name%_bfs_DRLU_sol.txt %name%_bfs_DRLU_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs LUDR %name%.txt %name%_bfs_LUDR_sol.txt %name%_bfs_LUDR_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs LURD %name%.txt %name%_bfs_LURD_sol.txt %name%_bfs_LURD_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs ULDR %name%.txt %name%_bfs_ULDR_sol.txt %name%_bfs_ULDR_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" bfs ULRD %name%.txt %name%_bfs_ULRD_sol.txt %name%_bfs_ULRD_stats.txt

start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs RDUL %name%.txt %name%_dfs_RDUL_sol.txt %name%_dfs_RDUL_stats.txt
start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs RDLU %name%.txt %name%_dfs_RDLU_sol.txt %name%_dfs_RDLU_stats.txt
start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs DRUL %name%.txt %name%_dfs_DRUL_sol.txt %name%_dfs_DRUL_stats.txt
start /WAIT "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs DRLU %name%.txt %name%_dfs_DRLU_sol.txt %name%_dfs_DRLU_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs LUDR %name%.txt %name%_dfs_LUDR_sol.txt %name%_dfs_LUDR_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs LURD %name%.txt %name%_dfs_LURD_sol.txt %name%_dfs_LURD_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs ULDR %name%.txt %name%_dfs_ULDR_sol.txt %name%_dfs_ULDR_stats.txt
::start "" "C:\Users\Flurrih\Documents\SISE\SISE_ONE\SISE_ONE\bin\Release\SISE_ONE.exe" dfs ULRD %name%.txt %name%_dfs_ULRD_sol.txt %name%_dfs_ULRD_stats.txt

set /a j=%j%+1
if [%j%] == [%JJ%] goto end_subname
goto subname
:end_subname
set /a j=1
set /a i=%i%+1

if [%i%] == [2] set JJ=5
if [%i%] == [3] set JJ=11
if [%i%] == [4] set JJ=25
if [%i%] == [5] set JJ=55
if [%i%] == [6] set JJ=108
if [%i%] == [7] set JJ=213

if [%i%] == [8] goto end
goto main

:end
pause > nul