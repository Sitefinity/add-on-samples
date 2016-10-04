param($installPath, $toolsPath, $package, $project)

# Get destinatin path
$contentFolderPath = (Get-ChildItem $installPath -filter "content" | Select-Object -first 1).FullName
$addonFolderPath = (Get-ChildItem $installPath -recurse -filter $package.Id | Select-Object -first 1).FullName
$addonRelativePath = $addonFolderPath.Replace($contentFolderPath, "")

$projectFullName = $project.FullName 
$fileInfo = new-object -typename System.IO.FileInfo -ArgumentList $projectFullName
$projectDirectory = $fileInfo.DirectoryName

$destinationPath = $projectDirectory + $addonRelativePath

# Get the nuspec file
$nuspecFilePath = (Get-ChildItem $destinationPath -filter "*.nuspec" | Select-Object -first 1).FullName

# Remove the nuspec file 
Remove-Item $nuspecFilePath -Force