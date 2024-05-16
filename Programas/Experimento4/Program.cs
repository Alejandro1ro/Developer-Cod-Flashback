using System.Diagnostics;
try{

    Console.WriteLine("Ale");
    //Ok.

}catch(Exception){
	Console.Write("Valor no valido.");
}
Console.ReadKey();

Process[] cmdProcesses = Process.GetProcessesByName("cmd");
foreach (Process cmdProcess in cmdProcesses){
	cmdProcess.Kill();
}
