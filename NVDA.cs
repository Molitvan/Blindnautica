using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Blindnautica
{
    static class NVDA
    {
        [DllImport("nvdaControllerClient.dll", CharSet = CharSet.Unicode)]
        private static extern int nvdaController_brailleMessage(string message);

        [DllImport("nvdaControllerClient.dll")]
        private static extern int nvdaController_cancelSpeech();

        [DllImport("nvdaControllerClient.dll", CharSet = CharSet.Unicode)]
        private static extern int nvdaController_speakText(string text);

        [DllImport("nvdaControllerClient.dll")]
        private static extern int nvdaController_testIfRunning();

        [DllImport("nvdaControllerClient.dll", CharSet = CharSet.Unicode)]
        private static extern int nvdaController_getProcessId(out uint processId);

        [DllImport("nvdaControllerClient.dll", CharSet = CharSet.Unicode)]
        private static extern int nvdaController_speakSsml(
            string ssml,
            SymbolLevel symbolLevel = SymbolLevel.Unchanged,
            SpeechPriority priority = SpeechPriority.Normal,
            bool asynchronous = true
        );

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        public delegate int OnSsmlMarkReached(string mark);

        [DllImport("nvdaControllerClient.dll", CharSet = CharSet.Unicode)]
        private static extern int nvdaController_setOnSsmlMarkReachedCallback(OnSsmlMarkReached callback);

        public static bool IsRunning => nvdaController_testIfRunning() == 0;

        public static void Braille(string message)
        {
            int res = nvdaController_brailleMessage(message);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }

        }

        public static void CancelSpeech()
        {
            int res = nvdaController_cancelSpeech();
            if (res != 0)
            {
                throw new Win32Exception(res);
            }

        }

        public static void Speak(string text, bool interrupt = true)
        {
            if (interrupt)
            {
                CancelSpeech();
            }
            int res = nvdaController_speakText(text);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }
        }

        public static void SpeakSsml(
            string ssml,
            SymbolLevel symbolLevel = SymbolLevel.Unchanged,
            SpeechPriority priority = SpeechPriority.Normal,
            bool asynchronous = true,
            OnSsmlMarkReached callback = null
        )
        {
            int res = NVDA.nvdaController_setOnSsmlMarkReachedCallback(callback);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }
            res = nvdaController_speakSsml(ssml, symbolLevel, priority, asynchronous);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }
            res = NVDA.nvdaController_setOnSsmlMarkReachedCallback(null);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }
        }

        public static uint GetProcessId()
        {
            uint pid;
            int res = nvdaController_getProcessId(out pid);
            if (res != 0)
            {
                throw new Win32Exception(res);
            }
            return pid;
        }
    }

    public enum SymbolLevel
    {
        None = 0,
        Some = 100,
        Most = 200,
        All = 300,
        Char = 1000,
        Unchanged = -1
    }

    public enum SpeechPriority
    {
        /// <summary>
        /// Indicates that a speech sequence should have normal priority.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Indicates that a speech sequence should be spoken after the next utterance of lower priority is complete.
        /// </summary>
        Next = 1,
        /// <summary>
        /// Indicates that a speech sequence is very important and should be spoken right now,
        /// interrupting low priority speech.
        /// After it is spoken, interrupted speech will resume.
        /// Note that this does not interrupt previously queued speech at the same priority.
        /// </summary>
        Now = 2
    }
}