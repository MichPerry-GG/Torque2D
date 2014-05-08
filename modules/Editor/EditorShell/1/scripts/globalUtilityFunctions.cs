//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//-----------------------------------------------------------------------------

/// @group Utility Functions

/// Point2F(float ar, float dimension)
/// Gets dimensions at the specified aspect ratio.
/// @param ar The aspect ratio of the dimensions to return.
/// @parem dimension The dimension of the shorter side in the returned extent.
/// @return The desired width and height.
function resolveAspectRatio(%ar, %dimension)
{
    %width = %dimension;
    %height = %dimension;
    
    if (%ar > 1.0)
        %width *= %ar;
    else
        %height /= %ar;

    return %width SPC %height;
}

/// float(float value, float min, float max)
/// Clamps the value between two numbers.
/// @param value The value to clamp.
/// @param min The minimum value to return.
/// @param max The maximum value to return.
/// @return 'max' if 'value' is greater than 'max', 'min' if 'value' is less
/// than 'min', otherwise 'value'.
function clamp(%value, %min, %max)
{
    if (%value < %min)
        return %min;

    if (%value > %max)
        return %max;

    return %value;
}

/// String(String name)
/// Makes sure a given name is valid and unused.
/// @param name The name to validate.
/// @return The validated name.
function validateObjectName(%name)
{
    // Remove whitespace
    %name = trim(%name);
   
    %firstChar = getSubStr(%name, 0, 1);
   
    // If it begins with a number place a '_' before the first character.
    if (strpos("0123456789", %firstChar) != -1)
        %name = "_" @ %name;

    // Replace whitespaces with underscores.
    %name = strreplace(%name, " ", "_");

    // Remove any other invalid characters
    %name = stripChars(%name, "-+*/%$&§=()[].?\"#,;!~<>|°^{}");

    // And if we have nothing left...
    if (%name $= "")
        %name = "Unnamed";

    // Make sure it's not being used.
    if (isObject(%name))
    {
        // Add numbers starting with 1 until we find a valid one.
        %base = %name;
        for (%i = 1; isObject(%name); %i++)
            %name = %base @ %i;
    }

    return %name;
}

function getImageCellCount(%imageAssetId)
{
    %asset = AssetDatabase.acquireAsset(%imageAssetId);    
    %cellCount = ImageAsset.CellCountX * ImageAsset.CellCountY;    
    AssetDatabase.releaseAsset(%imageAssetId);    
    return %cellCount;
}