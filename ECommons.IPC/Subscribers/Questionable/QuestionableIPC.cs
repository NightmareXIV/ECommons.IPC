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
    [EzIPC("GetStopKind")] public Func<string> GetStopKind{get; private set;}
    [EzIPC("IsWaitingOnPlayer")] public Func<bool> IsWaitingOnPlayer{get; private set;}
    [EzIPC("GetCurrentTask")] public Func<string> GetCurrentTask{get; private set;}
    [EzIPC("GetRemainingTasks")] public Func<List<string>> GetRemainingTasks{get; private set;}
    [EzIPC("SkipStep")] public Func<bool> SkipStep{get; private set;}
    [EzIPC("SetStopAfterCurrentQuest")] public Func<bool, bool> SetStopAfterCurrentQuest{get; private set;}
    [EzIPC("StartDailies")] public Func<List<string>, bool> StartDailies{get; private set;}
    [EzIPC("PreviewDailies")] public Func<List<string>, string> PreviewDailies{get; private set;}
    [EzIPC("GetDailiesResult")] public Func<string> GetDailiesResult{get; private set;}
    [EzIPC("HasQuestPath")] public Func<string, bool> HasQuestPath{get; private set;}
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
    [EzIPC("MarkAcceptOnly")] public Func<string, bool> MarkAcceptOnly{get; private set;}
    [EzIPC("ClearAcceptOnly")] public Func<string, bool> ClearAcceptOnly{get; private set;}
    [EzIPC("SetProfile")] public Func<string, string, bool> SetProfile{get; private set;}
    [EzIPC("RemoveProfile")] public Func<string, bool> RemoveProfile{get; private set;}
    [EzIPC("GetProfile")] public Func<string, string> GetProfile{get; private set;}
    [EzIPC("GetActiveProfile")] public Func<string> GetActiveProfile{get; private set;}
    [EzIPC("SetSessionProfile")] public Func<string, bool> SetSessionProfile{get; private set;}
    [EzIPC("ClearSessionProfile")] public Func<bool> ClearSessionProfile{get; private set;}
    [EzIPC("Stop")] public Func<string, bool> Stop { get; private set; }
}
