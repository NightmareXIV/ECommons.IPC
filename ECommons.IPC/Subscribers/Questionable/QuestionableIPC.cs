using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.Questionable;

public sealed class QuestionableIPC : IPCBase
{
    public QuestionableIPC()
    {
    }

    public QuestionableIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "Questionable";

    [EzIPC("IsRunning")] public Func<bool> IsRunning{get; private set;}
    [EzIPC("GetCurrentQuestId")] public Func<string?> GetCurrentQuestId{get; private set;}
    [EzIPC("GetCurrentStepData")] public Func<StepData?> GetCurrentStepData{get; private set;}
    [EzIPC("GetCurrentlyActiveEventQuests")] public Func<List<string>> GetCurrentlyActiveEventQuests{get; private set;}
    [EzIPC("StartQuest")] public Func<string, bool> StartQuest{get; private set;}
    [EzIPC("StartSingleQuest")] public Func<string, bool> StartSingleQuest{get; private set;}
    [EzIPC("StartEventQuests")] public Func<bool> StartEventQuests{get; private set;}
    [EzIPC("GetStopReason")] public Func<string> GetStopReason{get; private set;}
    [EzIPC("IsQuestLocked")] public Func<string, bool> IsQuestLocked{get; private set;}
    [EzIPC("IsQuestComplete")] public Func<string, bool> IsQuestComplete{get; private set;}
    [EzIPC("IsReadyToAcceptQuest")] public Func<string, bool> IsReadyToAcceptQuest{get; private set;}
    [EzIPC("IsQuestAccepted")] public Func<string, bool> IsQuestAccepted{get; private set;}
    [EzIPC("IsQuestUnobtainable")] public Func<string, bool> IsQuestUnobtainable{get; private set;}
    [EzIPC("ImportQuestPriority")] public Func<string, bool> ImportQuestPriority{get; private set;}
    [EzIPC("ClearQuestPriority")] public Func<bool> ClearQuestPriority{get; private set;}
    [EzIPC("AddQuestPriority")] public Func<string, bool> AddQuestPriority{get; private set;}
    [EzIPC("InsertQuestPriority")] public Func<int, string, bool> InsertQuestPriority{get; private set;}
    [EzIPC("ExportQuestPriority")] public Func<string> ExportQuestPriority{get; private set;}
    [EzIPC("Stop")] public Func<string, bool> Stop { get; private set; }
}
