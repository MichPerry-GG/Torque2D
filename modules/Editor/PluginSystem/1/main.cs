//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function PluginSystem::create(%this)
{
    // Find the plugin modules.
    %this.plugins = new SimSet();
    
    %pluginModules = ModuleDatabase.findModuleTypes("plugin", false);
    
    for(%i = 0; %i < getWordCount(%pluginModules); %i++)
    {
        // Fetch module definition.
        %moduleDefinition = getWord(%pluginModules, %i);
        
        // Add to plugins
        %this.plugins.add(%moduleDefinition);
    }
    
    EditorShell.triggerEvent("_StartUpComplete", "");
}

//-----------------------------------------------------------------------------

function PluginSystem::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function PluginSystem::loadPlugins(%this)
{
    ModuleDatabase.loadGroup("plugins");
}