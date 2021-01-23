using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Native.NtDll;
using static Native.NtDll.Structures;

namespace Native
{
    public class Wrapper
    {
        //http://www.dotnetframework.org/default.aspx/DotNET/DotNET/8@0/untmp/whidbey/REDBITS/ndp/fx/src/Services/Monitoring/system/Diagnosticts/ProcessManager@cs/1/ProcessManager@cs
        public static unsafe List<Structures._SYSTEM_PROCESS_THREADS_INFORMATION> GetProcessInfos()
        {

            int bufferSize = 128 * 1024;

            bufferSize = 1024;

            int requiredSize = 0;

            NTSTATUS status;

            _SYSTEM_PROCESS_INFORMATION[] processInfos;

            void* dataPtr = (void*)Marshal.AllocHGlobal(bufferSize);

            //   void* ipHandlePointer = (void*)Marshal.AllocHGlobal((IntPtr)nHandleInfoSize);

            List<Structures._SYSTEM_PROCESS_INFORMATION> MP = new List<Structures._SYSTEM_PROCESS_INFORMATION>();


            //var cities = new Dictionary<_SYSTEM_PROCESS_INFORMATION, _SYSTEM_THREAD_INFORMATION>();

            List<Structures._SYSTEM_PROCESS_THREADS_INFORMATION> AllFinfo = new List<Structures._SYSTEM_PROCESS_THREADS_INFORMATION>();

            try
            {
                status = NtDll.Functions.NtQuerySystemInformation(
                    Enumerations._SYSTEM_INFORMATION_CLASS.SystemProcessInformation,
                    dataPtr,
                    bufferSize,
                    out requiredSize);


                while (status == NTSTATUS.STATUS_INFO_LENGTH_MISMATCH)
                {
   
                    bufferSize = requiredSize;
                    Marshal.FreeHGlobal((IntPtr)dataPtr);
                    dataPtr = (void*)Marshal.AllocHGlobal(bufferSize);

                    status = NtDll.Functions.NtQuerySystemInformation(Enumerations._SYSTEM_INFORMATION_CLASS.SystemProcessInformation, dataPtr, bufferSize, out requiredSize);

                    if (status < 0)
                    { // see definition of NT_SUCCESS(Status) in SDK
                      //  throw new InvalidOperationException(SR.GetString(SR.CouldntGetProcessInfos), new Win32Exception(status));
                    }

                    GetProcessInfos(dataPtr, ref MP, ref AllFinfo);
                }

            }
            finally
            {
                Marshal.FreeHGlobal((IntPtr)dataPtr);
            }


            return AllFinfo;
            //  return processInfos;
        }


        private unsafe static void GetProcessInfos(void* dataPtr, ref List<Structures._SYSTEM_PROCESS_INFORMATION> AllProcess, ref List<Structures._SYSTEM_PROCESS_THREADS_INFORMATION> AllInfoProcThread)
        {
            long totalOffset = 0;

            Structures._SYSTEM_PROCESS_THREADS_INFORMATION ToAddIn = new Structures._SYSTEM_PROCESS_THREADS_INFORMATION();//NEW
            while (true)
            {

                IntPtr currentPtr = (IntPtr)((long)dataPtr + totalOffset);
                Structures._SYSTEM_PROCESS_INFORMATION pi = new Structures._SYSTEM_PROCESS_INFORMATION();

                pi = (Structures._SYSTEM_PROCESS_INFORMATION)Marshal.PtrToStructure(currentPtr, pi.GetType());

                AllProcess.Add(pi);

                ToAddIn.ProcInfo = pi;//NEW

                ToAddIn.ThreadInfo = new List<_SYSTEM_THREAD_INFORMATION>();//NEW

                currentPtr = (IntPtr)((long)currentPtr + Marshal.SizeOf(pi));

                int i = 0;

                while (i < pi.NumberOfThreads)
                {
                    Structures._SYSTEM_THREAD_INFORMATION ti = new Structures._SYSTEM_THREAD_INFORMATION();

                    ti = (Structures._SYSTEM_THREAD_INFORMATION)Marshal.PtrToStructure(currentPtr, ti.GetType());

                    ToAddIn.ThreadInfo.Add(ti);//NEW

                    currentPtr = (IntPtr)((long)currentPtr + Marshal.SizeOf(ti));
                    i++;
                }

                AllInfoProcThread.Add(ToAddIn);//NEW


                if (pi.NextEntryOffset == 0)
                {
                    break;
                }
                totalOffset += pi.NextEntryOffset;
            }


        }
    }
}
