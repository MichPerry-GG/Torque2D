//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function AnimationEditor::create(%this)
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

function AnimationEditor::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function AnimationEditor::buildMenu(%this)
{
    
}