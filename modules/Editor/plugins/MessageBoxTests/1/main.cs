//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

function MessageBoxTests::create(%this)
{
    %this.buildMenu();
}

//-----------------------------------------------------------------------------

function MessageBoxTests::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function MessageBoxTests::buildMenu(%this)
{
    %menu = new PopupMenu()
    {
        superClass = "MenuBuilder";

        barPosition = 4;
        barName     = "Message Boxes";      

        item[0] = "OK" TAB "" TAB "MessageBoxTests.showOK();";
        item[1] = "OK Cancel" TAB "" TAB "MessageBoxTests.showOKCancel();";
        item[2] = "OK Cancel Details" TAB "" TAB "MessageBoxTests.showOKCancelDetails();";
        item[3] = "Confirm" TAB "" TAB "MessageBoxTests.showConfirm();";
        item[4] = "Confirm Action" TAB "" TAB "MessageBoxTests.showConfirmAction();";        
        item[5] = "Confirm Delete" TAB "" TAB "MessageBoxTests.showConfirmDelete();";
        item[6] = "Confirm Overwrite" TAB "" TAB "MessageBoxTests.showConfirmOverwrite();";
        item[7] = "Warning" TAB "" TAB "MessageBoxTests.showWarning();";
    };
    
    EditorShell.addMenu(%menu);
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showOK(%this)
{
    MessageBoxOK("Show OK", "This is an OK Box", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showOKCancel(%this)
{
    MessageBoxOKCancel("Show OK Cancel", "Ok or Cancel?", "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showOKCancelDetails(%this)
{
    MessageBoxOKCancelDetails("Ok Cancel Details", "This is the message", "This are the details", "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirm(%this)
{
    ConfirmDialog.setupAndShow("500 400", "Do something?", "Do", "", "Don't", "", "Cancel", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmAction(%this)
{
    ConfirmActionGui.display("Confirm action?", %this, "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmDelete(%this)
{
    ConfirmDeleteGui.display("Confirm delete?", %this, "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmOverwrite(%this)
{
    ConfirmOverwriteGui.display("Confirm overwrite?", %this, "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showWarning(%this)
{
    WarningDialog.setupAndShow("500, 400", "Warning!", "Go!", "", "Wait!", "", "Never mind", "");
}