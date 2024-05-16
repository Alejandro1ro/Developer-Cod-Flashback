using System.Diagnostics;
animacionPresentacion();
dynamic[,] estudiantes = { { false, false, "Abel Rafael Roman Sebastian" }, { false, false, "Alexander Antonio Brito Soto" }, { false, false, "Angelis Carolina Cruz Ortiz" }, { false, false, "Dalbert Sanchez Reyes" }, { false, false, "Dariel Vallejo Contreras" }, { false, false, "Elian Antonio Ortiz Pacheco" }, { false, false, "Emir Fermin De Los Santos" }, { false, false, "Euris Alexander Rosa Vargas" }, { false, false, "Felix Jose Marte Balbuena" }, { false, false, "Hansell Feliz Morillo" }, { false, false, "Ivette Altagracia Mercedes Ventura" }, { false, false, "Jean Carlos Castillo Fernandez" }, { false, false, "Jeury Ramon Nuñez Cruz" }, { false, false, "Juan Jose Familia Polanco" }, { false, false, "Julio Cesar Marte Sosa" }, { false, false, "Junior Miguel Peguero Soriano" }, { false, false, "Kelwin Alejandro German Arias" }, { false, false, "Leandro Jimenez De Leon" }, { false, false, "Rayders Garcia Mones" }, { false, false, "Steven Moises Luna Orozco" }, { false, false, "Stharling Candelario Suazo" }, { false, false, "Ydan F. Monegro De Moya" }, { false, false, "Yohan Miguel Rodriguez Ozuna" }, { false, false, "Yosmal Zalaba" } };
dynamic[,] ruleta = { };
string[] seleccionados = new string[2];
Random random = new Random();
Console.Clear();

