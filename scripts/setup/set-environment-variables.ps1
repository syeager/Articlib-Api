$SOLUTION_DIRECTORY = (Get-Item .).Parent.Parent.FullName

[System.Environment]::SetEnvironmentVariable('ARTICLIB_SOLUTION_DIRECTORY', $SOLUTION_DIRECTORY, [System.EnvironmentVariableTarget]::User)