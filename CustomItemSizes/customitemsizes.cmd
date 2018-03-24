echo using SMLHelper.Patchers; > QPatch.cs
echo namespace ReplenishReactorRods >> QPatch.cs
echo { >> QPatch.cs
echo public class QPatch >> QPatch.cs
echo { >> QPatch.cs
echo private static readonly ConfigFile Config = new ConfigFile("config"); >> QPatch.cs
set i=1
:loop0
echo private static int _x%i% = 1; >> QPatch.cs
echo private static int _y%i% = 1;
set /a i+=1
if %i% == stop goto stop0
goto loop0
:stop0
echo public static void Patch() >> QPatch.cs
echo { >> QPatch.cs
echo Config.Load();
echo var configChanged =
echo Config.TryGet(ref _x%i%, "%i%", "X")
echo | Config.TryGet(ref _y%i%, "%i%", "Y")
rem stopped
echo | Config.TryGet(ref _xMIGold, "Gold Ingot - Gold", "Size", "x")
echo | Config.TryGet(ref _yMIGold, "Gold Ingot - Gold", "Size", "y")
set i=1
:loop1
echo CraftDataPatcher.customItemSizes[key: TechType.%i%] = new Vector2int(x: _x%i%, y: _y%i%); >> QPatch.cs
set /a i+=1
if %i% == stop goto stop1
goto loop1
:stop1       
echo } >> QPatch.cs
echo } >> QPatch.cs
echo } >> QPatch.cs