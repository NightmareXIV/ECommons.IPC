# ECommons.IPC
This library aims to collect IPC of various plugins to avoid/minimize amount of copypasting between plugins and for easier overall maintenance.

# How to use?
### 1. Lazy initialization.
Just access static `ECommonsIPC` class and pick your plugin. For example: `ECommonsIPC.Teleporter.Teleport(9, 0);`
### 2. Create your own instance.
`new TeleporterIPC();` or with wrapper: `new TeleporterIPC(SafeWrapper.AnyException);`. Also can be used with ECommons SingletonServiceManager.

## Safe Wrapper
If you want to use SafeWrapper globally by default, reassign it in your plugin's constructor like this:
```
public Plugin(IDalamudPluginInterface pi)
{
    IPCBase.DefaultWrapper = SafeWrapper.AnyException;
    //continue initialization
}
```

# Guidelines for adding a plugin
Note: ECommons.IPC does not attempts to preemptively gather all and any plugins and their methods. They are being added as they are needed; if you need extra method or extra plugin - feel free to pull request. 

**Plugin should have it's source code publicly available.** It doesn't necessarily have to have FOSS license, just source has to be published. And, if it has FOSS license but is distributed privately, it is not allowed to be added to this library.

1. Create a subfolder for the plugin in Subscribers folder. Name it after plugin's internal name or display name, whichever makes more sense.
2. Create a `PluginNameIPC.cs` file, which should inherit from `IPCBase`
3. Override `InternalName` (mandatory). If plugin's prefix differs from internal name, override it too (optional). 
4. Add your IPC methods. If custom structs and enums are needed, bring them as separate classes.
5. Finally, navigate to `ECommonsIPC.cs` and add a static property with your IPC there, similar to how other subscribers are already added there.

## Additional notes
1. **Custom delegates vs `Action`/`Func`**. Custom delegates are not mandatory, but can be great help if it's not clear what is expected as arguments. Define custom delegates in a nested static class named `Delegates`. If function is self-explanatory or doesn't even accepts any arguments, feel free to just use `Action`/`Func`.
2. **Helper methods.** Feel free to bring them whenever they make sense, just don't overdo it. If you prefer, you can keep delegates private and provide public methods that call delegates instead. 
3. **Events.** For now I decided not to handle events as they are rarely used by plugins at all and additional overhead they provide. However, it can be reconsidered if needed. 