//Agregar invitados
agregarInvitados:
try
{
    Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___         _ _           _        \n|_ _|_ ___ _(_) |_ __ _ __| |___ ___\n | || ' \\ V / |  _/ _` / _` / _ (_-<\n|___|_||_\\_/|_|\\__\\__,_\\__,_\\___/__/\n                                    \n"); Console.ResetColor();
    Console.Write("Desea agregar a ulgun invitado (Y/N)? ");
    char agregar = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (agregar != 'Y' && agregar != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto agregarInvitados;
    }
    else if (agregar == 'Y')
    {
        Console.Write("Cuantos? ");
        int cantidadAgregar = Convert.ToInt32(Console.ReadLine()!);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___         _ _           _        \n|_ _|_ ___ _(_) |_ __ _ __| |___ ___\n | || ' \\ V / |  _/ _` / _` / _ (_-<\n|___|_||_\\_/|_|\\__\\__,_\\__,_\\___/__/\n                                    \n"); Console.ResetColor();
        dynamic[,] estudiantesNew = new dynamic[(estudiantes.Length / 3) + cantidadAgregar, 3];

        //Copia la matriz
        for (int i = 0; i < estudiantes.Length / 3; i++)
        {
            for (int y = 0; y < 3; y++)
            {
                estudiantesNew[i, y] = estudiantes[i, y];
            }
        }
        //Fin copia matriz

        //Agrega al invitado
        for (int i = 0; i < cantidadAgregar; i++)
        {
            Console.Write($"Ingrese el nombre del invitado {i + 1}: ");
            string nomInvitado = $"{Console.ReadLine()!}(invitado)";
            for (int y = 0; y < 3; y++)
            {
                if (y == 2)
                {
                    estudiantesNew[((estudiantesNew.Length / 3) - cantidadAgregar) + i, y] = nomInvitado;
                }
                else
                {
                    estudiantesNew[((estudiantesNew.Length / 3) - cantidadAgregar) + i, y] = false;
                }
            }
        }
        //Fin agrega al invitado

        ruleta = estudiantesNew;
    }
    else if (agregar == 'N')
    {
        ruleta = estudiantes;
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto agregarInvitados;
}
//Fin agregar invitados
Console.Clear();

// animacionPresentacion(); 
programa: estud:
//Estudiantes aleatorios 
Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___    _           _ _          _            ___      _           _                  _        \n| __|__| |_ _  _ __| (_)__ _ _ _| |_ ___ ___ / __| ___| |___ __ __(_)___ _ _  __ _ __| |___ ___\n| _|(_-<  _| || / _` | / _` | ' \\  _/ -_|_-< \\__ \\/ -_) / -_) _/ _| / _ \\ ' \\/ _` / _` / _ (_-<\n|___/__/\\__|\\_,_\\__,_|_\\__,_|_||_\\__\\___/__/ |___/\\___|_\\___\\__\\__|_\\___/_||_\\__,_\\__,_\\___/__/\n                                                                                               \n"); Console.ResetColor();
int antNumRandom = 0, numRandom = 0, primerRandom = 0;
for (int i = 0; i < 2; i++)
{
    primerRandom = antNumRandom;
    numRandom = random.Next(0, ruleta.Length / 3);
    while (ruleta[numRandom, i] == true || antNumRandom == numRandom)
    {
        random = new Random();
        numRandom = random.Next(0, ruleta.Length / 3);
    }
    antNumRandom = numRandom;

    if (ruleta[numRandom, i] == false)
    {
        string rol = (i == 0) ? "Desarrollador en Vivo." : "Facilitador del Ejercicio a Desarrollar.";
        Console.WriteLine($"{i + 1}. {ruleta[numRandom, 2]} es un {rol}");
        seleccionados[i] = ruleta[numRandom, 2];
        ruleta[numRandom, i] = true;
    }
}
Console.ReadKey(); Console.Clear();
//Fin estudiantes aleatorios

//Faltantes
falta:
Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___     _ _            _          \n| __|_ _| | |_ __ _ _ _| |_ ___ ___\n| _/ _` | |  _/ _` | ' \\  _/ -_|_-<\n|_|\\__,_|_|\\__\\__,_|_||_\\__\\___/__/\n                                   \n"); Console.ResetColor();
try
{
    Console.Write("Unos de los estudiantes falta (Y/N)? ");
    Char falta = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (falta != 'Y' && falta != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto falta;
    }
    else if (falta == 'Y')
    {
        Console.Write("[1]Desarrollador [2]Facilitador <=> [3]Ambos? ");
        int estudFaltante = Convert.ToInt32(Console.ReadLine()!);

        if (estudFaltante != 1 && estudFaltante != 2 && estudFaltante != 3)
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
            Console.ReadKey(); Console.Clear(); goto falta;
        }
        else if (estudFaltante == 1 || estudFaltante == 2)
        {
            int faltante = estudFaltante - 1;
            while (ruleta[numRandom, faltante] == true || antNumRandom == numRandom)
            {
                random = new Random();
                numRandom = random.Next(0, ruleta.Length / 3);
            }

            if (ruleta[numRandom, faltante] == false)
            {
                string rol = (faltante == 0) ? "Desarrollador en Vivo." : "Facilitador del Ejercicio a Desarrollar.";
                Console.WriteLine($"{faltante + 1}. {ruleta[numRandom, 2]} es un el nuevo {rol}");
                seleccionados[faltante] = ruleta[numRandom, 2];
                ruleta[numRandom, faltante] = true;
            }
            Console.ReadKey(); Console.Clear(); goto falta;
        }
        else
        {
            Console.Clear();
            goto estud;
        }
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto falta;
}
Console.Clear();
//Fin faltantes

//Creando la carpeta
crearCarpeta:
Console.ForegroundColor = ConsoleColor.Green; Console.Write("  ___                _                               _ _           _     \n / __|_ _ ___ __ _  | |_ _  _   _ _ ___ _ __  ___ __(_) |_ ___ _ _(_)___ \n| (__| '_/ -_) _` | |  _| || | | '_/ -_) '_ \\/ _ (_-< |  _/ _ \\ '_| / _ \\\n \\___|_| \\___\\__,_|  \\__|\\_,_| |_| \\___| .__/\\___/__/_|\\__\\___/_| |_\\___/\n                                       |_|                               \n"); Console.ResetColor();
Console.Write("\nComo deseas nombrar tu proyecto? ");
string nomProyecto = Console.ReadLine()!.Replace(' ', '_');
string[] directorio = Directory.GetDirectories(@"..\Programas");
foreach (string dCompleto in directorio)
{
    DirectoryInfo nomDirectorio = new DirectoryInfo(dCompleto);
    if (nomDirectorio.Name == nomProyecto)
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Carpeta existente..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto crearCarpeta;
    }
}
animacionPacman();
crearCarpeta(nomProyecto);
Console.Clear();
//Fin creando carpeta

//Aqui van a ir el conjunto de reglas...
int minuto = 0, lineas = 0, intentos = 0, limiteMinuto = 0, limiteLineas = 0, limiteIntentos = 0;
lineas:
Console.ForegroundColor = ConsoleColor.Green; Console.Write(" __  __                      ___        _ _ _ _           _         \n|  \\/  |___ _ _ _  _   ___  | __|_ _ __(_) (_) |_ __ _ __| |___ _ _ \n| |\\/| / -_) ' \\ || | |___| | _/ _` / _| | | |  _/ _` / _` / _ \\ '_|\n|_|  |_\\___|_||_\\_,_|       |_|\\__,_\\__|_|_|_|\\__\\__,_\\__,_\\___/_|  \n                                                                    \n"); Console.ResetColor();
try
{
    Console.Write("Desea que tenga limite de lineas (Y/N)? ");
    char confirmLineas = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (confirmLineas != 'Y' && confirmLineas != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto lineas;
    }
    else if (confirmLineas == 'Y')
    {
        Console.Write("Cuantas? ");
        lineas = Convert.ToInt32(Console.ReadLine());
        limiteLineas = lineas;
        Console.Clear();
    }
    else if (confirmLineas == 'N')
    {
        lineas = int.MaxValue;
        Console.Clear();
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto lineas;
}
Console.Clear();

intentos:
Console.ForegroundColor = ConsoleColor.Green; Console.Write(" __  __                      ___        _ _ _ _           _         \n|  \\/  |___ _ _ _  _   ___  | __|_ _ __(_) (_) |_ __ _ __| |___ _ _ \n| |\\/| / -_) ' \\ || | |___| | _/ _` / _| | | |  _/ _` / _` / _ \\ '_|\n|_|  |_\\___|_||_\\_,_|       |_|\\__,_\\__|_|_|_|\\__\\__,_\\__,_\\___/_|  \n                                                                    \n"); Console.ResetColor();
try
{
    Console.Write("Desea que tenga limite de intentos (Y/N)? ");
    char cIntentos = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (cIntentos != 'Y' && cIntentos != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto intentos;
    }
    else if (cIntentos == 'Y')
    {
        Console.Write("Cuantos [2]/[3]? ");
        intentos = Convert.ToInt32(Console.ReadLine());
        limiteIntentos = intentos;
        if (intentos != 2 && intentos != 3)
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
            Console.ReadKey(); Console.Clear(); goto intentos;
        }
    }
    else if (cIntentos == 'N')
    {
        intentos = 1;
        Console.Clear();
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto intentos;
}
Console.Clear();

minuto:
Console.ForegroundColor = ConsoleColor.Green; Console.Write(" __  __                      ___        _ _ _ _           _         \n|  \\/  |___ _ _ _  _   ___  | __|_ _ __(_) (_) |_ __ _ __| |___ _ _ \n| |\\/| / -_) ' \\ || | |___| | _/ _` / _| | | |  _/ _` / _` / _ \\ '_|\n|_|  |_\\___|_||_\\_,_|       |_|\\__,_\\__|_|_|_|\\__\\__,_\\__,_\\___/_|  \n                                                                    \n"); Console.ResetColor();
try
{
    Console.Write("Limite de minutos para terminar el programa [1]/[3]/[5]: ");
    minuto = Convert.ToInt32(Console.ReadLine());
    limiteMinuto = minuto;
    if (minuto != 1 && minuto != 3 && minuto != 5)
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto minuto;
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto minuto;
}
Console.Clear();
//Fin del conjunto de reglas

//Para saber de que requirio el desarrollador
TimeSpan s_empleados = DateTime.Now - DateTime.Now;
int l_empleadas = 0, i_empleados = 0;
//Fin Para saber de que requirio el desarrollador

intentoPrograma:
Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(" _  _                   _                                                  \n| || |___ _ _ __ _   __| |___   _ __ _ _ ___  __ _ _ _ __ _ _ __  __ _ _ _ \n| __ / _ \\ '_/ _` | / _` / -_) | '_ \\ '_/ _ \\/ _` | '_/ _` | '  \\/ _` | '_|\n|_||_\\___/_| \\__,_| \\__,_\\___| | .__/_| \\___/\\__, |_| \\__,_|_|_|_\\__,_|_|  \n                               |_|           |___/                         \n"); Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("                 Presionar cualquier tecla para continuar...               "); Console.ResetColor();
Console.ReadKey(); Console.Clear();

//Automatizacion de reloj
dynamic[,] comando = { { 1, "add-type -AssemblyName System.Windows.Forms; Start ms-clock:; Start-Sleep -Seconds 2; [System.Windows.Forms.SendKeys]::SendWait('{TAB}{TAB}{TAB}{TAB}{TAB}'); Start-Sleep -Seconds 1; [System.Windows.Forms.SendKeys]::SendWait('{ENTER}{ENTER}{ENTER}');" }, { 3, "add-type -AssemblyName System.Windows.Forms; Start ms-clock:; Start-Sleep -Seconds 2; [System.Windows.Forms.SendKeys]::SendWait('{TAB}{TAB}{TAB}{RIGHT}{TAB}{TAB}'); Start-Sleep -Seconds 1; [System.Windows.Forms.SendKeys]::SendWait('{ENTER}{ENTER}{ENTER}');" }, { 5, "add-type -AssemblyName System.Windows.Forms; Start ms-clock:; Start-Sleep -Seconds 2; [System.Windows.Forms.SendKeys]::SendWait('{TAB}{TAB}{TAB}{DOWN}{TAB}{TAB}'); Start-Sleep -Seconds 1; [System.Windows.Forms.SendKeys]::SendWait('{ENTER}{ENTER}{ENTER}');" } };
for (int i = 0; i < comando.Length / 2; i++)
{
    if (minuto == comando[i, 0])
    {
        Process.Start("powershell", comando[i, 1]);
    }
}
//Fin automatizacion de reloj

//Codigo pre-hecho
StreamWriter sw = new StreamWriter(@$"..\Programas\{nomProyecto}\Program.cs");
Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write($"Tendra un maximo de {lineas} lineas para completar el programa\n"); Console.ResetColor();
Console.Write($"                     {new string(' ', Convert.ToString(lineas).Length - 1)}↓ CODIGO ↓                     \n");
sw.WriteLine("using System.Diagnostics;\ntry{\n");
//Codificacion del programa
DateTime tiempoInicio = DateTime.Now;
for (int i = 0; i < lineas; i++)
{
    Console.Write($"{i + 1} → ");
    string programaa = $"    {Console.ReadLine()!}";
    l_empleadas++;

    if (programaa != "    ")
    {
        sw.WriteLine(programaa);
    }
    if (programaa == "    //Ok." || (DateTime.Now - tiempoInicio).TotalSeconds >= minuto * 60)
    {
        s_empleados = DateTime.Now - tiempoInicio;
        cerrarProceso("Time");
        Console.ReadKey();
        break;
    }
}
//Fin codificicacion del programa
sw.WriteLine("\n}catch(Exception){\n\tConsole.Write(\"Valor no valido.\");\n}\nConsole.ReadKey();\n\nProcess[] cmdProcesses = Process.GetProcessesByName(\"cmd\");\nforeach (Process cmdProcess in cmdProcesses){\n\tcmdProcess.Kill();\n}");
sw.Close();
Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n{new string(' ', Convert.ToString(lineas).Length - 1)}Hasta aqui se tienes permitido seguir con el programa.      "); Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"         {new string(' ', Convert.ToString(lineas).Length - 1)}Precione una tecla para continuar...         "); Console.ResetColor();
Console.ReadKey(); Console.Clear();
//Fin codigo-prehecho

abrirCodigoProyecto(nomProyecto);
animacionPacman();
ejecucionProyecto(nomProyecto);

//Depuracion del programa
bool realizado = false;
depuracionPrograma:
try
{
    Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                            _          \n|   \\ ___ _ __ _  _ _ _ __ _ __(_)___ _ _  \n| |) / -_) '_ \\ || | '_/ _` / _| / _ \\ ' \\ \n|___/\\___| .__/\\_,_|_| \\__,_\\__|_\\___/_||_|\n         |_|                               \n"); Console.ResetColor();
    Console.Write("\nSe ha depurado el programa correctamente (Y/N)? ");
    char programa = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (programa != 'Y' && programa != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto depuracionPrograma;
    }
    else if (programa == 'N')
    {
        intentos--; i_empleados++;
        Console.Clear();
        corazones(intentos);
        if (intentos > 0)
        {
            goto intentoPrograma;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                            _          \n|   \\ ___ _ __ _  _ _ _ __ _ __(_)___ _ _  \n| |) / -_) '_ \\ || | '_/ _` / _| / _ \\ ' \\ \n|___/\\___| .__/\\_,_|_| \\__,_\\__|_\\___/_||_|\n         |_|                               \n"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n           Se acabaron tu intentos.          "); Console.ResetColor();
            Console.Write("\nPresiona cualquier tecla para para continuar.");
            Console.ReadKey(); Console.Clear();
        }
    }
    else if (programa == 'Y')
    {
        realizado = true;
        Console.Clear();
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto depuracionPrograma;
}
//Fin depuracion del programa

