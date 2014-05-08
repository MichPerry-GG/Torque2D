//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------
//
// How to use:
//
//    // Example 1: Create a dialog with two buttons active (middle button invisible).
//    ConfirmDialog.setupAndShow(EnemyToolWindow.getGlobalCenter(), "Remove Enemy?", 
//      "Delete", "DeleteSelectedEnemy();", "", "", "Cancel", "");
//
//    // Example 2: Create a dialog with three buttons.
//   ConfirmDialog.setupAndShow(%this.getGlobalCenter(), "Save strategy before exiting?", 
//      "Save", "AiEditorWindow.saveAndExit();", "Don't Save", "Canvas.popDialog(AiEditorGui);", "Cancel", "");   


/// <summary>
/// Sets Up and Shows the Dialog
/// </summary>
function ConfirmDialog::setupAndShow(%this, %center, %text, %buttonOneText, %buttonOneCommand,
                                     %buttonTwoText, %buttonTwoCommand, %buttonThreeText, %buttonThreeCommand)
{
   ConfirmDialogWindow.setPositionGlobal(%center.x - (ConfirmDialogWindow.extent.x / 2), 
      %center.y - (ConfirmDialogWindow.extent.y / 2));
      
   ConfirmDialogText.text = %text;
   
   ConfirmDialogOneButton.text = %buttonOneText;
   %this.oneCommand = %buttonOneCommand;
   
   ConfirmDialogTwoButton.text = %buttonTwoText;
   %this.twoCommand = %buttonTwoCommand;
   
   ConfirmDialogThreeButton.text = %buttonThreeText;
   %this.threeCommand = %buttonThreeCommand;
   
   Canvas.pushDialog(%this);
}

/// <summary>
/// Show/Hide active buttons.
/// </summary>
function ConfirmDialog::onDialogPush(%this)
{
   ConfirmDialogOneButton.Visible = (ConfirmDialogOneButton.text $= "") ? 0 : 1;
   ConfirmDialogTwoButton.Visible = (ConfirmDialogTwoButton.text $= "") ? 0 : 1;
   ConfirmDialogThreeButton.Visible = (ConfirmDialogThreeButton.text $= "") ? 0 : 1;
}

/// <summary>
/// Reset the dialog.
/// </summary>
function ConfirmDialog::onDialogPop(%this)
{
   ConfirmDialogText.text = "Are you sure?";
   ConfirmDialogOneButton.text = "";
   ConfirmDialogTwoButton.text = "";
   ConfirmDialogThreeButton.text = "";
   ConfirmDialog.oneCommand = "";
   ConfirmDialog.twoCommand = "";
   ConfirmDialog.threeCommand = "";
}

/// <summary>
/// Preform the "One" action assigned.
/// </summary>
function ConfirmDialogOneButton::onClick(%this)
{
   eval(ConfirmDialog.oneCommand);
   Canvas.popDialog(ConfirmDialog);
}

/// <summary>
/// Preform the "Two" action assigned.
/// </summary>
function ConfirmDialogTwoButton::onClick(%this)
{
   eval(ConfirmDialog.twoCommand);
   Canvas.popDialog(ConfirmDialog);
}

/// <summary>
/// Preform the "Three" action assigned.
/// </summary>
function ConfirmDialogThreeButton::onClick(%this)
{
   eval(ConfirmDialog.threeCommand);
   Canvas.popDialog(ConfirmDialog);
}
