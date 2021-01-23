# NtDll & Template

This is A way to implement NtDll in C# (also includes some kernel32.dll functions to get thread or process handle). Partially implemented.

Includes : 

* RtlAdjustPrivilege
* NtRaiseHardError
* NtShutdownSystem
* NtQuerySystemInformation (2 different signatures)
* NtSetInformationProcess
* NtQueryInformationProcess (2 different signatures)
* NtSetInformationThread
* NtQueryInformationThread (2 different signatures)
* RtlGetNativeSystemInformation (seems to be similar to NtQuerySystemInformation)
* DbgBreakPoint
* DbgUserBreakPoint
* GetCurrentThread (Kernel32)
* GetCurrentProcess (Kernel32)
* GetCurrentThreadId (Kernel32)
* GetCurrentProcessId (Kernel32)

Sample : 

* Get Firmware Type
* Get Numbers of Disks
* Get Total Number of Handles 
* Get Process ID (through Process and Thread)
* Debug Detection (3 ways)
* Get and Set Process Priority
* Get Thread Priority Boost
* Enable Thread Priority Boost
* Get All Processes like Process Hacker (and their threads) + some details (partially implemented)

Note  : Read sample project , commentaries and go to source links to understand how it works.

Sources : 

* http://ntoskrnl.org/
* https://doxygen.reactos.org
* http://www.dotnetframework.org
* https://csharp.hotexamples.com
