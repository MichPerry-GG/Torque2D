//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function ProjectManager::create(%this)
{
    // Execute scripts
    %fileSpec = "./scripts" @ "/*.cs";
    for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
        exec(%file);
            
    // Load GUIs
    %fileSpec = "./gui" @ "/*.taml";
    for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
        %this.add(TamlRead(%file));
}

//-----------------------------------------------------------------------------

function ProjectManager::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function ProjectManager::buildMenu(%this)
{
    
}