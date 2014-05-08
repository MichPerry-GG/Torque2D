//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function ImageEditor::create(%this)
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

function ImageEditor::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function ImageEditor::buildMenu(%this)
{
   
}