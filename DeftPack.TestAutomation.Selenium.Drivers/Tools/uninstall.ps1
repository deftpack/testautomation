param($installPath, $toolsPath, $package, $project)
$files = (Join-Path $toolsPath 'drivers') | Get-ChildItem
foreach ($file in $files) {
	$project.ProjectItems.Item($file.Name).Delete()
}