//Guardar informacion
guardarJson(seleccionados, limiteMinuto, limiteLineas, limiteIntentos, nomProyecto, s_empleados, l_empleadas, i_empleados, realizado);
verbd:
try
{
    Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                    _          _      _          \n| _ ) __ _ ___ ___   __| |___   __| |__ _| |_ ___ ___\n| _ \\/ _` (_-</ -_) / _` / -_) / _` / _` |  _/ _ (_-<\n|___/\\__,_/__/\\___| \\__,_\\___| \\__,_\\__,_|\\__\\___/__/\n                                                     \n"); Console.ResetColor();
    Console.Write("Desea ver la base de datos (Y/N)? ");
    char confirmBD = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (confirmBD != 'Y' && confirmBD != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto verbd;
    }
    else if (confirmBD == 'Y')
    {
        if (fClave() == 1601)
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                    _          _      _          \n| _ ) __ _ ___ ___   __| |___   __| |__ _| |_ ___ ___\n| _ \\/ _` (_-</ -_) / _` / -_) / _` / _` |  _/ _ (_-<\n|___/\\__,_/__/\\___| \\__,_\\___| \\__,_\\__,_|\\__\\___/__/\n                                                     \n"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("Tienes acceso..."); Console.ResetColor();
            Console.ReadKey(); Console.Clear(); abrirExcel();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                    _          _      _          \n| _ ) __ _ ___ ___   __| |___   __| |__ _| |_ ___ ___\n| _ \\/ _` (_-</ -_) / _` / -_) / _` / _` |  _/ _ (_-<\n|___/\\__,_/__/\\___| \\__,_\\___| \\__,_\\__,_|\\__\\___/__/\n                                                     \n"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("No tienes acceso..."); Console.ResetColor();
            Console.ReadKey(); Console.Clear(); goto verbd;
        }
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto verbd;
}
Console.Clear();
//Fin guardar informacion

