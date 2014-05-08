//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function EditorShell::initializeEventManager(%this)
{
    if (!isObject(%this.EditorEventManager))
    {
        %this.EditorEventManager = new EventManager()
        { 
            queue = "EditorEventManager"; 
        };
        
        %this.EditorEventManager.registerEvent("_StartUpComplete");
        %this.EditorEventManager.registerEvent("_PluginsLoaded");
        %this.EditorEventManager.registerEvent("_FileMenuChanged");
        %this.EditorEventManager.registerEvent("_CoreShutdown");
        
        %this.EditorEventManager.subscribe(%this, "_StartUpComplete", "onStartUpComplete");
        %this.EditorEventManager.subscribe(%this, "_PluginsLoaded", "onPluginsLoaded");
        %this.EditorEventManager.subscribe(%this, "_FileMenuChanged", "onFileMenuChanged");
        %this.EditorEventManager.subscribe(%this, "_CoreShutdown", "onCoreShutdown");
    }    
}

//-----------------------------------------------------------------------------

function EditorShell::registerEvent(%this, %eventName, %listener, %callback)
{
    %this.EditorEventManager.registerEvent(%eventName);
    %this.EditorEventManager.subscribe(%listener, %eventName, %callback);
}

//-----------------------------------------------------------------------------

function EditorShell::triggerEvent(%this, %eventName, %data)
{
    %this.EditorEventManager.postEvent(%eventName, %data);
}

//-----------------------------------------------------------------------------

function EditorShell::onStartupComplete(%this)
{
    echo("%- Startup complete");
    PluginSystem.loadPlugins();
}

//-----------------------------------------------------------------------------

function EditorShell::onPluginsLoaded(%this)
{
    echo("%- All plugins loaded");
}

//-----------------------------------------------------------------------------

function EditorShell::onFileMenuChanged(%this)
{
    EditorShell.detachMenuGroup();
    EditorShell.sortMenu();
    EditorShell.attachMenuGroup();
}

//-----------------------------------------------------------------------------

function EditorShell::onCoreShutdown(%this)
{
    echo("%- Editor shutting down");
}