//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function EditorShell::initializeMenu(%this)
{
    $cmdCtrl = $platform $= "macos" ? "Cmd" : "Ctrl";
    
    if( $platform $= "macos" )
        %nonMacMenu = -1000;
      
    if (isObject(%this.menuGroup))
        %this.menuGroup.delete();
        
    %this.menuGroup = new SimGroup();
}

//-----------------------------------------------------------------------------

function EditorShell::destroyMenu(%this)
{
    if (isObject(%this.menuGroup))
        %this.menuGroup.delete();
}

//-----------------------------------------------------------------------------

function EditorShell::addMenu(%this, %menu)
{
    if (isObject(%this.menuGroup))
    {
        %this.menuGroup.add(%menu);
        EditorShell.triggerEvent("_FileMenuChanged", "");
    }
}

//-----------------------------------------------------------------------------

function EditorShell::sortMenu(%this)
{
    
}

//-----------------------------------------------------------------------------

function EditorShell::attachMenuGroup(%this)
{
    if (!isObject(%this.menuGroup)) 
        return;

    for(%i = 0; %i < %this.menuGroup.getCount(); %i++)
        %this.menuGroup.getObject(%i).attachToMenuBar();
}

//-----------------------------------------------------------------------------

function EditorShell::detachMenuGroup(%this)
{
    if (!isObject(%this.menuGroup)) 
        return;
    
    for(%i = 0; %i < %this.menuGroup.getCount(); %i++)
        %this.menuGroup.getObject(%i).removeFromMenuBar();
}