//Fin del programa
repetir:
try
{
    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write(" ___ _           _     _                                           _ \n| __(_)_ _    __| |___| |   _ __ _ _ ___  __ _ _ _ __ _ _ __  __ _| |\n| _|| | ' \\  / _` / -_) |  | '_ \\ '_/ _ \\/ _` | '_/ _` | '  \\/ _` |_|\n|_| |_|_||_| \\__,_\\___|_|  | .__/_| \\___/\\__, |_| \\__,_|_|_|_\\__,_(_)\n                           |_|           |___/                       \n"); Console.ResetColor();
    Console.Write("\nDesea repetir el proceso (Y/N)? ");
    char repetir = Convert.ToChar(Console.ReadLine()!.ToUpper());
    if (repetir != 'Y' && repetir != 'N')
    {
        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
        Console.ReadKey(); Console.Clear(); goto repetir;
    }
    else if (repetir == 'Y')
    {
        for (int i = 0; i < (ruleta.Length / 3); i++)
        { // i += 1 // i = i + 1
            for (int y = 0; y < 2; y++)
            {
                ruleta[i, y] = false;
            }
        }
        Console.Clear(); goto programa;
    }
}
catch (Exception)
{
    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Valor no valido..."); Console.ResetColor();
    Console.ReadKey(); Console.Clear(); goto repetir;
}
Console.Clear();
//Fin del fin del programa

