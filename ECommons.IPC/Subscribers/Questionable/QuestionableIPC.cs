using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.Questionable;

public sealed class QuestionableIPC : IPCBase
{
    public QuestionableIPC()
    {
    }

    public QuestionableIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "Questionable";

    [EzIPC("IsRunning")] public Func<bool> IsRunning{get; private set;}
    [EzIPC("GetCurrentQuestId")] public Func<string?> GetCurrentQuestId{get; private set;}
    [EzIPC("GetCurrentStepData")] public Func<StepData?> GetCurrentStepData{get; private set;}
    [EzIPC("GetCurrentlyActiveEventQuests")] public Func<List<string>> GetCurrentlyActiveEventQuests{get; private set;}
    [EzIPC("StartQuest")] public Func<string, bool> StartQuest{get; private set;}
    [EzIPC("StartSingleQuest")] public Func<string, bool> StartSingleQuest{get; private set;}
    [EzIPC("IsQuestLocked")] public Func<string, bool> IsQuestLocked{get; private set;}
    [EzIPC("ImportQuestPriority")] public Func<string, bool> ImportQuestPriority{get; private set;}
    [EzIPC("ClearQuestPriority")] public Func<string, bool> ClearQuestPriority{get; private set;}
    [EzIPC("AddQuestPriority")] public Func<bool> AddQuestPriority{get; private set;}
    [EzIPC("InsertQuestPriority")] public Func<int, string, bool> InsertQuestPriority{get; private set;}
    [EzIPC("ExportQuestPriority")] public Func<string> ExportQuestPriority{get; private set;}
}
