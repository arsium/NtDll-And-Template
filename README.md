# NtDll & Template

This is A way to implement NtDll in C# (also includes some kernel32.dll functions to get thread or process handle).I tried to be closest to C++ implementations.Partially implemented.

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
* NTSTATUS (enum)
* _KWAIT_REASON (enum)
* _THREAD_INFO_CLASS (enum)
* _PROCESS_INFO_CLASS (enum)
* _PRIORITY_CLASS (enum)
* _SHUTDOWN_ACTION (enum)
* _SYSTEM_INFORMATION_CLASS (enum)
* _HARDERROR_RESPONSE (enum)
* _HARDERROR_RESPONSE_OPTION (enum)
* _PRIVILEGES (enum)
* _SYSTEM_HANDLE_ENTRY (struct)
* _SYSTEM_HANDLE_TABLE_ENTRY_INFO (struct)
* _SYSTEM_HANDLE_INFORMATION (struct)
* _THREAD_BASIC_INFORMATION (struct)
* _PROCESS_EXTENDED_BASIC_INFORMATION (struct)
* _PROCESS_BASIC_INFORMATION (struct)
* _SYSTEM_INTERRUPT_INFORMATION (struct)
* _SYSTEM_DPC_BEHAVIOR_INFORMATION (struct)
* _SYSTEM_FILECACHE_INFORMATION (struct)
* _SYSTEM_PAGEFILE_INFORMATION (struct)
* UNICODE_STRING (struct & class)
* _SYSTEM_PROCESSOR_POWER_INFORMATION (struct)
* _SYSTEM_EXTENDED_THREAD_INFORMATION (struct)
* _SYSTEM_EXTENDED_PROCESS_INFORMATION (struct)
* IO_COUNTERS (struct)
* VM_COUNTERS (struct)
* _CLIENT_ID (struct)
* _SYSTEM_THREAD_INFORMATION (struct)
* _SYSTEM_PROCESS_INFORMATION (struct)
* LARGE_INTEGER (struct)
* _SYSTEM_SET_TIME_ADJUST_INFORMATION (struct)
* _SYSTEM_QUERY_TIME_ADJUST_INFORMATION (struct)
* _SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION (struct)
* _SYSTEM_DEVICE_INFORMATION (struct)
* _SYSTEM_PROCESSOR_IDLE_INFORMATION (struct)
* _SYSTEM_TIMEOFDAY_INFORMATION (struct)
* _SYSTEM_PROCESSOR_IDLE_INFORMATION (struct)
* _SYSTEM_BASIC_INFORMATION (struct)
* _SYSTEM_PERFORMANCE_INFORMATION (struct)
* _SYSTEM_PROCESSOR_INFORMATION (struct)
* _SYSTEM_BOOT_ENVIRONMENT_INFORMATION (struct)

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

IMG : 

![Image description](https://i.postimg.cc/y1PZ4dNy/Capture-d-cran-29.png)
![Image description](https://i.postimg.cc/NFZ04Zkp/Capture-d-cran-30.png)

Sources (I will make a txt file with detail links): 

* http://ntoskrnl.org/
* https://doxygen.reactos.org
* http://www.dotnetframework.org
* https://csharp.hotexamples.com