//Funciones que estan del kilo
static void animacionPresentacion()
{
    const string espaciados = "\n\n\n\n\n\n\n";
    string[] animacionPacman = { $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗ ███████╗██████╗\n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗██╔════╝██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║     ███████╗██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝\n{espaciados}\n{espaciados}", $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗ ███████╗██████╗\n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗██╔════╝██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║     ███████╗██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝\n\n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n{espaciados}", $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗ ███████╗██████╗\n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗██╔════╝██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║     ███████╗██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝\n\n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n\n ███████╗██╗      █████╗ ███████╗██╗  ██╗██████╗  █████╗  ██████╗██╗  ██╗ \n ██╔════╝██║     ██╔══██╗██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██║ ██╔╝ \n █████╗  ██║     ███████║███████╗███████║██████╔╝███████║██║     █████╔╝  \n ██╔══╝  ██║     ██╔══██║╚════██║██╔══██║██╔══██╗██╔══██║██║     ██╔═██╗  \n ██║     ███████╗██║  ██║███████║██║  ██║██████╔╝██║  ██║╚██████╗██║  ██╗ \n ╚═╝     ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ \n" };
    int espacios = (Console.WindowWidth - (animacionPacman[0].Length / 6)) / 2;
    Console.Clear();
    for (int i = 1; i <= animacionPacman.Length * 3; i++)
    {
        Console.Write(animacionPacman[(i - 1) / animacionPacman.Length].Replace("\n", "\n" + new String(' ', espacios)));


        Thread.Sleep(300);
        Console.Clear();
        Thread.Sleep(200);
    }

    string[] animacionPresentacion = { $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗ ███████╗██████╗\n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗██╔════╝██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝█████╗  ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║     ███████╗██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n ███████╗██╗      █████╗ ███████╗██╗  ██╗██████╗  █████╗  ██████╗██╗  ██╗ \n ██╔════╝██║     ██╔══██╗██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██║ ██╔╝ \n █████╗  ██║     ███████║███████╗███████║██████╔╝███████║██║     █████╔╝  \n ██╔══╝  ██║     ██╔══██║╚════██║██╔══██║██╔══██╗██╔══██║██║     ██╔═██╗  \n ██║     ███████╗██║  ██║███████║██║  ██║██████╔╝██║  ██║╚██████╗██║  ██╗ \n ╚═╝     ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ \n                                                                          \n", $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗         ██████╗ \n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗        ██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝        ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝         ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║             ██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝             ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n ███████╗██╗      █████╗ ███████╗██╗  ██╗██████╗  █████╗  ██████╗██╗  ██╗ \n ██╔════╝██║     ██╔══██╗██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██║ ██╔╝ \n █████╗  ██║     ███████║███████╗███████║██████╔╝███████║██║     █████╔╝  \n ██╔══╝  ██║     ██╔══██║╚════██║██╔══██║██╔══██╗██╔══██║██║     ██╔═██╗  \n ██║     ███████╗██║  ██║███████║██║  ██║██████╔╝██║  ██║╚██████╗██║  ██╗ \n ╚═╝     ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ \n                                                                          \n", $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗         ██████╗ \n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗        ██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝        ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝         ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║             ██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝             ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n ███████╗██╗      █████╗         ██╗  ██╗██████╗  █████╗  ██████╗██╗  ██╗ \n ██╔════╝██║     ██╔══██╗        ██║  ██║██╔══██╗██╔══██╗██╔════╝██║ ██╔╝ \n █████╗  ██║     ███████║        ███████║██████╔╝███████║██║     █████╔╝  \n ██╔══╝  ██║     ██╔══██║        ██╔══██║██╔══██╗██╔══██║██║     ██╔═██╗  \n ██║     ███████╗██║  ██║        ██║  ██║██████╔╝██║  ██║╚██████╗██║  ██╗ \n ╚═╝     ╚══════╝╚═╝  ╚═╝        ╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝ \n                                                                          \n", $"\n██████╗ ███████╗██╗   ██╗███████╗██╗      ██████╗ ██████╗         ██████╗ \n██╔══██╗██╔════╝██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗        ██╔══██╗\n██║  ██║█████╗  ██║   ██║█████╗  ██║     ██║   ██║██████╔╝        ██████╔╝\n██║  ██║██╔══╝  ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝         ██╔══██╗\n██████╔╝███████╗ ╚████╔╝ ███████╗███████╗╚██████╔╝██║             ██║  ██║\n╚═════╝ ╚══════╝  ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝             ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n ███████╗██╗      █████╗         ██╗  ██╗██████╗  █████╗  ██████╗         \n ██╔════╝██║     ██╔══██╗        ██║  ██║██╔══██╗██╔══██╗██╔════╝         \n █████╗  ██║     ███████║        ███████║██████╔╝███████║██║              \n ██╔══╝  ██║     ██╔══██║        ██╔══██║██╔══██╗██╔══██║██║              \n ██║     ███████╗██║  ██║        ██║  ██║██████╔╝██║  ██║╚██████╗         \n ╚═╝     ╚══════╝╚═╝  ╚═╝        ╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗         ██╗   ██╗███████╗██╗      ██████╗ ██████╗         ██████╗ \n██╔══██╗        ██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗        ██╔══██╗\n██║  ██║        ██║   ██║█████╗  ██║     ██║   ██║██████╔╝        ██████╔╝\n██║  ██║        ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝         ██╔══██╗\n██████╔╝         ╚████╔╝ ███████╗███████╗╚██████╔╝██║             ██║  ██║\n╚═════╝           ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝             ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n ███████╗██╗      █████╗         ██╗  ██╗██████╗  █████╗  ██████╗         \n ██╔════╝██║     ██╔══██╗        ██║  ██║██╔══██╗██╔══██╗██╔════╝         \n █████╗  ██║     ███████║        ███████║██████╔╝███████║██║              \n ██╔══╝  ██║     ██╔══██║        ██╔══██║██╔══██╗██╔══██║██║              \n ██║     ███████╗██║  ██║        ██║  ██║██████╔╝██║  ██║╚██████╗         \n ╚═╝     ╚══════╝╚═╝  ╚═╝        ╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗         ██╗   ██╗███████╗██╗      ██████╗ ██████╗         ██████╗ \n██╔══██╗        ██║   ██║██╔════╝██║     ██╔═══██╗██╔══██╗        ██╔══██╗\n██║  ██║        ██║   ██║█████╗  ██║     ██║   ██║██████╔╝        ██████╔╝\n██║  ██║        ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║██╔═══╝         ██╔══██╗\n██████╔╝         ╚████╔╝ ███████╗███████╗╚██████╔╝██║             ██║  ██║\n╚═════╝           ╚═══╝  ╚══════╝╚══════╝ ╚═════╝ ╚═╝             ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗      █████╗         ██╗  ██╗██████╗  █████╗  ██████╗         \n         ██║     ██╔══██╗        ██║  ██║██╔══██╗██╔══██╗██╔════╝         \n         ██║     ███████║        ███████║██████╔╝███████║██║              \n         ██║     ██╔══██║        ██╔══██║██╔══██╗██╔══██║██║              \n         ███████╗██║  ██║        ██║  ██║██████╔╝██║  ██║╚██████╗         \n         ╚══════╝╚═╝  ╚═╝        ╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗         ██╗   ██╗███████╗██╗      ██████╗                 ██████╗ \n██╔══██╗        ██║   ██║██╔════╝██║     ██╔═══██╗                ██╔══██╗\n██║  ██║        ██║   ██║█████╗  ██║     ██║   ██║                ██████╔╝\n██║  ██║        ╚██╗ ██╔╝██╔══╝  ██║     ██║   ██║                ██╔══██╗\n██████╔╝         ╚████╔╝ ███████╗███████╗╚██████╔╝                ██║  ██║\n╚═════╝           ╚═══╝  ╚══════╝╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗      █████╗                 ██████╗  █████╗  ██████╗         \n         ██║     ██╔══██╗                ██╔══██╗██╔══██╗██╔════╝         \n         ██║     ███████║                ██████╔╝███████║██║              \n         ██║     ██╔══██║                ██╔══██╗██╔══██║██║              \n         ███████╗██║  ██║                ██████╔╝██║  ██║╚██████╗         \n         ╚══════╝╚═╝  ╚═╝                ╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗         ██╗   ██╗        ██╗      ██████╗                 ██████╗ \n██╔══██╗        ██║   ██║        ██║     ██╔═══██╗                ██╔══██╗\n██║  ██║        ██║   ██║        ██║     ██║   ██║                ██████╔╝\n██║  ██║        ╚██╗ ██╔╝        ██║     ██║   ██║                ██╔══██╗\n██████╔╝         ╚████╔╝         ███████╗╚██████╔╝                ██║  ██║\n╚═════╝           ╚═══╝          ╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗      █████╗                 ██████╗  █████╗  ██████╗         \n         ██║     ██╔══██╗                ██╔══██╗██╔══██╗██╔════╝         \n         ██║     ███████║                ██████╔╝███████║██║              \n         ██║     ██╔══██║                ██╔══██╗██╔══██║██║              \n         ███████╗██║  ██║                ██████╔╝██║  ██║╚██████╗         \n         ╚══════╝╚═╝  ╚═╝                ╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗         ██╗   ██╗        ██╗      ██████╗                 ██████╗ \n██╔══██╗        ██║   ██║        ██║     ██╔═══██╗                ██╔══██╗\n██║  ██║        ██║   ██║        ██║     ██║   ██║                ██████╔╝\n██║  ██║        ╚██╗ ██╔╝        ██║     ██║   ██║                ██╔══██╗\n██████╔╝         ╚████╔╝         ███████╗╚██████╔╝                ██║  ██║\n╚═════╝           ╚═══╝          ╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗                             ██████╗  █████╗  ██████╗         \n         ██║                             ██╔══██╗██╔══██╗██╔════╝         \n         ██║                             ██████╔╝███████║██║              \n         ██║                             ██╔══██╗██╔══██║██║              \n         ███████╗                        ██████╔╝██║  ██║╚██████╗         \n         ╚══════╝                        ╚═════╝ ╚═╝  ╚═╝ ╚═════╝         \n                                                                          \n", $"\n██████╗                          ██╗      ██████╗                 ██████╗ \n██╔══██╗                         ██║     ██╔═══██╗                ██╔══██╗\n██║  ██║                         ██║     ██║   ██║                ██████╔╝\n██║  ██║                         ██║     ██║   ██║                ██╔══██╗\n██████╔╝                         ███████╗╚██████╔╝                ██║  ██║\n╚═════╝                          ╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗                             ██████╗          ██████╗         \n         ██║                             ██╔══██╗        ██╔════╝         \n         ██║                             ██████╔╝        ██║              \n         ██║                             ██╔══██╗        ██║              \n         ███████╗                        ██████╔╝        ╚██████╗         \n         ╚══════╝                        ╚═════╝          ╚═════╝         \n                                                                          \n", $"\n██████╗                          ██╗      ██████╗                 ██████╗ \n██╔══██╗                         ██║     ██╔═══██╗                ██╔══██╗\n██║  ██║                         ██║     ██║   ██║                ██████╔╝\n██║  ██║                         ██║     ██║   ██║                ██╔══██╗\n██████╔╝                         ███████╗╚██████╔╝                ██║  ██║\n╚═════╝                          ╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗                             ██████╗                          \n         ██║                             ██╔══██╗                         \n         ██║                             ██████╔╝                         \n         ██║                             ██╔══██╗                         \n         ███████╗                        ██████╔╝                         \n         ╚══════╝                        ╚═════╝                          \n                                                                          \n", $"\n                                 ██╗      ██████╗                 ██████╗ \n                                 ██║     ██╔═══██╗                ██╔══██╗\n                                 ██║     ██║   ██║                ██████╔╝\n                                 ██║     ██║   ██║                ██╔══██╗\n                                 ███████╗╚██████╔╝                ██║  ██║\n                                 ╚══════╝ ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗                             ██████╗                          \n         ██║                             ██╔══██╗                         \n         ██║                             ██████╔╝                         \n         ██║                             ██╔══██╗                         \n         ███████╗                        ██████╔╝                         \n         ╚══════╝                        ╚═════╝                          \n                                                                          \n", $"\n                                          ██████╗                 ██████╗ \n                                         ██╔═══██╗                ██╔══██╗\n                                         ██║   ██║                ██████╔╝\n                                         ██║   ██║                ██╔══██╗\n                                         ╚██████╔╝                ██║  ██║\n                                          ╚═════╝                 ╚═╝  ╚═╝\n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n         ██╗                             ██████╗                          \n         ██║                             ██╔══██╗                         \n         ██║                             ██████╔╝                         \n         ██║                             ██╔══██╗                         \n         ███████╗                        ██████╔╝                         \n         ╚══════╝                        ╚═════╝                          \n                                                                          \n", $"\n                                          ██████╗                         \n                                         ██╔═══██╗                        \n                                         ██║   ██║                        \n                                         ██║   ██║                        \n                                         ╚██████╔╝                        \n                                          ╚═════╝                         \n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n                                         ██████╗                          \n                                         ██╔══██╗                         \n                                         ██████╔╝                         \n                                         ██╔══██╗                         \n                                         ██████╔╝                         \n                                         ╚═════╝                          \n                                                                          \n", $"\n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n                                         ██████╗                          \n                                         ██╔══██╗                         \n                                         ██████╔╝                         \n                                         ██╔══██╗                         \n                                         ██████╔╝                         \n                                         ╚═════╝                          \n                                                                          \n", $"\n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n                                                                          \n", $"\n{espaciados}                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ ██████╗                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                          ╚═════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ █████                           \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                            ════╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ ████                            \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                             ═══╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ ███                             \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                              ══╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ ██                              \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                               ═╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗ █                               \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                ╝ ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████╗                                 \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                  ╚═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██████                                  \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                   ═════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ █████                                   \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                    ════╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ████                                    \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                     ═══╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ███                                     \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                      ══╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ ██                                      \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                       ═╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗ █                                       \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                        ╝ ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████╗                                         \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                          ╚═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██████                                          \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                           ═════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          █████                                           \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                            ════╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ████                                            \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                             ═══╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ███                                             \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                              ══╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          ██                                              \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                               ═╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                          █                                               \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                                ╝                         \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                         ██╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔╝                        \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                          █╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████╔                         \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                           ╔════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██████                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                            ════╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝█████                           \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                             ═══╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝████                            \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                              ══╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝███                             \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                               ═╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝██                              \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                ╝██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝█                               \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                 ██╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔╝                                \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                  █╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████╔                                 \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                   ╔═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██████                                  \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                    ═══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚█████                                   \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                     ══██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚████                                    \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                      ═██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚███                                     \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                       ██╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚██                                      \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                        █╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚█                                       \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                         ╗██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗╚                                        \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                          ██╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████╗                                         \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                           █╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██████                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                            ╔══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚█████                                           \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                             ══██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚████                                            \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                              ═██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚███                                             \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                               ██╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚██                                              \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                █╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚█                                               \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                 ╗                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                         ╚                                                \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║██║  ██║                        \n                         ██║     ██║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║██║  ██                         \n                          █║     ██║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║██║  █                          \n                           ║     ██║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║██║                             \n                                 ██║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║██                              \n                                  █║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║█                               \n                                   ║   ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██║                                \n                                       ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   ██                                 \n                                       ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║   █                                  \n                                       ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║                                      \n                                       ██║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║                                      \n                                        █║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║                                      \n                                         ║██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██║                                      \n                                          ██║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     ██                                       \n                                           █║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║     █                                        \n                                            ║  ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██║                                              \n                                               ██║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         ██                                               \n                                                █║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}                                                                          \n                                                                          \n                         █                                                \n                                                 ║                        \n                                                                          \n                                                                          \n                                                                          \n{espaciados}", $"\n{espaciados}{espaciados}{espaciados}", };
    Console.Clear();
    for (int i = 0; i < animacionPresentacion.Length; i++)
    {
        Console.Write(animacionPresentacion[i].Replace("\n", "\n" + new String(' ', espacios)));
        if (i == 0) { Thread.Sleep(4000); }
        if (i <= 15) { Thread.Sleep(200); }
        else if (i <= animacionPresentacion.Length) { Thread.Sleep(75); }
        Console.Clear();
    }
}
static void animacionPacman()
{
    Console.Clear();
    string[] animacionPacman = { "\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n       Cargando       ", "\n██████████████████████\n██████████████████████\n███████████████████░██\n██████████████████████\n██████████████████████\n       Cargando       ", "\n██████████████████████\n██████████████████████\n██████████████████░░██\n██████████████████████\n██████████████████████\n       Cargando       ", "\n██████████████████████\n██████████████████████\n███████████████░██░░██\n██████████████████████\n██████████████████████\n       Cargando.      ", "\n██████████████████████\n██████████████████████\n██████████████░░██░░██\n██████████████████████\n██████████████████████\n       Cargando.      ", "\n██████████████████████\n██████████████████████\n███████████░██░░██░░██\n██████████████████████\n██████████████████████\n       Cargando.      ", "\n██████████████████████\n██████████████████████\n██████████░░██░░██░░██\n██████████████████████\n██████████████████████\n       Cargando..     ", "\n██████████████████████\n▀█████████████████████\n █████████░░██░░██░░██\n▄█████████████████████\n██████████████████████\n       Cargando..     ", "\n▀█████████████████████\n░▄████████████████████\n██████████░░██░░██░░██\n░▀████████████████████\n▄█████████████████████\n       Cargando..     ", "\n▀█████████████████████\n░░▀███████████████████\n░░ ███████░░██░░██░░██\n░░▄███████████████████\n▄█████████████████████\n       Cargando...    ", "\n▀▀▀███████████████████\n░░░▄██████████████████\n░░████████░░██░░██░░██\n░░░▀██████████████████\n▄▄▄███████████████████\n       Cargando...    ", "\n▀▀▀███████████████████\n░░░░▀█████████████████\n░░░░ █████░░██░░██░░██\n░░░░▄█████████████████\n▄▄▄███████████████████\n       Cargando...    ", "\n█▀▀▀▀█████████████████\n░░░░░▄████████████████\n░░░░██████░░██░░██░░██\n░░░░░▀████████████████\n█▄▄▄▄█████████████████\n       Cargando       ", "\n██▀▀▀█████████████████\n█░░░░░▀███████████████\n▌░░░░░ ███░░██░░██░░██\n█░░░░░▄███████████████\n██▄▄▄█████████████████\n       Cargando       ", "\n███▀▀▀▀███████████████\n██░░░░░▄██████████████\n█▌░░░░████░░██░░██░░██\n██░░░░░▀██████████████\n███▄▄▄▄███████████████\n       Cargando       ", "\n████▀▀▀███████████████\n███░░░░░▀█████████████\n██▌░░░░░ █░░██░░██░░██\n███░░░░░▄█████████████\n████▄▄▄███████████████\n       Cargando.      ", "\n█████▀▀▀▀█████████████\n████░░░░░▄████████████\n███▌░░░░██░░██░░██░░██\n████░░░░░▀████████████\n█████▄▄▄▄█████████████\n       Cargando.      ", "\n██████▀▀▀█████████████\n█████░░░░░▀███████████\n████▌░░░░░ ░██░░██░░██\n█████░░░░░▄███████████\n██████▄▄▄█████████████\n       Cargando.      ", "\n███████▀▀▀▀███████████\n██████░░░░░▄██████████\n█████▌░░░░░░██░░██░░██\n██████░░░░░▀██████████\n███████▄▄▄▄███████████\n       Cargando..     ", "\n████████▀▀▀███████████\n███████░░░░░▀█████████\n██████▌░░░░░ █░░██░░██\n███████░░░░░▄█████████\n████████▄▄▄███████████\n       Cargando..     ", "\n█████████▀▀▀▀█████████\n████████░░░░░▄████████\n███████▌░░░░██░░██░░██\n████████░░░░░▀████████\n█████████▄▄▄▄█████████\n       Cargando..     ", "\n██████████▀▀▀█████████\n█████████░░░░░▀███████\n████████▌░░░░░ ░██░░██\n█████████░░░░░▄███████\n██████████▄▄▄█████████\n       Cargando...    ", "\n████████████▀▀▀▀██████\n███████████░░░░░▄█████\n██████████▌░░░░░██░░██\n███████████░░░░░▀█████\n████████████▄▄▄▄██████\n       Cargando...    ", "\n█████████████▀▀▀██████\n████████████░░░░░▀████\n███████████▌░░░░░ ░░██\n████████████░░░░░▄████\n█████████████▄▄▄██████\n       Cargando...    ", "\n███████████████▀▀▀▀███\n██████████████░░░░░▄██\n█████████████▌░░░░░░██\n██████████████░░░░░▀██\n███████████████▄▄▄▄███\n       Cargando       ", "\n████████████████▀▀▀███\n███████████████░░░░░▀█\n██████████████▌░░░░░ █\n███████████████░░░░░▄█\n████████████████▄▄▄███\n       Cargando       ", "\n█████████████████▀▀▀▀█\n████████████████░░░░░▄\n███████████████▌░░░░██\n████████████████░░░░░▀\n█████████████████▄▄▄▄█\n       Cargando       ", "\n██████████████████▀▀▀█\n█████████████████░░░░░\n████████████████▌░░░░░\n█████████████████░░░░░\n██████████████████▄▄▄█\n       Cargando.      ", "\n███████████████████▀▀▀\n██████████████████░░░░\n█████████████████▌░░░░\n██████████████████░░░░\n███████████████████▄▄▄\n       Cargando.      ", "\n████████████████████▀▀\n███████████████████░░░\n██████████████████▌░░░\n███████████████████░░░\n████████████████████▄▄\n       Cargando.      ", "\n█████████████████████▀\n████████████████████░░\n███████████████████▌░░\n████████████████████░░\n█████████████████████▄\n       Cargando..     ", "\n██████████████████████\n█████████████████████░\n████████████████████▌░\n█████████████████████░\n██████████████████████\n       Cargando..     ", "\n██████████████████████\n██████████████████████\n█████████████████████▌\n██████████████████████\n██████████████████████\n       Cargando..     ", "\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n       Cargando...    ", "\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n       Cargando...    ", "\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n██████████████████████\n       Cargando...    " };
    for (int i = 0; i < 2; i++)
    {
        int espacios = (Console.WindowWidth - (animacionPacman[0].Length / 5)) / 2;
        for (int y = 0; y < animacionPacman.Length; y++)
        {
            Console.Write(animacionPacman[y].Replace("\n", "\n" + new String(' ', espacios)));
            Thread.Sleep(100);
            Console.Clear();
        }
    }
    Console.Clear();
}
static void crearCarpeta(string nomProyecto)
{
    string rutaCarpetaProyecto = @"..\Programas";
    Process.Start("cmd", $"cmd /c start cmd /k \"cd {rutaCarpetaProyecto} && dotnet new console -o {nomProyecto}\"");
    Thread.Sleep(5000);

    cerrarProceso("cmd");
}
static void cerrarProceso(string procesoKill)
{
    Process[] cmdProcesses = Process.GetProcessesByName(procesoKill);
    foreach (Process cmdProcess in cmdProcesses)
    {
        cmdProcess.Kill();
    }
}
static void abrirCodigoProyecto(string nomProyecto)
{
    string rutaProyecto = @$"..\Programas\{nomProyecto}\Program.cs";
    Process.Start(new ProcessStartInfo(rutaProyecto) { UseShellExecute = true });
}
static void ejecucionProyecto(string nomProyecto)
{
    string rutaCarpetaProyecto = @$"..\Programas\{nomProyecto}";
    string comando = $"cmd /c start cmd /k \"cd {rutaCarpetaProyecto} && dotnet run\"";
    Process.Start("cmd", comando);
}
static void corazones(int intentos)
{
    Console.ForegroundColor = ConsoleColor.Red;
    dynamic[] corazonTres = { "\n +----------------------------------------------------+\n |   ▓▓▓▓  ▓▓▓▓        ▓▓▓▓  ▓▓▓▓        ▓▓▓▓  ▓▓▓▓   | \n | ▓▓████▓▓████▓▓    ▓▓████▓▓████▓▓    ▓▓████▓▓████▓▓ | \n | ▓▓██████████▓▓    ▓▓██████████▓▓    ▓▓██████████▓▓ | \n |   ▓▓██████▓▓        ▓▓██████▓▓        ▓▓██████▓▓   | \n |     ▓▓██▓▓            ▓▓██▓▓            ▓▓██▓▓     | \n |       ▓▓                ▓▓                ▓▓       |\n +----------------------------------------------------+ \n", "\n +----------------------------------------------------+\n |                     ▓▓▓▓  ▓▓▓▓        ▓▓▓▓  ▓▓▓▓   | \n |                   ▓▓████▓▓████▓▓    ▓▓████▓▓████▓▓ | \n |                   ▓▓██████████▓▓    ▓▓██████████▓▓ | \n |                     ▓▓██████▓▓        ▓▓██████▓▓   | \n |                       ▓▓██▓▓            ▓▓██▓▓     | \n |                         ▓▓                ▓▓       | \n +----------------------------------------------------+\n" }, corazonDos = { "\n +----------------------------------------------------+\n |                    ▓▓▓▓  ▓▓▓▓        ▓▓▓▓  ▓▓▓▓    |\n |                  ▓▓████▓▓████▓▓    ▓▓████▓▓████▓▓  |\n |                  ▓▓██████████▓▓    ▓▓██████████▓▓  |\n |                    ▓▓██████▓▓        ▓▓██████▓▓    |\n |                      ▓▓██▓▓            ▓▓██▓▓      |\n |                        ▓▓                ▓▓        |\n +----------------------------------------------------+\n", "\n +----------------------------------------------------+\n |                                      ▓▓▓▓  ▓▓▓▓    |\n |                                    ▓▓████▓▓████▓▓  |\n |                                    ▓▓██████████▓▓  |\n |                                      ▓▓██████▓▓    |\n |                                        ▓▓██▓▓      |\n |                                          ▓▓        |\n +----------------------------------------------------+\n" }, corazonUno = { "\n +----------------------------------------------------+\n |                                      ▓▓▓▓  ▓▓▓▓    |\n |                                    ▓▓████▓▓████▓▓  |\n |                                    ▓▓██████████▓▓  |\n |                                      ▓▓██████▓▓    |\n |                                        ▓▓██▓▓      |\n |                                          ▓▓        |\n +----------------------------------------------------+\n", "\n +----------------------------------------------------+\n |                                                    |\n |                                                    |\n |                                                    |\n |                                                    |\n |                                                    |\n |                                                    |\n +----------------------------------------------------+\n" };

    int espacios = (Console.WindowWidth - (corazonTres[0].Length / 8)) / 2;
    if (intentos == 2)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < corazonTres.Length; y++)
            {
                Console.Write(corazonTres[y].Replace("\n", "\n" + new String(' ', espacios)));
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
    else if (intentos == 1)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < corazonDos.Length; y++)
            {
                Console.Write(corazonDos[y].Replace("\n", "\n" + new String(' ', espacios)));
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
    else if (intentos == 0)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < corazonUno.Length; y++)
            {
                Console.Write(corazonUno[y].Replace("\n", "\n" + new String(' ', espacios)));
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
    Console.ResetColor();
}
static void guardarJson(string[] seleccionados, int minuto, int lineas, int l_intentos, string nomProyecto, TimeSpan s_empleados, int l_empleadas, int i_empleados, bool realizado)
{
    StreamReader sr = new StreamReader(@"..\BD_Proyecto.json");
    string rutaArchivo = Path.GetFullPath(@$"..\Programas\{nomProyecto}\bin\Debug\net8.0\{nomProyecto}.exe");
    rutaArchivo = rutaArchivo.Replace("\\", "\\\\");
    string bdAnterior = sr.ReadToEnd().Replace("]", ",{\n  \"Facilitador\" : \"" + seleccionados[1] + "\",\n  \"Lim. minutos\" : " + minuto + ",\n  \"Lim. linea\" : " + lineas + ",\n  \"Lim. intentos\" : " + l_intentos + ",\n  \"Desarrollador\" : \"" + seleccionados[0] + "\",\n  \"S. Empleados\" : " + s_empleados.TotalSeconds + ",\n  \"L. Empleadas\" : " + l_empleadas + ",\n  \"I. Empleados\" : " + i_empleados + ",\n  \"Programa\": \"=HYPERLINK(\\\"" + rutaArchivo + "\\\", \\\"" + nomProyecto + "\\\")\",\n  \"Realizado\" : true,\n  \"Puntuacion\" : 10,\n  \"Fecha\" : \"" + DateTime.Now.ToString("dd/MM/yyyy") + "\"\n}]");
    sr.Close();

    StreamWriter sw = new StreamWriter(@"..\BD_Proyecto.json");
    sw.WriteLine(bdAnterior);
    sw.Close();
}
static int fClave()
{
    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
    int clave = 0;
    Console.Clear();
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Green; Console.Write(" ___                    _          _      _          \n| _ ) __ _ ___ ___   __| |___   __| |__ _| |_ ___ ___\n| _ \\/ _` (_-</ -_) / _` / -_) / _` / _` |  _/ _ (_-<\n|___/\\__,_/__/\\___| \\__,_\\___| \\__,_\\__,_|\\__\\___/__/\n                                                     \n"); Console.ResetColor();
        Console.Write("Introduzca su clave: ");
        keyInfo = Console.ReadKey();
        Console.Clear();
        if (keyInfo.Key == ConsoleKey.Enter)
        {
            break;
        }
        clave += keyInfo.KeyChar;
    }
    return clave;
}
static void abrirExcel()
{
    string rutaArchivo = Path.GetFullPath(@"..\BD_Proyecto.xlsx");
    Process.Start("powershell", $"add-type -AssemblyName System.Windows.Forms; Start-Process -FilePath \"{rutaArchivo}\"; start-sleep -Seconds 6; [System.Windows.Forms.SendKeys]::SendWait('^%{{F5}}')");
    //+SHIFT <=> ^CTRL <=> %ALT <=> ~ENTER 
}
//Fin de funciones que estan del kilo
